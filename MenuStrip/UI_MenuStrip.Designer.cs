namespace UI_MenuStrip
{
    partial class UI_MenuStrip_page
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test121ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test11ToolStripMenuItem,
            this.test12ToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.testToolStripMenuItem.Text = "test 1";
            // 
            // test11ToolStripMenuItem
            // 
            this.test11ToolStripMenuItem.Name = "test11ToolStripMenuItem";
            this.test11ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.test11ToolStripMenuItem.Text = "test 1-1";
            // 
            // test12ToolStripMenuItem
            // 
            this.test12ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test121ToolStripMenuItem});
            this.test12ToolStripMenuItem.Name = "test12ToolStripMenuItem";
            this.test12ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.test12ToolStripMenuItem.Text = "test 1-2";
            // 
            // test121ToolStripMenuItem
            // 
            this.test121ToolStripMenuItem.Name = "test121ToolStripMenuItem";
            this.test121ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.test121ToolStripMenuItem.Text = "test 1-2-1";
            // 
            // UI_MenuStrip_page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(704, 361);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UI_MenuStrip_page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Strip";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test121ToolStripMenuItem;


    }
}

