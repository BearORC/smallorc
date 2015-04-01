namespace importHashmapToOracle
{
    partial class FormImportHashmapToOracle
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
            this.textBoxDbLink = new System.Windows.Forms.TextBox();
            this.textBoxDbUsername = new System.Windows.Forms.TextBox();
            this.textBoxDbPassword = new System.Windows.Forms.TextBox();
            this.buttonConnectDb = new System.Windows.Forms.Button();
            this.buttonInsertToDb = new System.Windows.Forms.Button();
            this.buttonSelectDbFolder = new System.Windows.Forms.Button();
            this.dataGridViewDb = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDbLink
            // 
            this.textBoxDbLink.Location = new System.Drawing.Point(12, 12);
            this.textBoxDbLink.Name = "textBoxDbLink";
            this.textBoxDbLink.Size = new System.Drawing.Size(350, 21);
            this.textBoxDbLink.TabIndex = 0;
            // 
            // textBoxDbUsername
            // 
            this.textBoxDbUsername.Location = new System.Drawing.Point(12, 39);
            this.textBoxDbUsername.Name = "textBoxDbUsername";
            this.textBoxDbUsername.Size = new System.Drawing.Size(172, 21);
            this.textBoxDbUsername.TabIndex = 1;
            // 
            // textBoxDbPassword
            // 
            this.textBoxDbPassword.Location = new System.Drawing.Point(190, 39);
            this.textBoxDbPassword.Name = "textBoxDbPassword";
            this.textBoxDbPassword.Size = new System.Drawing.Size(172, 21);
            this.textBoxDbPassword.TabIndex = 2;
            // 
            // buttonConnectDb
            // 
            this.buttonConnectDb.Location = new System.Drawing.Point(368, 10);
            this.buttonConnectDb.Name = "buttonConnectDb";
            this.buttonConnectDb.Size = new System.Drawing.Size(75, 23);
            this.buttonConnectDb.TabIndex = 3;
            this.buttonConnectDb.Text = "连接数据库";
            this.buttonConnectDb.UseVisualStyleBackColor = true;
            this.buttonConnectDb.Click += new System.EventHandler(this.buttonConnectDb_Click);
            // 
            // buttonInsertToDb
            // 
            this.buttonInsertToDb.Location = new System.Drawing.Point(368, 37);
            this.buttonInsertToDb.Name = "buttonInsertToDb";
            this.buttonInsertToDb.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertToDb.TabIndex = 4;
            this.buttonInsertToDb.Text = "插入数据";
            this.buttonInsertToDb.UseVisualStyleBackColor = true;
            this.buttonInsertToDb.Click += new System.EventHandler(this.buttonInsertToDb_Click);
            // 
            // buttonSelectDbFolder
            // 
            this.buttonSelectDbFolder.Location = new System.Drawing.Point(449, 10);
            this.buttonSelectDbFolder.Name = "buttonSelectDbFolder";
            this.buttonSelectDbFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectDbFolder.TabIndex = 5;
            this.buttonSelectDbFolder.Text = "选择文件夹";
            this.buttonSelectDbFolder.UseVisualStyleBackColor = true;
            this.buttonSelectDbFolder.Click += new System.EventHandler(this.buttonSelectDbFolder_Click);
            // 
            // dataGridViewDb
            // 
            this.dataGridViewDb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDb.Location = new System.Drawing.Point(12, 66);
            this.dataGridViewDb.Name = "dataGridViewDb";
            this.dataGridViewDb.RowTemplate.Height = 23;
            this.dataGridViewDb.Size = new System.Drawing.Size(512, 430);
            this.dataGridViewDb.TabIndex = 6;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // FormImportHashmapToOracle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 508);
            this.Controls.Add(this.dataGridViewDb);
            this.Controls.Add(this.buttonSelectDbFolder);
            this.Controls.Add(this.buttonInsertToDb);
            this.Controls.Add(this.buttonConnectDb);
            this.Controls.Add(this.textBoxDbPassword);
            this.Controls.Add(this.textBoxDbUsername);
            this.Controls.Add(this.textBoxDbLink);
            this.Name = "FormImportHashmapToOracle";
            this.Text = "映射关系导入工具";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDbLink;
        private System.Windows.Forms.TextBox textBoxDbUsername;
        private System.Windows.Forms.TextBox textBoxDbPassword;
        private System.Windows.Forms.Button buttonConnectDb;
        private System.Windows.Forms.Button buttonInsertToDb;
        private System.Windows.Forms.Button buttonSelectDbFolder;
        private System.Windows.Forms.DataGridView dataGridViewDb;
        private System.Data.DataSet dataSet1;
    }
}

