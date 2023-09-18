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
            this.groupBoxInput.SuspendLayout();
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxInput);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
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
    }
}