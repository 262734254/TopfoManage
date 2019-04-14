using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace Tz888.COM
{
   public class Compage
    {
       public Compage()
       { 

       
       }

       /// <summary>
       /// 新建文件
       /// </summary>
       /// <param name="FolderPathName">跟径和文件名称</param>
       public void CreateFolder(string FolderPathName)
       {
           if (FolderPathName.Trim().Length > 0)
           {
               try
               {
                   //string CreatePath = System.Web.HttpContext.Current.Server.MapPath("../PIC/picture/" + FolderPathName).ToString();
                   string CreatePath = System.Web.HttpContext.Current.Server.MapPath(FolderPathName).ToString();
                   if (!Directory.Exists(CreatePath))
                   {
                       Directory.CreateDirectory(CreatePath);
                   }
               }
               catch
               {
                   throw;
               }
           }
       }

       /// <summary>
       /// 写入文件
       /// </summary>
       /// <param name="Path">路径</param>
       /// <param name="Text">写入内容</param>
       public static void Writer(string Path, string Text)
       {
           // FileWriter(HttpContext.Current.Server.MapPath(Path), Text, "gb2312");
           FileWriter(Path, Text, "gb2312");
       }

       //public static void WriterS(string Path, string Text)
       //{
       //    FileWriter(Path, Text, "gb2312");
       //}
       /// <summary>
       /// 读取文件类型
       /// </summary>
       /// <param name="Path">地址</param>
       /// <returns></returns>
       public static string Reader(string Path)
       {
           // return FileReaders(HttpContext.Current.Server.MapPath(Path), "gb2312");
           return FileReaders(Path, "gb2312");
       }

       /// <summary>
       /// 读取文件
       /// </summary>
       /// <param name="Path">文件路径</param>
       /// <param name="Coding">文件编码</param>
       /// <returns></returns>
       private static string FileReaders(string Path, string Coding)
       {
           StreamReader sr;
           string str = "";
           if (File.Exists(Path))
           {
               try
               {
                   sr = new StreamReader(Path, Encoding.GetEncoding(Coding));
                   str = sr.ReadToEnd();
                   sr.Close();
               }
               catch (Exception e)
               {
                   throw new Exception(e.Message, e);
               }
           }
           return str;
       }

       /// <summary>
       /// 写入文件
       /// </summary>
       /// <param name="Path">文件路径</param>
       /// <param name="Text">写入内容</param>
       /// <param name="Coding">文件编码</param>
       private static void FileWriter(string Path, string Text, string Coding)
       {
           StreamWriter sw;
           try
           {
               sw = new StreamWriter(Path, false, Encoding.GetEncoding(Coding));
               // sw.WriteLine(Text);
               sw.Write(Text);
               sw.Flush();
               sw.Close();
           }
           catch (Exception e)
           {
               throw new Exception(e.Message, e);
           }
       }

    }
}
