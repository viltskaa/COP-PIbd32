namespace DesktopWithMyVisualComponents
{
    partial class FormMain
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
            this.customInputRangeNumber = new MyCustomComponents.CustomInputRangeNumber();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.labelCheckValue = new System.Windows.Forms.Label();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.buttonSetBorders = new System.Windows.Forms.Button();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelRange = new System.Windows.Forms.Label();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.groupBoxSelected = new System.Windows.Forms.GroupBox();
            this.buttonGetSelected = new System.Windows.Forms.Button();
            this.labelSelectedValue = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.customSelectedCheckedListBoxProperty = new MyCustomComponents.CustomSelectedCheckedListBoxProperty();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.buttonGetFromTree = new System.Windows.Forms.Button();
            this.buttonAddToTree = new System.Windows.Forms.Button();
            this.comboBoxTransportType = new System.Windows.Forms.ComboBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxRegNumber = new System.Windows.Forms.TextBox();
            this.customTreeCell = new MyCustomComponents.CustomTreeCell();
            this.labelRegNum = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelTransportType = new System.Windows.Forms.Label();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxSelected.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.SuspendLayout();
            // 
            // customInputRangeNumber
            // 
            this.customInputRangeNumber.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.customInputRangeNumber.CausesValidation = false;
            this.customInputRangeNumber.Location = new System.Drawing.Point(30, 19);
            this.customInputRangeNumber.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.customInputRangeNumber.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.customInputRangeNumber.Name = "customInputRangeNumber";
            this.customInputRangeNumber.Size = new System.Drawing.Size(126, 30);
            this.customInputRangeNumber.TabIndex = 0;
            this.customInputRangeNumber.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(169, 22);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(126, 23);
            this.buttonCheck.TabIndex = 1;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // labelCheckValue
            // 
            this.labelCheckValue.AutoSize = true;
            this.labelCheckValue.Location = new System.Drawing.Point(30, 111);
            this.labelCheckValue.Name = "labelCheckValue";
            this.labelCheckValue.Size = new System.Drawing.Size(65, 15);
            this.labelCheckValue.TabIndex = 2;
            this.labelCheckValue.Text = "Enter value";
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(30, 71);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(55, 23);
            this.textBoxMin.TabIndex = 3;
            this.textBoxMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMin_KeyPress);
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(103, 71);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(53, 23);
            this.textBoxMax.TabIndex = 4;
            this.textBoxMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMax_KeyPress);
            // 
            // buttonSetBorders
            // 
            this.buttonSetBorders.Location = new System.Drawing.Point(169, 71);
            this.buttonSetBorders.Name = "buttonSetBorders";
            this.buttonSetBorders.Size = new System.Drawing.Size(126, 23);
            this.buttonSetBorders.TabIndex = 5;
            this.buttonSetBorders.Text = "Set Borders";
            this.buttonSetBorders.UseVisualStyleBackColor = true;
            this.buttonSetBorders.Click += new System.EventHandler(this.buttonSetBorders_Click);
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(29, 54);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(56, 15);
            this.labelMin.TabIndex = 6;
            this.labelMin.Text = "MinValue";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(101, 54);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(58, 15);
            this.labelMax.TabIndex = 7;
            this.labelMax.Text = "MaxValue";
            // 
            // labelRange
            // 
            this.labelRange.AutoSize = true;
            this.labelRange.Location = new System.Drawing.Point(88, 75);
            this.labelRange.Name = "labelRange";
            this.labelRange.Size = new System.Drawing.Size(12, 15);
            this.labelRange.TabIndex = 8;
            this.labelRange.Text = "-";
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.customInputRangeNumber);
            this.groupBoxInput.Controls.Add(this.labelCheckValue);
            this.groupBoxInput.Controls.Add(this.labelRange);
            this.groupBoxInput.Controls.Add(this.buttonCheck);
            this.groupBoxInput.Controls.Add(this.labelMax);
            this.groupBoxInput.Controls.Add(this.textBoxMin);
            this.groupBoxInput.Controls.Add(this.labelMin);
            this.groupBoxInput.Controls.Add(this.textBoxMax);
            this.groupBoxInput.Controls.Add(this.buttonSetBorders);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(311, 190);
            this.groupBoxInput.TabIndex = 9;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Input";
            // 
            // groupBoxSelected
            // 
            this.groupBoxSelected.Controls.Add(this.buttonGetSelected);
            this.groupBoxSelected.Controls.Add(this.labelSelectedValue);
            this.groupBoxSelected.Controls.Add(this.buttonClear);
            this.groupBoxSelected.Controls.Add(this.buttonAdd);
            this.groupBoxSelected.Controls.Add(this.textBoxAdd);
            this.groupBoxSelected.Controls.Add(this.customSelectedCheckedListBoxProperty);
            this.groupBoxSelected.Location = new System.Drawing.Point(340, 12);
            this.groupBoxSelected.Name = "groupBoxSelected";
            this.groupBoxSelected.Size = new System.Drawing.Size(311, 190);
            this.groupBoxSelected.TabIndex = 10;
            this.groupBoxSelected.TabStop = false;
            this.groupBoxSelected.Text = "Selected";
            // 
            // buttonGetSelected
            // 
            this.buttonGetSelected.Location = new System.Drawing.Point(192, 144);
            this.buttonGetSelected.Name = "buttonGetSelected";
            this.buttonGetSelected.Size = new System.Drawing.Size(100, 23);
            this.buttonGetSelected.TabIndex = 14;
            this.buttonGetSelected.Text = "Get Selected";
            this.buttonGetSelected.UseVisualStyleBackColor = true;
            this.buttonGetSelected.Click += new System.EventHandler(this.buttonGetSelected_Click);
            // 
            // labelSelectedValue
            // 
            this.labelSelectedValue.AutoSize = true;
            this.labelSelectedValue.Location = new System.Drawing.Point(192, 111);
            this.labelSelectedValue.Name = "labelSelectedValue";
            this.labelSelectedValue.Size = new System.Drawing.Size(82, 15);
            this.labelSelectedValue.TabIndex = 11;
            this.labelSelectedValue.Text = "Selected value";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(192, 81);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 23);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(192, 52);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 23);
            this.buttonAdd.TabIndex = 12;
            this.buttonAdd.Text = "Add or Select";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Location = new System.Drawing.Point(192, 23);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(100, 23);
            this.textBoxAdd.TabIndex = 11;
            // 
            // customSelectedCheckedListBoxProperty
            // 
            this.customSelectedCheckedListBoxProperty.Location = new System.Drawing.Point(36, 19);
            this.customSelectedCheckedListBoxProperty.Name = "customSelectedCheckedListBoxProperty";
            this.customSelectedCheckedListBoxProperty.SelectedElement = "";
            this.customSelectedCheckedListBoxProperty.Size = new System.Drawing.Size(150, 157);
            this.customSelectedCheckedListBoxProperty.TabIndex = 0;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.labelTransportType);
            this.groupBoxData.Controls.Add(this.labelModel);
            this.groupBoxData.Controls.Add(this.labelRegNum);
            this.groupBoxData.Controls.Add(this.buttonGetFromTree);
            this.groupBoxData.Controls.Add(this.buttonAddToTree);
            this.groupBoxData.Controls.Add(this.comboBoxTransportType);
            this.groupBoxData.Controls.Add(this.textBoxModel);
            this.groupBoxData.Controls.Add(this.textBoxRegNumber);
            this.groupBoxData.Controls.Add(this.customTreeCell);
            this.groupBoxData.Location = new System.Drawing.Point(12, 208);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(639, 230);
            this.groupBoxData.TabIndex = 11;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data";
            // 
            // buttonGetFromTree
            // 
            this.buttonGetFromTree.Location = new System.Drawing.Point(432, 195);
            this.buttonGetFromTree.Name = "buttonGetFromTree";
            this.buttonGetFromTree.Size = new System.Drawing.Size(188, 23);
            this.buttonGetFromTree.TabIndex = 5;
            this.buttonGetFromTree.Text = "Get Selected";
            this.buttonGetFromTree.UseVisualStyleBackColor = true;
            this.buttonGetFromTree.Click += new System.EventHandler(this.buttonGetFromTree_Click);
            // 
            // buttonAddToTree
            // 
            this.buttonAddToTree.Location = new System.Drawing.Point(432, 166);
            this.buttonAddToTree.Name = "buttonAddToTree";
            this.buttonAddToTree.Size = new System.Drawing.Size(188, 23);
            this.buttonAddToTree.TabIndex = 4;
            this.buttonAddToTree.Text = "Add";
            this.buttonAddToTree.UseVisualStyleBackColor = true;
            this.buttonAddToTree.Click += new System.EventHandler(this.buttonAddToTree_Click);
            // 
            // comboBoxTransportType
            // 
            this.comboBoxTransportType.FormattingEnabled = true;
            this.comboBoxTransportType.Location = new System.Drawing.Point(432, 134);
            this.comboBoxTransportType.Name = "comboBoxTransportType";
            this.comboBoxTransportType.Size = new System.Drawing.Size(188, 23);
            this.comboBoxTransportType.TabIndex = 3;
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(432, 90);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(188, 23);
            this.textBoxModel.TabIndex = 2;
            // 
            // textBoxRegNumber
            // 
            this.textBoxRegNumber.Location = new System.Drawing.Point(432, 46);
            this.textBoxRegNumber.Name = "textBoxRegNumber";
            this.textBoxRegNumber.Size = new System.Drawing.Size(188, 23);
            this.textBoxRegNumber.TabIndex = 1;
            // 
            // customTreeCell
            // 
            this.customTreeCell.Location = new System.Drawing.Point(15, 22);
            this.customTreeCell.Name = "customTreeCell";
            this.customTreeCell.Size = new System.Drawing.Size(398, 202);
            this.customTreeCell.TabIndex = 0;
            // 
            // labelRegNum
            // 
            this.labelRegNum.AutoSize = true;
            this.labelRegNum.Location = new System.Drawing.Point(432, 28);
            this.labelRegNum.Name = "labelRegNum";
            this.labelRegNum.Size = new System.Drawing.Size(146, 15);
            this.labelRegNum.TabIndex = 6;
            this.labelRegNum.Text = "Регистрационный номер";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(432, 72);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(50, 15);
            this.labelModel.TabIndex = 7;
            this.labelModel.Text = "Модель";
            // 
            // labelTransportType
            // 
            this.labelTransportType.AutoSize = true;
            this.labelTransportType.Location = new System.Drawing.Point(432, 116);
            this.labelTransportType.Name = "labelTransportType";
            this.labelTransportType.Size = new System.Drawing.Size(93, 15);
            this.labelTransportType.TabIndex = 8;
            this.labelTransportType.Text = "Тип транспорта";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.groupBoxSelected);
            this.Controls.Add(this.groupBoxInput);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxSelected.ResumeLayout(false);
            this.groupBoxSelected.PerformLayout();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyCustomComponents.CustomInputRangeNumber customInputRangeNumber;
        private Button buttonCheck;
        private Label labelCheckValue;
        private TextBox textBoxMin;
        private TextBox textBoxMax;
        private Button buttonSetBorders;
        private Label labelMin;
        private Label labelMax;
        private Label labelRange;
        private GroupBox groupBoxInput;
        private GroupBox groupBoxSelected;
        private Button buttonGetSelected;
        private Label labelSelectedValue;
        private Button buttonClear;
        private Button buttonAdd;
        private TextBox textBoxAdd;
        private MyCustomComponents.CustomSelectedCheckedListBoxProperty customSelectedCheckedListBoxProperty;
        private GroupBox groupBoxData;
        private MyCustomComponents.CustomTreeCell customTreeCell;
        private Button buttonGetFromTree;
        private Button buttonAddToTree;
        private ComboBox comboBoxTransportType;
        private TextBox textBoxModel;
        private TextBox textBoxRegNumber;
        private Label labelTransportType;
        private Label labelModel;
        private Label labelRegNum;
    }
}