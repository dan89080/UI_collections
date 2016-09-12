namespace UI_TimerImg_test
{
    partial class UI_TimerImg_test_Page
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_Canvas = new System.Windows.Forms.PictureBox();
            this.checkBox_Pause = new System.Windows.Forms.CheckBox();
            this.textBox_Xcnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Canvas
            // 
            this.pictureBox_Canvas.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Canvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Canvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Canvas.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Canvas.Name = "pictureBox_Canvas";
            this.pictureBox_Canvas.Size = new System.Drawing.Size(500, 400);
            this.pictureBox_Canvas.TabIndex = 1;
            this.pictureBox_Canvas.TabStop = false;
            // 
            // checkBox_Pause
            // 
            this.checkBox_Pause.AutoSize = true;
            this.checkBox_Pause.Location = new System.Drawing.Point(354, 516);
            this.checkBox_Pause.Name = "checkBox_Pause";
            this.checkBox_Pause.Size = new System.Drawing.Size(73, 24);
            this.checkBox_Pause.TabIndex = 5;
            this.checkBox_Pause.Text = "Pause";
            this.checkBox_Pause.UseVisualStyleBackColor = true;
            this.checkBox_Pause.Click += new System.EventHandler(this.checkBox_Pause_Click);
            // 
            // textBox_Xcnt
            // 
            this.textBox_Xcnt.Location = new System.Drawing.Point(92, 494);
            this.textBox_Xcnt.Name = "textBox_Xcnt";
            this.textBox_Xcnt.Size = new System.Drawing.Size(100, 29);
            this.textBox_Xcnt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 497);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "count :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(725, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(145, 516);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // UI_TimerImg_Page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Xcnt);
            this.Controls.Add(this.checkBox_Pause);
            this.Controls.Add(this.pictureBox_Canvas);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "UI_TimerImg_Page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_TimerImg";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Canvas;
        private System.Windows.Forms.CheckBox checkBox_Pause;
        private System.Windows.Forms.TextBox textBox_Xcnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

