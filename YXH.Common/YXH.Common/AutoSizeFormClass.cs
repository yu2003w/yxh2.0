using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YXH.Common
{
    /// <summary>
    /// 自动大小形式类
    /// </summary>
    public class AutoSizeFormClass
    {
        /// <summary>
        /// 控制矩形结构
        /// </summary>
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }
        /// <summary>
        /// 旧的控制
        /// </summary>
        public List<AutoSizeFormClass.controlRect> oldCtrl = new List<AutoSizeFormClass.controlRect>();
        /// <summary>
        /// 控制编号
        /// </summary>
        private int ctrlNo;

        /// <summary>
        /// 控制初始化大小
        /// </summary>
        /// <param name="mForm">需要控制的控件/窗体对象</param>
        public void controllInitializeSize(Control mForm)
        {
            AutoSizeFormClass.controlRect item;

            item.Left = mForm.Left;
            item.Top = mForm.Top;
            item.Width = mForm.Width;
            item.Height = mForm.Height;

            this.oldCtrl.Add(item);

            this.AddControl(mForm);
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="ctl">控件对象</param>
        private void AddControl(Control ctl)
        {
            foreach (Control control in ctl.Controls)
            {
                AutoSizeFormClass.controlRect item;

                item.Left = control.Left;
                item.Top = control.Top;
                item.Width = control.Width;
                item.Height = control.Height;

                this.oldCtrl.Add(item);

                if (control.Controls.Count > 0)
                {
                    this.AddControl(control);
                }
            }
        }

        /// <summary>
        /// 控件自适应大小
        /// </summary>
        /// <param name="mForm">需要控制的控件对象</param>
        public void controlAutoSize(Control mForm)
        {
            if (this.ctrlNo == 0)
            {
                AutoSizeFormClass.controlRect item;

                item.Left = 0;
                item.Top = 0;
                item.Width = mForm.PreferredSize.Width;
                item.Height = mForm.PreferredSize.Height;

                this.oldCtrl.Add(item);

                this.AddControl(mForm);
            }

            float wScale = (float)mForm.Width / (float)this.oldCtrl[0].Width;
            float hScale = (float)mForm.Height / (float)this.oldCtrl[0].Height;

            this.ctrlNo = 1;

            this.AutoScaleControl(mForm, wScale, hScale);
        }

        /// <summary>
        /// 自动比例控制
        /// </summary>
        /// <param name="ctl">需要控制的控件对象</param>
        /// <param name="wScale">宽度比例值</param>
        /// <param name="hScale">高度比例值</param>
        private void AutoScaleControl(Control ctl, float wScale, float hScale)
        {
            foreach (Control control in ctl.Controls)
            {
                if (control.Name.Equals("panContent"))
                {
                    Console.WriteLine(control.Name);
                }

                int left = this.oldCtrl[this.ctrlNo].Left;
                int top = this.oldCtrl[this.ctrlNo].Top;
                int width = this.oldCtrl[this.ctrlNo].Width;
                int height = this.oldCtrl[this.ctrlNo].Height;

                control.Left = (int)((float)left * wScale);
                control.Top = (int)((float)top * hScale);
                control.Width = (int)((float)width * wScale);
                control.Height = (int)((float)height * hScale);

                this.ctrlNo++;

                if (control.Controls.Count > 0)
                {
                    this.AutoScaleControl(control, wScale, hScale);
                }
            }
        }
    }
}
