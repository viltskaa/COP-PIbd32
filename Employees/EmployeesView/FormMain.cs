﻿using Bazunov_Components.Models;
using CustomComponent.Models;
using EmployeesContracts.BindingModels;
using EmployeesContracts.BusinessLogicsContracts;
using EmployeesContracts.ViewModels;
using EmployeesDatabaseImplement.Models;
using MyCustomComponents;
using MyCustomComponents.Models;
using PluginsConventionLibrary.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace EmployeesView
{
    public partial class FormMain : Form
    {
        private readonly Dictionary<string, IPluginsConvention> _plugins;
        private string _selectedPlugin;
        private ContextMenuStrip contextMenu = new ContextMenuStrip();

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
                    ToolStripMenuItem itemMenu = new ToolStripMenuItem();
                    itemMenu.Text = plugin.Value.PluginName;
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
                MessageBox.Show("Нет выбранного элемента", "Ошибка",
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
            if (MessageBox.Show("Удалить выбранный элемент", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) { return; }
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show("Нет выбранного элемента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_plugins[_selectedPlugin].DeleteElement(element))
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void CreateWord()
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (_plugins[_selectedPlugin].CreateSimpleDocument(new PluginsConventionSaveDocument { FileName = dialog.FileName }))
                {
                    //MessageBox.Show("Документ сохранен", "Создание документа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при создании документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void CreateExcel()
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (_plugins[_selectedPlugin].CreateChartDocument(new PluginsConventionSaveDocument { FileName = dialog.FileName }))
                {
                    //MessageBox.Show("Документ сохранен", "Создание документа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при создании документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void CreatePdf()
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (_plugins[_selectedPlugin].CreateTableDocument(new PluginsConventionSaveDocument { FileName = dialog.FileName }))
                {
                    //MessageBox.Show("Документ сохранен", "Создание документа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при создании документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewElement();
        }

        private void UpdElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateElement();
        }

        private void DelElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteElement();
        }

        private void PdfDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePdf();
        }

        private void ExcelDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateExcel();
        }

        private void WordDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateWord();
        }
    }
}
