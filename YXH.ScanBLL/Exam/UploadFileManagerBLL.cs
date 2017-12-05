using System.Collections.Generic;
using YXH.Enum;
using YXH.Model;
using YXH.Common;
using System.Threading;
using System;
using YXH.Scanner.DALFactory;
using System.IO;

namespace YXH.ScanBLL
{
    /// <summary>
    /// 静态信息处理
    /// </summary>
    public class UploadFileManagerBLL
    {
        BaseFactory _dalFactory = new BaseFactory(ScanGlobalInfo.loginUser.data.uname);
        /// <summary>
        /// 声明实例
        /// </summary>
        private static UploadFileManagerBLL _instance;
        /// <summary>
        /// 数据对象锁
        /// </summary>
        public static object lockDataModifyObj = new object();
        /// <summary>
        /// 操作对象锁
        /// </summary>
        public static object lockCompletedQModifyObj = new object();
        /// <summary>
        /// 目标队列
        /// </summary>
        private Queue<object> _targetQueue;
        /// <summary>
        /// 完成队列
        /// </summary>
        private Queue<object> _completedQueue;
        /// <summary>
        /// 设置同时进行上传的线程数量
        /// </summary>
        private int _threadNum = 3;
        /// <summary>
        /// 当前上传元参数
        /// </summary>
        private UploadMetaParam _curUploadParam;
        /// <summary>
        /// 是否已经上传
        /// </summary>
        private bool _isAbortUpload;

        /// <summary>
        /// 定义静态实例
        /// </summary>
        public static UploadFileManagerBLL Instance
        {
            get
            {
                if (UploadFileManagerBLL._instance == null)
                {
                    UploadFileManagerBLL._instance = new UploadFileManagerBLL();
                }

                return UploadFileManagerBLL._instance;
            }
        }

        /// <summary>
        /// 目标队列
        /// </summary>
        public Queue<object> TargetQueue
        {
            get
            {
                if (this._targetQueue == null)
                {
                    this._targetQueue = new Queue<object>();
                }

                return this._targetQueue;
            }
            set
            {
                lock (UploadFileManagerBLL.lockDataModifyObj)
                {
                    this._targetQueue = value;
                }
            }
        }

        /// <summary>
        /// 线程数量
        /// </summary>
        public int ThreadNum
        {
            get
            {
                return this._threadNum;
            }
            set
            {
                this._threadNum = value;
            }
        }
        /// <summary>
        /// 完成队列
        /// </summary>
        public Queue<object> CompletedQueue
        {
            get
            {
                if (this._completedQueue == null)
                {
                    this._completedQueue = new Queue<object>();
                }

                return this._completedQueue;
            }
            set
            {
                lock (UploadFileManagerBLL.lockCompletedQModifyObj)
                {
                    this._completedQueue = value;
                }
            }
        }
        /// <summary>
        /// 当前上传元参数
        /// </summary>
        public UploadMetaParam CurUploadParam
        {
            get
            {
                if (this._curUploadParam == null)
                {
                    this._curUploadParam = new UploadMetaParam();
                }

                return this._curUploadParam;
            }
            set
            {
                lock (UploadFileManagerBLL.lockDataModifyObj)
                {
                    this._curUploadParam = value;
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="thrnum">线程数，默认3</param>
        public void Initial(int thrnum = 3)
        {
            this.ThreadNum = thrnum;

            this.TargetQueue.Clear();
            this.CompletedQueue.Clear();

            this._isAbortUpload = false;
        }

        /// <summary>
        /// 开始上传
        /// </summary>
        /// <param name="state">状态</param>
        public void RunUpload(object state)
        {
            this._isAbortUpload = false;

            for (int i = 0; i < this.ThreadNum; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Upload), state);
            }
        }

        /// <summary>
        /// 取消所有正在上传的任务
        /// </summary>
        public void CancelAllUploadingTask()
        {
            //lock (UploadFileManagerBLL.lockDataModifyObj)
            //{
            //    this._isAbortUpload = true;
            //    this.CurUploadParam.IsTryAgain = false;
            //    this.CurUploadParam.TimeOut = -1L;
            //    this.TargetQueue.Clear();
            //    this.CompletedQueue.Clear();
            //}
            //List<KsProgressManager> list = null;
            //lock (UploadFileManagerBLL.lockDataModifyObj)
            //{
            //    if (this.CurProgressManaList.Values != null && this.CurProgressManaList.Values.Count > 0)
            //    {
            //        list = this.CurProgressManaList.Values.ToList<KsProgressManager>();
            //    }
            //}
            //if (list != null && list.Count > 0)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        KsProgressManager ksProgressManager = list[i];
            //        if (ksProgressManager.CurProgressStatus == KsProgressState.STARTED || ksProgressManager.CurProgressStatus == KsProgressState.TRANSFERRED)
            //        {
            //            ksProgressManager.Cancel = true;
            //        }
            //    }
            //}
            //throw new Exception("暂未设置服务器");
        }

        /// <summary>
        /// 上传目标文件
        /// </summary>
        /// <param name="filePath">上传路径</param>
        /// <param name="fileName">文件路径</param>
        /// <returns>操作结果</returns>
        public bool UploadMaterialsFile(string filePath, string fileName)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception(string.Format("文件{0}不存在！", filePath));
            }

            bool result = false;
            bool flag = false;
            int num = 1;

            while (!flag && num <= 3)
            {
                try
                {
                    ALiProgressManager.Oss_PutObject(filePath, fileName);

                    flag = true;
                    result = true;
                }
                catch (ThreadAbortException tae)
                {
                    throw tae;
                }
                catch (Exception ex)
                {
                    if (num == 3)
                    {
                        throw new Exception("上传图片中断:" + ex.Message.ToString());
                    }

                    throw ex;
                }

                num++;
            }

            return result;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        private void Upload(object state)
        {
            while (this.TargetQueue.Count > 0)
            {
                UploadMeta uploadMeta = new UploadMeta();
                object obj = null;

                try
                {
                    lock (UploadFileManagerBLL.lockDataModifyObj)
                    {
                        obj = this.TargetQueue.Dequeue();
                    }
                }
                catch (Exception ex)
                {
                    if (obj == null)
                    {
                        continue;
                    }

                    LogHelper.WriteFatalLog(ex.Message, ex);
                }
                if (obj.GetType() == typeof(VolumnDataRow))
                {
                    VolumnDataRow volumnDataRow = (VolumnDataRow)obj;

                    uploadMeta.Id = volumnDataRow.Data.Guid.ToString();

                    uploadMeta.FileList.AddRange(volumnDataRow.Data.ImagePath);

                    if (!ScanRecordHelper.Instance.IsRecordExist(uploadMeta.Id))
                    {
                        continue;
                    }
                }
                else if (this.CurUploadParam.CurType == UploadType.SingleFile)
                {
                    string text = (string)obj;

                    uploadMeta.Id = text;

                    uploadMeta.FileList.Add(text);
                }
                if (this.DoUpload(uploadMeta))
                {
                    lock (UploadFileManagerBLL.lockCompletedQModifyObj)
                    {
                        if (!this._isAbortUpload)
                        {
                            this.CompletedQueue.Enqueue(obj);
                        }

                        continue;
                    }
                }
                if (this._curUploadParam != null && this._curUploadParam.IsTryAgain && !this._isAbortUpload)
                {
                    lock (UploadFileManagerBLL.lockDataModifyObj)
                    {
                        this.TargetQueue.Enqueue(obj);
                    }
                }
            }
        }

        /// <summary>
        /// 执行文件上传
        /// </summary>
        /// <param name="imageFileName">需要上传的文件名称</param>
        /// <returns>返回上传成功的字符编码</returns>
        private bool ExcuteUpload(string imageFileName)
        {
            try
            {
                return ALiProgressManager.PutObjectByScan(PathHelper.LocalVolumneImgDir + imageFileName, imageFileName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 上传扫描文件
        /// </summary>
        /// <param name="curUploadMeta">当前上传源</param>
        /// <returns>操作结果</returns>
        private bool DoUpload(UploadMeta curUploadMeta)
        {

            if (curUploadMeta != null && curUploadMeta.FileList.Count > 0)
            {
                foreach (string current in curUploadMeta.FileList)
                {
                    if (ExcuteUpload(current))
                    {
                        curUploadMeta.CompletedCount++;
                    }
                    else if (FileHelper.ExistsFile(PathHelper.LocalVolumneImgDir + current))    //如果第一次因为网络原因上传失败，尝试上传第二次。第二次结果不予理会，交由提交数据前的检查
                    {
                        ExcuteUpload(current);
                    }
                }

                if (curUploadMeta.CompletedCount == curUploadMeta.FileList.Count)
                {
                    return true;
                }
            }

            return false;
        }
    }
}