using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            // 首次访问下载页面进行解析
            string uri = textBoxWeiboUrl.Text;
            WebClient wc = new WebClient();
            richTextBoxConsole.AppendText("Sending an HTTP GET request to " + uri + "\r\n");
            byte[] page = wc.DownloadData(uri);
            //string content = System.Text.Encoding.UTF8.GetString(page);
            string content = Encoding.UTF8.GetString(page);
            richTextBoxConsole.AppendText("----------第一次返回-----------\r\n" + content + "\r\n");
            // 建立正则表达式进行解析
            string regex = "flashvars=\\\"list=http.*\\\"+";
            Regex re = new Regex(regex);
            MatchCollection matches = re.Matches(content);
            System.Collections.IEnumerator enu = matches.GetEnumerator();
            while (enu.MoveNext() && enu.Current != null)
            {
                Match match = (Match)(enu.Current);
                richTextBoxConsole.AppendText("matchValue:" + match.Value.Replace("flashvars=\"list=", "").Replace("\"", "") + "\r\n");
                WebClient wc2 = new WebClient();
                wc2.Encoding = System.Text.Encoding.UTF8;
                string surl = match.Value.Replace("flashvars=\"list=", "").Replace("\"", "");
                Stream streamResponse = wc2.OpenRead(System.Web.HttpUtility.UrlDecode(surl));
                StreamReader srResponse = new StreamReader(streamResponse);
                string content2 = srResponse.ReadToEnd();
                richTextBoxConsole.AppendText("HTTP response is: " + "\r\n");
                richTextBoxConsole.AppendText(content2 + "\r\n");
            }

        }
    }
}
