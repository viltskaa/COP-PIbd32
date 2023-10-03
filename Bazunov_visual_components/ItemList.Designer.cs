namespace Bazunov_visual_components
{
    partial class ItemList
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
            this.ListBoxCustom = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListBoxCustom
            // 
            this.ListBoxCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxCustom.FormattingEnabled = true;
            this.ListBoxCustom.ItemHeight = 15;
            this.ListBoxCustom.Location = new System.Drawing.Point(0, 0);
            this.ListBoxCustom.Name = "ListBoxCustom";
            this.ListBoxCustom.Size = new System.Drawing.Size(272, 259);
            this.ListBoxCustom.TabIndex = 0;
            this.ListBoxCustom.SelectedIndexChanged += new System.EventHandler(this.ListBoxCustom_SelectedIndexChanged);
            // 
            // ItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListBoxCustom);
            this.Name = "ItemList";
            this.Size = new System.Drawing.Size(272, 265);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox ListBoxCustom;
    }
}
