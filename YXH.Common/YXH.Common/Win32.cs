using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YXH.Common
{
    public static class Win32
    {
        /// <summary>
        /// 矩形结构
        /// </summary>
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        /// <summary>
        /// 窗体结构
        /// </summary>
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }

        /// <summary>
        /// 设置尺寸参数
        /// </summary>
        public struct NCCALCSIZE_PARAMS
        {
            public Win32.RECT rgc;
            public Win32.WINDOWPOS wndpos;
        }

        /// <summary>
        /// 标签滚动信息结构
        /// </summary>
        public struct tagSCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        /// <summary>
        /// 功能栏枚举
        /// </summary>
        public enum fnBar
        {
            SB_HORZ,
            SB_VERT,
            SB_CTL
        }

        /// <summary>
        /// 文件捕捉类型
        /// </summary>
        public enum fMask
        {
            SIF_ALL,
            SIF_DISABLENOSCROLL = 16,
            SIF_PAGE = 2,
            SIF_POS = 4,
            SIF_RANGE = 1,
            SIF_TRACKPOS = 8
        }

        /// <summary>
        /// 菜单信息
        /// </summary>
        public struct MENUINFO
        {
            public int cbSize;
            public uint fMask;
            public int dwStyle;
            public int cyMax;
            public int hbrBack;
            public int dwContextHelpID;
            public int dwMenuData;
        }

        /// <summary>
        /// 滚动信息结构
        /// </summary>
        public struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        /// <summary>
        /// 滚动信息遮罩类型枚举
        /// </summary>
        public enum ScrollInfoMask
        {
            SIF_RANGE = 1,
            SIF_PAGE,
            SIF_POS = 4,
            SIF_DISABLENOSCROLL = 8,
            SIF_TRACKPOS = 16,
            SIF_ALL = 23
        }

        /// <summary>
        /// 滚动条方向枚举
        /// </summary>
        public enum ScrollBarDirection
        {
            SB_HORZ,
            SB_VERT,
            SB_CTL,
            SB_BOTH
        }

        /// <summary>
        /// 系统时间处理
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class SYSTEMTIME
        {
            public short wYear; //年
            public short wMonth;    //月
            public short wDayOfWeek;    //在当周的第几天
            public short wDay;  //日
            public short wHour; //时
            public short wMinute;   //分
            public short wSecond;   //秒
            public short wMilliseconds; //毫秒

            /// <summary>
            /// 日期/时间类型转换方法
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Concat(new string[]
				{
					"[SYSTEMTIME: ",
					this.wDay.ToString(CultureInfo.InvariantCulture),
					"/",
					this.wMonth.ToString(CultureInfo.InvariantCulture),
					"/",
					this.wYear.ToString(CultureInfo.InvariantCulture),
					" ",
					this.wHour.ToString(CultureInfo.InvariantCulture),
					":",
					this.wMinute.ToString(CultureInfo.InvariantCulture),
					":",
					this.wSecond.ToString(CultureInfo.InvariantCulture),
					"]"
				});
            }
        }

        /// <summary>
        /// 系统时间数组
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class SYSTEMTIMEARRAY
        {
            public short wYear1;    //年
            public short wMonth1;   //月
            public short wDayOfWeek1;   //在当周的第几天
            public short wDay1; //日
            public short wHour1;    //时
            public short wMinute1;  //分
            public short wSecond1;  //秒
            public short wMilliseconds1;    //毫秒
            public short wYear2;    //年
            public short wMonth2;   //月
            public short wDayOfWeek2;   //在当周的第几天
            public short wDay2; //日
            public short wHour2;    //时
            public short wMinute2;  //分
            public short wSecond2;  //秒
            public short wMilliseconds2;    //毫秒
        }

        public const int MF_REMOVE = 4096;
        public const int SC_RESTORE = 61728;
        public const int SC_MOVE = 61456;
        public const int SC_SIZE = 61440;
        public const int SC_MINIMIZE = 61472;
        public const int SC_MAXIMIZE = 61488;
        public const int SC_CLOSE = 61536;
        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GW_OWNER = 4;
        public const int GW_CHILD = 5;
        public const int GWL_STYLE = -16;
        public const int WM_LBUTTONDOWN = 513;
        public const int WM_LBUTTONUP = 514;
        public const int WM_LBUTTONDBLCLK = 163;
        public const int WM_WINDOWPOSCHANGING = 70;
        public const int WM_PAINT = 15;
        public const int WM_CREATE = 1;
        public const int WM_ACTIVATE = 6;
        public const int WM_NCCREATE = 129;
        public const int WM_NCCALCSIZE = 131;
        public const int WM_NCPAINT = 133;
        public const int WM_NCACTIVATE = 134;
        public const int WM_NCLBUTTONDOWN = 161;
        public const int WM_NCLBUTTONUP = 162;
        public const int WM_NCLBUTTONDBLCLK = 163;
        public const int WM_NCMOUSEMOVE = 160;
        public const int WM_STYLECHANGING = 124;
        public const int WM_STYLECHANGED = 125;
        public const int WM_HSCROLL = 276;
        public const int WM_VSCROLL = 277;
        public const int WM_PRINT = 791;
        public const int WM_DESTROY = 2;
        public const int WM_SHOWWINDOW = 24;
        public const int WM_SHARED_MENU = 482;
        public const int WM_SETREDRAW = 11;
        public const int WM_USER = 1024;
        public const int WM_NCHITTEST = 132;
        public const int WM_SYSCOMMAND = 274;
        public const int WM_COMMAND = 273;
        public const int WM_MOUSEMOVE = 512;
        public const int HC_ACTION = 0;
        public const int WH_CALLWNDPROC = 4;
        public const int HTCLIENT = 1;
        public const int HTLEFT = 10;
        public const int HTRIGHT = 11;
        public const int HTTOP = 12;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 16;
        public const int HTBOTTOMRIGHT = 17;
        public const int HTCAPTION = 2;
        public const int HWND_TOPMOST = -1;
        public const int HWND_NOTOPMOST = -2;
        public const int HWND_TOP = 0;
        public const int HWND_BOTTOM = 1;
        public const int SWP_NOACTIVATE = 16;
        public const int SWP_SHOWWINDOW = 64;
        public const int SWP_HIDEWINDOW = 128;
        public const int SWP_NOZORDER = 4;
        public const int SWP_NOMOVE = 2;
        public const int SWP_NOREPOSITION = 512;
        public const int SWP_NOSIZE = 1;
        public const int SE_SHUTDOWN_PRIVILEGE = 19;
        public const int WS_SYSMENU = 524288;
        public const int WS_SIZEBOX = 262144;
        public const int WS_MAXIMIZEBOX = 65536;
        public const int WS_MINIMIZEBOX = 131072;
        public const long WS_VISIBLE = 268435456L;
        public const int GWL_WNDPROC = -4;
        public const int GCW_ATOM = -32;
        public const int GCL_CBCLSEXTRA = -20;
        public const int GCL_CBWNDEXTRA = -18;
        public const int GCL_HBRBACKGROUND = -10;
        public const int GCL_HCURSOR = -12;
        public const int GCL_HICON = -14;
        public const int GCL_HMODULE = -16;
        public const int GCL_MENUNAME = -8;
        public const int GCL_STYLE = -26;
        public const int GCL_WNDPROC = -24;
        public const int CS_DROPSHADOW = 131072;
        public const int EM_GETEVENTMASK = 1083;
        public const int EM_SETEVENTMASK = 1093;
        public const int SB_THUMBTRACK = 5;
        public const int SB_HORZ = 0;
        public const int SB_VERT = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="Index"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int Index, int Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(IntPtr hWnd, int Index);

        /// <summary>
        /// 获取系统菜单项
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="flag"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern IntPtr GetSystemMenu(IntPtr hwnd, int flag);

        /// <summary>
        /// 跟踪弹出菜单
        /// </summary>
        /// <param name="hMenu"></param>
        /// <param name="wFlags"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="nReserved"></param>
        /// <param name="hwnd"></param>
        /// <param name="lprc"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int TrackPopupMenu(int hMenu, int wFlags, int x, int y, int nReserved, IntPtr hwnd, int lprc);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// 释放捕获
        /// </summary>
        /// <returns>释放当前线程的处理捕获</returns>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="hMenu"></param>
        /// <param name="IDItem"></param>
        /// <param name="Flagsw"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool DeleteMenu(int hMenu, int IDItem, int Flagsw);

        /// <summary>
        /// 获取系统菜单
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="bRevert"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetSystemMenu(int hwnd, int bRevert);

        /// <summary>
        /// 创建圆角区域
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

        /// <summary>
        /// 设置窗体区域
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="hRgn"></param>
        /// <param name="bRedraw"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, bool bRedraw);

        /// <summary>
        /// 查找窗口
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 设置？
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);

        /// <summary>
        /// 获取？
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// 创建模式刷
        /// </summary>
        /// <param name="hBitmap">位图</param>
        /// <returns></returns>
        [DllImport("gdi32")]
        public static extern int CreatePatternBrush(int hBitmap);

        /// <summary>
        /// 设置菜单信息
        /// </summary>
        /// <param name="hMenu">菜单句柄</param>
        /// <param name="mi">菜单参数</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int SetMenuInfo(IntPtr hMenu, ref Win32.MENUINFO mi);

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="minSize"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        /// <summary>
        /// 设置进程工作集大小
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int GetClassLong(int hwnd, int nIndex);

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int SetClassLong(int hwnd, int nIndex, int dwNewLong);

        /// <summary>
        /// 锁定窗口更新
        /// </summary>
        /// <param name="hWndLock"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        /// <summary>
        /// 获取?
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr handle);

        /// <summary>
        /// 发布？
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="hDC"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ReleaseDC(IntPtr handle, IntPtr hDC);

        /// <summary>
        /// 创建？
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport("Gdi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// 获取？
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="className"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hwnd, char[] className, int maxCount);

        /// <summary>
        /// 获取窗体
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="uCmd"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

        /// <summary>
        /// 获取窗体可见状态
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <returns>可见状态</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(IntPtr hwnd);

        /// <summary>
        /// 获取客户端尺寸
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="lpRect">矩形结构</param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, ref Win32.RECT lpRect);

        /// <summary>
        /// 获取客户端尺寸
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="rect">矩形类型</param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, [In] [Out] ref Rectangle rect);

        /// <summary>
        /// 移动窗体
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="X">X轴位置</param>
        /// <param name="Y">Y轴位置</param>
        /// <param name="nWidth">宽度</param>
        /// <param name="nHeight">高度</param>
        /// <param name="bRepaint">是否重新绘制</param>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        /// 更新窗体
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <returns>是否成功</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hwnd);

        /// <summary>
        /// 验证矩形是否有效
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="rect">目标矩形</param>
        /// <param name="bErase">是否擦除无效的矩形</param>
        /// <returns>验证结果</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(IntPtr hwnd, ref Rectangle rect, bool bErase);

        /// <summary>
        /// 验证矩形
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="rect">目标矩形</param>
        /// <returns>验证结果</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool ValidateRect(IntPtr hwnd, ref Rectangle rect);

        /// <summary>
        /// 获取窗体矩形
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="rect">目标矩形</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, [In] [Out] ref Rectangle rect);

        /// <summary>
        /// 设置窗体位置
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long uFlags);

        /// <summary>
        /// 获取客户端矩形
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="rect">目标矩形</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetClientRect(HandleRef hWnd, [In] [Out] ref Win32.RECT rect);

        /// <summary>
        /// 获取滚动条信息
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="fnBar"></param>
        /// <param name="lpsi"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref Win32.SCROLLINFO lpsi);

        /// <summary>
        /// 设置滚动条信息
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="fnBar"></param>
        /// <param name="lpsi"></param>
        /// <param name="fRedraw"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref Win32.SCROLLINFO lpsi, bool fRedraw);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, long wParam, int lParam);

        /// <summary>
        /// 显示滚动条
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="iBar"></param>
        /// <param name="bShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ShowScrollBar(IntPtr hWnd, int iBar, int bShow);

        /// <summary>
        /// 设置父级
        /// </summary>
        /// <param name="hWndChild">子窗体句柄</param>
        /// <param name="hWndNewParent"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// 合并整数
        /// </summary>
        /// <param name="lowPart"></param>
        /// <param name="highPart"></param>
        /// <returns></returns>
        public static int MakeLong(short lowPart, short highPart)
        {
            return (int)((ushort)lowPart) | (int)highPart << 16;
        }

        /// <summary>
        /// 内存拷贝
        /// </summary>
        /// <param name="dest">目标对象</param>
        /// <param name="src">源对象</param>
        /// <param name="len">长度</param>
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory")]
        public static extern void memcpy(IntPtr dest, IntPtr src, int len);

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="uType"></param>
        /// <param name="wLanguageId"></param>
        /// <param name="dwMilliseconds"></param>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBoxTimeoutW")]
        public static extern void Show(IntPtr handle, string text, string caption, MessageBoxButtons uType, ushort wLanguageId, uint dwMilliseconds);
    }
}
