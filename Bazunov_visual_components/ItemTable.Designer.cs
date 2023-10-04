namespace Bazunov_VisualComponents
{
    partial class ItemTable
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridViewItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewItems
            // 
            this.DataGridViewItems.AllowUserToAddRows = false;
            this.DataGridViewItems.AllowUserToDeleteRows = false;
            this.DataGridViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewItems.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewItems.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DataGridViewItems.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewItems.MultiSelect = false;
            this.DataGridViewItems.Name = "DataGridViewItems";
            this.DataGridViewItems.ReadOnly = true;
            this.DataGridViewItems.RowHeadersVisible = false;
            this.DataGridViewItems.RowTemplate.Height = 25;
            this.DataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewItems.ShowEditingIcon = false;
            this.DataGridViewItems.Size = new System.Drawing.Size(548, 358);
            this.DataGridViewItems.TabIndex = 0;
            // 
            // ItemTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridViewItems);
            this.Name = "ItemTable";
            this.Size = new System.Drawing.Size(548, 358);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView DataGridViewItems;
    }
}
