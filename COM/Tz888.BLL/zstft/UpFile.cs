using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace Tz888.BLL.zstft
{
    public class UpFile
    {
        ///<summary> 
        ///是否允许该扩展名上传 
        ///</summary> 
        ///<paramname = "hifile">FileName</param> 
        ///<returns>允许则返回true,否则返回false</returns> 
        private static bool IsAllowedExtension(HttpPostedFile files, string AllowFileExtens)
        {
            string strExtension = "";
            if (files.FileName != string.Empty)
            {
                string FileName = files.FileName;
                //取得上传文件的扩展名 
                strExtension = FileName.Substring(FileName.LastIndexOf(".") + 1);
                //判断该扩展名是否合法 
                if (AllowFileExtens.IndexOf(strExtension) > -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary> 
        /// 判断上传文件大小是否超过最大值 
        /// </summary> 
        /// <param name="hifile">HttpPostedFile</param> 
        /// <param name="FileSize">文件大小</param> 
        /// <returns>超过最大值返回false,否则返回true.</returns> 
        private static bool IsAllowedLength(HttpPostedFile files, int FileSize)
        {
            //如果上传文件的大小超过最大值,返回flase,否则返回true. 
            if (files.ContentLength > FileSize * 1024)
            {
                return false;
            }
            return true;
        }

        /// <summary> 
        /// 获取一个不重复的文件名 
        /// </summary> 
        /// <returns></returns> 
        private static string GetUniqueString()
        {
            //得到的文件名形如：20050922101010 
            return DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        /// <summary>
        /// 上传文件并返回上传后的文件名 
        /// </summary>
        /// <param name="files">HttpPostedFile</param>
        /// <param name="strAbsolutePath">文件存放的路径</param>
        /// <param name="Msg">上传信息</param>
        /// <param name="FileSize">文件大小(以KB为单位)</param>
        /// <param name="AllowFileExtens">扩展名(多个以|分割)</param>
        /// <returns></returns>
        public static string SaveFile(HttpPostedFile files, string strAbsolutePath, ref string ErrorMsg, int FileSize, string AllowFileExtens,int type,string oldFileName,int width,int height)
        {
            bool IsError = false;
            string FileName = "", strExtension = "",strNewFileName="";
            FileName = files.FileName;
            //取得上传文件的扩展名 
            strExtension = FileName.Substring(FileName.LastIndexOf("."));
            //判断当前文件类型是否在上传文件类型的范围内
            if (!IsAllowedExtension(files, AllowFileExtens))
            {
                ErrorMsg = "上传的文件类型不正确!(只允许上传" + AllowFileExtens + ")";
                IsError = true;
            }
            //判断当前文件大小
            if (!IsAllowedLength(files, FileSize) && !IsError)
            {
                ErrorMsg = "文件大小不能出超过" + FileSize + "KB!";
                IsError = true;
            }

            if (!IsError)
            {
                //文件上传后的命名 
                strNewFileName = GetUniqueString() + strExtension;
                try
                {
                    if (type == 1 && oldFileName!="")
                    {
                        //strNewFileName = oldFileName;
                        DelFile(oldFileName);
                    }
                    if (!Directory.Exists(strAbsolutePath))
                        Directory.CreateDirectory(strAbsolutePath);
                    files.SaveAs(strAbsolutePath + strNewFileName);
                    MakeThumbnail(strAbsolutePath + strNewFileName, width, height);
                }
                catch(Exception ex)
                {
                    ErrorMsg = "上传失败 " + ex.Message + "!";
                }
            }
            return strNewFileName;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="FilePath">路径</param>
        public static void DelFile(string FilePath)
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, int width, int height)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            string mode = "HW";

            if (originalImage.Height > height && originalImage.Width > width)
            {
                mode = "Cut";
            }
            else if (originalImage.Width > width)
            {
                mode = "W";
            }
            else if (originalImage.Height > height)
            {
                mode = "H";
            }

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);
            originalImage.Dispose();
            g.Dispose();
            try
            {
                DelFile(originalImagePath);
                //以jpg格式保存缩略图
                bitmap.Save(originalImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                bitmap.Dispose();
            }
        }
    }
}
