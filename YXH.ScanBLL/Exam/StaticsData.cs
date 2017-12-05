using System;
using System.Collections.Generic;
using System.Data;
using YXH.Common;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 静态数据处理
    /// </summary>
    public class StaticsData<T>
    {
        /// <summary>
        /// 内容数组
        /// </summary>
        private string[] _properties;
        /// <summary>
        /// 文件夹名称数组
        /// </summary>
        private string[] _fieldNames;
        /// <summary>
        /// 列信息
        /// </summary>
        private Dictionary<string, string> _ColumnInfo;
        /// <summary>
        /// 路径信息列表
        /// </summary>
        private List<T> _srcDataList;
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable _dataSource;
        /// <summary>
        /// 选项卡名称
        /// </summary>
        private string _SheetName = "数据统计";
        /// <summary>
        /// 文件名
        /// </summary>
        public string _FileName = "";
        /// <summary>
        /// 内容数组
        /// </summary>
        public string[] Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new string[0];
                }

                return this._properties;
            }
        }
        /// <summary>
        /// 文件夹名称数组
        /// </summary>
        public string[] FieldNames
        {
            get
            {
                if (this._fieldNames == null)
                {
                    this._fieldNames = new string[0];
                }

                return this._fieldNames;
            }
        }

        /// <summary>
        /// 列信息
        /// </summary>
        public Dictionary<string, string> ColumnInfo
        {
            get
            {
                if (this._ColumnInfo == null)
                {
                    this._ColumnInfo = new Dictionary<string, string>();
                }
                if (this.Properties.Length == this.FieldNames.Length && this.Properties.Length > 0)
                {
                    for (int i = 0; i < this.Properties.Length; i++)
                    {
                        this._ColumnInfo.Add(this.Properties[i], this.FieldNames[i]);
                    }
                }

                return this._ColumnInfo;
            }
            set
            {
                this._ColumnInfo = value;
            }
        }

        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable DataSource
        {
            get
            {
                if (this._dataSource == null)
                {
                    this._dataSource = new DataTable();
                }

                return this._dataSource;
            }
            set
            {
                this._dataSource = value;
            }
        }
        /// <summary>
        /// 选项卡名称
        /// </summary>
        public string SheetName
        {
            get
            {
                return this._SheetName;
            }
            set
            {
                this._SheetName = value;
            }
        }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(this._FileName))
                {
                    this._FileName = this.SheetName;
                }

                return this._FileName;
            }
            set
            {
                this._FileName = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="srcList">路径列表</param>
        /// <param name="properties">内容数组</param>
        /// <param name="fieldNames">文件夹名称数组</param>
        public StaticsData(List<T> srcList, string[] properties, string[] fieldNames)
        {
            this._properties = properties;
            this._fieldNames = fieldNames;
            this._srcDataList = srcList;

            if (this._srcDataList == null)
            {
                this._srcDataList = new List<T>();
            }

            this.SetDataToDataTable();
        }

        /// <summary>
        /// 设置数据到DataTable
        /// </summary>
        /// <returns></returns>
        private int SetDataToDataTable()
        {
            if (this._srcDataList != null && this._srcDataList.Count > 0)
            {
                this.DataSource = DBUtility.FillDataTable<T>(this._srcDataList);
            }

            return this.DataSource.Rows.Count;
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns>操作状态</returns>
        public bool ExportToExcel(string FilePath)
        {
            bool result;

            try
            {
                FileHelper.ExportListToExcel(FilePath, this._SheetName, this._srcDataList, this.FieldNames, this.Properties);

                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}

