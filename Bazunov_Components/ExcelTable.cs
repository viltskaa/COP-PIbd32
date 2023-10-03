using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.ComponentModel;
using Bazunov_Components.Helpers;
using Bazunov_Components.Models;

namespace Bazunov_Components
{
    public partial class ExcelTable : Component
    {
        private SpreadsheetDocument? _spreadsheetDocument;
        private SharedStringTablePart? _shareStringPart;
        private Worksheet? _worksheet;

        public ExcelTable()
        {
            InitializeComponent();
        }

        public ExcelTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateDocument(ExcelInfo info)
        {
            _spreadsheetDocument = SpreadsheetDocument.Create(info.FileName, SpreadsheetDocumentType.Workbook);
            var workbookpart = _spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            CreateStyleForExcel.CreateStyles(workbookpart);
            _shareStringPart = _spreadsheetDocument.WorkbookPart!.GetPartsOfType<SharedStringTablePart>().Any()
                                ? _spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First()
                                : _spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
            var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            var sheets = _spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
            var sheet = new Sheet()
            {
                Id = _spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "List"
            };
            sheets.Append(sheet);
            _worksheet = worksheetPart.Worksheet;
        }
    }
}
