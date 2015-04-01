namespace WeiboVideoUrlTool
{
    partial class WeiboVideoUrlTool
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetUrl = new System.Windows.Forms.Button();
            this.textBoxWeiboUrl = new System.Windows.Forms.TextBox();
            this.richTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonGetUrl
            // 
            this.buttonGetUrl.Location = new System.Drawing.Point(1058, 11);
            this.buttonGetUrl.Name = "buttonGetUrl";
            this.buttonGetUrl.Size = new System.Drawing.Size(75, 23);
            this.buttonGetUrl.TabIndex = 0;
            this.buttonGetUrl.Text = "获取";
            this.buttonGetUrl.UseVisualStyleBackColor = true;
            this.buttonGetUrl.Click += new System.EventHandler(this.buttonGetUrl_Click);
            // 
            // textBoxWeiboUrl
            // 
            this.textBoxWeiboUrl.Location = new System.Drawing.Point(13, 13);
            this.textBoxWeiboUrl.Name = "textBoxWeiboUrl";
            this.textBoxWeiboUrl.Size = new System.Drawing.Size(1012, 21);
            this.textBoxWeiboUrl.TabIndex = 1;
            // 
            // richTextBoxConsole
            // 
            this.richTextBoxConsole.Location = new System.Drawing.Point(13, 41);
            this.richTextBoxConsole.Name = "richTextBoxConsole";
            this.richTextBoxConsole.Size = new System.Drawing.Size(1012, 478);
            this.richTextBoxConsole.TabIndex = 2;
            this.richTextBoxConsole.Text = "";
            // 
            // WeiboVideoUrlTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 531);
            this.Controls.Add(this.richTextBoxConsole);
            this.Controls.Add(this.textBoxWeiboUrl);
            this.Controls.Add(this.buttonGetUrl);
            this.Name = "WeiboVideoUrlTool";
            this.Text = "WeiboVideoUrlTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetUrl;
        private System.Windows.Forms.TextBox textBoxWeiboUrl;
        private System.Windows.Forms.RichTextBox richTextBoxConsole;
    }
}

