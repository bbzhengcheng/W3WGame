using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using WangFramework.Utility;

namespace W3WGame.Services
{
    /// <summary>
    /// 上传服务
    /// </summary>
    public class UploadService
    {
        /// <summary>
        /// 上传图片的最大大小
        /// </summary>
        private static readonly int SystemImageMaxLength = ConfigurationManager.AppSettings["SystemImageMaxLength"] == null
            ? 300
            : Convert.ToInt32(ConfigurationManager.AppSettings["SystemImageMaxLength"]);

        /// <summary>
        /// 上传商品图片的最大大小
        /// </summary>
        private static readonly int GoodsImageMaxLength = ConfigurationManager.AppSettings["GoodsImageMaxLength"] == null
            ? 1024
            : Convert.ToInt32(ConfigurationManager.AppSettings["GoodsImageMaxLength"]);

        /// <summary>
        /// 商品大图尺寸
        /// </summary>
        private const string BigGoodsImageSize = "300_300";

        /// <summary>
        /// 商品中图尺寸
        /// </summary> 
        private const string StandardGoodsImageSize = "160_160";

        /// <summary>
        /// 商品小图尺寸
        /// </summary>
        private const string SmallGoodsImageSize = "50_50";

        /// <summary>
        /// 上传图片的格式 
        /// </summary>
        private static readonly string ImageExtensions = ConfigurationManager.AppSettings["ImageExtensions"] ?? ".gif|.jpg|.jpeg|.bmp|.png|.ico";

        /// <summary>
        /// 可上传的文件格式
        /// </summary>
        private static readonly string FileExtensions = ConfigurationManager.AppSettings["FileExtensions"] ?? ".gif|.jpg|.jpeg|.bmp|.png|.ico";

        /// <summary>
        /// 可上传文件的最大大小
        /// </summary>
        private static readonly int FileMaxSize = ConfigurationManager.AppSettings["FileMaxSize"] == null
                                                      ? 1024 * 5
                                                      : Convert.ToInt32(ConfigurationManager.AppSettings["FileMaxSize"]);

        #region 系统/新闻-图片上传 UploadSystemImage

        /// <summary>
        /// 系统/新闻-图片上传
        /// </summary>
        /// <param name="file">图片文件</param>
        /// <param name="errMsg">异常信息</param>
        /// <param name="savePath">上传后的相对路径</param>
        /// <returns>是否上传成功</returns>
        public static bool UploadSystemImage(HttpPostedFileBase file, out string errMsg, out string savePath)
        {
            errMsg = string.Empty;
            savePath = string.Empty;

            if (file == null)
            {
                errMsg = "上传的图片不能为空";
                return false;
            }

            if (file.ContentLength == 0)
            {
                errMsg = "上传的图片不能为空";
                return false;
            }

            if (file.ContentLength / 1024 > SystemImageMaxLength)
            {
                errMsg = "上传的图片太大了";
                return false;
            }

            if (!ImageExtensions.Contains(Utils.GetUrlSuffix(file.FileName).ToLower()))
            {
                errMsg = "上传的图片格式不正确";
                return false;
            }

            try
            {
                Image.FromStream(file.InputStream, true, true);

                var path = GetSystemImageFilePath(file.FileName);
                file.SaveAs(HttpContext.Current.Server.MapPath(path));
                savePath = path;
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        private static string GetSystemImageFilePath(string fileName)
        {
            var savePath = string.Format("/Upload/SystemImage/{0}/{1}"
                                         , DateTime.Now.ToString("yyyyMM")
                                         , DateTime.Now.ToString("yyyyMMddHHmmssfff") + Utils.GetFileExtName(fileName));
            var dir = Path.GetDirectoryName(HttpContext.Current.Server.MapPath(savePath));
            if (dir != null && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return savePath;
        }

        #endregion

        #region 上传商品图片 UploadGoodsImage

        /// <summary>
        /// 上传商品图片
        /// </summary>
        /// <param name="file">图片文件</param>
        /// <param name="errMsg">异常信息</param>
        /// <param name="savePath">上传后的相对路径</param>
        /// <returns>是否上传成功</returns>
        public static bool UploadGoodsImage(HttpPostedFileBase file, out string savePath, out string errMsg)
        {
            errMsg = string.Empty;
            savePath = string.Empty;

            if (file == null)
            {
                errMsg = "上传的图片不能为空";
                return false;
            }

            if (file.ContentLength == 0)
            {
                errMsg = "上传的图片不能为空";
                return false;
            }

            if (file.ContentLength / 1024 > GoodsImageMaxLength)
            {
                errMsg = "上传的图片太大了";
                return false;
            }

            if (!ImageExtensions.Contains(Utils.GetUrlSuffix(file.FileName).ToLower()))
            {
                errMsg = "上传的图片格式不正确";
                return false;
            }

            try
            {
                var image = Image.FromStream(file.InputStream, true, true);
                var now = DateTime.Now;
                var path = GetGoodsImageFilePath(now, file.FileName);

                var bigSize = BigGoodsImageSize.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => Convert.ToInt32(c)).ToList();
                var standardSzie = StandardGoodsImageSize.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => Convert.ToInt32(c)).ToList();
                var smallSize = SmallGoodsImageSize.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => Convert.ToInt32(c)).ToList();

                ImageUtility.CutForCustom(file, HttpContext.Current.Server.MapPath(path), image.Width, image.Height, string.Empty, string.Empty);
                ImageUtility.CutForCustom(file, HttpContext.Current.Server.MapPath(GetGoodsImageFilePath(now, file.FileName, GoodsImageSize.Big)), bigSize[0], bigSize[1], string.Empty, string.Empty);
                ImageUtility.CutForCustom(file, HttpContext.Current.Server.MapPath(GetGoodsImageFilePath(now, file.FileName, GoodsImageSize.Standard)), standardSzie[0], standardSzie[1], string.Empty, string.Empty);
                ImageUtility.CutForCustom(file, HttpContext.Current.Server.MapPath(GetGoodsImageFilePath(now, file.FileName, GoodsImageSize.Small)), smallSize[0], smallSize[1], string.Empty, string.Empty);

                savePath = path;
                return true;
            }
            catch (Exception)
            {
                errMsg = "上传的图片格式不正确";
                return false;
            }

        }

        private static string GetGoodsImageFilePath(DateTime now, string fileName)
        {
            var savePath = string.Format("/Upload/GoodsImage/{0}/{1}"
                                         , now.ToString("yyyyMM")
                                         , now.ToString("yyyyMMddHHmmssfff") + Utils.GetFileExtName(fileName));

            var dir = Path.GetDirectoryName(HttpContext.Current.Server.MapPath(savePath));
            if (dir != null && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return savePath;
        }

        private static string GetGoodsImageFilePath(DateTime now, string fileName, GoodsImageSize size)
        {
            var savePath = string.Format("/Upload/GoodsImage/{0}/{1}"
                                         , now.ToString("yyyyMM")
                                         , now.ToString("yyyyMMddHHmmssfff") + "_" + size.ToString() + Utils.GetFileExtName(fileName));
            var dir = Path.GetDirectoryName(HttpContext.Current.Server.MapPath(savePath));
            if (dir != null && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return savePath;
        }

        public static string GetGoodsImageUrl(string fileName, GoodsImageSize size)
        {
            return fileName.Replace(Utils.GetFileExtName(fileName), string.Empty) + "_" + size.ToString() +
                   Utils.GetFileExtName(fileName);
        }

        #endregion

        #region 上传文件

        public static bool UploadFile(HttpPostedFileBase file, out string savePath, out string errMsg)
        {
            errMsg = string.Empty;
            savePath = string.Empty;

            if (file == null || file.ContentLength == 0)
            {
                errMsg = "请选择上传的文件";
                return false;
            }

            if (!FileExtensions.Contains(Utils.GetUrlSuffix(file.FileName)))
            {
                errMsg = "该文件不允许上传";
                return false;
            }

            if (file.ContentLength / 1024 > FileMaxSize)
            {
                errMsg = "文件过大，无法上传";
                return false;
            }

            savePath = GetFilePath(DateTime.Now, file.FileName);
            file.SaveAs(HttpContext.Current.Server.MapPath(savePath));
            return true;
        }

        private static string GetFilePath(DateTime now, string fileName)
        {
            var imgtype = fileName.Substring(fileName.LastIndexOf('.'));

            var savePath = string.Format("/Upload/File/{0}/{1}", now.ToString("yyyyMM"), now.ToString("yyyyMMddhhmmss")+imgtype);
            var dir = Path.GetDirectoryName(HttpContext.Current.Server.MapPath(savePath));
            if (dir != null && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return savePath;
        }
        #endregion
    }

    /// <summary>
    /// 商品图片尺寸
    /// </summary>
    public enum GoodsImageSize
    {
        /// <summary>
        /// 大图
        /// </summary>
        Big = 1,

        /// <summary>
        /// 中图
        /// </summary>
        Standard = 2,

        /// <summary>
        /// 小图
        /// </summary>
        Small = 3,
    }

}