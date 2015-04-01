using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace importHashmapToOracle
{
    public partial class FormImportHashmapToOracle : Form
    {
        public FormImportHashmapToOracle()
        {
            InitializeComponent();
        }

        private static Hashtable puidmap = new Hashtable();

        private void buttonConnectDb_Click(object sender, EventArgs e)
        {

        }

        private void buttonInsertToDb_Click(object sender, EventArgs e)
        {

        }

        private void buttonSelectDbFolder_Click(object sender, EventArgs e)
        {
            string folder = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folder = folderBrowserDialog.SelectedPath;
            }
            if (Directory.Exists(folder))
            {
                //文件夹及子文件夹下的所有文件的全路径
                string[] files = Directory.GetFiles(folder, "*.db", SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = Path.GetFileNameWithoutExtension(files[i]);//只取后缀
                }

                for (int i = 0; i < files.Count(); i++)
                {
                    //建立SQLite连接
                    System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection();
                    System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                    connstr.DataSource = files[i];
                    //connstr.Password = "kdc";
                    conn.ConnectionString = connstr.ToString();
                    conn.Open();
                    //执行查询语句
                    string sql = "select id,puid from camdevices";
                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandText = sql;
                    System.Data.SQLite.SQLiteDataAdapter dataAdapter = new System.Data.SQLite.SQLiteDataAdapter(sql, conn);
                    //填充架构及数据
                    dataAdapter.FillSchema(dataSet1, SchemaType.Source, "camdevices");
                    dataAdapter.Fill(dataSet1, "camdevices");
                    //清空dataGridView数据源
                    if (dataGridViewDb.DataSource != null && dataGridViewDb.DataSource != "")
                    {
                        dataGridViewDb.DataSource = "";
                        dataGridViewDb.Refresh();
                    }
                    //填充dataGridView
                    dataGridViewDb.DataSource = dataSet1.Tables[0];
                    //刷新映射表
                    if (puidmap.ToString() != null && puidmap.ToString() != "")
                    {
                        puidmap.Clear();
                    }
                    for (int j = 0; j < dataSet1.Tables[0].Rows.Count; j++)
                    {
                        puidmap.Add(dataSet1.Tables[0].Rows[i][0], dataSet1.Tables[0].Rows[i][1]);
                    }
                    conn.Close();
                }
            }
        }
    }
}
