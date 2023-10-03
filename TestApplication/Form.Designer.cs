namespace TestApplication
{
    partial class Form
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
            this.ItemList = new Bazunov_visual_components.ItemList();
            this.ButtonListClear = new System.Windows.Forms.Button();
            this.ButtonLoadList = new System.Windows.Forms.Button();
            this.dateBoxWithNull = new Bazunov_VisualComponents.DateBoxWithNull();
            this.ButtonGetValue = new System.Windows.Forms.Button();
            this.ButtonSetValue = new System.Windows.Forms.Button();
            this.itemTable = new Bazunov_VisualComponents.ItemTable();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.textBoxEvent = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonSel = new System.Windows.Forms.Button();
            this.excelTable = new Bazunov_Components.ExcelTable(this.components);
            this.buttonExcel = new System.Windows.Forms.Button();
            this.excelSaveHeader = new System.Windows.Forms.Button();
            this.SaveBar = new System.Windows.Forms.Button();
            this.excelWithCustomTable = new Bazunov_Components.ExcelWithCustomTable(this.components);
            this.excelGistogram = new Bazunov_Components.ExcelGistogram(this.components);
            this.SuspendLayout();
            // 
            // ItemList
            // 
            this.ItemList.Location = new System.Drawing.Point(12, 12);
            this.ItemList.Name = "ItemList";
            this.ItemList.SelectedElement = "";
            this.ItemList.Size = new System.Drawing.Size(210, 212);
            this.ItemList.TabIndex = 0;
            this.ItemList.ChangeEvent += new System.EventHandler(this.ItemList_ChangeEvent);
            // 
            // ButtonListClear
            // 
            this.ButtonListClear.Location = new System.Drawing.Point(12, 230);
            this.ButtonListClear.Name = "ButtonListClear";
            this.ButtonListClear.Size = new System.Drawing.Size(210, 23);
            this.ButtonListClear.TabIndex = 1;
            this.ButtonListClear.Text = "List Clear";
            this.ButtonListClear.UseVisualStyleBackColor = true;
            this.ButtonListClear.Click += new System.EventHandler(this.ButtonListClear_Click);
            // 
            // ButtonLoadList
            // 
            this.ButtonLoadList.Location = new System.Drawing.Point(12, 259);
            this.ButtonLoadList.Name = "ButtonLoadList";
            this.ButtonLoadList.Size = new System.Drawing.Size(210, 23);
            this.ButtonLoadList.TabIndex = 2;
            this.ButtonLoadList.Text = "Load List";
            this.ButtonLoadList.UseVisualStyleBackColor = true;
            this.ButtonLoadList.Click += new System.EventHandler(this.ButtonLoadList_Click);
            // 
            // dateBoxWithNull
            // 
            this.dateBoxWithNull.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dateBoxWithNull.Location = new System.Drawing.Point(228, 12);
            this.dateBoxWithNull.Name = "dateBoxWithNull";
            this.dateBoxWithNull.Size = new System.Drawing.Size(147, 29);
            this.dateBoxWithNull.TabIndex = 3;
            this.dateBoxWithNull.Value = null;
            this.dateBoxWithNull.CheckBoxEvent += new System.EventHandler(this.dateBoxWithNull1_CheckBoxEvent);
            this.dateBoxWithNull.ChangeEvent += new System.EventHandler(this.dateBoxWithNull1_ChangeEvent);
            // 
            // ButtonGetValue
            // 
            this.ButtonGetValue.Location = new System.Drawing.Point(228, 47);
            this.ButtonGetValue.Name = "ButtonGetValue";
            this.ButtonGetValue.Size = new System.Drawing.Size(147, 23);
            this.ButtonGetValue.TabIndex = 4;
            this.ButtonGetValue.Text = "Get Value";
            this.ButtonGetValue.UseVisualStyleBackColor = true;
            this.ButtonGetValue.Click += new System.EventHandler(this.ButtonGetValue_Click);
            // 
            // ButtonSetValue
            // 
            this.ButtonSetValue.Location = new System.Drawing.Point(228, 76);
            this.ButtonSetValue.Name = "ButtonSetValue";
            this.ButtonSetValue.Size = new System.Drawing.Size(147, 23);
            this.ButtonSetValue.TabIndex = 5;
            this.ButtonSetValue.Text = "Set Value";
            this.ButtonSetValue.UseVisualStyleBackColor = true;
            this.ButtonSetValue.Click += new System.EventHandler(this.ButtonSetValue_Click);
            // 
            // itemTable
            // 
            this.itemTable.Location = new System.Drawing.Point(381, 12);
            this.itemTable.Name = "itemTable";
            this.itemTable.Size = new System.Drawing.Size(548, 426);
            this.itemTable.TabIndex = 6;
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(935, 12);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(94, 23);
            this.ButtonClear.TabIndex = 7;
            this.ButtonClear.Text = "Table clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // textBoxEvent
            // 
            this.textBoxEvent.Location = new System.Drawing.Point(228, 105);
            this.textBoxEvent.Name = "textBoxEvent";
            this.textBoxEvent.Size = new System.Drawing.Size(147, 23);
            this.textBoxEvent.TabIndex = 8;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(935, 41);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(94, 23);
            this.ButtonAdd.TabIndex = 9;
            this.ButtonAdd.Text = "Table Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonSel
            // 
            this.ButtonSel.Location = new System.Drawing.Point(935, 70);
            this.ButtonSel.Name = "ButtonSel";
            this.ButtonSel.Size = new System.Drawing.Size(94, 23);
            this.ButtonSel.TabIndex = 10;
            this.ButtonSel.Text = "Get Value";
            this.ButtonSel.UseVisualStyleBackColor = true;
            this.ButtonSel.Click += new System.EventHandler(this.ButtonSel_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(12, 415);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonExcel.TabIndex = 11;
            this.buttonExcel.Text = "Excel Save";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // excelSaveHeader
            // 
            this.excelSaveHeader.Location = new System.Drawing.Point(93, 415);
            this.excelSaveHeader.Name = "excelSaveHeader";
            this.excelSaveHeader.Size = new System.Drawing.Size(129, 23);
            this.excelSaveHeader.TabIndex = 12;
            this.excelSaveHeader.Text = "Save With Header";
            this.excelSaveHeader.UseVisualStyleBackColor = true;
            this.excelSaveHeader.Click += new System.EventHandler(this.excelSaveHeader_Click);
            // 
            // SaveBar
            // 
            this.SaveBar.Location = new System.Drawing.Point(228, 415);
            this.SaveBar.Name = "SaveBar";
            this.SaveBar.Size = new System.Drawing.Size(147, 23);
            this.SaveBar.TabIndex = 13;
            this.SaveBar.Text = "Save Bar";
            this.SaveBar.UseVisualStyleBackColor = true;
            this.SaveBar.Click += new System.EventHandler(this.SaveBar_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 450);
            this.Controls.Add(this.SaveBar);
            this.Controls.Add(this.excelSaveHeader);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.ButtonSel);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.textBoxEvent);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.itemTable);
            this.Controls.Add(this.ButtonSetValue);
            this.Controls.Add(this.ButtonGetValue);
            this.Controls.Add(this.dateBoxWithNull);
            this.Controls.Add(this.ButtonLoadList);
            this.Controls.Add(this.ButtonListClear);
            this.Controls.Add(this.ItemList);
            this.Name = "Form";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bazunov_visual_components.ItemList ItemList;
        private Button ButtonListClear;
        private Button ButtonLoadList;
        private Bazunov_VisualComponents.DateBoxWithNull dateBoxWithNull;
        private Button ButtonGetValue;
        private Button ButtonSetValue;
        private Bazunov_VisualComponents.ItemTable itemTable;
        private Button ButtonClear;
        private TextBox textBoxEvent;
        private Button ButtonAdd;
        private Button ButtonSel;
        private Bazunov_Components.ExcelTable excelTable;
        private Button buttonExcel;
        private Button excelSaveHeader;
        private Button SaveBar;
        private Bazunov_Components.ExcelWithCustomTable excelWithCustomTable;
        private Bazunov_Components.ExcelGistogram excelGistogram;
    }
}