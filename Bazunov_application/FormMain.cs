using PluginsConventionLibrary.Plugins;
using System.Windows.Forms;

namespace Bazunov_application
{
    public partial class FormMain : Form
    {
        private readonly Dictionary<string, IPluginsConvention> _plugins;
        private string _selectedPlugin;

        public FormMain()
        {
            InitializeComponent();
            _plugins = LoadPlugins();
            _selectedPlugin = string.Empty;
        }

        private Dictionary<string, IPluginsConvention> LoadPlugins()
        {
            PluginsManager manager = new PluginsManager();
            var plugins = manager.plugins_dictionary;

            ToolStripItem[] toolStripItems = new ToolStripItem[plugins.Count];
            int i = 0;
            if (plugins.Count > 0)
            {
                foreach (var plugin in plugins)
                {
                    ToolStripMenuItem itemMenu = new()
                    {
                        Text = plugin.Value.PluginName
                    };
                    itemMenu.Click += (sender, e) =>
                    {
                        _selectedPlugin = plugin.Value.PluginName;
                        panelControl.Controls.Clear();
                        panelControl.Controls.Add(_plugins[_selectedPlugin].GetControl);
                        panelControl.Controls[0].Dock = DockStyle.Fill;
                    };
                    toolStripItems[i] = itemMenu;
                    i++;
                }
                ControlsStripMenuItem.DropDownItems.AddRange(toolStripItems);
            }
            return plugins;
        }

        private void AddNewElement()
        {
            var form = _plugins[_selectedPlugin].GetForm(null);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void UpdateElement()
        {
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show("��� ���������� ��������", "������",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = _plugins[_selectedPlugin].GetForm(element);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void DeleteElement()
        {
            if (MessageBox.Show("������� ��������� �������", "��������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) { return; }
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show("��� ���������� ��������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_plugins[_selectedPlugin].DeleteElement(element))
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void CreateWord()
        {
            if (_plugins[_selectedPlugin].GetElement == null) return;
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (!_plugins[_selectedPlugin].CreateSimpleDocument(new PluginsConventionSaveDocument { FileName = dialog.FileName }))
            {
                MessageBox.Show("Error", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreatePdf()
        {
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (!_plugins[_selectedPlugin].CreateChartDocument(new PluginsConventionSaveDocument { FileName = dialog.FileName }))
            {
                MessageBox.Show("Error", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateExcel()
        {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (!_plugins[_selectedPlugin].CreateTableDocument(new PluginsConventionSaveDocument { FileName = dialog.FileName }))
            {
                MessageBox.Show("Error", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.A:
                    AddNewElement();
                    break;
                case Keys.U:
                    UpdateElement();
                    break;
                case Keys.D:
                    DeleteElement();
                    break;
                case Keys.S:
                    CreateWord();
                    break;
                case Keys.T:
                    CreatePdf();
                    break;
                case Keys.C:
                    CreateExcel();
                    break;
            }
        }

        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e) => AddNewElement();
        private void UpdElementToolStripMenuItem_Click(object sender, EventArgs e) => UpdateElement();
        private void DelElementToolStripMenuItem_Click(object sender, EventArgs e) => DeleteElement();
        private void WordDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateExcel();
        private void PdfDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateWord();
        private void ExcelDocToolStripMenuItem_Click(object sender, EventArgs e) => CreatePdf();
    }
}