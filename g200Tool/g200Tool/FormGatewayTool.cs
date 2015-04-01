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

namespace g200Tool
{
    public partial class FormGatewayTool : Form
    {
        public FormGatewayTool()
        {
            InitializeComponent();
        }

        string datasource = "";
        string excelsource = "";
        private static Hashtable puidmap = new Hashtable();

        private void buttonSelectDbFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "db files (*.db)|*.db";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            dialog.ShowDialog();
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                //修改选择框文字信息
                textBoxDbUrl.Text = dialog.FileName;
                //设置文件路径为数据源
                datasource = dialog.FileName;

            }
        }

        private void buttonSelectExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "xls files (*.xls)|*.xls";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.ShowDialog();
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                //修改选择框文字信息
                textBoxExcelUrl.Text = dialog.FileName;
                //设置文件路径为数据源
                excelsource = dialog.FileName;

            }
        }

        private void buttonImportData_Click(object sender, EventArgs e)
        {
            if (!datasource.Equals(""))
            {
                //建立SQLite连接
                System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection();
                System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                connstr.DataSource = datasource;
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
                for (int i = 0; i < dataSet1.Tables[0].Rows.Count; i++)
                {
                    puidmap.Add(dataSet1.Tables[0].Rows[i][0], dataSet1.Tables[0].Rows[i][1]);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("请选择数据库文件");
                return;
            }
            if (!excelsource.Equals(""))
            {
                if (dataGridViewExcel.DataSource != null && dataGridViewExcel.DataSource != "")
                {
                    dataGridViewExcel.DataSource = "";
                    dataGridViewExcel.Refresh();
                }
                DataTable dt = ExcelInput(excelsource);
                dataGridViewExcel.DataSource = dt;
            }
            else
            {
                MessageBox.Show("请选择模板文件");
                return;
            }

        }








        private static DataTable ExcelInput(string FilePath)
        {
            //第一行一般为标题行。
            DataTable table = new DataTable();

            //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档，然后关闭文件
            FileStream fsRead = File.OpenRead(FilePath);
            NPOI.HSSF.UserModel.HSSFWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook(fsRead);
            fsRead.Close();
            //获取excel的第一个sheet
            NPOI.HSSF.UserModel.HSSFSheet sheet = (NPOI.HSSF.UserModel.HSSFSheet)workbook.GetSheetAt(0);

            //获取Excel的最大行数
            int rowsCount = sheet.PhysicalNumberOfRows;
            //为保证Table布局与Excel一样，这里应该取所有行中的最大列数（需要遍历整个Sheet）。
            //为少一交全Excel遍历，提高性能，我们可以人为把第0行的列数调整至所有行中的最大列数。
            //int colsCount = sheet.GetRow(1).PhysicalNumberOfCells;

            //for (int i = 0; i < colsCount; i++)
            //{
            //    table.Columns.Add(i.ToString());
            //}

            //for (int x = 0; x < rowsCount; x++)
            //{
            //    DataRow dr = table.NewRow();
            //    for (int y = 0; y < colsCount; y++)
            //    {
            //        dr[y] = sheet.GetRow(x).GetCell(y).ToString();
            //    }
            //    table.Rows.Add(dr);
            //}

            //dataGridView标题
            table.Columns.Add("原始值");
            table.Columns.Add("修正值");
            //取模板中第6列,从第二行开始循环取值
            for (int x = 2; x < rowsCount; x++)
            {
                DataRow dr = table.NewRow();
                dr[0] = sheet.GetRow(x).GetCell(6).ToString();
                //第二列填入修改后的值
                dr[1] = getValueFromHashmap(sheet.GetRow(x).GetCell(6).ToString().Substring(0, 32)) + sheet.GetRow(x).GetCell(6).ToString().Substring(32, sheet.GetRow(x).GetCell(6).ToString().Length - 32);
                table.Rows.Add(dr);
            }
            sheet = null;
            workbook = null;
            return table;
        }
        private static string getValueFromHashmap(string key)
        {
            if (puidmap.Contains(key))
            {
                return puidmap[key].ToString();
            }
            else
            {
                return key;
            }
        }

        private void buttonUpdateAndSaveFile_Click(object sender, EventArgs e)
        {
            if (!datasource.Equals("") && !excelsource.Equals(""))
            {
                //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档，然后关闭文件
                FileStream fsRead = File.OpenRead(excelsource);
                NPOI.HSSF.UserModel.HSSFWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook(fsRead);
                fsRead.Close();
                //获取excel的第一个sheet
                NPOI.HSSF.UserModel.HSSFSheet sheet = (NPOI.HSSF.UserModel.HSSFSheet)workbook.GetSheetAt(0);

                //获取Excel的最大行数
                int rowsCount = sheet.PhysicalNumberOfRows;

                for (int x = 2; x < rowsCount; x++)
                {
                    sheet.GetRow(x).GetCell(6).SetCellValue(getValueFromHashmap(sheet.GetRow(x).GetCell(6).ToString().Substring(0, 32)) + sheet.GetRow(x).GetCell(6).ToString().Substring(32, sheet.GetRow(x).GetCell(6).ToString().Length - 32));
                }
                //把编辑过后的工作薄重新保存为excel文件
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Filter = "All files (*.*)|*.*|xls files (*.xls)|*.xls";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                dialog.ShowDialog();

                if (!string.IsNullOrEmpty(dialog.FileName))
                {

                    FileStream fsWrite = File.Create(@dialog.FileName);
                    workbook.Write(fsWrite);
                    fsWrite.Close();
                }
            }
            else
            {
                MessageBox.Show("都不加载下数据就搞？重头来过！");
                datasource = "";
                excelsource = "";
                textBoxExcelUrl.Text = "";
                textBoxDbUrl.Text = "";
            }

        }

    }
}
