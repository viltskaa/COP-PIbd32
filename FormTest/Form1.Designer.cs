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
            dropDownList = new Kashin_1.DropDownList();
            TextBoxList = new TextBox();
            ButtonAdd = new Button();
            ButtonClear = new Button();
            ButtonCheckDrop = new Button();
            labelSelectedValue = new Label();
            ButtonCheckText = new Button();
            ButtonExample = new Button();
            textBoxExample = new TextBox();
            labelShowText = new Label();
            phoneTextBox = new CustomComponent.PhoneTextBox();
            listBoxManys = new CustomComponent.ListBoxMany();
            dateTimePicker = new DateTimePicker();
            textBoxDay = new TextBox();
            numericUpDown = new NumericUpDown();
            buttonInList = new Button();
            buttonGet = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // dropDownList
            // 
            dropDownList.Location = new Point(12, 12);
            dropDownList.Name = "dropDownList";
            dropDownList.SelectedValue = "";
            dropDownList.Size = new Size(127, 29);
            dropDownList.TabIndex = 0;
            // 
            // TextBoxList
            // 
            TextBoxList.Location = new Point(12, 47);
            TextBoxList.Name = "TextBoxList";
            TextBoxList.Size = new Size(127, 23);
            TextBoxList.TabIndex = 1;
            // 
            // ButtonAdd
            // 
            ButtonAdd.Location = new Point(12, 76);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(75, 23);
            ButtonAdd.TabIndex = 2;
            ButtonAdd.Text = "Add";
            ButtonAdd.UseVisualStyleBackColor = true;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // ButtonClear
            // 
            ButtonClear.Location = new Point(12, 105);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(75, 23);
            ButtonClear.TabIndex = 3;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            ButtonClear.Click += ButtonClear_Click;
            // 
            // ButtonCheckDrop
            // 
            ButtonCheckDrop.Location = new Point(12, 134);
            ButtonCheckDrop.Name = "ButtonCheckDrop";
            ButtonCheckDrop.Size = new Size(75, 23);
            ButtonCheckDrop.TabIndex = 4;
            ButtonCheckDrop.Text = "CheckDrop";
            ButtonCheckDrop.UseVisualStyleBackColor = true;
            ButtonCheckDrop.Click += ButtonCheckDrop_Click;
            // 
            // labelSelectedValue
            // 
            labelSelectedValue.AutoSize = true;
            labelSelectedValue.Location = new Point(12, 169);
            labelSelectedValue.Name = "labelSelectedValue";
            labelSelectedValue.Size = new Size(40, 15);
            labelSelectedValue.TabIndex = 5;
            labelSelectedValue.Text = "Check";
            // 
            // ButtonCheckText
            // 
            ButtonCheckText.Location = new Point(214, 66);
            ButtonCheckText.Name = "ButtonCheckText";
            ButtonCheckText.Size = new Size(99, 23);
            ButtonCheckText.TabIndex = 7;
            ButtonCheckText.Text = "CheckPhone";
            ButtonCheckText.UseVisualStyleBackColor = true;
            ButtonCheckText.Click += ButtonCheckText_Click;
            // 
            // ButtonExample
            // 
            ButtonExample.Location = new Point(215, 124);
            ButtonExample.Name = "ButtonExample";
            ButtonExample.Size = new Size(99, 23);
            ButtonExample.TabIndex = 8;
            ButtonExample.Text = "CheckExample";
            ButtonExample.UseVisualStyleBackColor = true;
            ButtonExample.Click += ButtonExample_Click;
            // 
            // textBoxExample
            // 
            textBoxExample.Location = new Point(214, 95);
            textBoxExample.Name = "textBoxExample";
            textBoxExample.Size = new Size(100, 23);
            textBoxExample.TabIndex = 9;
            // 
            // labelShowText
            // 
            labelShowText.AutoSize = true;
            labelShowText.Location = new Point(215, 47);
            labelShowText.Name = "labelShowText";
            labelShowText.Size = new Size(40, 15);
            labelShowText.TabIndex = 10;
            labelShowText.Text = "Check";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(214, 12);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Pattern = null;
            phoneTextBox.Size = new Size(108, 31);
            phoneTextBox.TabIndex = 11;
            // 
            // listBoxManys
            // 
            listBoxManys.Location = new Point(354, 12);
            listBoxManys.Name = "listBoxManys";
            listBoxManys.SelectedIndex = -1;
            listBoxManys.Size = new Size(453, 150);
            listBoxManys.TabIndex = 12;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(827, 20);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(120, 23);
            dateTimePicker.TabIndex = 13;
            // 
            // textBoxDay
            // 
            textBoxDay.Location = new Point(827, 49);
            textBoxDay.Name = "textBoxDay";
            textBoxDay.Size = new Size(120, 23);
            textBoxDay.TabIndex = 14;
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(827, 78);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(120, 23);
            numericUpDown.TabIndex = 15;
            // 
            // buttonInList
            // 
            buttonInList.Location = new Point(827, 107);
            buttonInList.Name = "buttonInList";
            buttonInList.Size = new Size(120, 23);
            buttonInList.TabIndex = 16;
            buttonInList.Text = "Add";
            buttonInList.UseVisualStyleBackColor = true;
            buttonInList.Click += buttonInList_Click;
            // 
            // buttonGet
            // 
            buttonGet.Location = new Point(827, 139);
            buttonGet.Name = "buttonGet";
            buttonGet.Size = new Size(120, 23);
            buttonGet.TabIndex = 17;
            buttonGet.Text = "Get";
            buttonGet.UseVisualStyleBackColor = true;
            buttonGet.Click += buttonGet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 450);
            Controls.Add(buttonGet);
            Controls.Add(buttonInList);
            Controls.Add(numericUpDown);
            Controls.Add(textBoxDay);
            Controls.Add(dateTimePicker);
            Controls.Add(listBoxManys);
            Controls.Add(phoneTextBox);
            Controls.Add(labelShowText);
            Controls.Add(textBoxExample);
            Controls.Add(ButtonExample);
            Controls.Add(ButtonCheckText);
            Controls.Add(labelSelectedValue);
            Controls.Add(ButtonCheckDrop);
            Controls.Add(ButtonClear);
            Controls.Add(ButtonAdd);
            Controls.Add(TextBoxList);
            Controls.Add(dropDownList);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}