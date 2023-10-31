namespace DesktopAppForComponents
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.навыкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordСФотоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfТаблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelГистограммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWithImages1 = new MyCustomComponents.WordWithImages(this.components);
            this.componentTableToPdf1 = new CustomComponent.ComponentTableToPdf(this.components);
            this.bazunovItemTable = new Bazunov_VisualComponents.ItemTable();
            this.excelGistogram1 = new Bazunov_Components.ExcelGistogram(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.действияToolStripMenuItem,
            this.документыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.навыкиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // навыкиToolStripMenuItem
            // 
            this.навыкиToolStripMenuItem.Name = "навыкиToolStripMenuItem";
            this.навыкиToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.навыкиToolStripMenuItem.Text = "Навыки";
            this.навыкиToolStripMenuItem.Click += new System.EventHandler(this.навыкиToolStripMenuItem_Click);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordСФотоToolStripMenuItem,
            this.pdfТаблицаToolStripMenuItem,
            this.excelГистограммаToolStripMenuItem});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // wordСФотоToolStripMenuItem
            // 
            this.wordСФотоToolStripMenuItem.Name = "wordСФотоToolStripMenuItem";
            this.wordСФотоToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.wordСФотоToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.wordСФотоToolStripMenuItem.Text = "Word с фото";
            this.wordСФотоToolStripMenuItem.Click += new System.EventHandler(this.wordСФотоToolStripMenuItem_Click);
            // 
            // pdfТаблицаToolStripMenuItem
            // 
            this.pdfТаблицаToolStripMenuItem.Name = "pdfТаблицаToolStripMenuItem";
            this.pdfТаблицаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.pdfТаблицаToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.pdfТаблицаToolStripMenuItem.Text = "Pdf таблица";
            this.pdfТаблицаToolStripMenuItem.Click += new System.EventHandler(this.pdfТаблицаToolStripMenuItem_Click);
            // 
            // excelГистограммаToolStripMenuItem
            // 
            this.excelГистограммаToolStripMenuItem.Name = "excelГистограммаToolStripMenuItem";
            this.excelГистограммаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.excelГистограммаToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.excelГистограммаToolStripMenuItem.Text = "Excel гистограмма";
            this.excelГистограммаToolStripMenuItem.Click += new System.EventHandler(this.excelГистограммаToolStripMenuItem_Click);
            // 
            // bazunovItemTable
            // 
            this.bazunovItemTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bazunovItemTable.Location = new System.Drawing.Point(12, 27);
            this.bazunovItemTable.Name = "bazunovItemTable";
            this.bazunovItemTable.Size = new System.Drawing.Size(703, 358);
            this.bazunovItemTable.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 397);
            this.Controls.Add(this.bazunovItemTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem навыкиToolStripMenuItem;
        private ToolStripMenuItem действияToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem документыToolStripMenuItem;
        private ToolStripMenuItem wordСФотоToolStripMenuItem;
        private ToolStripMenuItem pdfТаблицаToolStripMenuItem;
        private ToolStripMenuItem excelГистограммаToolStripMenuItem;
        private MyCustomComponents.WordWithImages wordWithImages1;
        private CustomComponent.ComponentTableToPdf componentTableToPdf1;
        private Bazunov_VisualComponents.ItemTable bazunovItemTable;
        private Bazunov_Components.ExcelGistogram excelGistogram1;
    }
}