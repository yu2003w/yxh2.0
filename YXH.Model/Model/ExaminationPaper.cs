using System;
using System.Collections.Generic;
using YXH.Enum;

namespace YXH.Model
{
    /// <summary>
    /// 考卷
    /// </summary>
    public class ExaminationPaper
    {
        /// <summary>
        /// 确认提交类型是修改
        /// </summary>
        private bool _confirmOmrIsModify;
        /// <summary>
        /// 卷状态
        /// </summary>
        private List<VolumeStatus> _status;
        /// <summary>
        /// 图片是否等待上传
        /// </summary>
        private bool _isWaitToUpload = true;
        /// <summary>
        /// 数据是否已保存
        /// </summary>
        private bool _isWaitSave;
        /// <summary>
        /// 识别项列表
        /// </summary>
        private List<OmrItem> _omrItemList;
        /// <summary>
        /// 错误标记点
        /// </summary>
        private Dictionary<string, List<int>> _ErrorMarkPoints;

        /// <summary>
        /// 图片路径
        /// </summary>
        public string[] ImagePath { get; set; }
        /// <summary>
        /// 批次编号
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 确认提交类型是修改
        /// </summary>
        public bool ConfirmOmrIsModify
        {
            get
            {
                return this._confirmOmrIsModify;
            }
            set
            {
                this._confirmOmrIsModify = value;
            }
        }
        /// <summary>
        /// 卷状态列表
        /// </summary>
        public List<VolumeStatus> Status
        {
            get
            {
                if (this._status == null)
                {
                    this._status = new List<VolumeStatus>();
                }

                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 准考证号
        /// </summary>
        public string Zkzh { get; set; }
        /// <summary>
        /// 原始准考证号
        /// </summary>
        public string Zkzh_origin { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Userid { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public string Classid { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string Classname { get; set; }
        /// <summary>
        /// 识别结果
        /// </summary>
        public string Omr { get; set; }
        /// <summary>
        /// 识别结果数组
        /// </summary>
        public string[] Omrs { get; set; }
        /// <summary>
        /// 识别项列表
        /// </summary>
        public List<OmrItem> OmrItemList
        {
            get
            {
                if (this._omrItemList == null)
                {
                    this._omrItemList = new List<OmrItem>();
                }

                return this._omrItemList;
            }
            set
            {
                this._omrItemList = value;
            }
        }
        /// <summary>
        /// 识别值类型
        /// </summary>
        public OmrValueType OmrItemTye
        {
            get
            {
                if (this.OmrItemList.Exists((OmrItem p) => p.type == OmrValueType.NotConfirm))
                {
                    return OmrValueType.NotConfirm;
                }
                if (this.OmrItemList.Exists((OmrItem p) => p.type == OmrValueType.Empty))
                {
                    return OmrValueType.Empty;
                }

                return OmrValueType.Confirm;
            }
        }
        /// <summary>
        /// 是否等待上传
        /// </summary>
        public bool IsWaitToUpload
        {
            get
            {
                return this._isWaitToUpload;
            }
            set
            {
                this._isWaitToUpload = value;
            }
        }

        /// <summary>
        /// 数据是否已保存
        /// </summary>
        public bool IsWaitSave
        {
            get
            {
                return _isWaitSave;
            }
            set
            {
                _isWaitSave = value;
            }
        }

        /// <summary>
        /// Guid
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// 扫描时间
        /// </summary>
        public DateTime ScanTime { get; set; }
        /// <summary>
        /// 考场
        /// </summary>
        public string Room { get; set; }
        /// <summary>
        /// 扫描ID
        /// </summary>
        public string ScanID { get; set; }
        /// <summary>
        /// 考场占用状态
        /// </summary>
        public RoomMatchStatus MatchStatus { get; set; }
        /// <summary>
        /// 状态字符串
        /// </summary>
        public string StatusString
        {
            get
            {
                string text = string.Empty;

                this.Status.Sort((VolumeStatus first, VolumeStatus next) => first - next);

                for (int i = 0; i < this.Status.Count; i++)
                {
                    if (i < this.Status.Count - 1)
                    {
                        text = text + (int)this.Status[i] + ",";
                    }
                    else
                    {
                        text += (int)this.Status[i];
                    }
                }

                return text;
            }
        }
        /// <summary>
        /// 源卷标状态
        /// </summary>
        public string VolumnStatus_origin { get; set; }
        /// <summary>
        /// 错误标记点列表
        /// </summary>
        public Dictionary<string, List<int>> ErrorMarkPoints
        {
            get
            {
                if (this._ErrorMarkPoints == null)
                {
                    this._ErrorMarkPoints = new Dictionary<string, List<int>>();
                }

                return this._ErrorMarkPoints;
            }
            set
            {
                this._ErrorMarkPoints = value;
            }
        }
    }
}
