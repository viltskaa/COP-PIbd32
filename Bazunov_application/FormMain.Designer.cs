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
            this.itemTable1 = new Bazunov_VisualComponents.ItemTable();
            this.SuspendLayout();
            // 
            // itemTable1
            // 
            this.itemTable1.Location = new System.Drawing.Point(12, 12);
            this.itemTable1.Name = "itemTable1";
            this.itemTable1.Size = new System.Drawing.Size(726, 444);
            this.itemTable1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 468);
            this.Controls.Add(this.itemTable1);
            this.Name = "FormMain";
            this.Text = "Bazunov Application";
            this.ResumeLayout(false);

        }

        #endregion

        private Bazunov_VisualComponents.ItemTable itemTable1;
    }
}