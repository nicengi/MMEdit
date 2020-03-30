using System;

namespace MMEdit
{
    /// <summary>
    /// 通知状态改变。
    /// </summary>
    public interface INotifyStatusChanged
    {
        #region Events
        /// <summary>
        /// 在状态改变时发生。
        /// </summary>
        event EventHandler<FileStatusEventArgs> StatusChanged;
        #endregion

        #region Methods
        /// <summary>
        /// 引发 <see cref=" INotifyStatusChanged.StatusChanged"/> 事件。
        /// </summary>
        /// <param name="status"></param>
        void OnStatusChanged(FileStatus status);
        #endregion
    }
}
