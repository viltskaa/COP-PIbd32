namespace PluginsConventionLibrary.Forms
{
    partial class EmployerForm
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
            this.textBoxFio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customInputRangeNumber = new MyCustomComponents.CustomInputRangeNumber();
            this.dropDownList = new Kashin_1.DropDownList();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPosts = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFio
            // 
            this.textBoxFio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFio.Location = new System.Drawing.Point(41, 6);
            this.textBoxFio.Name = "textBoxFio";
            this.textBoxFio.Size = new System.Drawing.Size(284, 23);
            this.textBoxFio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Experience";
            // 
            // customInputRangeNumber
            // 
            this.customInputRangeNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customInputRangeNumber.AutoSize = true;
            this.customInputRangeNumber.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.customInputRangeNumber.CausesValidation = false;
            this.customInputRangeNumber.Location = new System.Drawing.Point(82, 35);
            this.customInputRangeNumber.MaxValue = null;
            this.customInputRangeNumber.MinValue = null;
            this.customInputRangeNumber.Name = "customInputRangeNumber";
            this.customInputRangeNumber.Size = new System.Drawing.Size(243, 31);
            this.customInputRangeNumber.TabIndex = 3;
            this.customInputRangeNumber.Value = null;
            // 
            // dropDownList
            // 
            this.dropDownList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropDownList.Location = new System.Drawing.Point(82, 72);
            this.dropDownList.Name = "dropDownList";
            this.dropDownList.SelectedValue = "";
            this.dropDownList.Size = new System.Drawing.Size(243, 29);
            this.dropDownList.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subdivision";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Posts";
            // 
            // textBoxPosts
            // 
            this.textBoxPosts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPosts.Location = new System.Drawing.Point(53, 107);
            this.textBoxPosts.Name = "textBoxPosts";
            this.textBoxPosts.Size = new System.Drawing.Size(272, 23);
            this.textBoxPosts.TabIndex = 7;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.Location = new System.Drawing.Point(12, 141);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(313, 26);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // EmployerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 179);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxPosts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dropDownList);
            this.Controls.Add(this.customInputRangeNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFio);
            this.Name = "EmployerForm";
            this.Text = "EmployerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployerForm_FormClosed);
            this.Load += new System.EventHandler(this.EmployerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxFio;
        private Label label1;
        private Label label2;
        private MyCustomComponents.CustomInputRangeNumber customInputRangeNumber;
        private Kashin_1.DropDownList dropDownList;
        private Label label3;
        private Label label4;
        private TextBox textBoxPosts;
        private Button buttonCreate;
    }
}