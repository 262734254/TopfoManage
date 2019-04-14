using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using Tz888.Common;
using System.Web.UI.HtmlControls;
using System.IO;


/// <summary>
/// Merchant 的摘要说明
/// </summary>
[WebService(Namespace = "http://www.topfo.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Merchant : System.Web.Services.WebService
{
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();
    private static Tz888.BLL.MerchantManage.PageStatic page = new Tz888.BLL.MerchantManage.PageStatic(); //实例化招商创建文件类
    private static Tz888.BLL.offer.PageStatic CapitalPage = new Tz888.BLL.offer.PageStatic(); //实例化投资创建文件类
    Tz888.BLL.PageBLL ProjectStatic = new Tz888.BLL.PageBLL();
    Tz888.BLL.news.PageStatic newstatic = new Tz888.BLL.news.PageStatic();
    Tz888.BLL.ProfessionalManage.PageStatic pagestatic = new Tz888.BLL.ProfessionalManage.PageStatic();
    Tz888.BLL.ProfessionalManage.PageStaticTalents pagestaticstatic = new Tz888.BLL.ProfessionalManage.PageStaticTalents();
    Tz888.BLL.ProfessionalManage.PageStaticOrg pagestaicorg = new Tz888.BLL.ProfessionalManage.PageStaticOrg();

    public Merchant()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }
    #region 生成招商静态文件
    /// <summary>
    /// 生成招商静态文件
    /// </summary>
    /// <param name="infoID">ID</param>
    /// <param name="title">标题</param>
    /// <param name="publishT">时间</param>
    /// <param name="AreaName">地区</param>
    /// <param name="Content">内容</param>
    /// <param name="IndustryCarveOutID">行页</param>
    /// <param name="MerchantNameTotal">投资总金额</param>
    /// <param name="validateID">有效期</param>
    /// <param name="Idstuny">行页</param>
    /// <param name="IsVip">价格</param>
    /// <param name="KeyWord">关键字</param>
    /// <param name="DisplayTitle">网页tilte</param>
    /// <param name="Descript">描述</param>
    /// <param name="pic">图片</param>
    /// <returns></returns>
    [WebMethod]
    public int StaticHtml(int infoID, string title, string publishT, string AreaName, string Content, string IndustryCarveOutID, string MerchantNameTotal, string validateID, string Idstuny, string IsVip, string KeyWord, string DisplayTitle, string Descript, string pic)
    {
        return page.StaticHtml(infoID, title, publishT, AreaName, Content, IndustryCarveOutID, MerchantNameTotal, validateID, Idstuny, IsVip, KeyWord, DisplayTitle, Descript, pic);

    } 
    #endregion
    #region 删除文件
    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="FolderPathName">文件名</param>
    [WebMethod]
    public void DeleteFile(string FolderPathName)
    {
        com.DeleteFile(FolderPathName);
    } 
    #endregion

    #region 生成投资静态文件
    /// <summary>
    /// 生成投资静态文件
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public int CapitalStaicHtml(int infoID, string title, string publishT, string AreaName, string Content, string IndustryCarveOutID, string CooperationTypeName, string Money, string validateID, string MerchantNameTotal, string Idstuny, string pic, string IsVip, string KeyWord, string DisplayTitle, string Descript, string Register)
    {
        return CapitalPage.StaticHtml(infoID, title, publishT, AreaName, Content, IndustryCarveOutID, CooperationTypeName, Money, validateID, MerchantNameTotal, Idstuny, pic, IsVip, KeyWord, DisplayTitle, Descript, Register);
                                        
    }
    
    #endregion

    [WebMethod]
    #region 融资静态文件
    public void ProjectStaticHtml(string InfoID, string ProjectName, string ComAbout, string CountryCode, string ProvinceID,
      string CItyID, string CountyID, string IndustryBID, string CapitalTotal, string iZqYqjjdwqk,
          string iZqXmyxqs, string PublishT, string ComBrief, string ManageTeamAbout, string DisplayTitle, string KeyWord,
      string Descript, int num, string lated, string MainPoint, string FixPriceID)
    {
        ProjectStatic.ProjectZqHtml(InfoID, ProjectName, ComAbout, CountryCode, ProvinceID,
                                    CItyID, CountyID, IndustryBID, CapitalTotal, iZqYqjjdwqk, iZqXmyxqs,
                                    PublishT, ComBrief, ManageTeamAbout, DisplayTitle, KeyWord, Descript,
                                    num, lated, MainPoint, FixPriceID);
    } 
    #endregion

    #region 文件上传
    [WebMethod]
    public string GetUploadFilePath(string FileType, string InfoType, bool IsFullPath)
    {
        return Tz888.Common.Common.GetUploadFilePath(FileType, InfoType, IsFullPath);
    }

    [WebMethod]
    public string GetFileServerURL()
    {
        return Tz888.Common.Common.GetFileServerURL();
    }

    [WebMethod]
    public string GetUploadFileRootPath()
    {
        return Tz888.Common.Common.GetUploadFilePath();
    }

    [WebMethod]
    public string newslu()
    {
 return  ConfigurationManager.AppSettings["UpimageNews"].ToString(); 
    }

    [WebMethod(Description = "上传资源图片文件")]
    public string InfoFileUploadImage(string ImagefileName, byte[] byteFileStream)
    {
        string ImageBasePath = ConfigurationManager.AppSettings["FZFileServerPath"].ToString();
        string filePath = "";
        string mess = "";
        try
        {
            DateTime Now = DateTime.Now;


            string newFileName = Now.Year.ToString() + "/" + Now.Month.ToString() + "/" + ImagefileName;
             filePath = ImageBasePath + newFileName;


            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));


            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(byteFileStream);
            w.Flush();
            fs.Close();
        }
        catch (Exception eX)
        {
            mess = eX.Message;
        }

        if (mess != "")
        {
            return mess;
        }
        else
        {
            return filePath;
        }
    }

    #endregion
    //生成新闻资讯静态页面
    [WebMethod]
    public int StaticHtmlnews(int newsid)
    {
        return newstatic.StaticHtml(newsid);
    }
    //新闻资讯上传图片地址


    [WebMethod(Description = "上传图片文件")]
    public string NewsFileUploadImage(string ImagefileName, byte[] byteFileStream)
    {

        string ImageBasePath = ConfigurationManager.AppSettings["UpimageNews"].ToString(); //招商生成页面存放位置

        string mess = "";
        try
        {
            DateTime Now = DateTime.Now;
            //string newFileName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(ImagefileName);
            string newFileName = ImagefileName;
            string filePath = ImageBasePath + newFileName;
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));


            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(byteFileStream);
            w.Flush();
            fs.Close();
        }
        catch (Exception eX)
        {
            mess = eX.Message;
        }

        if (mess != "")
        {
            return mess;
        }
        else
        {
            return "1";
        }
    }

    //[WebMethod]
    //public string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string path, int size, string filetype)
    //{
    //    try
    //    {
    //        string strSaveName = string.Empty;
    //        string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
    //        strSaveName = System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + strtype;
    //        if (!Directory.Exists(path))
    //        {
    //            Directory.CreateDirectory(path);
    //        }
    //        string strSavePath = path + strSaveName;//为文件获取保存路径
    //        int fileSize = postedFile.PostedFile.ContentLength / 1024;
    //        //是否限制文件类型
    //        if (filetype.Length > 0)
    //        {
    //            if (filetype.ToLower().Equals("default"))
    //            {
    //                if (strtype.ToLower() != ".jpg" && strtype.ToLower() != ".bmp" && strtype.ToLower() != ".gif")
    //                    return "1";
    //            }
    //        }
    //        //是否限制大小
    //        if (size > 0)
    //        {
    //            if (fileSize <= size)
    //            {
    //                postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
    //                return strSaveName;
    //            }
    //            else
    //            {
    //                //上传的文件大小超出
    //                return "2";
    //            }
    //        }
    //        else
    //        {
    //            postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
    //            return strSaveName;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}
    //新闻首页生成静态
    [WebMethod]
    public string newsIndex()
    {
        return ConfigurationManager.AppSettings["DKNewsIndex"].ToString();
    }
    //专业人才上传图片地址
    [WebMethod]
    public string rencai()
    {
        DateTime Now = DateTime.Now;
        string par = "J:/topfo/tzWeb/dservice/image/" + Now.Year.ToString() + "/";
        return par;
    }
    //生成专业服务静态页面
    [WebMethod]
    public int StaticHtmlfuwu(int professionalid)
    {
        return pagestatic.StaticHtml(professionalid);
    }
    //生成专业机构静态页面
    [WebMethod]
    public int StaticHtmljigou(int professionalid)
    {
        return pagestaicorg.StaticHtml(professionalid);
    }
    //生成专业人才静态页面
    [WebMethod]
    public int StaticHtmlrencai(int professionalid)
    {
        return pagestaticstatic.StaticHtml(professionalid);
    }

     [WebMethod(Description = "上传图片文件")]
    public string FileUploadImage(string ImagefileName, byte[] byteFileStream)
    {
        string ImageBasePath = ConfigurationManager.AppSettings["RenCai"].ToString(); //招商生成页面存放位置

        string mess = "";
        try
        {
            DateTime Now = DateTime.Now;
            //string newFileName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(ImagefileName);
            string newFileName = Now.Year.ToString() + "/" + Now.Month.ToString() + "/" + ImagefileName;
            string filePath = ImageBasePath + newFileName;
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));


            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(byteFileStream);
            w.Flush();
            fs.Close();
        }
        catch (Exception eX)
        {
            mess = eX.Message;
        }

        if (mess != "")
        {
            return mess;
        }
        else
        {
            return "1";
        }
    }






}

