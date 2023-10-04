namespace Bazunov_application
{
    partial class FormMain
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
            this.listBoxMany1 = new CustomComponent.ListBoxMany();
            this.SuspendLayout();
            // 
            // listBoxMany1
            // 
            this.listBoxMany1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMany1.Location = new System.Drawing.Point(0, 0);
            this.listBoxMany1.Name = "listBoxMany1";
            this.listBoxMany1.SelectedIndex = -1;
            this.listBoxMany1.Size = new System.Drawing.Size(738, 456);
            this.listBoxMany1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 468);
            this.Controls.Add(this.listBoxMany1);
            this.Name = "FormMain";
            this.Text = "Bazunov Application";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomComponent.ListBoxMany listBoxMany1;
    }
}