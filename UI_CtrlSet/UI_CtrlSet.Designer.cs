namespace UI_CtrlSet
{
    partial class UI_CtrlSet_Page
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
            this.the_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // the_panel
            // 
            this.the_panel.Location = new System.Drawing.Point(52, 74);
            this.the_panel.Name = "the_panel";
            this.the_panel.Size = new System.Drawing.Size(200, 100);
            this.the_panel.TabIndex = 0;
            this.the_panel.Visible = false;
            // 
            // UI_CtrlSet_Page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.the_panel);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "UI_CtrlSet_Page";
            this.Text = "UI_CtrlSet";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel the_panel;

    }
}

