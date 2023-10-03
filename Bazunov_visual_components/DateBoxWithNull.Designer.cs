namespace Bazunov_VisualComponents
{
    partial class DateBoxWithNull
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
            this.CheckBoxNull = new System.Windows.Forms.CheckBox();
            this.TextBoxDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CheckBoxNull
            // 
            this.CheckBoxNull.AutoSize = true;
            this.CheckBoxNull.Location = new System.Drawing.Point(3, 7);
            this.CheckBoxNull.Name = "CheckBoxNull";
            this.CheckBoxNull.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxNull.TabIndex = 0;
            this.CheckBoxNull.UseVisualStyleBackColor = true;
            this.CheckBoxNull.CheckedChanged += new System.EventHandler(this.CheckBoxNull_CheckedChanged);
            // 
            // TextBoxDate
            // 
            this.TextBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDate.Location = new System.Drawing.Point(24, 3);
            this.TextBoxDate.Name = "TextBoxDate";
            this.TextBoxDate.Size = new System.Drawing.Size(271, 23);
            this.TextBoxDate.TabIndex = 1;
            this.TextBoxDate.TextChanged += new System.EventHandler(this.TextBoxDate_TextChanged);
            // 
            // DateBoxWithNull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.TextBoxDate);
            this.Controls.Add(this.CheckBoxNull);
            this.Name = "DateBoxWithNull";
            this.Size = new System.Drawing.Size(298, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox CheckBoxNull;
        private TextBox TextBoxDate;
    }
}
