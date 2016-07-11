namespace Kml2Xlsx
{
    partial class Kml2XlsxForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxKmlFileUrl = new System.Windows.Forms.TextBox();
            this.dataSetFileData = new System.Data.DataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSaveToOracle = new System.Windows.Forms.Button();
            this.buttonGpsOffset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFileData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(552, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 21);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "浏览";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxKmlFileUrl
            // 
            this.textBoxKmlFileUrl.Location = new System.Drawing.Point(13, 12);
            this.textBoxKmlFileUrl.Name = "textBoxKmlFileUrl";
            this.textBoxKmlFileUrl.Size = new System.Drawing.Size(533, 21);
            this.textBoxKmlFileUrl.TabIndex = 1;
            // 
            // dataSetFileData
            // 
            this.dataSetFileData.DataSetName = "NewDataSet";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(776, 420);
            this.dataGridView1.TabIndex = 4;
            // 
            // buttonSaveToOracle
            // 
            this.buttonSaveToOracle.Location = new System.Drawing.Point(633, 12);
            this.buttonSaveToOracle.Name = "buttonSaveToOracle";
            this.buttonSaveToOracle.Size = new System.Drawing.Size(75, 21);
            this.buttonSaveToOracle.TabIndex = 5;
            this.buttonSaveToOracle.Text = "存入Oracle";
            this.buttonSaveToOracle.UseVisualStyleBackColor = true;
            this.buttonSaveToOracle.Click += new System.EventHandler(this.buttonSaveToOracle_Click);
            // 
            // buttonGpsOffset
            // 
            this.buttonGpsOffset.Location = new System.Drawing.Point(714, 12);
            this.buttonGpsOffset.Name = "buttonGpsOffset";
            this.buttonGpsOffset.Size = new System.Drawing.Size(75, 21);
            this.buttonGpsOffset.TabIndex = 6;
            this.buttonGpsOffset.Text = "纠偏";
            this.buttonGpsOffset.UseVisualStyleBackColor = true;
            this.buttonGpsOffset.Click += new System.EventHandler(this.buttonGpsOffset_Click);
            // 
            // Kml2XlsxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 472);
            this.Controls.Add(this.buttonGpsOffset);
            this.Controls.Add(this.buttonSaveToOracle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxKmlFileUrl);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "Kml2XlsxForm";
            this.Text = "Kml2XlsxForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFileData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxKmlFileUrl;
        private System.Data.DataSet dataSetFileData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSaveToOracle;
        private System.Windows.Forms.Button buttonGpsOffset;
    }
}

