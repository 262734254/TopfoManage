using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Text;
using System.IO;
using Tz888.SQLServerDAL.Register;
using Tz888.Common;

public partial class CatialManage_CatialStatic : System.Web.UI.Page
{
    private readonly Tz888.BLL.CatialManage.CatialInfoBLL bll = new Tz888.BLL.CatialManage.CatialInfoBLL();
    string[] InduyStrs ={ "#", "$", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "*" };
    string[] Provinces ={ "1002", "1098", "1103", "1181", "1277", "1382", "1474", "1511", "1670", "1816", "2728", "1908", "2002", "2218", "2177", "2434", "2536", "2561", "2610", "2614", "2728", "2847", "2973", "3078", "3256", "3262", "3290", "3371", "3478", "3559", "2258", "2361" };
    string Template = "";     //模板
    string ProvinceID = "";   //区域ID
    string InduyStr = "";     //行业
    string FileName = "";     //文件名
    string InduyName = "";    //区域名称
    string InduyID = "";         //区域ID
    string ProvinceName = "";  //区域名称
    int Count = 0;            //总条数
    int PageCount = 0;        //总页数
    int PageSize = 10;        //每页显示条数
    StringBuilder sb = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn1_Click(object sender, EventArgs e)
    {
        Template = GetTemplateData();
        bool isTure = true;
        try
        {
            //生成所有区域下的所有项目
            for (int i = 0; i < Provinces.Length; i++)
            {
                ProvinceID = Provinces[i].ToString();
                ProvinceName = GetProvinceName(ProvinceID);//获取区域名称
                Count = bll.GetCountByProvinceID(ProvinceID);//获取总条数
                if (Count > 0)
                {
                    //获取总页数
                    PageCount = bll.GetPageCount(Count, PageSize);
                    for (int j = 1; j <= PageCount; j++)
                    {
                        DataTable dt = bll.GetCatialInfoByProvinceID(j, ProvinceID);//获取当前页数据
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                FileName = "tz" + ProvinceID + "_" + j.ToString() + ".shtml";//文件名
                                sb.Append(GetDataItem(row));//拼接数据
                            }
                            CreatePage(j);//创建静态页面
                            sb.Length = 0;
                        }
                    }
                }
                else
                {
                    FileName = "tz" + ProvinceID + "_1.shtml";//文件名
                    sb.Append("暂无数据...");//拼接数据
                    CreatePage(1);//创建静态页面
                    sb.Length = 0;
                }
            }
        }
        catch (Exception ex)
        {
            isTure = false;
            Tz888.Common.MessageBox.Show(this.Page, ex.Message);
        }

        if (isTure)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成成功");
        }
    }

    protected void Btn2_Click(object sender, EventArgs e)
    {
        Template = GetTemplateData();
        ProvinceID = "Induy";
        bool isTure = true;
        InduyStr= Induy.SelectedValue;
        if(!string.IsNullOrEmpty(InduyStr) && InduyStr=="all")
        {
            try
            {
                //生成所有区域下的所有行业项目
                for (int i = 0; i < InduyStrs.Length; i++)
                {
                    InduyStr = InduyStrs[i].ToString();
                    InduyID = bll.GetIndustryBID(InduyStr);//获取行业ID
                    InduyName = bll.GetInduyName(InduyStr);//获取行业名称
                    Count = bll.GetCountByIndustryBID(InduyStr);//获取总条数
                    if (Count > 0)
                    {
                        //获取总页数
                        PageCount = bll.GetPageCount(Count, PageSize);
                        for (int j = 1; j <= PageCount; j++)
                        {
                            DataTable dt = bll.GetCatialInfoIndustryBID(j, InduyStr);//获取当前页数据
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    FileName = "tzInduy_" + InduyID + "_" + j.ToString() + ".shtml";//文件
                                    sb.Append(GetDataItem(row));//拼接数据
                                }
                                CreatePage(j);//创建静态页面
                                sb.Length = 0;
                            }
                        }
                    }
                    else
                    {
                        FileName = "tzInduy_" + InduyID + "_1.shtml";//文件名
                        sb.Append("暂无数据...");//拼接数据
                        CreatePage(1);//创建静态页面
                        sb.Length = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                isTure = false;
                Tz888.Common.MessageBox.Show(this.Page, ex.Message);
            }
        }
        else if(!string.IsNullOrEmpty(InduyStr) && InduyStr!="all")
        {
            try
            {
                //生成所有区域下的当前行业项目
                InduyID = bll.GetIndustryBID(InduyStr);//获取行业ID
                InduyName = bll.GetInduyName(InduyStr);//获取行业名称
                Count = bll.GetCountByIndustryBID(InduyStr);//获取总条数
                if (Count > 0)
                {
                    //获取总页数
                    PageCount = bll.GetPageCount(Count, PageSize);
                    for (int i = 1; i <= PageCount; i++)
                    {
                        DataTable dt = bll.GetCatialInfoIndustryBID(i, InduyStr);//获取当前页数据
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                FileName = "tzInduy_" + InduyID + "_" + i.ToString() + ".shtml";//文件
                                sb.Append(GetDataItem(row));//拼接数据
                            }
                            CreatePage(i);//创建静态页面
                            sb.Length = 0;
                        }
                    }
                }
                else
                {
                    FileName = "tzInduy_" + InduyID + "_1.shtml";//文件名
                    sb.Append("暂无数据...");//拼接数据
                    CreatePage(1);//创建静态页面
                    sb.Length = 0;
                }
            }
            catch (Exception ex)
            {
                isTure = false;
                Tz888.Common.MessageBox.Show(this.Page, ex.Message);
            }
        }
       

        if (isTure)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成成功");
        }
    }

    protected void Btn3_Click(object sender, EventArgs e)
    {
        bool isTure = true;
        Template = GetTemplateData();
        try
        {
            for (int n = 0; n < Provinces.Length; n++)
            {
                ProvinceID = Provinces[n].ToString();
                //生成所有区域下的所有行业
                for (int i = 0; i < InduyStrs.Length; i++)
                {
                    InduyStr = InduyStrs[i].ToString();
                    InduyID = bll.GetIndustryBID(InduyStr);//获取行业ID
                    InduyName = bll.GetInduyName(InduyStr);//获取行业名称
                    ProvinceName = GetProvinceName(ProvinceID);//获取区域名称
                    Count = bll.GetCountByIndustryBIDAndProvinceID(InduyStr, ProvinceID);//获取总条数
                    if (Count > 0)
                    {
                        PageCount = bll.GetPageCount(Count, PageSize);//获取总页数
                        for (int j = 1; j <= PageCount; j++)
                        {
                            DataTable dt = bll.GetCatialInfoByIndustryBIDAndProvinceID(j, InduyStr, ProvinceID);//获取当前页数据
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    FileName = "tz" + ProvinceID + "_" + InduyID + "_" + j.ToString() + ".shtml";//文件名
                                    sb.Append(GetDataItem(row));//拼接数据
                                }
                                CreatePage(j);//创建静态页面
                                sb.Length = 0;
                            }
                        }
                    }
                    else
                    {
                        FileName = "tz" + ProvinceID + "_" + InduyID + "_1.shtml";//文件名
                        sb.Append("暂无数据...");//拼接数据
                        CreatePage(1);//创建静态页面
                        sb.Length = 0;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            isTure = false;
            Tz888.Common.MessageBox.Show(this.Page, ex.Message);
        }

        if (isTure)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成成功");
        }
    }

    protected void ButStatic_Click(object sender, EventArgs e)
    {
        ProvinceID = Province.SelectedValue;
        InduyStr = Induy.SelectedValue;
        Template = GetTemplateData();
        bool IsTure = true;
        try
        {
            if (!string.IsNullOrEmpty(ProvinceID) && string.IsNullOrEmpty(InduyStr))
            {
                //生成当前区域下的所有项目
                ProvinceName = GetProvinceName(ProvinceID);//获取区域名称
                Count = bll.GetCountByProvinceID(ProvinceID);//获取总条数
                if (Count > 0)
                {
                    //获取总页数
                    PageCount = bll.GetPageCount(Count, PageSize);
                    for (int i = 1; i <= PageCount; i++)
                    {
                        DataTable dt = bll.GetCatialInfoByProvinceID(i, ProvinceID);//获取当前页数据
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                FileName = "tz" + ProvinceID + "_" + i.ToString() + ".shtml";//文件名
                                sb.Append(GetDataItem(row));//拼接数据
                            }
                            CreatePage(i);//创建静态页面
                            sb.Length = 0;
                        }
                    }
                }
                else
                {
                    FileName = "tz" + ProvinceID + "_1.shtml";//文件名
                    sb.Append("暂无数据...");//拼接数据
                    CreatePage(1);//创建静态页面
                    sb.Length = 0;
                }
            }
            else if (!string.IsNullOrEmpty(ProvinceID) && !string.IsNullOrEmpty(InduyStr) && InduyStr == "all")
            {
                //生成当前区域下的所有行业项目
                for (int i = 0; i < InduyStrs.Length; i++)
                {
                    InduyStr = InduyStrs[i].ToString();
                    InduyID = bll.GetIndustryBID(InduyStr);//获取行业ID
                    InduyName = bll.GetInduyName(InduyStr);//获取行业名称
                    ProvinceName = GetProvinceName(ProvinceID);//获取区域名称
                    Count = bll.GetCountByIndustryBIDAndProvinceID(InduyStr, ProvinceID);//获取总条数
                    if (Count > 0)
                    {
                        PageCount = bll.GetPageCount(Count, PageSize);//获取总页数
                        for (int j = 1; j <= PageCount; j++)
                        {
                            DataTable dt = bll.GetCatialInfoByIndustryBIDAndProvinceID(j, InduyStr, ProvinceID);//获取当前页数据
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    FileName = "tz" + ProvinceID + "_" + InduyID + "_" + j.ToString() + ".shtml";//文件名
                                    sb.Append(GetDataItem(row));//拼接数据
                                }
                                CreatePage(j);//创建静态页面
                                sb.Length = 0;
                            }
                        }
                    }
                    else
                    {
                        FileName = "tz" + ProvinceID + "_" + InduyID + "_1.shtml";//文件名
                        sb.Append("暂无数据...");//拼接数据
                        CreatePage(1);//创建静态页面
                        sb.Length = 0;
                    }
                }
            }
            else if (!string.IsNullOrEmpty(ProvinceID) && !string.IsNullOrEmpty(InduyStr) && InduyStr != "all")
            {
                //生成当前区域下的当前行业项目
                InduyID = bll.GetIndustryBID(InduyStr);//获取行业ID
                InduyName = bll.GetInduyName(InduyStr);//获取行业名称
                ProvinceName = GetProvinceName(ProvinceID);//获取区域名称
                Count = bll.GetCountByIndustryBIDAndProvinceID(InduyStr, ProvinceID);//获取总条数
                if (Count > 0)
                {
                    PageCount = bll.GetPageCount(Count, PageSize);//获取总页数
                    for (int i = 1; i <= PageCount; i++)
                    {
                        DataTable dt = bll.GetCatialInfoByIndustryBIDAndProvinceID(i, InduyStr, ProvinceID);//获取当前页数据
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                FileName = "tz" + ProvinceID + "_" + InduyID + "_" + i.ToString() + ".shtml";//文件名
                                sb.Append(GetDataItem(row));//拼接数据
                            }
                            CreatePage(i);//创建静态页面
                            sb.Length = 0;
                        }
                    }
                }
                else
                {
                    FileName = "tz" + ProvinceID + "_" + InduyID + "_1.shtml";//文件名
                    sb.Append("暂无数据...");//拼接数据
                    CreatePage(1);//创建静态页面
                    sb.Length = 0;
                }
            }
        }
        catch (Exception ex)
        {
            IsTure = false;
            Tz888.Common.MessageBox.Show(this.Page, ex.Message);
        }
        if (IsTure)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成成功！");
        }
    }

    //创建静态页面
    public void CreatePage(int PageCurrent)
    {
        string PageTitle = "$Province$#Induy#投资项目|$Province$#Induy#投资项目信息汇总|投资项目 $Province$#Induy#项目分类 - 中国招商投资网";
        string Pagekeywords = "$Province$#Induy#投资项目, $Province$#Induy#投资项目新资讯";
        string Pagedescription = "有关$Province$#Induy#投资项目信息汇总，投资项目频道，全国最新$Province$#Induy#投资项目信息发布，"
                            + "让投资者更快找到$Province$#Induy#投资项目相关的投资项目和项目信息，展示哪些企业的投资项目；"
                            + "同时也为企业提供全国优秀$Province$#Induy#投资项目资讯，让企业更快找到$Province$#Induy#投资项目相关信息。";

        string DataSource = Template.Replace("$State$", sb.ToString());
        DataSource = DataSource.Replace("$Page$", GetPageNumberStr(PageCurrent));
        DataSource = DataSource.Replace("$QuYuAre$", ProvinceName);
        DataSource = DataSource.Replace("$QAreList$", ProvinceID);
        PageTitle = PageTitle.Replace("$Province$", ProvinceName).Replace("#Induy#", InduyName);
        Pagekeywords = Pagekeywords.Replace("$Province$", ProvinceName).Replace("#Induy#", InduyName);
        Pagedescription = Pagedescription.Replace("$Province$", ProvinceName).Replace("#Induy#", InduyName);
        DataSource = DataSource.Replace("$DisplayTitle$", PageTitle);
        DataSource = DataSource.Replace("$KeyWord$", Pagekeywords);
        DataSource = DataSource.Replace("$Descript$", Pagedescription);

        string SavePath = @"J:\topfo\tz\search\";
        if (!Directory.Exists(SavePath))
            Directory.CreateDirectory(SavePath);
        Write(SavePath + FileName, DataSource);
    }

    public string GetDataItem(DataRow row)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<ul>");
        sb.Append("<li>");
        sb.Append("<div class=\"ziyuan-list-1\">");
        sb.Append("<input type=\"checkbox\" name=\"checkboxRecord\" value=" + row["InfoID"].ToString() + " />");
        sb.Append("</div>");
        sb.Append("<div class=\"ziyuan-list-2\"><img src=\"http://search.topfo.com/images/search_34.jpg\" /></div>");
        sb.Append("<div class=\"ziyuan-list-3\">");
        sb.Append("<h3><a href=\"http://www.topfo.com/" + row["HtmlFile"].ToString() + "\" class=\"f_lan-bd\" target=\"_blank\"> " + row["Title"].ToString() + "</a></h3>");
        sb.Append("<div style=\" color:#666; margin-bottom:6px\">" + SubString(Text.ThrowHtml(row["ComAbout"].ToString()), 110, "....") + "</div>");
        sb.Append("<div><span class=\"ziyuan-list-3-a1\">状态：<span class=\"f_org\">[已审核]</span></span>");
        sb.Append("<span class=\"ziyuan-list-3-a1\">总金额：<span class=\"f_org\">" + row["CapitalName"].ToString() + "</span></span>");
        sb.Append("<span class=\"ziyuan-list-3-a1\">地区：<span class=\"f_org\">" + GetProvinceNameByProvinceID(row["ProvinceID"].ToString()) + "</span></span>");
        sb.Append("<span class=\"ziyuan-list-3-b1\">行业：<span class=\"f_org\">" + GetInduyNameByInduyID(row["IndustryBID"].ToString()) + "</span></span> </div>");
        sb.Append("<div class=\"f_gray \" style=\"clear:both\">发布时间:  " + row["publishT"].ToString().Substring(0, 9).Trim() + "  有效时间：" + TimeConvert(row["ValidateTerm"].ToString()) + "</div>");
        sb.Append("</div>");
        sb.Append("<div class=\"ziyuan-list-4\">");
        sb.Append("<a href=\"http://www.topfo.com/" + row["HtmlFile"].ToString() + "\" target=\"_blank\"><img src=\"http://search.topfo.com/images/search_38.jpg\" /></a>");
        sb.Append("</div>");
        sb.Append("</li>");
        sb.Append("</ul>");
        return sb.ToString();
    }

    //获取对应的行业名称
    public string GetInduyNameByInduyID(string Induys)
    {
        string Name = "";
        Induys = Induys.Trim();
        if (Induys.ToString() == "")
        {
            Name = "暂无行业";
        }
        else
        {
            Induys = Induys.Trim();
            Induys = Induys.Substring(0, Induys.Length - 1);
            string[] Str = Induys.Split(',');
            if (Str.Length > 1)
            {
                foreach (string s in Str)
                {
                    Name += bll.GetInduyName(s) + " ";
                }
            }
            else
            {
                Name = bll.GetInduyName(Induys);
            }
        }
        return Name;
    }

    //获取对应的城市名称
    public string GetProvinceNameByProvinceID(string ProvinceIDS)
    {
        string Name = "";
        ProvinceIDS = ProvinceIDS.Trim();
        if (ProvinceIDS.ToString() == "")
        {
            Name = "暂无区域";
        }
        else
        {
            ProvinceIDS = ProvinceIDS.Substring(0, ProvinceIDS.Length - 1);
            string[] Str = ProvinceIDS.Split(',');
            if (Str.Length > 1)
            {
                foreach (string s in Str)
                {
                    Name += GetProvinceName(s) + " ";
                }
            }
            else
            {
                Name = GetProvinceName(ProvinceIDS);
            }
        }
        return Name;
    }

    //写入数据
    public void Write(string FilePath, string DataSource)
    {
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter(FilePath, false, Encoding.GetEncoding("gb2312"));
            sw.Write(DataSource);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (sw != null)
            {
                sw.Close();
                sw.Dispose();
            }
        }
    }

    /// <summary>
    /// 有效期转换
    /// </summary>
    /// <param name="ValidateTerm"></param>
    /// <returns></returns>
    public string TimeConvert(string ValidateTerm)
    {
        switch (ValidateTerm.ToString().Trim())
        {
            case "3": ValidateTerm = "3个月"; break;
            case "6": ValidateTerm = "6个月"; break;
            case "36": ValidateTerm = "3年"; break;
            case "60": ValidateTerm = "5年"; break;
            case "12": ValidateTerm = "1年"; break;
            case "24": ValidateTerm = "2年"; break;
        }
        return ValidateTerm;
    }

    //读取模板数据
    public string GetTemplateData()
    {
        string DataSource = "";
        string TemplatePath = @"J:\topfo\tz\Template\search-1.htm"; //@"D:\search-1.htm"; //
        Encoding code = Encoding.GetEncoding("gb2312");
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(TemplatePath, code);
            DataSource = sr.ReadToEnd();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
                sr.Dispose();
            }
        }
        return DataSource;
    }

    //截取字符串
    public string SubString(string Str, int Length, string ReplaceStr)
    {
        int peplaceStrLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(ReplaceStr);
        int strLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(Str);
        if (strLength > Length)
        {
            for (int i = Str.Length; i > 0; i--)
            {
                strLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(Str.Substring(0, i));
                if (strLength <= Length - peplaceStrLength)
                    return Str.Substring(0, i) + ReplaceStr;
            }
            return "";
        }
        else
            return Str;
    }


    /// <summary>
    /// 分页方法
    /// </summary>
    /// <param name="PageCurrent">当前页</param>
    /// <param name="PageCount">总页数</param>
    /// <param name="PageSize">每页显示的条数</param>
    /// <param name="Number">显示页码数</param>
    /// <param name="Space">间隔范围</param>
    /// <param name="linkAddress">连接地址</param>
    /// <returns></returns>
    public string GetPageNumberStr(int PageCurrent)
    {
        int Number = 10;
        int Space = 1;//间隔范围
        string TempInduyID = "";
        string TempProvinceID = "";
        if (string.IsNullOrEmpty(InduyID))
            TempInduyID = "";
        else
            TempInduyID = InduyID + "_";

        if (string.IsNullOrEmpty(ProvinceID))
            TempProvinceID = "Induy_";
        else
            TempProvinceID = ProvinceID + "_";

        StringBuilder sbStr = new StringBuilder();
        string NextPage = "";
        string UpPage = "";
        int temp = 0;

        if (PageCount > 0)
        {
            if (PageCurrent == 1)
            {
                NextPage = "tz" + TempProvinceID + TempInduyID + "2.shtml";
                UpPage = "tz" + TempProvinceID + TempInduyID + "1.shtml";
            }
            else if (PageCurrent >= PageCount)
            {
                NextPage = "tz" + TempProvinceID + TempInduyID + PageCount.ToString() + ".shtml";
                temp = PageCount - 1;
                UpPage = "tz" + TempProvinceID + TempInduyID + temp.ToString() + ".shtml";
            }
            else
            {
                temp = PageCurrent + 1;
                NextPage = "tz" + TempProvinceID + TempInduyID + temp.ToString() + ".shtml";

                temp = PageCurrent - 1;
                UpPage = "tz" + TempProvinceID + TempInduyID + temp.ToString() + ".shtml";
            }

            sbStr.Append("<div class=\"page_sub\">");
            sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + "1" + ".shtml\" target=\"_parent\">首页</a>");
            sbStr.Append("<a href=\"" + UpPage.ToString() + "\" target=\"_parent\">&lt;</a>");

            if (PageCount <= Number)
            {
                //如果总页数小于等于显示页码数
                for (int i = 1; i <= PageCount; i++)
                {
                    if (PageCurrent == i)
                    {
                        sbStr.Append("<span>" + PageCurrent.ToString() + "</span>");
                    }
                    else
                    {
                        if (i == 1)
                        {
                            sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + "1.shtml\" target=\"_parent\">" + i.ToString() + "</a>");
                        }
                        else
                        {
                            sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + i.ToString() + ".shtml\" target=\"_parent\">" + i.ToString() + "</a>");
                        }
                    }
                }
            }
            else
            {
                //如果总页数大于显示页码数

                //计算器
                int Count = 0;
                //开始位置
                int Start = ((PageCurrent == 1) ? PageCurrent : Space + PageCurrent);

                for (int i = Start; i <= PageCount; i++)
                {
                    if (Count >= Number)
                        break;

                    Count++;

                    if (PageCurrent == i)
                    {
                        sbStr.Append("<span>" + PageCurrent.ToString() + "</span>");
                    }
                    else
                    {
                        sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + i.ToString() + ".shtml\" target=\"_parent\">" + i.ToString() + "</a>"); 
                    }
                }
            }
            sbStr.Append("<a href=\"" + NextPage.ToString() + "\" target=\"_parent\">&gt;</a>");
            sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + PageCount.ToString() + ".shtml\" target=\"_parent\">尾页</a>");
            sbStr.Append("<div class=\"clear\"></div>");
            sbStr.Append("</div>");
        }
        return sbStr.ToString();
    }



    //public string GetPageNumberStr(int PageCurrent)
    //{
    //    string TempInduyID = "";
    //    string TempProvinceID = "";
    //    if (string.IsNullOrEmpty(InduyID))
    //        TempInduyID = "";
    //    else
    //        TempInduyID = InduyID + "_";

    //    if (string.IsNullOrEmpty(ProvinceID))
    //        TempProvinceID = "Induy_";
    //    else
    //        TempProvinceID = ProvinceID + "_";

    //    StringBuilder sbStr = new StringBuilder();
    //    string NextPage = "";
    //    string UpPage = "";
    //    int temp = 0;

    //    if (PageCount > 1)
    //    {
    //        if (PageCurrent == 1)
    //        {
    //            NextPage = "tz" + TempProvinceID + TempInduyID + "2.shtml";
    //            UpPage = "tz" + TempProvinceID + TempInduyID + "1.shtml";
    //        }
    //        else if (PageCurrent >= PageCount)
    //        {
    //            NextPage = "tz" + TempProvinceID + TempInduyID + PageCount.ToString() + ".shtml";
    //            temp = PageCount - 1;
    //            UpPage = "tz" + TempProvinceID + TempInduyID + temp.ToString() + ".shtml";
    //        }
    //        else
    //        {
    //            temp = PageCurrent + 1;
    //            NextPage = "tz" + TempProvinceID + TempInduyID + temp.ToString() + ".shtml";

    //            temp = PageCurrent - 1;
    //            UpPage = "tz" + TempProvinceID + TempInduyID + temp.ToString() + ".shtml";
    //        }

    //        sbStr.Append("<div class=\"page_sub\">");
    //        sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + "1" + ".shtml\" target=\"_parent\">首页</a>");
    //        sbStr.Append("<a href=\"" + UpPage.ToString() + "\" target=\"_parent\">&lt;</a>");
    //        for (int i = 1; i <= PageCount; i++)
    //        {
    //            if (PageCurrent == i)
    //            {
    //                sbStr.Append("<span>" + PageCurrent.ToString() + "</span>");
    //            }
    //            else
    //            {
    //                if (i == 1)
    //                {
    //                    sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + "1.shtml\" target=\"_parent\">" + i.ToString() + "</a>");
    //                }
    //                else
    //                {
    //                    sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + i.ToString() + ".shtml\" target=\"_parent\">" + i.ToString() + "</a>");
    //                }
    //            }
    //        }

    //        sbStr.Append("<a href=\"" + NextPage.ToString() + "\" target=\"_parent\">&gt;</a>");
    //        sbStr.Append("<a href=\"tz" + TempProvinceID + TempInduyID + PageCount.ToString() + ".shtml\" target=\"_parent\">尾页</a>");
    //        sbStr.Append("<div class=\"clear\"></div>");
    //        sbStr.Append("</div>");
    //    }
    //    return sbStr.ToString();
    //}

    public string GetProvinceName(string ProvinceID)
    {
        string ProvinceName = "";
        switch (ProvinceID)
        {
            case "1098": ProvinceName = "北京"; break;
            case "1002": ProvinceName = "安徽"; break;
            case "1103": ProvinceName = "福建"; break;
            case "1181": ProvinceName = "甘肃"; break;
            case "1277": ProvinceName = "广西"; break;
            case "1382": ProvinceName = "贵州"; break;
            case "1474": ProvinceName = "海南"; break;
            case "1511": ProvinceName = "河北"; break;
            case "1670": ProvinceName = "河南"; break;
            case "1816": ProvinceName = "黑龙江"; break;
            case "2728": ProvinceName = "山西"; break;
            case "1908": ProvinceName = "湖北"; break;
            case "2002": ProvinceName = "湖南"; break;
            case "2218": ProvinceName = "吉林"; break;
            case "2177": ProvinceName = "江苏"; break;
            case "2434": ProvinceName = "内蒙古"; break;
            case "2536": ProvinceName = "宁夏"; break;
            case "2561": ProvinceName = "青海"; break;
            case "2610": ProvinceName = "上海"; break;
            case "2614": ProvinceName = "广东"; break;
            case "2847": ProvinceName = "山东"; break;
            case "2973": ProvinceName = "陕西"; break;
            case "3078": ProvinceName = "四川"; break;
            case "3256": ProvinceName = "天津"; break;
            case "3262": ProvinceName = "重庆"; break;
            case "3290": ProvinceName = "西藏"; break;
            case "3371": ProvinceName = "新疆"; break;
            case "3478": ProvinceName = "浙江"; break;
            case "3559": ProvinceName = "云南"; break;
            case "2258": ProvinceName = "江西"; break;
            case "2361": ProvinceName = "辽宁"; break;
        }
        return ProvinceName;
    }
}