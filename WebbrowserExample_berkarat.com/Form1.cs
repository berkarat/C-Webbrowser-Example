using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebbrowserExample_berkarat.com
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// BERK ARAT
        /// berkarat.com 
        /// Web Browser Example
        /// </summary>
        #region Declares

        string gidilen_url = string.Empty;
        #endregion
        public Form1()
        {
            InitializeComponent(); webBrowser1.Navigate("https://www.google.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            forwardbtn.Enabled = false;
            backbtn.Enabled = false;

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {// GO BTN 
            webBrowser1.Navigate(toolStripTextBox1.Text);

        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text.Length > 1)
            {
                webBrowser1.Navigate("https://www.google.com/search?q=" + toolStripTextBox2.Text);
            }
            else
            {
                webBrowser1.Navigate("https://www.google.com");
            }

        }
        private void homebtn_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
        }
        private void forwardbtn_Click(object sender, EventArgs e)
        {

            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }
        private void backbtn_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }

        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            gidilen_url = e.Url.ToString();

            if (webBrowser1.CanGoBack)
            {
                backbtn.Enabled = true;
            }
            else
            {
                backbtn.Enabled = false;

            }
            if (webBrowser1.CanGoForward)
            {
                forwardbtn.Enabled = true;
            }
            else
            {
                forwardbtn.Enabled = false;

            }
        }
        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.Clear();
        }
        private void refreshbtn_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(gidilen_url);

        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // favorite kontrolü aynısı varsa eklemez 

            bool isexist =false ;
            for (int i = 0; i < toolStripDropDownButton1.DropDownItems.Count; i++)
            {
                if (toolStripDropDownButton1.DropDownItems[i].Text == gidilen_url)
                {
                    isexist = true;
                    break;
                }

            }
            if (!isexist)
            {
                toolStripDropDownButton1.DropDownItems.Add(gidilen_url);
            }
        }
    }
}
