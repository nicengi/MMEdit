using System.Drawing;
using System.Windows.Forms;

namespace MMEdit
{
    public static partial class ExtensionMethods
    {
        #region Methods
        /// <summary>
        /// 获取指定大小的缩略图 <see cref="Image"/>。
        /// </summary>
        /// <param name="original"></param>
        /// <param name="thumbWidth"></param>
        /// <param name="thumbHeight"></param>
        /// <returns></returns>
        public static Image GetThumbnail(this Image original, int thumbWidth, int thumbHeight)
        {
            Image image = new Bitmap(original, thumbWidth, thumbHeight);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g.Clear(Color.Transparent);
                g.DrawImage(original, 0, 0, thumbWidth, thumbHeight);

                return image;
            }
        }

        /// <summary>
        /// 将指定的文件名筛选器字符串合并到 <see cref="FileDialog"/>。
        /// </summary>
        /// <param name="dialog"></param>
        /// <param name="filter"></param>
        public static void CombineFilter(this FileDialog dialog, string filter)
        {

            dialog.Filter = func(dialog.Filter) + filter;

            string func(string str)
            {
                if (!string.IsNullOrEmpty(str) && dialog.Filter[str.Length - 1] != '|')
                    return str += "|";
                else
                    return str;
            }
        }
        #endregion
    }
}
