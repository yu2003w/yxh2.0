using System;
using System.Drawing;
using System.Windows.Forms;
using YXH.Common;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 前置工具条
    /// </summary>
    public sealed class OutlookBar : Panel
    {
        /// <summary>
        /// 按钮高度
        /// </summary>
        private int buttonHeight;
        /// <summary>
        /// 选中按钮面板索引
        /// </summary>
        public int selectedBandPanelIndex;
        /// <summary>
        /// 强调条索引
        /// </summary>
        private int hlBandIndex;
        /// <summary>
        /// 强调内容索引
        /// </summary>
        private int hlContentIndex;
        /// <summary>
        /// 按钮高度
        /// </summary>
        public int ButtonHeight
        {
            get
            {
                return this.buttonHeight;
            }
            set
            {
                this.buttonHeight = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public OutlookBar()
        {
            this.buttonHeight = 40;
            this.selectedBandPanelIndex = 0;
            base.BorderStyle = BorderStyle.None;
            this.BackColor = Scheme.UnifiedBackColor;
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        public void Initialize()
        {
            base.Parent.SizeChanged += new EventHandler(this.SizeChangedEvent);
        }

        /// <summary>
        /// 添加条
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="content">内容面板</param>
        /// <param name="onClickEvent">点击事件头</param>
        public void AddBand(string caption, ContentPanel content, EventHandler onClickEvent)
        {
            if (content != null)
            {
                content.outlookBar = this;
            }

            int count = base.Controls.Count;
            BandTagInfo bti = new BandTagInfo(this, count);
            BandPanel bandPanel = new BandPanel(caption, content, bti, onClickEvent);

            base.Controls.Add(bandPanel);
            this.RecalcLayout(bandPanel, count);
        }

        /// <summary>
        /// 添加条
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="content">内容面板</param>
        /// <param name="onClickEvent">点击事件头</param>
        /// <param name="imageNormal">标准图片</param>
        /// <param name="imageHighlight">强调图片</param>
        public void AddBand(string caption, ContentPanel content, EventHandler onClickEvent, Image imageNormal, Image imageHighlight)
        {
            if (content != null)
            {
                content.outlookBar = this;
            }

            int count = base.Controls.Count;
            BandTagInfo bti = new BandTagInfo(this, count);
            BandPanel bandPanel = new BandPanel(caption, content, bti, onClickEvent, imageNormal, imageHighlight);

            base.Controls.Add(bandPanel);
            this.RecalcLayout(bandPanel, count);
        }

        /// <summary>
        /// 设置选中条
        /// </summary>
        /// <param name="index">索引</param>
        public void SetSelectedBand(int index)
        {
            this.GetSelectedBandPanel().selected = false;

            this.GetSelectedBandPanel().Invalidate();

            this.selectedBandPanelIndex = index;
            this.GetSelectedBandPanel().selected = true;

            this.GetSelectedBandPanel().Invalidate();
            this.RedrawBands();
        }

        /// <summary>
        /// 强调选择
        /// </summary>
        public void HighlightSelection()
        {
            this.HighlightSelection(this.hlBandIndex, this.hlContentIndex);
        }

        /// <summary>
        /// 强调选择
        /// </summary>
        /// <param name="bandIndex">条索引</param>
        /// <param name="contentIndex">内容索引</param>
        public void HighlightSelection(int bandIndex, int contentIndex)
        {
            this.hlBandIndex = bandIndex;
            this.hlContentIndex = contentIndex;

            for (int i = 0; i < base.Controls.Count; i++)
            {
                BandPanel bandPanel = base.Controls[i] as BandPanel;

                bandPanel.selected = (i == this.selectedBandPanelIndex);
                bandPanel.IsHighlight = (i == this.hlBandIndex);

                BandButton bandButton = bandPanel.Controls[0] as BandButton;

                bandButton.BackColor = Scheme.CommonNormalColor;
                bandButton.ForeColor = (bandPanel.IsHighlight ? Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27))))) : Color.Black);

                bandButton.Invalidate();
                bandPanel.Controls[0].Invalidate();

                if (bandPanel.HasContentPanel)
                {
                    ContentPanel contentPanel = bandPanel.Controls[1] as ContentPanel;

                    if (i == this.hlBandIndex)
                    {
                        contentPanel.HighlightSelection(this.hlContentIndex);
                    }
                    else
                    {
                        contentPanel.ResetSelection();
                    }
                }
            }
        }

        /// <summary>
        /// 重置强调
        /// </summary>
        public void ResetHighlight()
        {
            this.hlContentIndex = -1;

            for (int i = 0; i < base.Controls.Count; i++)
            {
                BandPanel bandPanel = base.Controls[i] as BandPanel;

                if (bandPanel.HasContentPanel)
                {
                    ContentPanel contentPanel = bandPanel.Controls[1] as ContentPanel;

                    contentPanel.ResetSelection();
                }
            }
        }

        /// <summary>
        /// 获取选中条面板
        /// </summary>
        /// <returns></returns>
        public BandPanel GetSelectedBandPanel()
        {
            return base.Controls[this.selectedBandPanelIndex] as BandPanel;
        }

        /// <summary>
        /// 重绘指定的步骤面板
        /// </summary>
        private void RedrawBands()
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                BandPanel bandPanel = base.Controls[i] as BandPanel;

                this.RecalcLayout(bandPanel, i);
            }
        }

        /// <summary>
        /// 重新计算布局
        /// </summary>
        /// <param name="bandPanel">条面板</param>
        /// <param name="index">索引</param>
        private void RecalcLayout(BandPanel bandPanel, int index)
        {
            int contentHeight = this.GetSelectedBandPanel().GetContentHeight(),
                num = this.buttonHeight * index;

            if (index > this.selectedBandPanelIndex)
            {
                num += contentHeight;
            }

            int num2 = this.buttonHeight;

            if (this.selectedBandPanelIndex == index)
            {
                num2 += contentHeight;
            }

            bandPanel.Location = new Point(0, num);
            bandPanel.Size = new Size(base.ClientRectangle.Width, num2);
            bandPanel.Controls[0].Location = new Point(0, 0);
            bandPanel.Controls[0].Size = new Size(base.ClientRectangle.Width, this.buttonHeight);

            if (bandPanel.HasContentPanel)
            {
                bandPanel.Controls[1].Location = new Point(0, this.buttonHeight);

                int height = bandPanel.Controls[1].Size.Height;

                bandPanel.Controls[1].Size = new Size(base.ClientRectangle.Width, height);
            }
        }

        /// <summary>
        /// 大小改变事件
        /// </summary>
        private void SizeChangedEvent(object sender, EventArgs e)
        {
            base.Size = new Size(base.Size.Width, ((Control)sender).ClientRectangle.Size.Height);

            this.RedrawBands();
        }
    }
}
