using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeiboVideoUrlTool
{
    public partial class WeiboVideoUrlTool : Form
    {
        public WeiboVideoUrlTool()
        {
            InitializeComponent();
        }

        private void buttonGetUrl_Click(object sender, EventArgs e)
        {
            string uri = textBoxWeiboUrl.Text;
            WebClient wc = new WebClient();
            Console.WriteLine("Sending an HTTP GET request to " + uri);
            byte[] bResponse = wc.DownloadData(uri);
            string strResponse = Encoding.ASCII.GetString(bResponse);
            Console.WriteLine("HTTP response is: ");
            Console.WriteLine(strResponse);
        }
    }
}
