using System;

namespace MMEdit
{
    /// <summary>
    /// 表示文件状态。
    /// </summary>
    public enum FileStatus
    {
        /// <summary>
        /// 表示文件被打开。
        /// </summary>
        Opened,

        /// <summary>
        /// 表示文件被修改。
        /// </summary>
        Changed,

        /// <summary>
        /// 表示文件被保存。
        /// </summary>
        Saved,

        /// <summary>
        /// 表示文件被重新加载。
        /// </summary>
        Reloaded,

        /// <summary>
        /// 表示文件被关闭。
        /// </summary>
        Closed,
    }

    /// <summary>
    /// 为文件状态事件提供数据。
    /// </summary>
    public class FileStatusEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="FileStatusEventArgs"/> 类的新实例。
        /// </summary>
        /// <param name="status">文件状态。</param>
        public FileStatusEventArgs(FileStatus status)
        {
            Status = status;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取文件状态。
        /// </summary>
        public FileStatus Status { get; }
		#endregion
	}
}
