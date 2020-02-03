using System;

namespace MMEdit
{
    /// <summary>
    /// 指示文件状态。
    /// </summary>
    public enum FileStatus
    {
        Opened,
        Changed,
        Saved,
    }

    /// <summary>
    /// 为文件状态事件提供数据。
    /// </summary>
    public class FileStatusEventArgs : EventArgs
    {
        #region Constructor
        public FileStatusEventArgs(FileStatus status)
        {
            Status = status;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 指示文件状态。
        /// </summary>
        public FileStatus Status { get; }
		#endregion
	}
}
