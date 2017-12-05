using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace YXH.Main
{
    /// <summary>
    /// 更新说明窗体
    /// </summary>
    public partial class UpdateExplainForm : Form
    {
        /// <summary>
        /// 窗体构造
        /// </summary>
        public UpdateExplainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void UpdateExplainForm_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("UpdateExplain.xml");

            XmlNode xn = xmlDoc.SelectSingleNode("UpdateExplain");

            XmlNodeList xnl = xn.ChildNodes;

            txtContext.Text += xnl.Item(0).InnerText;
        }
    }
}
