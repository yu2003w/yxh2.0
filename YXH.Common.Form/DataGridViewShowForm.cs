using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YXH.Common.Form
{
    /// <summary>
    /// DataGridView显示窗体
    /// </summary>
    public partial class DataGridViewShowForm :System.Windows.Forms. Form
    {
        /// <summary>
        /// 导出事件头
        /// </summary>
        public EventHandler Exportedhandle;

        /// <summary>
        /// 当前列信息
        /// </summary>
        private Dictionary<string, string> _curColInfo;

        /// <summary>
        /// 显示标题
        /// </summary>
        public string Show_Title
        {
            set
            {
                this.lbl_Title.Text = value;
            }
        }
        /// <summary>
        /// 当前列信息
        /// </summary>
        private Dictionary<string, string> CurColInfo
        {
            get
            {
                if (this._curColInfo == null)
                {
                    this._curColInfo = new Dictionary<string, string>();
                }

                return this._curColInfo;
            }
            set
            {
                this._curColInfo = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public DataGridViewShowForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="dataSrc"></param>
        public void SetDataSource(object dataSrc)
        {
            this.dg_DataShow.DataSource = dataSrc;
        }

        /// <summary>
        /// 设置列文本和是否显示
        /// </summary>
        /// <param name="columnInfo">列信息</param>
        public void SetColumnTextAndVisible(Dictionary<string, string> columnInfo)
        {
            if (columnInfo != null && columnInfo.Values.Count > 0)
            {
                foreach (DataGridViewColumn dataGridViewColumn in this.dg_DataShow.Columns)
                {
                    if (!columnInfo.ContainsKey(dataGridViewColumn.Name))
                    {
                        dataGridViewColumn.Visible = false;
                    }
                    else
                    {
                        dataGridViewColumn.HeaderText = columnInfo[dataGridViewColumn.Name];
                    }
                }

                this._curColInfo = columnInfo;
            }
        }

        /// <summary>
        /// 返回按钮点击事件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 导出按钮点击事件
        /// </summary>
        private void btn_export_Click(object sender, EventArgs e)
        {
            if (this.Exportedhandle != null)
            {
                this.Exportedhandle(sender, e);
            }
        }
    }
}
