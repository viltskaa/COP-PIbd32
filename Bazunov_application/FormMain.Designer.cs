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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newEmployerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEmployerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEmployerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEmployerToolStripMenuItem,
            this.editEmployerToolStripMenuItem,
            this.deleteEmployerToolStripMenuItem,
            this.createExcelToolStripMenuItem,
            this.createWordToolStripMenuItem,
            this.createPdfToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 136);
            // 
            // newEmployerToolStripMenuItem
            // 
            this.newEmployerToolStripMenuItem.Name = "newEmployerToolStripMenuItem";
            this.newEmployerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.newEmployerToolStripMenuItem.Text = "New Employer";
            this.newEmployerToolStripMenuItem.Click += new System.EventHandler(this.NewEmployerToolStripMenuItem_Click);
            // 
            // editEmployerToolStripMenuItem
            // 
            this.editEmployerToolStripMenuItem.Name = "editEmployerToolStripMenuItem";
            this.editEmployerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.editEmployerToolStripMenuItem.Text = "Edit Employer";
            this.editEmployerToolStripMenuItem.Click += new System.EventHandler(this.EditEmployerToolStripMenuItem_Click);
            // 
            // deleteEmployerToolStripMenuItem
            // 
            this.deleteEmployerToolStripMenuItem.Name = "deleteEmployerToolStripMenuItem";
            this.deleteEmployerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteEmployerToolStripMenuItem.Text = "Delete Employer";
            this.deleteEmployerToolStripMenuItem.Click += new System.EventHandler(this.DeleteEmployerToolStripMenuItem_Click);
            // 
            // createExcelToolStripMenuItem
            // 
            this.createExcelToolStripMenuItem.Name = "createExcelToolStripMenuItem";
            this.createExcelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.createExcelToolStripMenuItem.Text = "Create Excel";
            this.createExcelToolStripMenuItem.Click += new System.EventHandler(this.CreateExcelToolStripMenuItem_Click);
            // 
            // createWordToolStripMenuItem
            // 
            this.createWordToolStripMenuItem.Name = "createWordToolStripMenuItem";
            this.createWordToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.createWordToolStripMenuItem.Text = "Create Word";
            this.createWordToolStripMenuItem.Click += new System.EventHandler(this.CreateWordToolStripMenuItem_Click);
            // 
            // createPdfToolStripMenuItem
            // 
            this.createPdfToolStripMenuItem.Name = "createPdfToolStripMenuItem";
            this.createPdfToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.createPdfToolStripMenuItem.Text = "Create Pdf";
            this.createPdfToolStripMenuItem.Click += new System.EventHandler(this.CreatePdfToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 477);
            this.Name = "FormMain";
            this.Text = "Bazunov Application";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem newEmployerToolStripMenuItem;
        private ToolStripMenuItem editEmployerToolStripMenuItem;
        private ToolStripMenuItem deleteEmployerToolStripMenuItem;
        private ToolStripMenuItem createExcelToolStripMenuItem;
        private ToolStripMenuItem createWordToolStripMenuItem;
        private ToolStripMenuItem createPdfToolStripMenuItem;
        private MyCustomComponents.CustomTreeCell customTreeCell1;
    }
}