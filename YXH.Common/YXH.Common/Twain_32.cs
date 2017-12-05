using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YXH.Twain.Structure;
using YXH.Twain.Structure.Enum;

namespace YXH.Common
{
    /// <summary>
    /// 扫描仪中介驱动处理
    /// </summary>
    public class Twain_32
    {
        /// <summary>
        /// 初始化中间程序
        /// </summary>
        /// <param name="hMainWnd">主要窗口句柄</param>
        /// <param name="TwainReportLevel">驱动报表等级</param>
        /// <returns>初始化结果</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IntialTwain(IntPtr hMainWnd, int TwainReportLevel);

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="msg">消息体</param>
        /// <returns>处理状态</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ProcessMessage(ref Message msg);

        /// <summary>
        /// 捕获UI
        /// </summary>
        /// <param name="ShowUI">界面显示状态</param>
        /// <returns>捕获状态</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Acqurie(bool ShowUI);

        /// <summary>
        /// 安装
        /// </summary>
        /// <returns>安装状态</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Setup();

        /// <summary>
        /// 选择扫描仪来源
        /// </summary>
        /// <returns>选中状态</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SelectSource();

        /// <summary>
        /// 设置参考参数
        /// </summary>
        /// <param name="cap">参考量</param>
        /// <param name="value">参考值</param>
        /// <param name="valueType">值类型</param>
        /// <returns>设置状态</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetCapParam(ushort cap, uint value, ushort valueType);

        /// <summary>
        /// 设置转发触发
        /// </summary>
        /// <param name="pro">转移委托句柄</param>
        /// <returns>转发状态</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetOnTranfer(FOnTransfer pro);

        /// <summary>
        /// 设置停止
        /// </summary>
        /// <param name="pro">转移结束委托</param>
        /// <returns>停止状态</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetOnEnd(FOnEndTransfer pro);

        /// <summary>
        /// 打开源
        /// </summary>
        /// <returns>打开结果</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool OpenSource();

        /// <summary>
        /// 获取参考参数
        /// </summary>
        /// <param name="cap">参考量</param>
        /// <returns>参考值</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetCapParam(ushort cap);

        /// <summary>
        /// 获取当前扫描识别
        /// </summary>
        /// <returns>扫描识别句柄</returns>
        [DllImport("Twack_32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetCurrentDsIdentify();

        /// <summary>
        /// 获取支持大小信息
        /// </summary>
        /// <returns>支持大小信息</returns>
        public static SuportSizeInfo GetScanPaperSizeInfo()
        {
            try
            {
                SuportSizeInfo suportSizeInfo = new SuportSizeInfo();
                string capParam = Twain_32.GetCapParam(4386);

                LogHelper.WriteInfoLog(capParam);
                CapabilityResult capabilityResult = SerializerHelper.DeserializeJson<CapabilityResult>(capParam);

                if (capabilityResult.ReturnCode == "0" && capabilityResult.hContainer != null && !string.IsNullOrEmpty(capabilityResult.hContainer.ItemList))
                {
                    string[] array = capabilityResult.hContainer.ItemList.Split(new char[]
					{
						','
					});
                    List<SuportSize> list = new List<SuportSize>();

                    for (int i = 0; i < array.Length; i++)
                    {
                        list.Add((SuportSize)System.Enum.Parse(typeof(SuportSize), array[i].Trim()));
                    }

                    suportSizeInfo.DeviceSuportSizes = list;
                    suportSizeInfo.DefaultSize = suportSizeInfo.DeviceSuportSizes[int.Parse(capabilityResult.hContainer.DefaultIndex)];
                    suportSizeInfo.CurrentSize = suportSizeInfo.DeviceSuportSizes[int.Parse(capabilityResult.hContainer.CurrentIndex)];

                    return suportSizeInfo;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFatalLog(ex.Message.ToString(), ex);
            }

            return null;
        }

        /// <summary>
        /// 获取支持大小枚举
        /// </summary>
        /// <param name="curPageSize">支持大小枚举</param>
        /// <returns>支持枚举</returns>
        public static SuportSize GetSupportSize(SuportSize curPageSize)
        {
            SuportSize result = curPageSize;

            if (curPageSize == SuportSize.TWSS_B4 || curPageSize == SuportSize.TWSS_JISB4 || curPageSize == SuportSize.TWSS_B5LETTER || curPageSize == SuportSize.TWSS_ISOB5)
            {
                SuportSizeInfo scanPaperSizeInfo = Twain_32.GetScanPaperSizeInfo();

                if (scanPaperSizeInfo != null)
                {
                    if (curPageSize == SuportSize.TWSS_B4 || curPageSize == SuportSize.TWSS_JISB4)
                    {
                        if (scanPaperSizeInfo.DeviceSuportSizes.Contains(SuportSize.TWSS_B4))
                        {
                            result = SuportSize.TWSS_B4;
                        }
                        else if (scanPaperSizeInfo.DeviceSuportSizes.Contains(SuportSize.TWSS_JISB4))
                        {
                            result = SuportSize.TWSS_JISB4;
                        }
                    }
                    if (curPageSize == SuportSize.TWSS_B5LETTER || curPageSize == SuportSize.TWSS_ISOB5)
                    {
                        if (scanPaperSizeInfo.DeviceSuportSizes.Contains(SuportSize.TWSS_B5LETTER))
                        {
                            result = SuportSize.TWSS_B5LETTER;
                        }
                        else if (scanPaperSizeInfo.DeviceSuportSizes.Contains(SuportSize.TWSS_ISOB5))
                        {
                            result = SuportSize.TWSS_ISOB5;
                        }
                    }
                }
                else
                {
                    LogHelper.WriteFatalLog("获取扫描仪支持纸张性能失败");
                }
            }

            return result;
        }
    }
}
