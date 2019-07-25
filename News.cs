using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
    public partial class News : Form
    {
        protected string username = "";
        protected Color colors;
        public News()
        {
            InitializeComponent();
        }
       

        private void btnVisit_Click(object sender, EventArgs e)
        {
            string strUrl = cbUrl.Text;
            if (!cbUrl.AutoCompleteCustomSource.Contains(strUrl))
                cbUrl.AutoCompleteCustomSource.Add(strUrl);
            if (strUrl == "")
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "文本文件|*.txt|网页|*.htm*";
                var s = openFileDialog1.ShowDialog();
                if (s == System.Windows.Forms.DialogResult.OK)
                {
                    strUrl = openFileDialog1.FileName;
                }
            }
            wbActivityBrowser.Navigate(strUrl);
        }
        private void cbUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVisit_Click(null, null);
        }

        private void btnGoPrv_Click(object sender, EventArgs e)
        {
            wbActivityBrowser.GoBack();
        }

        private void btnGoNext_Click(object sender, EventArgs e)
        {
            wbActivityBrowser.GoForward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            wbActivityBrowser.Refresh();
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            TabPage tpPage = tabControl1.SelectedTab;
            tpPage.Text = wbActivityBrowser.DocumentTitle;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (wbActivityBrowser.Url != null)
                cbUrl.Text = wbActivityBrowser.Url.ToString();
            switch (wbActivityBrowser.ReadyState)
            {
                case WebBrowserReadyState.Complete:
                    tsslStatus.Text = "完成";
                    break;
                case WebBrowserReadyState.Interactive:
                    tsslStatus.Text = "部分完成";
                    break;
                case WebBrowserReadyState.Loaded:
                    tsslStatus.Text = "已初始化";
                    break;
                case WebBrowserReadyState.Loading:
                    tsslStatus.Text = "正在加载";
                    break;
                case WebBrowserReadyState.Uninitialized:
                    tsslStatus.Text = "未加载";
                    break;
            }
        }
        
        private void News_Load(object sender, EventArgs e)
        {
            StreamReader dr = new StreamReader("config.text");
            string strUrl = "";
            while ((strUrl = dr.ReadLine()) != null)
            {
                btnNew_Click(null, null);
                cbUrl.Text = strUrl;
                tabControl1_SelectedIndexChanged(null, null);
                btnVisit_Click(null, null);
                webBrowser1_ProgressChanged(null, null);
            }
            dr.Close();
        }
        
        private void News_Resize(object sender, EventArgs e)
        {
            cbUrl.Width = this.Width - 480;
        }

        WebBrowser wbActivityBrowser;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tpPage = tabControl1.SelectedTab;
            if (tpPage != null)
                wbActivityBrowser = (WebBrowser)tpPage.Controls[0];

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            TabPage tbPage = new TabPage();
            tbPage.Text = "新建页面";
            WebBrowser wbNewWebBrz = new WebBrowser();
            wbNewWebBrz.Dock = DockStyle.Fill;
            wbNewWebBrz.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            wbNewWebBrz.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
            tbPage.Controls.Add(wbNewWebBrz);
            tabControl1.TabPages.Add(tbPage);
            tabControl1.SelectedTab = tbPage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TabPage tpPage = tabControl1.SelectedTab;
            if (tpPage != null)
                tabControl1.TabPages.Remove(tpPage);
            if (tabControl1.TabPages.Count == 0)
                this.Close();
        }

        private void cbUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
                btnVisit_Click(null, null);
        }
       

    }
}
