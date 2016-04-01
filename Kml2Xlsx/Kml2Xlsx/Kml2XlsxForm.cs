using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Kml2Xlsx
{
    public partial class Kml2XlsxForm : Form
    {
        public Kml2XlsxForm()
        {
            InitializeComponent();
        }
        string datasource = "";

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // 对话框过滤
            dialog.Filter = "kml files (*.kml)|*.kml";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            // 弹出对话框
            dialog.ShowDialog();
            
            // 文件名判断
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                //修改选择框文字信息
                textBoxKmlFileUrl.Text = dialog.FileName;
                //设置文件路径为数据源
                datasource = dialog.FileName;

            }

            // 重置dataSet数据
            dataSetFileData.Reset();
            // 将Xml数据读入dataSet
            ReadXml(datasource,dataSetFileData);

            // 初始化需要新增的列
            DataColumn newNameColumn = new DataColumn("name", dataSetFileData.Tables["Placemark"].Columns["name"].DataType);
            DataColumn newDescriptionColumn = new DataColumn("description", dataSetFileData.Tables["Placemark"].Columns["description"].DataType);
            // 新增列
            dataSetFileData.Tables["Point"].Columns.Add(newNameColumn);
            dataSetFileData.Tables["Point"].Columns.Add(newDescriptionColumn);
            // 获取总行数
            int rowcount = dataSetFileData.Tables["Point"].Rows.Count;
            // 每行循环填入新增列的值
            for (int i = 0; i < rowcount; i++)
            {
                // 根据关联关系Placemark_Point，取出父表数据
                DataRow parentdr = dataSetFileData.Tables["Point"].Rows[i].GetParentRow("Placemark_Point");
                // 两个新增列填值
                dataSetFileData.Tables["Point"].Rows[i]["name"] = parentdr["name"];
                dataSetFileData.Tables["Point"].Rows[i]["description"] = parentdr["description"];
            }
            // dataGridView显示dataSet的数据
            dataGridView1.DataSource = dataSetFileData.Tables["Point"];
            // 将dataTable数据插入Oracle数据库
            DoInsert(dataSetFileData.Tables["Point"]);

        }
        private static void ReadXml(String xmlFilePath,DataSet ds)
        {
            // 使用UTF8编码从字节流中读取数据
            StreamReader sr = new StreamReader(xmlFilePath, Encoding.UTF8);
            // 将Xml数据读入dataSet
            ds.ReadXml(sr);
            // 关闭StreamReader对象和基础流
            sr.Close();
        }

        private void DoInsert(DataTable dt)
        {
            // 初始化语句列表
            ArrayList SQLStringList = new ArrayList();

            // 插入前删除数据
            //SQLStringList.Add("Delete删除语句");

            // 循环生成插入语句
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SQLStringList.Add("insert into TEMP_QX_JWD (C_JWD, C_NAME, C_DESC) VALUES ('"+ dt.Rows[i]["coordinates"] + "','"+ dt.Rows[i]["name"] + "','"+ dt.Rows[i]["description"] + "')");
                }

            }

            // 将语句列表以事务方式执行
            ExecuteSqlTran(SQLStringList);
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            string oraUser = "ezview";
            string oraPass = "ezview";
            string oraIp = "45.4.0.242";
            string connectionString = "User ID="+ oraUser + ";Password="+ oraPass + ";Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = "+ oraIp + ")(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = orcl)))";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                OracleTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (OracleException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

    }
}
