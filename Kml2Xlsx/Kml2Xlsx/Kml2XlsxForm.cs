using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dialog.Filter = "kml files (*.kml)|*.kml";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            dialog.ShowDialog();
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                //修改选择框文字信息
                textBoxKmlFileUrl.Text = dialog.FileName;
                //设置文件路径为数据源
                datasource = dialog.FileName;

            }
        }
    }
}
