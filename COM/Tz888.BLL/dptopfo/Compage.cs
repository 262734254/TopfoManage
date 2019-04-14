using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Threading;

namespace GZS.BLL
{
   public class Compage
    {
       public Compage()
       { 

       
       }

       /// <summary>
       /// �½��ļ�
       /// </summary>
       /// <param name="FolderPathName">�������ļ�����</param>
       public static string CreateFolder(string FolderPathName)
       {
           string CreatePath = "";
           if (FolderPathName.Trim().Length > 0)
           {
               try
               {
                   //string CreatePath = System.Web.HttpContext.Current.Server.MapPath("../PIC/picture/" + FolderPathName).ToString();
                    CreatePath = System.Web.HttpContext.Current.Server.MapPath(FolderPathName).ToString();
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
           return CreatePath;
       }

       /// <summary>
       /// д���ļ�
       /// </summary>
       /// <param name="Path">·��</param>
       /// <param name="Text">д������</param>
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
       /// ��ȡ�ļ�����
       /// </summary>
       /// <param name="Path">��ַ</param>
       /// <returns></returns>
       public static string Reader(string Path)
       {
           // return FileReaders(HttpContext.Current.Server.MapPath(Path), "gb2312");
           return FileReaders(Path, "gb2312");
       }

       /// <summary>
       /// ��ȡ�ļ�
       /// </summary>
       /// <param name="Path">�ļ�·��</param>
       /// <param name="Coding">�ļ�����</param>
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
       /// д���ļ�
       /// </summary>
       /// <param name="Path">�ļ�·��</param>
       /// <param name="Text">д������</param>
       /// <param name="Coding">�ļ�����</param>
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
       public void DeleteFile(string FolderPathName)
       {

           if (FolderPathName.Trim().Length > 0)
           {
               try
               {
                  string CreatePath = System.IO.Path.GetFileName(FolderPathName).ToString();
                  if (!Directory.Exists(CreatePath))
                   {
                       File.Delete(FolderPathName);
                       return;
                   }
               }
               catch
               {
                   throw;
               }
           }
       }


    }
}
