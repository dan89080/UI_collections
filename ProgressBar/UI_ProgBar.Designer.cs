namespace UI_ProgBar
{
    partial class UI_ProgBar_page
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
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.label_Increment = new System.Windows.Forms.Label();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_timerAble = new System.Windows.Forms.Button();
            this.checkBox_toInputText = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_InputOnce = new System.Windows.Forms.Button();
            this.textBox_inc_Timer = new System.Windows.Forms.TextBox();
            this.textBox_inc_Once = new System.Windows.Forms.TextBox();
            this.label_interval = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_SetInterval = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_SetInterval = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.Location = new System.Drawing.Point(137, 104);
            this.MyProgressBar.Maximum = 1000;
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(100, 23);
            this.MyProgressBar.TabIndex = 0;
            // 
            // label_Increment
            // 
            this.label_Increment.AutoSize = true;
            this.label_Increment.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Increment.Location = new System.Drawing.Point(216, 133);
            this.label_Increment.Name = "label_Increment";
            this.label_Increment.Size = new System.Drawing.Size(160, 40);
            this.label_Increment.TabIndex = 2;
            this.label_Increment.Text = "Progress Increment:\r\n()";
            // 
            // button_reset
            // 
            this.button_reset.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_reset.Location = new System.Drawing.Point(246, 104);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(96, 23);
            this.button_reset.TabIndex = 3;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_timerAble
            // 
            this.button_timerAble.Location = new System.Drawing.Point(137, 132);
            this.button_timerAble.Name = "button_timerAble";
            this.button_timerAble.Size = new System.Drawing.Size(75, 46);
            this.button_timerAble.TabIndex = 4;
            this.button_timerAble.Text = "enable\r\ntimer(10)";
            this.button_timerAble.UseVisualStyleBackColor = true;
            this.button_timerAble.Click += new System.EventHandler(this.button_timerAble_Click);
            // 
            // checkBox_toInputText
            // 
            this.checkBox_toInputText.AutoSize = true;
            this.checkBox_toInputText.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_toInputText.Location = new System.Drawing.Point(234, 27);
            this.checkBox_toInputText.Name = "checkBox_toInputText";
            this.checkBox_toInputText.Size = new System.Drawing.Size(119, 21);
            this.checkBox_toInputText.TabIndex = 6;
            this.checkBox_toInputText.Text = "Enable Input(1)";
            this.checkBox_toInputText.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "(1) By timer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "(2) Only once:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(18, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Progress:";
            // 
            // button_InputOnce
            // 
            this.button_InputOnce.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_InputOnce.Location = new System.Drawing.Point(234, 54);
            this.button_InputOnce.Name = "button_InputOnce";
            this.button_InputOnce.Size = new System.Drawing.Size(96, 23);
            this.button_InputOnce.TabIndex = 11;
            this.button_InputOnce.Text = "Input once";
            this.button_InputOnce.UseVisualStyleBackColor = true;
            this.button_InputOnce.Click += new System.EventHandler(this.button_InputOnce_Click);
            // 
            // textBox_inc_Timer
            // 
            this.textBox_inc_Timer.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_inc_Timer.Location = new System.Drawing.Point(125, 24);
            this.textBox_inc_Timer.Name = "textBox_inc_Timer";
            this.textBox_inc_Timer.Size = new System.Drawing.Size(100, 23);
            this.textBox_inc_Timer.TabIndex = 1;
            // 
            // textBox_inc_Once
            // 
            this.textBox_inc_Once.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_inc_Once.Location = new System.Drawing.Point(125, 53);
            this.textBox_inc_Once.Name = "textBox_inc_Once";
            this.textBox_inc_Once.Size = new System.Drawing.Size(100, 23);
            this.textBox_inc_Once.TabIndex = 8;
            this.textBox_inc_Once.Text = "0";
            // 
            // label_interval
            // 
            this.label_interval.AutoSize = true;
            this.label_interval.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_interval.Location = new System.Drawing.Point(18, 133);
            this.label_interval.Name = "label_interval";
            this.label_interval.Size = new System.Drawing.Size(117, 40);
            this.label_interval.TabIndex = 12;
            this.label_interval.Text = "Timer Interval:\r\n(--)ms";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_InputOnce);
            this.groupBox1.Controls.Add(this.textBox_inc_Timer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox_toInputText);
            this.groupBox1.Controls.Add(this.textBox_inc_Once);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 86);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set increment";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_SetInterval);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_SetInterval);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(12, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 65);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set interval";
            // 
            // button_SetInterval
            // 
            this.button_SetInterval.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_SetInterval.Location = new System.Drawing.Point(234, 26);
            this.button_SetInterval.Name = "button_SetInterval";
            this.button_SetInterval.Size = new System.Drawing.Size(96, 23);
            this.button_SetInterval.TabIndex = 14;
            this.button_SetInterval.Text = "Set interval";
            this.button_SetInterval.UseVisualStyleBackColor = true;
            this.button_SetInterval.Click += new System.EventHandler(this.button_SetInterval_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "(3) Input:";
            // 
            // textBox_SetInterval
            // 
            this.textBox_SetInterval.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_SetInterval.Location = new System.Drawing.Point(125, 25);
            this.textBox_SetInterval.Name = "textBox_SetInterval";
            this.textBox_SetInterval.Size = new System.Drawing.Size(100, 23);
            this.textBox_SetInterval.TabIndex = 12;
            this.textBox_SetInterval.Text = "0";
            // 
            // UI_ProgBar_page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MyProgressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_interval);
            this.Controls.Add(this.button_timerAble);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Increment);
            this.Controls.Add(this.button_reset);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UI_ProgBar_page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress Bar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Increment;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_timerAble;
        private System.Windows.Forms.CheckBox checkBox_toInputText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_InputOnce;
        private System.Windows.Forms.TextBox textBox_inc_Timer;
        private System.Windows.Forms.TextBox textBox_inc_Once;
        public System.Windows.Forms.ProgressBar MyProgressBar;
        private System.Windows.Forms.Label label_interval;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_SetInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_SetInterval;
    }
}

