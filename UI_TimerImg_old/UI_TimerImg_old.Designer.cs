namespace UI_TimerImg_old
{
    partial class UI_TimerImg_old_Page
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox_Canvas = new System.Windows.Forms.PictureBox();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.textBox_YValue = new System.Windows.Forms.TextBox();
            this.textBox_Xcnt = new System.Windows.Forms.TextBox();
            this.checkBox_Puase = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer_FPS = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            this.pictureBox_Canvas.TabIndex = 0;
            this.pictureBox_Canvas.TabStop = false;
            this.pictureBox_Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Canvas_Paint);
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Interval = 1;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // textBox_YValue
            // 
            this.textBox_YValue.Location = new System.Drawing.Point(1, 532);
            this.textBox_YValue.Name = "textBox_YValue";
            this.textBox_YValue.Size = new System.Drawing.Size(100, 29);
            this.textBox_YValue.TabIndex = 1;
            // 
            // textBox_Xcnt
            // 
            this.textBox_Xcnt.Location = new System.Drawing.Point(123, 532);
            this.textBox_Xcnt.Name = "textBox_Xcnt";
            this.textBox_Xcnt.Size = new System.Drawing.Size(100, 29);
            this.textBox_Xcnt.TabIndex = 2;
            // 
            // checkBox_Puase
            // 
            this.checkBox_Puase.AutoSize = true;
            this.checkBox_Puase.Location = new System.Drawing.Point(246, 532);
            this.checkBox_Puase.Name = "checkBox_Puase";
            this.checkBox_Puase.Size = new System.Drawing.Size(73, 24);
            this.checkBox_Puase.TabIndex = 4;
            this.checkBox_Puase.Text = "Pause";
            this.checkBox_Puase.UseVisualStyleBackColor = true;
            this.checkBox_Puase.CheckedChanged += new System.EventHandler(this.checkBox_Puase_CheckedChanged);
            this.checkBox_Puase.Click += new System.EventHandler(this.checkBox_Puase_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(365, 532);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 5;
            // 
            // timer_FPS
            // 
            this.timer_FPS.Interval = 1000;
            this.timer_FPS.Tick += new System.EventHandler(this.timer_FPS_Tick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(513, 532);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 29);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(654, 530);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 29);
            this.textBox3.TabIndex = 7;
            // 
            // UI_TimerImg_old_Page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1067, 573);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox_Puase);
            this.Controls.Add(this.textBox_Xcnt);
            this.Controls.Add(this.textBox_YValue);
            this.Controls.Add(this.pictureBox_Canvas);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "UI_TimerImg_old_Page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_TimerImg_old";
            this.Load += new System.EventHandler(this.UI_TimerImg_Page_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Canvas;
        private System.Windows.Forms.Timer timer_Refresh;
        private System.Windows.Forms.TextBox textBox_YValue;
        private System.Windows.Forms.TextBox textBox_Xcnt;
        private System.Windows.Forms.CheckBox checkBox_Puase;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer_FPS;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

