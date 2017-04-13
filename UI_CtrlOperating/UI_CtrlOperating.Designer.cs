namespace UI_CtrlOperating
{
    partial class UI_CtrlOperating_Page
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Aro_Edit = new System.Windows.Forms.RadioButton();
            this.radioButton_Func_Edit = new System.Windows.Forms.RadioButton();
            this.radioButton_UI_Edit = new System.Windows.Forms.RadioButton();
            this.radioButton_Exec = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.usrCtrl_Unit1 = new UI_CtrlOperating.UsrCtrl_Unit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UI_CtrlOperating.Properties.Resources.Sunset;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 51);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Aro_Edit);
            this.groupBox1.Controls.Add(this.radioButton_Func_Edit);
            this.groupBox1.Controls.Add(this.radioButton_UI_Edit);
            this.groupBox1.Controls.Add(this.radioButton_Exec);
            this.groupBox1.Location = new System.Drawing.Point(12, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode Select";
            // 
            // radioButton_Aro_Edit
            // 
            this.radioButton_Aro_Edit.AutoSize = true;
            this.radioButton_Aro_Edit.Location = new System.Drawing.Point(17, 107);
            this.radioButton_Aro_Edit.Name = "radioButton_Aro_Edit";
            this.radioButton_Aro_Edit.Size = new System.Drawing.Size(98, 20);
            this.radioButton_Aro_Edit.TabIndex = 3;
            this.radioButton_Aro_Edit.Text = "箭頭編輯模式";
            this.radioButton_Aro_Edit.UseVisualStyleBackColor = true;
            this.radioButton_Aro_Edit.CheckedChanged += new System.EventHandler(this.rdoBtn_CheckedChanged);
            // 
            // radioButton_Func_Edit
            // 
            this.radioButton_Func_Edit.AutoSize = true;
            this.radioButton_Func_Edit.Location = new System.Drawing.Point(17, 55);
            this.radioButton_Func_Edit.Name = "radioButton_Func_Edit";
            this.radioButton_Func_Edit.Size = new System.Drawing.Size(98, 20);
            this.radioButton_Func_Edit.TabIndex = 2;
            this.radioButton_Func_Edit.Text = "指令編輯模式";
            this.radioButton_Func_Edit.UseVisualStyleBackColor = true;
            this.radioButton_Func_Edit.CheckedChanged += new System.EventHandler(this.rdoBtn_CheckedChanged);
            // 
            // radioButton_UI_Edit
            // 
            this.radioButton_UI_Edit.AutoSize = true;
            this.radioButton_UI_Edit.Checked = true;
            this.radioButton_UI_Edit.Location = new System.Drawing.Point(17, 81);
            this.radioButton_UI_Edit.Name = "radioButton_UI_Edit";
            this.radioButton_UI_Edit.Size = new System.Drawing.Size(98, 20);
            this.radioButton_UI_Edit.TabIndex = 1;
            this.radioButton_UI_Edit.TabStop = true;
            this.radioButton_UI_Edit.Text = "介面編輯模式";
            this.radioButton_UI_Edit.UseVisualStyleBackColor = true;
            this.radioButton_UI_Edit.CheckedChanged += new System.EventHandler(this.rdoBtn_CheckedChanged);
            // 
            // radioButton_Exec
            // 
            this.radioButton_Exec.AutoSize = true;
            this.radioButton_Exec.Location = new System.Drawing.Point(17, 29);
            this.radioButton_Exec.Name = "radioButton_Exec";
            this.radioButton_Exec.Size = new System.Drawing.Size(74, 20);
            this.radioButton_Exec.TabIndex = 0;
            this.radioButton_Exec.Text = "執行模式";
            this.radioButton_Exec.UseVisualStyleBackColor = true;
            this.radioButton_Exec.CheckedChanged += new System.EventHandler(this.rdoBtn_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(24, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create Button";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(153, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Create PictureBox";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(282, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 30);
            this.button3.TabIndex = 6;
            this.button3.Text = "Link Button";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(164, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 123);
            this.button4.TabIndex = 7;
            this.button4.Text = "點\r\n膠\r\n結\r\n束";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // usrCtrl_Unit1
            // 
            this.usrCtrl_Unit1.BackColor = System.Drawing.Color.Coral;
            this.usrCtrl_Unit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrCtrl_Unit1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.usrCtrl_Unit1.Location = new System.Drawing.Point(12, 53);
            this.usrCtrl_Unit1.Name = "usrCtrl_Unit1";
            this.usrCtrl_Unit1.Size = new System.Drawing.Size(98, 38);
            this.usrCtrl_Unit1.TabIndex = 2;
            this.usrCtrl_Unit1.Visible = false;
            // 
            // UI_CtrlOperating_Page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(809, 363);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.usrCtrl_Unit1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "UI_CtrlOperating_Page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "UI_CtrlOperating";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UI_CtrlOperating_Page_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UI_CtrlOperating_Page_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private UsrCtrl_Unit usrCtrl_Unit1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Func_Edit;
        private System.Windows.Forms.RadioButton radioButton_UI_Edit;
        private System.Windows.Forms.RadioButton radioButton_Exec;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton_Aro_Edit;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

