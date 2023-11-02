using Bazunov_Components;
using CustomComponent;
using DocumentFormat.OpenXml.Wordprocessing;
using EnterpriseBusinessLogic.BusinessLogics;
using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.ViewModels;
using MyCustomComponents.Models;
using MyCustomComponents;
using PluginsConventionLibrary.Forms;
using PluginsConventionLibrary.Plugins;
using System.ComponentModel.Composition;
using Bazunov_Components.Models;
using CustomComponent.Models;

namespace PluginsConventionLibrary.MyPlugins;

[Export(typeof(IPluginsConvention))]
public class MainPluginConvention : IPluginsConvention
{
    private ListBoxMany listBoxMany { get; }
    private readonly IEmployeeLogic _employeeLogic;
    private readonly ISubdivisionLogic _subdivisionLogic;

    public MainPluginConvention()
    {
        _employeeLogic = new EmployeeLogic();
        _subdivisionLogic = new SubdivisionLogic();
        listBoxMany = new ListBoxMany();
        var menu = new ContextMenuStrip();
        var skillMenuItem = new ToolStripMenuItem("Forms");
        menu.Items.Add(skillMenuItem);
        skillMenuItem.Click += (sender, e) =>
        {
            var directory = new DirectoryForm(_subdivisionLogic);
            directory.ShowDialog();
        };
        listBoxMany.ContextMenuStrip = menu;
        ReloadData();
    }

    public string PluginName => "Employees";

    public UserControl GetControl => listBoxMany;

    PluginsConventionElement IPluginsConvention.GetElement => GetElement();

    public PluginsConventionElement GetElement()
    {
        var employee = listBoxMany.GetItemFromList<EmployeeViewModel>();
        return new PluginsConventionElement { Id = employee.Id };
    }

    public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
    {
        try
        {
            var listEmp = _employeeLogic.Read(null);
            var listSubd = _subdivisionLogic.Read(null);
            var data = new Dictionary<string, List<(string Name, double Value)>>();
            foreach (var item in listSubd)
            {
                var listSorted = listEmp.Where(x => x.Subdivision.Equals(item.Name));
                var employeeViewModels = listSorted as EmployeeViewModel[] ?? listSorted.ToArray();
                var x = (
                    employeeViewModels.Count(y => y.Experience is >= 1 and < 5),
                    employeeViewModels.Count(y => y.Experience is >= 5 and < 10),
                    employeeViewModels.Count(y => y.Experience is >= 10 and < 20),
                    employeeViewModels.Count(y => y.Experience is >= 20 and < 30));
                data.Add(
                    item.Name, 
                    new List<(string Name, double Value)> { ("1-5", x.Item1), ("5-10", x.Item2), ("10-20", x.Item3), ("20-30", x.Item4) });
            }
            var componentDiagramToPdf = new ComponentDiagramToPdf();
            componentDiagramToPdf.CreateDoc(new ComponentDiagramToPdfConfig
            {
                FilePath = saveDocument.FileName,
                Header = "Chart",
                ChartTitle = "Chart",
                Data = data
            });
            return true;
        } catch (Exception)
        {
            return false;
        }
    }

    public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
    {
        try
        {
            var list = _employeeLogic.Read(null);
            var wordWithTable = new WordWithTable();
            wordWithTable.CreateDoc(new WordWithTableDataConfig<EmployeeViewModel>
            {
                FilePath = saveDocument.FileName,
                Header = "Table:",
                UseUnion = true,
                ColumnsRowsWidth = new List<(int, int)> { (0, 5), (0, 5), (0, 10), (0, 10) },
                ColumnUnion = new List<(int StartIndex, int Count)> { (2, 2) },
                Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
                    (0, 0, "Id", "Id"),
                    (1, 0, "Fio", "Fio"),
                    (2, 0, "Work", ""),
                    (2, 1, "Subdivision", "Subdivision"),
                    (3, 1, "Experience", "Experience"),
                },
                Data = list
            });
            return true;
        }
        catch (Exception) { return false; }
    }

    public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
    {
        try
        {
            var ent = listBoxMany.GetItemFromList<EmployeeViewModel>();
            var eml = _employeeLogic.Read(new EmployeeBindingModel { Id = ent.Id })[0];
            var data = new string[1, 5];
            var i = 0;
            foreach (var post in eml.Posts.Split(","))
            {
                data[0, i++] = post;
            }

            var excelTable = new ExcelTable();
            excelTable.CreateDoc(new TableConfig
            {
                FilePath = saveDocument.FileName,
                Header = "Example",
                Data = new List<string[,]> { data }
            });
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteElement(PluginsConventionElement element)
    {
        try
        {
            _employeeLogic.Delete(new EmployeeBindingModel { Id = element.Id });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    public Form GetForm(PluginsConventionElement element)
    {
        var form = new EmployerForm(_employeeLogic, _subdivisionLogic)
        {
            Id = element.Id
        };
        return form;
    }

    public void ReloadData()
    {
        try
        {
            listBoxMany.SetLayout("{Id} {Fio} {Experience}", "{", "}");

            var list = _employeeLogic.Read(null);
            if (list == null) throw new Exception("Error on read");
            for (var i = 0; i < list.Count; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    listBoxMany.AddItemInList(list[i], i, j);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}