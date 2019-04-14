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
        ///�Ƿ��������չ���ϴ� 
        ///</summary> 
        ///<paramname = "hifile">FileName</param> 
        ///<returns>�����򷵻�true,���򷵻�false</returns> 
        private static bool IsAllowedExtension(HttpPostedFile files, string AllowFileExtens)
        {
            string strExtension = "";
            if (files.FileName != string.Empty)
            {
                string FileName = files.FileName;
                //ȡ���ϴ��ļ�����չ�� 
                strExtension = FileName.Substring(FileName.LastIndexOf(".") + 1);
                //�жϸ���չ���Ƿ�Ϸ� 
                if (AllowFileExtens.IndexOf(strExtension) > -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary> 
        /// �ж��ϴ��ļ���С�Ƿ񳬹����ֵ 
        /// </summary> 
        /// <param name="hifile">HttpPostedFile</param> 
        /// <param name="FileSize">�ļ���С</param> 
        /// <returns>�������ֵ����false,���򷵻�true.</returns> 
        private static bool IsAllowedLength(HttpPostedFile files, int FileSize)
        {
            //����ϴ��ļ��Ĵ�С�������ֵ,����flase,���򷵻�true. 
            if (files.ContentLength > FileSize * 1024)
            {
                return false;
            }
            return true;
        }

        /// <summary> 
        /// ��ȡһ�����ظ����ļ��� 
        /// </summary> 
        /// <returns></returns> 
        private static string GetUniqueString()
        {
            //�õ����ļ������磺20050922101010 
            return DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        /// <summary>
        /// �ϴ��ļ��������ϴ�����ļ��� 
        /// </summary>
        /// <param name="files">HttpPostedFile</param>
        /// <param name="strAbsolutePath">�ļ���ŵ�·��</param>
        /// <param name="Msg">�ϴ���Ϣ</param>
        /// <param name="FileSize">�ļ���С(��KBΪ��λ)</param>
        /// <param name="AllowFileExtens">��չ��(�����|�ָ�)</param>
        /// <returns></returns>
        public static string SaveFile(HttpPostedFile files, string strAbsolutePath, ref string ErrorMsg, int FileSize, string AllowFileExtens,int type,string oldFileName,int width,int height)
        {
            bool IsError = false;
            string FileName = "", strExtension = "",strNewFileName="";
            FileName = files.FileName;
            //ȡ���ϴ��ļ�����չ�� 
            strExtension = FileName.Substring(FileName.LastIndexOf("."));
            //�жϵ�ǰ�ļ������Ƿ����ϴ��ļ����͵ķ�Χ��
            if (!IsAllowedExtension(files, AllowFileExtens))
            {
                ErrorMsg = "�ϴ����ļ����Ͳ���ȷ!(ֻ�����ϴ�" + AllowFileExtens + ")";
                IsError = true;
            }
            //�жϵ�ǰ�ļ���С
            if (!IsAllowedLength(files, FileSize) && !IsError)
            {
                ErrorMsg = "�ļ���С���ܳ�����" + FileSize + "KB!";
                IsError = true;
            }

            if (!IsError)
            {
                //�ļ��ϴ�������� 
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
                    ErrorMsg = "�ϴ�ʧ�� " + ex.Message + "!";
                }
            }
            return strNewFileName;
        }

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="FilePath">·��</param>
        public static void DelFile(string FilePath)
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);
        }

        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="originalImagePath">Դͼ·��������·����</param>
        /// <param name="thumbnailPath">����ͼ·��������·����</param>
        /// <param name="width">����ͼ���</param>
        /// <param name="height">����ͼ�߶�</param>
        /// <param name="mode">��������ͼ�ķ�ʽ</param>    
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
                case "HW"://ָ���߿����ţ����ܱ��Σ�                
                    break;
                case "W"://ָ�����߰�����                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://ָ���ߣ�������
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://ָ���߿�ü��������Σ�                
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

            //�½�һ��bmpͼƬ
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //�½�һ������
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //���ø�������ֵ��
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //���ø�����,���ٶȳ���ƽ���̶�
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //��ջ�������͸������ɫ���
            g.Clear(System.Drawing.Color.Transparent);

            //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);
            originalImage.Dispose();
            g.Dispose();
            try
            {
                DelFile(originalImagePath);
                //��jpg��ʽ��������ͼ
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
