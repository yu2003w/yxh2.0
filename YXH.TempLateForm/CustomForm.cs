using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using YXH.Enum;
using YXH.Model;

namespace YXH.TemplateForm
{
    public partial class CustomForm : Form
    {
        /// <summary>
        /// 开始点
        /// </summary>
        Point _startPoint = new Point();
        /// <summary>
        /// 结束点
        /// </summary>
        Point _endPoint = new Point();
        /// <summary>
        /// 开始绘制
        /// </summary>
        bool _drawingStart = false;
        /// <summary>
        /// 鼠标是按下
        /// </summary>
        bool _mouseIsDown = false;
        /// <summary>
        /// 试题框选区域参数
        /// </summary>
        public TestletsArgumentModel _tam = new TestletsArgumentModel();
        /// <summary>
        /// 已框选试题区域的参数
        /// </summary>
        List<string> _testletsArgument = new List<string>();
        /// <summary>
        /// 父窗体
        /// </summary>
        private ExamImageForm _parentForm;
        /// <summary>
        /// 父窗体操作
        /// </summary>
        public ExamImageForm ParentForm
        {
            get { return _parentForm; }
            set { _parentForm = value; }
        }
        /// <summary>
        /// 当前操作类型（考号或客观题）
        /// </summary>
        private OperationType _opType;
        /// <summary>
        /// 当前图片缩放比例
        /// </summary>
        private float _zoomRatio;

        #region 绘制参数

        private bool _isShowLine = false;

        #endregion

        #region 单双击控制

        private bool _isFirstClick = true;
                private int _milliseconds = 0;
        private Timer _doubleClickTimer;
        private Rectangle _doubleRec;

        #endregion

        /// <summary>
        /// 带初始化图形的构造函数
        /// </summary>
        /// <param name="answerRegion">需要展示的图形</param>
        public CustomForm(Bitmap answerRegion, OperationType type, float zoomRatio)
        {
            InitializeComponent();

            pictureBox.Image = answerRegion;
            _zoomRatio = zoomRatio;
            _opType = type;
            _doubleClickTimer = new Timer();
            _doubleClickTimer.Interval = 100;
            _doubleClickTimer.Tick += new EventHandler(DoubleClickTimer_Tick);
        }

        public void SetZoomRatio(float zoomRatio)
        {
            RecalculationBlobs(zoomRatio / _zoomRatio);

            _zoomRatio = zoomRatio;

            RePaintAll();
        }

        /// <summary>
        /// 重算斑点位置
        /// </summary>
        private void RecalculationBlobs(float zoomRatio)
        {
            if (_testletsArgument == null || _testletsArgument.Count < 1)
            {
                return;
            }

            for (int i = 0; i < _testletsArgument.Count; i++)
            {
                string[] blobAttribute = _testletsArgument[i].Split(',');

                blobAttribute[0] = (float.Parse(blobAttribute[0]) * zoomRatio).ToString();
                blobAttribute[1] = (float.Parse(blobAttribute[1]) * zoomRatio).ToString();
                blobAttribute[5] = (float.Parse(blobAttribute[5]) * zoomRatio).ToString();
                blobAttribute[6] = (float.Parse(blobAttribute[6]) * zoomRatio).ToString();
                blobAttribute[7] = (float.Parse(blobAttribute[7]) * zoomRatio).ToString();
                blobAttribute[8] = (float.Parse(blobAttribute[8]) * zoomRatio).ToString();

                string newBlobAttStr = string.Empty;

                foreach (string item in blobAttribute)
                {
                    newBlobAttStr += string.Format("{0},", item);
                }

                _testletsArgument[i] = newBlobAttStr.TrimEnd(',');
            }
        }

        /// <summary>
        /// 完成生成当前生成区域
        /// </summary>
        public void CompleteCustomBlobs()
        {
            StringBuilder sbBlobInfo = new StringBuilder();
            StringBuilder sbNumberInfo = new StringBuilder();

            foreach (string areaItems in _testletsArgument)
            {
                string[] blobAttribute = areaItems.Split(',');
                int rowNumber = int.Parse(blobAttribute[2]),
                    colNumber = int.Parse(blobAttribute[3]),
                    penWidth = int.Parse(blobAttribute[4]),
                    startQid = 0;

                float startPointX = float.Parse(blobAttribute[0]),
                    startPointY = float.Parse(blobAttribute[1]),
                    blobWidth = float.Parse(blobAttribute[5]),
                    blobHSpace = float.Parse(blobAttribute[6]),
                    blobHeight = float.Parse(blobAttribute[7]),
                    blobVspace = float.Parse(blobAttribute[8]),
                    drawPointX = startPointX;

                if (blobAttribute.Length > 9)
                {
                    startQid = int.Parse(blobAttribute[9]);
                }

                for (int i = 0; i < rowNumber; i++)
                {
                    if (i > 0)
                    {
                        drawPointX = startPointX + blobWidth * i + blobHSpace * i;
                    }

                    float drawPointY = startPointY;

                    for (int j = 0; j < colNumber; j++)
                    {
                        if (j > 0)
                        {
                            drawPointY = startPointY + blobHeight * j + blobVspace * j;
                        }
                        if (_opType == OperationType.OBJECTIVE_OMR && i == 0)
                        {
                            int numX = 0;

                            switch (startQid.ToString().Length)
                            {
                                case 1:
                                    numX = ((int)((drawPointX - 25f * _zoomRatio) / _zoomRatio));

                                    break;
                                case 2:
                                    numX = ((int)((drawPointX - 40f * _zoomRatio) / _zoomRatio));

                                    break;
                                case 3:
                                    numX = ((int)((drawPointX - 50f * _zoomRatio) / _zoomRatio));

                                    break;
                                default:
                                    numX = ((int)((drawPointX - 60f * _zoomRatio) / _zoomRatio));

                                    break;
                            }

                            sbNumberInfo.AppendFormat("{0},{1},{2};", startQid, numX, ((int)((float)drawPointY / _zoomRatio)));

                            startQid++;
                        }

                        sbBlobInfo.AppendFormat("{0},{1},{2},{3};", (int)((float)drawPointX / _zoomRatio), (int)((float)drawPointY / _zoomRatio), (int)((float)blobWidth / _zoomRatio), (int)((float)blobHeight / _zoomRatio));
                    }
                }
            }

            ParentForm._cusBlobInfoStr = sbBlobInfo.ToString();

            if (sbNumberInfo.Length > 0)
            {
                ParentForm._cusNumInfoStr = sbNumberInfo.ToString();
            }
        }

        /// <summary>
        /// 双击事件的标记事件
        /// </summary>
        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            _milliseconds += 100;

            if (_milliseconds >= SystemInformation.DoubleClickTime)
            {
                _doubleClickTimer.Stop();
                                _isFirstClick = true;
                _milliseconds = 0;
            }
        }

        /// <summary>
        /// 鼠标在pictureBox 上的移动事件
        /// </summary>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
            _isShowLine = true;

            if (_isFirstClick)
            {
                PictureBox_Paint(new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// 鼠标在Picture box 上的按下事件
        /// </summary>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_isFirstClick)
            {
                _doubleRec = new Rectangle(e.X - SystemInformation.DoubleClickSize.Width / 2,
                    e.Y - SystemInformation.DoubleClickSize.Height / 2,
                    SystemInformation.DoubleClickSize.Width,
                    SystemInformation.DoubleClickSize.Height);
                _isFirstClick = false;
                _doubleClickTimer.Start();
            }

            this.pictureBox.Focus();

            _startPoint.X = e.X;
            _startPoint.Y = e.Y;

            if (e.Button == MouseButtons.Left)
            {
                _mouseIsDown = true;
            }
        }

        /// <summary>
        /// 计算涂点属性
        /// </summary>
        /// <returns>返回对应属性列表</returns>
        private int[] ComputeBlobAttribute(TestletsArgumentModel tam)
        {
            int regionWidth = _endPoint.X - _startPoint.X,
                regionHeight = _endPoint.Y - (_opType == OperationType.SCHOOLNUMBER_OMR ? (int)((float)pictureBox.Size.Height / 11f) : _startPoint.Y);

            float blobWidth = (float)regionWidth / (float)tam.OptionsNumber,
                blobHeight = (float)regionHeight / (float)tam.ItemNumber,
                blobHSpace = 0f, //水平间距
                blobVspace = 0f; //垂直间距

            blobWidth = blobWidth * 4.0f / 5.0f;
            blobHSpace = blobWidth / 3.0f;
            blobHeight = blobHeight * 5.0f / 7.0f;
            blobVspace = blobHeight / 2.4f;

            return new int[] { (int)Math.Floor(blobWidth), (int)Math.Floor(blobHSpace), (int)Math.Floor(blobHeight), (int)Math.Floor(blobVspace) };
        }

        /// <summary>
        /// 区域设置时调用的方法
        /// </summary>
        public void Refresh_SettingArea(TestletsArgumentModel tam)
        {
            _tam = tam;
        }

        /// <summary>
        /// 鼠标移动时重绘界面内的线条
        /// </summary>
        /// <param name="point">参考线停止的坐标点</param>
        private void PictureBox_Paint(Point point)
        {
            Graphics g = pictureBox.CreateGraphics();

            pictureBox.Invalidate();
            pictureBox.Update();

            if (_mouseIsDown)
            {
                g.DrawLine(new Pen(Color.Gray, 2), new Point(0, _startPoint.Y), new Point(pictureBox.Width, _startPoint.Y));
                g.DrawLine(new Pen(Color.Gray, 2), new Point(_startPoint.X, 0), new Point(_startPoint.X, pictureBox.Height));

                _drawingStart = true;

                Pen pp = new Pen(Color.Blue, 1);

                pp.DashStyle = DashStyle.Custom;
                pp.DashPattern = new float[] { 3f, 3f };

                g.DrawRectangle(pp, Math.Min(_startPoint.X, point.X), Math.Min(_startPoint.Y, point.Y), Math.Abs(point.X - _startPoint.X), Math.Abs(point.Y - _startPoint.Y));
                g.Dispose();
                Refresh();
            }
            else
            {
                if (_isShowLine)
                {
                    g.DrawLine(new Pen(Color.Gray, 2), new Point(0, point.Y), new Point(pictureBox.Width, point.Y));
                    g.DrawLine(new Pen(Color.Gray, 2), new Point(point.X, 0), new Point(point.X, pictureBox.Height));
                }
            }
            if (_testletsArgument != null && _testletsArgument.Count > 0)
            {
                RePaintAll();
            }
        }

        /// <summary>
        /// 重绘所有斑点
        /// </summary>
        public void RePaintAll()
        {
            foreach (string item in _testletsArgument)
            {
                SelectedBlob(item);
            }
        }

        /// <summary>
        /// 框选斑点
        /// </summary>
        /// <param name="testLetsArgument">斑点的坐标属性</param>
        private void SelectedBlob(string testLetsArgument)
        {
            string[] blobAttribute = testLetsArgument.Split(',');
            float startPointX = float.Parse(blobAttribute[0]),
                startPointY = float.Parse(blobAttribute[1]),
                blobWidth = float.Parse(blobAttribute[5]),
                blobHSpace = float.Parse(blobAttribute[6]),
                blobHeight = float.Parse(blobAttribute[7]),
                blobVspace = float.Parse(blobAttribute[8]),
                drawPointX = startPointX;
            int rowNumber = int.Parse(blobAttribute[2]),
                colNumber = int.Parse(blobAttribute[3]),
                penWidth = int.Parse(blobAttribute[4]);

            for (int i = 0; i < rowNumber; i++)
            {
                if (i > 0)
                {
                    drawPointX = startPointX + blobWidth * i + blobHSpace * i;
                }

                float drawPointY = startPointY;

                for (int j = 0; j < colNumber; j++)
                {
                    if (j > 0)
                    {
                        drawPointY = startPointY + blobHeight * j + blobVspace * j;
                    }

                    Graphics g = pictureBox.CreateGraphics();

                    //g.DrawRectangle(new Pen(Color.Red, penWidth), (int)((float)drawPointX * currZoomRatio), (int)((float)drawPointY * currZoomRatio), (int)((float)blobWidth * currZoomRatio), (int)((float)blobHeight * currZoomRatio));
                    g.DrawRectangle(new Pen(Color.Red, penWidth), (int)((float)drawPointX), (int)((float)drawPointY), (int)((float)blobWidth), (int)((float)blobHeight));
                    g.Dispose();
                }
            }
        }

        /// <summary>
        /// 刷新属性设置
        /// </summary>
        /// <param name="blobAttribute">斑点参数列表</param>
        /// <param name="index">执行框选事件</param>
        public void Refresh_Adjust(List<string> blobAttribute, int index)
        {
            _testletsArgument = blobAttribute;

            Refresh();
            RePaintAll();
        }

        /// <summary>
        /// 图片框双击事件
        /// </summary>
        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;

            if (mea.Button == MouseButtons.Left)
            {
                if (_testletsArgument != null && _testletsArgument.Count > 0)
                {
                    string copyStr = _testletsArgument[_testletsArgument.Count - 1];
                    string[] copyStrArray = copyStr.Split(',');
                    string newStr = e.X.ToString() + "," + e.Y.ToString();

                    for (int i = 0; i < copyStrArray.Length; i++)
                    {
                        if (i > 1)
                        {
                            newStr += "," + copyStrArray[i];
                        }
                    }

                    string lastStr = _testletsArgument[_testletsArgument.Count - 1],
                        lastQid = lastStr.Substring(lastStr.LastIndexOf(',') + 1),
                        groupStartQid = (int.Parse(lastQid) + 1).ToString(),
                        groupEndQid = (int.Parse(groupStartQid) + _tam.ItemNumber - 1).ToString();

                    newStr = newStr.Substring(0, newStr.LastIndexOf(','));
                    newStr = newStr.Substring(0, newStr.LastIndexOf(','));
                    newStr += "," + groupStartQid + "," + groupEndQid;

                    _testletsArgument.Add(newStr);

                    RePaintAll();

                    _mouseIsDown = false;
                }
                else
                {
                    MessageBox.Show("请先框选参考区域", "提示", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// 画框点击事件
        /// </summary>
        private void pictureBox_Click(object sender, EventArgs ea)
        {
            if (_isFirstClick)
            {
                Point pe = Control.MousePosition;
                MouseEventArgs e = (MouseEventArgs)ea;
                float currRaatio = _zoomRatio;

                _endPoint.X = e.X;
                _endPoint.Y = e.Y;

                Pen pp = new Pen(Color.Blue, 1);
                Graphics g = pictureBox.CreateGraphics();

                if (_drawingStart && _mouseIsDown)
                {
                    g.DrawRectangle(pp, Math.Min(_startPoint.X, _endPoint.X), Math.Min(_startPoint.Y, _endPoint.Y), Math.Abs(_endPoint.X - _startPoint.X), Math.Abs(_endPoint.Y - _startPoint.Y));
                    g.Dispose();
                }
                if (e.Button == MouseButtons.Left)
                {
                    _mouseIsDown = false;
                }

                _drawingStart = false;

                string maxStartQid = string.Empty;

                foreach (string itemStr in _testletsArgument)
                {
                    string[] itemParArray = itemStr.Split(',');

                    if (maxStartQid.Equals(string.Empty))
                    {
                        int curStartQid = 0;

                        if (int.TryParse(itemParArray[itemParArray.Length - 1], out curStartQid))
                        {
                            maxStartQid = (curStartQid + 1).ToString();
                        }
                        else
                        {
                            MessageBox.Show("无效的开始题号");

                            return;
                        }
                    }
                    else
                    {
                        int curStartQid = 0,
                            maxQid = 0;

                        if (int.TryParse(itemParArray[itemParArray.Length - 1], out curStartQid))
                        {
                            curStartQid++;

                            if (int.TryParse(maxStartQid, out maxQid))
                            {
                                if (curStartQid > maxQid)
                                {
                                    maxStartQid = curStartQid.ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("无效的开始题号");
                            }
                        }
                        else
                        {
                            MessageBox.Show("无效的开始题号");
                        }
                    }
                }

                if (maxStartQid.Equals(string.Empty))
                {
                    maxStartQid = "1";
                }

                SettingTestletsArgument sta = new SettingTestletsArgument(maxStartQid, _opType);

                sta.ParentForm = this;

                if (sta.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                int startPointY = 0;

                if (_opType == OperationType.SCHOOLNUMBER_OMR)
                {
                    startPointY = (int)((float)pictureBox.Size.Height / 11f);
                }
                else
                {
                    startPointY = _startPoint.Y;
                }

                string blobAttribute = string.Join(",", ComputeBlobAttribute(_tam)),
                    testletsArgumentStr = _startPoint.X.ToString() + "," + startPointY.ToString() + "," + _tam.OptionsNumber.ToString() + "," +
                    _tam.ItemNumber.ToString() + "," + "1" + "," + blobAttribute;

                testletsArgumentStr += "," + _tam.StartQID.ToString() + "," + _tam.EndQID.ToString();

                _testletsArgument.Add(testletsArgumentStr);
            }
        }

        /// <summary>
        /// 打开调整面板
        /// </summary>
        public void OpenAdjust()
        {
            if (_testletsArgument == null || _testletsArgument.Count < 1)
            {
                MessageBox.Show("请先框选客观题块再进行调整");

                return;
            }

            SettintBlobArguments sba = new SettintBlobArguments(_testletsArgument, _testletsArgument.Count - 1, _opType);

            sba.ParentForm = this;
            sba.BlobAttributeList = _testletsArgument;

            sba.ShowDialog();
        }

        /// <summary>
        /// 画框的鼠标离开事件
        /// </summary>
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            _isShowLine = false;
            Cursor.Current = Cursors.Arrow;

            PictureBox_Paint(new Point());
        }
    }
}
