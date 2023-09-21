namespace FormTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dropDownList = new Kashin_1.DropDownList();
            this.TextBoxList = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonCheckDrop = new System.Windows.Forms.Button();
            this.labelSelectedValue = new System.Windows.Forms.Label();
            this.ButtonCheckText = new System.Windows.Forms.Button();
            this.ButtonExample = new System.Windows.Forms.Button();
            this.textBoxExample = new System.Windows.Forms.TextBox();
            this.labelShowText = new System.Windows.Forms.Label();
            this.phoneTextBox = new CustomComponent.PhoneTextBox();
            this.listBoxManys = new CustomComponent.ListBoxMany();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxDay = new System.Windows.Forms.TextBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonInList = new System.Windows.Forms.Button();
            this.buttonGet = new System.Windows.Forms.Button();
            this.ButtonDocumentWithContextTextPdf = new System.Windows.Forms.Button();
            this.componentTextToPdf = new CustomComponent.ComponentTextToPdf(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dropDownList
            // 
            this.dropDownList.Location = new System.Drawing.Point(14, 16);
            this.dropDownList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dropDownList.Name = "dropDownList";
            this.dropDownList.SelectedValue = "";
            this.dropDownList.Size = new System.Drawing.Size(145, 39);
            this.dropDownList.TabIndex = 0;
            // 
            // TextBoxList
            // 
            this.TextBoxList.Location = new System.Drawing.Point(14, 63);
            this.TextBoxList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxList.Name = "TextBoxList";
            this.TextBoxList.Size = new System.Drawing.Size(145, 27);
            this.TextBoxList.TabIndex = 1;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(14, 101);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(86, 31);
            this.ButtonAdd.TabIndex = 2;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click_1);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(14, 140);
            this.ButtonClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(86, 31);
            this.ButtonClear.TabIndex = 3;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            // 
            // ButtonCheckDrop
            // 
            this.ButtonCheckDrop.Location = new System.Drawing.Point(14, 179);
            this.ButtonCheckDrop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonCheckDrop.Name = "ButtonCheckDrop";
            this.ButtonCheckDrop.Size = new System.Drawing.Size(86, 31);
            this.ButtonCheckDrop.TabIndex = 4;
            this.ButtonCheckDrop.Text = "CheckDrop";
            this.ButtonCheckDrop.UseVisualStyleBackColor = true;
            this.ButtonCheckDrop.Click += new System.EventHandler(this.ButtonCheckDrop_Click_1);
            // 
            // labelSelectedValue
            // 
            this.labelSelectedValue.AutoSize = true;
            this.labelSelectedValue.Location = new System.Drawing.Point(14, 225);
            this.labelSelectedValue.Name = "labelSelectedValue";
            this.labelSelectedValue.Size = new System.Drawing.Size(48, 20);
            this.labelSelectedValue.TabIndex = 5;
            this.labelSelectedValue.Text = "Check";
            // 
            // ButtonCheckText
            // 
            this.ButtonCheckText.Location = new System.Drawing.Point(245, 88);
            this.ButtonCheckText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonCheckText.Name = "ButtonCheckText";
            this.ButtonCheckText.Size = new System.Drawing.Size(113, 31);
            this.ButtonCheckText.TabIndex = 7;
            this.ButtonCheckText.Text = "CheckPhone";
            this.ButtonCheckText.UseVisualStyleBackColor = true;
            // 
            // ButtonExample
            // 
            this.ButtonExample.Location = new System.Drawing.Point(246, 165);
            this.ButtonExample.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonExample.Name = "ButtonExample";
            this.ButtonExample.Size = new System.Drawing.Size(113, 31);
            this.ButtonExample.TabIndex = 8;
            this.ButtonExample.Text = "CheckExample";
            this.ButtonExample.UseVisualStyleBackColor = true;
            // 
            // textBoxExample
            // 
            this.textBoxExample.Location = new System.Drawing.Point(245, 127);
            this.textBoxExample.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxExample.Name = "textBoxExample";
            this.textBoxExample.Size = new System.Drawing.Size(114, 27);
            this.textBoxExample.TabIndex = 9;
            // 
            // labelShowText
            // 
            this.labelShowText.AutoSize = true;
            this.labelShowText.Location = new System.Drawing.Point(246, 63);
            this.labelShowText.Name = "labelShowText";
            this.labelShowText.Size = new System.Drawing.Size(48, 20);
            this.labelShowText.TabIndex = 10;
            this.labelShowText.Text = "Check";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(245, 16);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Pattern = null;
            this.phoneTextBox.Size = new System.Drawing.Size(123, 41);
            this.phoneTextBox.TabIndex = 11;
            // 
            // listBoxManys
            // 
            this.listBoxManys.Location = new System.Drawing.Point(405, 16);
            this.listBoxManys.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.listBoxManys.Name = "listBoxManys";
            this.listBoxManys.SelectedIndex = -1;
            this.listBoxManys.Size = new System.Drawing.Size(518, 200);
            this.listBoxManys.TabIndex = 12;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(945, 27);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(137, 27);
            this.dateTimePicker.TabIndex = 13;
            // 
            // textBoxDay
            // 
            this.textBoxDay.Location = new System.Drawing.Point(945, 65);
            this.textBoxDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxDay.Name = "textBoxDay";
            this.textBoxDay.Size = new System.Drawing.Size(137, 27);
            this.textBoxDay.TabIndex = 14;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(945, 104);
            this.numericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(137, 27);
            this.numericUpDown.TabIndex = 15;
            // 
            // buttonInList
            // 
            this.buttonInList.Location = new System.Drawing.Point(945, 143);
            this.buttonInList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonInList.Name = "buttonInList";
            this.buttonInList.Size = new System.Drawing.Size(137, 31);
            this.buttonInList.TabIndex = 16;
            this.buttonInList.Text = "Add";
            this.buttonInList.UseVisualStyleBackColor = true;
            this.buttonInList.Click += new System.EventHandler(this.buttonInList_Click);
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(945, 185);
            this.buttonGet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(137, 31);
            this.buttonGet.TabIndex = 17;
            this.buttonGet.Text = "Get";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // ButtonDocumentWithContextTextPdf
            // 
            this.ButtonDocumentWithContextTextPdf.Location = new System.Drawing.Point(25, 399);
            this.ButtonDocumentWithContextTextPdf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonDocumentWithContextTextPdf.Name = "ButtonDocumentWithContextTextPdf";
            this.ButtonDocumentWithContextTextPdf.Size = new System.Drawing.Size(221, 80);
            this.ButtonDocumentWithContextTextPdf.TabIndex = 18;
            this.ButtonDocumentWithContextTextPdf.Text = "Text To Pdf";
            this.ButtonDocumentWithContextTextPdf.UseVisualStyleBackColor = true;
            this.ButtonDocumentWithContextTextPdf.Click += new System.EventHandler(this.ButtonDocumentWithContextTextPdf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 600);
            this.Controls.Add(this.ButtonDocumentWithContextTextPdf);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.buttonInList);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.textBoxDay);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.listBoxManys);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.labelShowText);
            this.Controls.Add(this.textBoxExample);
            this.Controls.Add(this.ButtonExample);
            this.Controls.Add(this.ButtonCheckText);
            this.Controls.Add(this.labelSelectedValue);
            this.Controls.Add(this.ButtonCheckDrop);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.TextBoxList);
            this.Controls.Add(this.dropDownList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Kashin_1.DropDownList dropDownList;
        private TextBox TextBoxList;
        private Button ButtonAdd;
        private Button ButtonClear;
        private Button ButtonCheckDrop;
        private Label labelSelectedValue;
        private Button ButtonCheckText;
        private Button ButtonExample;
        private TextBox textBoxExample;
        private Label labelShowText;
        private CustomComponent.PhoneTextBox phoneTextBox;
        private CustomComponent.ListBoxMany listBoxManys;
        private DateTimePicker dateTimePicker;
        private TextBox textBoxDay;
        private NumericUpDown numericUpDown;
        private Button buttonInList;
        private Button buttonGet;
        private Button ButtonDocumentWithContextTextPdf;
        private CustomComponent.ComponentTextToPdf componentTextToPdf;

    }
}