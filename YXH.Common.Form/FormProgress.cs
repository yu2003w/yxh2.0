using System;
using System.Windows.Forms;

namespace YXH.Common.Form
{
    /// <summary>
    /// 处理进度窗口
    /// </summary>
    public partial class FormProgress : System.Windows.Forms.Form
    {
        /// <summary>
        /// 取消事件头
        /// </summary>
        public EventHandler Cancelhandle;
        /// <summary>
        /// 完成事件头
        /// </summary>
        public EventHandler Completedhandle;
        /// <summary>
        /// 消息体
        /// </summary>
        public string MsgInfo
        {
            get
            {
                return this.lblMsgInfo.Text;
            }
            set
            {
                this.lblMsgInfo.Text = value;
            }
        }
        /// <summary>
        /// 进度最大值
        /// </summary>
        public int ProgressMaxValue
        {
            get
            {
                return this.progressBar.Maximum;
            }
            set
            {
                this.progressBar.Maximum = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public FormProgress()
        {
            InitializeComponent();

            this.progressBar.Maximum = 100;
        }

        /// <summary>
        /// 设置进度条
        /// </summary>
        /// <param name="Progress">进度值</param>
        /// <param name="msg">消息</param>
        public void SetProgress(int Progress, string msg)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new MethodInvoker(delegate
                {
                    this.SetProgress(Progress, msg);
                }));

                return;
            }

            this.MsgInfo = msg;

            if (Progress > this.progressBar.Maximum)
            {
                Progress = this.progressBar.Maximum;
            }

            this.progressBar.Value = Progress;

            if (this.progressBar.Value == this.progressBar.Maximum && this.Completedhandle != null)
            {
                this.Completedhandle(null, null);
            }
        }

        /// <summary>
        /// 窗体鼠标按下事件
        /// </summary>
        private void FormMsg_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(base.Handle, 274, 61458, 0);
        }
    }
}
