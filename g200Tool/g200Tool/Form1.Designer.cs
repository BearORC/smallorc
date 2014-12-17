namespace g200Tool
{
    partial class FormGatewayTool
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
            this.buttonSelectDbFile = new System.Windows.Forms.Button();
            this.buttonSelectExcelFile = new System.Windows.Forms.Button();
            this.buttonImportData = new System.Windows.Forms.Button();
            this.buttonUpdateAndSaveFile = new System.Windows.Forms.Button();
            this.dataGridViewDb = new System.Windows.Forms.DataGridView();
            this.dataGridViewExcel = new System.Windows.Forms.DataGridView();
            this.textBoxDbUrl = new System.Windows.Forms.TextBox();
            this.textBoxExcelUrl = new System.Windows.Forms.TextBox();
            this.dataSet1 = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelectDbFile
            // 
            this.buttonSelectDbFile.Location = new System.Drawing.Point(709, 10);
            this.buttonSelectDbFile.Name = "buttonSelectDbFile";
            this.buttonSelectDbFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectDbFile.TabIndex = 0;
            this.buttonSelectDbFile.Text = "选择DB文件";
            this.buttonSelectDbFile.UseVisualStyleBackColor = true;
            this.buttonSelectDbFile.Click += new System.EventHandler(this.buttonSelectDbFile_Click);
            // 
            // buttonSelectExcelFile
            // 
            this.buttonSelectExcelFile.Location = new System.Drawing.Point(709, 37);
            this.buttonSelectExcelFile.Name = "buttonSelectExcelFile";
            this.buttonSelectExcelFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectExcelFile.TabIndex = 1;
            this.buttonSelectExcelFile.Text = "选择模板";
            this.buttonSelectExcelFile.UseVisualStyleBackColor = true;
            this.buttonSelectExcelFile.Click += new System.EventHandler(this.buttonSelectExcelFile_Click);
            // 
            // buttonImportData
            // 
            this.buttonImportData.Location = new System.Drawing.Point(709, 66);
            this.buttonImportData.Name = "buttonImportData";
            this.buttonImportData.Size = new System.Drawing.Size(75, 23);
            this.buttonImportData.TabIndex = 2;
            this.buttonImportData.Text = "导入数据";
            this.buttonImportData.UseVisualStyleBackColor = true;
            this.buttonImportData.Click += new System.EventHandler(this.buttonImportData_Click);
            // 
            // buttonUpdateAndSaveFile
            // 
            this.buttonUpdateAndSaveFile.Location = new System.Drawing.Point(709, 95);
            this.buttonUpdateAndSaveFile.Name = "buttonUpdateAndSaveFile";
            this.buttonUpdateAndSaveFile.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateAndSaveFile.TabIndex = 3;
            this.buttonUpdateAndSaveFile.Text = "修改并另存";
            this.buttonUpdateAndSaveFile.UseVisualStyleBackColor = true;
            this.buttonUpdateAndSaveFile.Click += new System.EventHandler(this.buttonUpdateAndSaveFile_Click);
            // 
            // dataGridViewDb
            // 
            this.dataGridViewDb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDb.Location = new System.Drawing.Point(12, 66);
            this.dataGridViewDb.Name = "dataGridViewDb";
            this.dataGridViewDb.RowTemplate.Height = 23;
            this.dataGridViewDb.Size = new System.Drawing.Size(346, 394);
            this.dataGridViewDb.TabIndex = 4;
            // 
            // dataGridViewExcel
            // 
            this.dataGridViewExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExcel.Location = new System.Drawing.Point(364, 66);
            this.dataGridViewExcel.Name = "dataGridViewExcel";
            this.dataGridViewExcel.RowTemplate.Height = 23;
            this.dataGridViewExcel.Size = new System.Drawing.Size(339, 394);
            this.dataGridViewExcel.TabIndex = 5;
            // 
            // textBoxDbUrl
            // 
            this.textBoxDbUrl.Location = new System.Drawing.Point(12, 12);
            this.textBoxDbUrl.Name = "textBoxDbUrl";
            this.textBoxDbUrl.ReadOnly = true;
            this.textBoxDbUrl.Size = new System.Drawing.Size(691, 21);
            this.textBoxDbUrl.TabIndex = 6;
            // 
            // textBoxExcelUrl
            // 
            this.textBoxExcelUrl.Location = new System.Drawing.Point(12, 39);
            this.textBoxExcelUrl.Name = "textBoxExcelUrl";
            this.textBoxExcelUrl.ReadOnly = true;
            this.textBoxExcelUrl.Size = new System.Drawing.Size(691, 21);
            this.textBoxExcelUrl.TabIndex = 7;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // FormGatewayTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 472);
            this.Controls.Add(this.textBoxExcelUrl);
            this.Controls.Add(this.textBoxDbUrl);
            this.Controls.Add(this.dataGridViewExcel);
            this.Controls.Add(this.dataGridViewDb);
            this.Controls.Add(this.buttonUpdateAndSaveFile);
            this.Controls.Add(this.buttonImportData);
            this.Controls.Add(this.buttonSelectExcelFile);
            this.Controls.Add(this.buttonSelectDbFile);
            this.Name = "FormGatewayTool";
            this.Text = "G网关映射导出工具";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectDbFile;
        private System.Windows.Forms.Button buttonSelectExcelFile;
        private System.Windows.Forms.Button buttonImportData;
        private System.Windows.Forms.Button buttonUpdateAndSaveFile;
        private System.Windows.Forms.DataGridView dataGridViewDb;
        private System.Windows.Forms.DataGridView dataGridViewExcel;
        private System.Windows.Forms.TextBox textBoxDbUrl;
        private System.Windows.Forms.TextBox textBoxExcelUrl;
        private System.Data.DataSet dataSet1;
    }
}

