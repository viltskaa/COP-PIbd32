﻿using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopAppForComponents
{
    public partial class FormEmployee : Form
    {
        public int Id { set { id = value; } }

        private readonly IEmployeeLogic _logic;
        private readonly ISkillLogic _logicS;
        private string image = null;
        private int? id;

        public FormEmployee(IEmployeeLogic logic, ISkillLogic logicS)
        {
            InitializeComponent();
            _logic = logic;
            _logicS = logicS;
        }

        private void kashinTextBoxPhoneNumber_Enter(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Show("X-XXX-XX-XX", kashinTextBoxPhoneNumber, 30, -20, 1000);
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            kashinTextBoxPhoneNumber.Pattern = @"^\d{1}-\d{3}-\d{2}-\d{2}$";
            List<SkillViewModel> viewS = _logicS.Read(null);

            if (viewS != null)
            {
                foreach (SkillViewModel s in viewS)
                {
                    customSelectedCheckedListBoxProperty1.Items.Add(s.Name);
                }
            }

            if (id.HasValue)
            {
                try
                {
                    EmployeeViewModel view = _logic.Read(new EmployeeBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxFIO.Text = view.FIO;
                        kashinTextBoxPhoneNumber.TextBoxValue = view.PhoneNumber;
                        customSelectedCheckedListBoxProperty1.SelectedElement = view.Skill;
                        pictureBoxPhoto.Image = StringToImage(view.Photo);
                        image = view.Photo;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Image StringToImage(string bytes)
        {
            byte[] arrayimg = Convert.FromBase64String(bytes);
            Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
            return imageStr;
        }

        private string ImageToString(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.CreateOrUpdate(new EmployeeBindingModel
                {
                    Id = id,
                    FIO = textBoxFIO.Text,
                    Photo = image,
                    Skill = customSelectedCheckedListBoxProperty1.SelectedElement,
                    PhoneNumber = kashinTextBoxPhoneNumber.TextBoxValue
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonPhoto_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.Title = "Выберите изображение";
            dialog.Filter = "jpg files (*.jpg)|*.jpg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var image_new = new Bitmap(dialog.FileName);
                pictureBoxPhoto.Image = image_new;
                image = ImageToString(image_new);
            }

            dialog.Dispose();
        }
    }
}
