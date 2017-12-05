using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YXH.Enum;
using YXH.Model;
using YXH.ScanBLL;

namespace YXH.TemplateForm
{
    /// <summary>
    /// 操作内容面板
    /// </summary>
    public class OperationContext
    {
        /// <summary>
        /// 操作结构
        /// </summary>
        public struct Operation
        {
            public Color ForeColor;
            /// <summary>
            /// 控件的标题
            /// </summary>
            public string Title;
            /// <summary>
            /// 控件绑定的点击事件
            /// </summary>
            public EventHandler Click;
            /// <summary>
            /// 文本框的默认文本
            /// </summary>
            public string DefaultText;
            /// <summary>
            /// 公司名称
            /// </summary>
            public string Name;
            /// <summary>
            /// 控件的文本改变事件
            /// </summary>
            public EventHandler TextChanged;
            /// <summary>
            /// 获得焦点事件
            /// </summary>
            public EventHandler GotFocus;
            /// <summary>
            /// 失去焦点事件
            /// </summary>
            public EventHandler LostFocus;
            /// <summary>
            /// ComboBox的默认选中索引
            /// </summary>
            public int DefaultSelectedIndex;
            /// <summary>
            /// 控件的选中值改变事件
            /// </summary>
            public EventHandler SelectedIndexChanged;
            /// <summary>
            /// 控件的Tip信息
            /// </summary>
            public string tips;
            /// <summary>
            /// 控件的的图片
            /// </summary>
            public Image image;
        }
        /// <summary>
        /// 提示信息
        /// </summary>
        protected string tips;
        /// <summary>
        /// 编辑按钮面板
        /// </summary>
        private FlowLayoutPanel editPan;
        /// <summary>
        /// 下拉框面板
        /// </summary>
        private FlowLayoutPanel cbxPan;
        /// <summary>
        /// 文本框面板
        /// </summary>
        private FlowLayoutPanel txtPan;
        /// <summary>
        /// 展示面板
        /// </summary>
        private FlowLayoutPanel opPan;
        /// <summary>
        /// 内容面板
        /// </summary>
        private FlowLayoutPanel contextPan;
        /// <summary>
        /// 父控件
        /// </summary>
        private Control parent;
        /// <summary>
        /// 可调整的矩形
        /// </summary>
        private ResizableRectangle rect;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OperationType type;

        /// <summary>
        /// 业务处理实例
        /// </summary>
        BaseDisposeBLL _bdBLL = new BaseDisposeBLL();

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="type">操作类型</param>
        /// <param name="parent">父控件</param>
        /// <param name="rect">操作矩形</param>
        /// <param name="tips">提示信息</param>
        public OperationContext(OperationType type, Control parent, ResizableRectangle rect, string tips = "")
        {
            this.type = type;
            this.parent = parent;
            this.tips = tips;
            this.rect = rect;

            this.InitializeComponent();
        }

        /// <summary>
        /// 初始化组件
        /// </summary>
        private void InitializeComponent()
        {
            parent.SuspendLayout();
            opPan = new FlowLayoutPanel();
            editPan = new FlowLayoutPanel();
            txtPan = new FlowLayoutPanel();
            cbxPan = new FlowLayoutPanel();
            contextPan = new FlowLayoutPanel();
            opPan.AutoSize = true;
            opPan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            opPan.BackColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            opPan.FlowDirection = FlowDirection.RightToLeft;
            opPan.Location = new Point(0, 0);
            opPan.Name = "VPan";
            opPan.Size = new Size(1, 1);
            opPan.TabIndex = 0;
            opPan.Visible = true;
            editPan.AutoSize = true;
            editPan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            editPan.BackColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            editPan.Location = new Point(0, 0);
            editPan.Name = "HPan";
            editPan.Size = new Size(1, 1);
            editPan.TabIndex = 0;
            editPan.Visible = true;
            txtPan.AutoSize = true;
            txtPan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            txtPan.BackColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            txtPan.Location = new Point(0, 0);
            txtPan.Name = "TPan";
            txtPan.Size = new Size(1, 1);
            txtPan.TabIndex = 0;
            txtPan.Visible = true;
            cbxPan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cbxPan.BackColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            cbxPan.Location = new Point(0, 0);
            cbxPan.Name = "CPan";
            cbxPan.Size = new Size(1, 1);
            cbxPan.TabIndex = 0;
            cbxPan.Visible = true;
            cbxPan.AutoSize = true;
            contextPan.AutoSize = true;
            contextPan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            contextPan.BackColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            contextPan.FlowDirection = FlowDirection.RightToLeft;
            contextPan.Location = new Point(0, 0);
            contextPan.Margin = new Padding(0);
            contextPan.Padding = new Padding(0);
            contextPan.Name = "context pan";
            contextPan.Size = new Size(0, 0);
            contextPan.TabIndex = 0;
            contextPan.Visible = false;
            contextPan.Controls.Add(opPan);
            contextPan.Controls.Add(editPan);
            contextPan.Controls.Add(txtPan);
            contextPan.Controls.Add(cbxPan);
            parent.Controls.Add(contextPan);
            contextPan.BringToFront();
            parent.ResumeLayout();
        }

        /// <summary>
        /// 生成文本框
        /// </summary>
        /// <param name="item">文本框设置</param>
        public void AddTOperation(OperationContext.Operation item)
        {
            TextBox txtControl = new TextBox();

            txtControl.Location = new Point(0, 0);
            txtControl.BackColor = Color.White;
            txtControl.Margin = new Padding(0, 9, 0, 0);
            txtControl.Name = ((item.Name == null || item.Name.Equals(string.Empty)) ? "T" + txtPan.Controls.Count : item.Name);
            txtControl.Size = new Size(58, 22);
            txtControl.TabIndex = opPan.Controls.Count;
            txtControl.Text = item.DefaultText;
            txtControl.Tag = rect;
            txtControl.ForeColor = item.ForeColor;
            txtControl.GotFocus += item.GotFocus;
            txtControl.LostFocus += item.LostFocus;
            txtControl.TextChanged += item.TextChanged;

            txtPan.Controls.Add(txtControl);
        }

        /// <summary>
        /// 添加题号文本框
        /// </summary>
        /// <param name="items">文本框项数组</param>
        public void AddTOperation(OperationContext.Operation[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                OperationContext.Operation item = items[i];

                this.AddTOperation(item);
            }
        }

        /// <summary>
        /// 添加题类型下拉框
        /// </summary>
        /// <param name="item">添加项</param>
        public void AddCOperation(OperationContext.Operation item)
        {
            ComboBox cbControl = new ComboBox();

            cbControl.Location = new Point(0, 0);
            cbControl.BackColor = Color.White;
            cbControl.Margin = new Padding(0, 9, 0, 0);
            cbControl.Name = "C" + cbxPan.Controls.Count;
            cbControl.Size = new Size(58, 22);
            cbControl.TabIndex = opPan.Controls.Count;
            cbControl.Text = string.Empty;
            cbControl.Tag = rect;
            cbControl.ForeColor = Color.Black;
            cbControl.DropDownStyle = ComboBoxStyle.DropDownList;

            List<KeyValue<int, string>> comboxDataSourceList = new List<KeyValue<int, string>>(){
                new KeyValue<int,string>((int)TopicType.None,"题类型")
            };

            comboxDataSourceList.AddRange(GetQuestionType());
            cbControl.Items.AddRange(comboxDataSourceList.ToArray());
            cbControl.DisplayMember = "Value";
            cbControl.ValueMember = "Key";
            cbControl.SelectedIndex = item.DefaultSelectedIndex;

            cbControl.SelectedIndexChanged += item.SelectedIndexChanged;

            cbxPan.Controls.Add(cbControl);
        }

        /// <summary>
        /// 获取模板使用的题类型
        /// </summary>
        /// <returns>返回获取到的键值列表</returns>
        private List<KeyValue<int, string>> GetQuestionType()
        {
            QuestionTypeResponse qtRes = _bdBLL.GetTemplateQuestionType();
            List<KeyValue<int, string>> result = new List<KeyValue<int, string>>();

            if (qtRes != null && qtRes.Data != null && qtRes.Data.Count > 0)
            {
                foreach (QuestType qt in qtRes.Data)
                {
                    result.Add(new KeyValue<int, string>(qt.Type, qt.Name));
                }
            }

            return result;
        }

        /// <summary>
        /// 添加题类型下拉框
        /// </summary>
        /// <param name="items">项列表</param>
        public void AddCOperation(OperationContext.Operation[] items)
        {
            foreach (Operation item in items)
            {
                AddCOperation(item);
            }
        }


        /// <summary>
        /// 添加高级操作
        /// </summary>
        /// <param name="item">操作对象</param>
        public void AddHOperation(OperationContext.Operation item)
        {
            Button button = new Button();

            button.BackColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(0, 0);
            button.Name = "H" + this.editPan.Controls.Count;
            button.Size = new Size(75, 34);
            button.Margin = new Padding(1, 1, 1, 1);
            button.Padding = new Padding(0);
            button.TabIndex = this.editPan.Controls.Count;
            button.Text = item.Title;
            button.Click += item.Click;
            button.Tag = this.rect;
            button.ForeColor = Color.Black;
            button.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));

            this.editPan.Controls.Add(button);
        }

        /// <summary>
        /// 添加文字操作按钮
        /// </summary>
        /// <param name="item">操作对象</param>
        public void AddVOperation(OperationContext.Operation item)
        {
            Button button = new Button();
            button.BackColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(0, 0);
            button.Name = "V" + this.opPan.Controls.Count;
            button.Size = new Size(40, 40);
            button.TabIndex = this.opPan.Controls.Count;
            button.Text = item.Title;
            button.Click += item.Click;
            button.Tag = this.rect;

            this.opPan.Controls.Add(button);
        }

        /// <summary>
        /// 添加图标操作按钮
        /// </summary>
        /// <param name="item">操作对象</param>
        private void AddOpButton(OperationContext.Operation item)
        {
            Button button = new Button();
            button.BackColor = Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(0, 0);
            button.Margin = new Padding(0, 0, 0, 0);
            button.Padding = new Padding(0);
            button.Name = "V" + this.opPan.Controls.Count;
            button.Size = new Size(38, 38);
            button.TabIndex = this.opPan.Controls.Count;
            button.Image = item.image;
            button.Click += item.Click;
            button.Tag = this.rect;

            this.opPan.Controls.Add(button);
        }

        /// <summary>
        /// 添加水平操作
        /// </summary>
        /// <param name="items">操作对象</param>
        public void AddHOperation(OperationContext.Operation[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                OperationContext.Operation item = items[i];

                this.AddHOperation(item);
            }
        }

        /// <summary>
        /// 移除水平操作
        /// </summary>
        public void RemoveHOperatoin()
        {
            this.contextPan.Controls.Remove(this.editPan);
        }

        /// <summary>
        /// 添加垂直操作
        /// </summary>
        /// <param name="items">操作对象</param>
        public void AddVOperation(OperationContext.Operation[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                OperationContext.Operation item = items[i];

                this.AddOpButton(item);
            }
        }

        /// <summary>
        /// 显示操作面板
        /// </summary>
        /// <param name="r">需要显示的操作面板区域参数</param>
        public void Show(Rectangle r)
        {
            this.Move(r);

            this.contextPan.Visible = true;
        }

        /// <summary>
        /// 移动操作面板矩形
        /// </summary>
        /// <param name="r">需要移动的操作面板矩形参数</param>
        public void Move(Rectangle r)
        {
            Point location = new Point(r.Right - this.contextPan.Width, r.Bottom + 5);

            if (location.X < 0)
            {
                location.X = 0;
            }

            this.contextPan.Location = location;
        }

        /// <summary>
        /// 隐藏内容面板
        /// </summary>
        public void Hide()
        {
            this.contextPan.Visible = false;
        }

        /// <summary>
        /// 隐藏操作面板
        /// </summary>
        public void HideOperation()
        {
            this.opPan.Visible = false;
        }

        /// <summary>
        /// 显示操作面板
        /// </summary>
        public void ShowOperation()
        {
            this.opPan.Visible = true;
        }

        /// <summary>
        /// 只启用编辑按钮
        /// </summary>
        /// <param name="button">按钮对象</param>
        public void EnableEditButtonOnly(Button button)
        {
            int num = this.editPan.Controls.IndexOf(button);

            for (int i = 0; i < this.editPan.Controls.Count; i++)
            {
                if (i != num)
                {
                    this.editPan.Controls[i].Enabled = false;
                }
            }
        }

        /// <summary>
        /// 启用所有按钮
        /// </summary>
        public void EnableEditButtonAll()
        {
            for (int i = 0; i < this.editPan.Controls.Count; i++)
            {
                this.editPan.Controls[i].Enabled = true;
            }
        }
    }
}
