namespace saper_form {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butt21 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(12, 584);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(641, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "ОСТАЛОСЬ МИН: 5";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("AlphaSmart 3000", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(12, 630);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(641, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "ПОБЕДА!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butt21
            // 
            this.butt21.BackColor = System.Drawing.Color.DarkSlateGray;
            this.butt21.FlatAppearance.BorderSize = 0;
            this.butt21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butt21.Font = new System.Drawing.Font("AlphaSmart 3000", 15.75F);
            this.butt21.ForeColor = System.Drawing.Color.White;
            this.butt21.Location = new System.Drawing.Point(230, 21);
            this.butt21.Margin = new System.Windows.Forms.Padding(0);
            this.butt21.Name = "butt21";
            this.butt21.Size = new System.Drawing.Size(185, 30);
            this.butt21.TabIndex = 0;
            this.butt21.TabStop = false;
            this.butt21.Tag = "";
            this.butt21.Text = "НОВАЯ ИГРА";
            this.butt21.UseVisualStyleBackColor = false;
            this.butt21.Click += new System.EventHandler(this.NewGame);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(665, 631);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butt21);
            this.ForeColor = System.Drawing.Color.CadetBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "МИНЕР";
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butt21;
    }
}

