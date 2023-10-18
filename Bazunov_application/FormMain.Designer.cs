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
            this.listBoxMany = new CustomComponent.ListBoxMany();
            this.excelTable = new Bazunov_Components.ExcelTable(this.components);
            this.componentDiagramToPdf = new CustomComponent.ComponentDiagramToPdf(this.components);
            this.wordWithTable = new MyCustomComponents.WordWithTable(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEmployerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEmployerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEmployerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMany
            // 
            this.listBoxMany.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.listBoxMany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMany.Location = new System.Drawing.Point(0, 24);
            this.listBoxMany.Name = "listBoxMany";
            this.listBoxMany.SelectedIndex = -1;
            this.listBoxMany.Size = new System.Drawing.Size(895, 453);
            this.listBoxMany.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.directoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(895, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createEmployerToolStripMenuItem,
            this.editEmployerToolStripMenuItem,
            this.deleteEmployerToolStripMenuItem,
            this.excelToolStripMenuItem,
            this.wordToolStripMenuItem,
            this.pdfToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // createEmployerToolStripMenuItem
            // 
            this.createEmployerToolStripMenuItem.Name = "createEmployerToolStripMenuItem";
            this.createEmployerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.createEmployerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.createEmployerToolStripMenuItem.Text = "Create Employer";
            this.createEmployerToolStripMenuItem.Click += new System.EventHandler(this.CreateEmployerToolStripMenuItem_Click);
            // 
            // editEmployerToolStripMenuItem
            // 
            this.editEmployerToolStripMenuItem.Name = "editEmployerToolStripMenuItem";
            this.editEmployerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.editEmployerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.editEmployerToolStripMenuItem.Text = "Edit Employer";
            this.editEmployerToolStripMenuItem.Click += new System.EventHandler(this.EditEmployerToolStripMenuItem_Click_1);
            // 
            // deleteEmployerToolStripMenuItem
            // 
            this.deleteEmployerToolStripMenuItem.Name = "deleteEmployerToolStripMenuItem";
            this.deleteEmployerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteEmployerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.deleteEmployerToolStripMenuItem.Text = "Delete Employer";
            this.deleteEmployerToolStripMenuItem.Click += new System.EventHandler(this.DeleteEmployerToolStripMenuItem_Click_1);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
            // 
            // wordToolStripMenuItem
            // 
            this.wordToolStripMenuItem.Name = "wordToolStripMenuItem";
            this.wordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.wordToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.wordToolStripMenuItem.Text = "Word";
            this.wordToolStripMenuItem.Click += new System.EventHandler(this.WordToolStripMenuItem_Click);
            // 
            // pdfToolStripMenuItem
            // 
            this.pdfToolStripMenuItem.Name = "pdfToolStripMenuItem";
            this.pdfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.pdfToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.pdfToolStripMenuItem.Text = "Pdf";
            this.pdfToolStripMenuItem.Click += new System.EventHandler(this.PdfToolStripMenuItem_Click);
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.directoryToolStripMenuItem.Text = "Directory";
            this.directoryToolStripMenuItem.Click += new System.EventHandler(this.DirectoryToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 477);
            this.Controls.Add(this.listBoxMany);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Bazunov Application";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MyCustomComponents.CustomTreeCell customTreeCell1;
        private CustomComponent.ListBoxMany listBoxMany;
        private Bazunov_Components.ExcelTable excelTable;
        private CustomComponent.ComponentDiagramToPdf componentDiagramToPdf;
        private MyCustomComponents.WordWithTable wordWithTable;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem actionToolStripMenuItem;
        private ToolStripMenuItem createEmployerToolStripMenuItem;
        private ToolStripMenuItem editEmployerToolStripMenuItem;
        private ToolStripMenuItem deleteEmployerToolStripMenuItem;
        private ToolStripMenuItem excelToolStripMenuItem;
        private ToolStripMenuItem wordToolStripMenuItem;
        private ToolStripMenuItem pdfToolStripMenuItem;
        private ToolStripMenuItem directoryToolStripMenuItem;
    }
}