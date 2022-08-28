namespace FormSort1
{
    partial class FormSort
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MySort1 = new System.Windows.Forms.Button();
            this.BttnCountingSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MySort1
            // 
            this.MySort1.Location = new System.Drawing.Point(56, 41);
            this.MySort1.Name = "MySort1";
            this.MySort1.Size = new System.Drawing.Size(75, 23);
            this.MySort1.TabIndex = 0;
            this.MySort1.Text = "MySort1";
            this.MySort1.UseVisualStyleBackColor = true;
            this.MySort1.Click += new System.EventHandler(this.MySort1_Click);
            // 
            // BttnCountingSort
            // 
            this.BttnCountingSort.Location = new System.Drawing.Point(40, 12);
            this.BttnCountingSort.Name = "BttnCountingSort";
            this.BttnCountingSort.Size = new System.Drawing.Size(107, 23);
            this.BttnCountingSort.TabIndex = 1;
            this.BttnCountingSort.Text = "CountingSort";
            this.BttnCountingSort.UseVisualStyleBackColor = true;
            this.BttnCountingSort.Click += new System.EventHandler(this.bttnCountingSort_Click);
            // 
            // FormSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 82);
            this.Controls.Add(this.BttnCountingSort);
            this.Controls.Add(this.MySort1);
            this.Name = "FormSort";
            this.Text = "FormSort";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MySort1;
        private System.Windows.Forms.Button BttnCountingSort;
    }
}

