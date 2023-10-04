namespace DesktopAppForComponents
{
    partial class FormEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.kashinTextBoxPhoneNumber = new CustomComponent.PhoneTextBox();
            this.labelSkill = new System.Windows.Forms.Label();
            this.customSelectedCheckedListBoxProperty1 = new MyCustomComponents.CustomSelectedCheckedListBoxProperty();
            this.buttonPhoto = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancelAdd = new System.Windows.Forms.Button();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(26, 10);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(37, 15);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО:";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFIO.Location = new System.Drawing.Point(31, 28);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(285, 23);
            this.textBoxFIO.TabIndex = 1;
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(26, 54);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(104, 15);
            this.labelPhoneNumber.TabIndex = 2;
            this.labelPhoneNumber.Text = "Номер телефона:";
            // 
            // kashinTextBoxPhoneNumber
            // 
            this.kashinTextBoxPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kashinTextBoxPhoneNumber.Location = new System.Drawing.Point(28, 72);
            this.kashinTextBoxPhoneNumber.Name = "kashinTextBoxPhoneNumber";
            this.kashinTextBoxPhoneNumber.Pattern = "";
            this.kashinTextBoxPhoneNumber.Size = new System.Drawing.Size(295, 243);
            this.kashinTextBoxPhoneNumber.TabIndex = 3;
            this.kashinTextBoxPhoneNumber.TextBoxValue = "";
            this.kashinTextBoxPhoneNumber.Enter += new System.EventHandler(this.kashinTextBoxPhoneNumber_Enter);
            // 
            // labelSkill
            // 
            this.labelSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSkill.AutoSize = true;
            this.labelSkill.Location = new System.Drawing.Point(95, 104);
            this.labelSkill.Name = "labelSkill";
            this.labelSkill.Size = new System.Drawing.Size(46, 15);
            this.labelSkill.TabIndex = 4;
            this.labelSkill.Text = "Навык:";
            // 
            // customSelectedCheckedListBoxProperty1
            // 
            this.customSelectedCheckedListBoxProperty1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customSelectedCheckedListBoxProperty1.Location = new System.Drawing.Point(95, 122);
            this.customSelectedCheckedListBoxProperty1.Name = "customSelectedCheckedListBoxProperty1";
            this.customSelectedCheckedListBoxProperty1.SelectedElement = "";
            this.customSelectedCheckedListBoxProperty1.Size = new System.Drawing.Size(152, 219);
            this.customSelectedCheckedListBoxProperty1.TabIndex = 5;
            // 
            // buttonPhoto
            // 
            this.buttonPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPhoto.Location = new System.Drawing.Point(31, 455);
            this.buttonPhoto.Name = "buttonPhoto";
            this.buttonPhoto.Size = new System.Drawing.Size(285, 36);
            this.buttonPhoto.TabIndex = 6;
            this.buttonPhoto.Text = "Загрузить фото";
            this.buttonPhoto.UseVisualStyleBackColor = true;
            this.buttonPhoto.Click += new System.EventHandler(this.buttonPhoto_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(171, 497);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(76, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancelAdd
            // 
            this.buttonCancelAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelAdd.Location = new System.Drawing.Point(253, 497);
            this.buttonCancelAdd.Name = "buttonCancelAdd";
            this.buttonCancelAdd.Size = new System.Drawing.Size(63, 23);
            this.buttonCancelAdd.TabIndex = 8;
            this.buttonCancelAdd.Text = "Отмена";
            this.buttonCancelAdd.UseVisualStyleBackColor = true;
            this.buttonCancelAdd.Click += new System.EventHandler(this.buttonCancelAdd_Click);
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(31, 283);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(285, 166);
            this.pictureBoxPhoto.TabIndex = 9;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // FormEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 538);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.buttonCancelAdd);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonPhoto);
            this.Controls.Add(this.customSelectedCheckedListBoxProperty1);
            this.Controls.Add(this.labelSkill);
            this.Controls.Add(this.kashinTextBoxPhoneNumber);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelFIO);
            this.Name = "FormEmployee";
            this.Text = "Сотрудник";
            this.Load += new System.EventHandler(this.FormEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelFIO;
        private TextBox textBoxFIO;
        private Label labelPhoneNumber;
        private CustomComponent.PhoneTextBox kashinTextBoxPhoneNumber;
        private Label labelSkill;
        private MyCustomComponents.CustomSelectedCheckedListBoxProperty customSelectedCheckedListBoxProperty1;
        private Button buttonPhoto;
        private Button buttonSave;
        private Button buttonCancelAdd;
        private PictureBox pictureBoxPhoto;
    }
}