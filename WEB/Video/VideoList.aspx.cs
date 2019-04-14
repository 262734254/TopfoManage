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
using Tz888.BLL.Video;
using Tz888.BLL.FenZhan;
using Tz888.Common;
using System.Text;
using System.IO;
using System.Net;

public partial class Video_VideoList : System.Web.UI.Page
{
    private readonly VideoBLL bll = new VideoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                    DelVideoById(Id);
                else
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
            }
            InitFenZhan();
            dataBind("");
        }
    }

    public string GetFenZhanName(string Id)
    {
        if (Id == "0")
            return "所有分站";
        string FenZhanName = "";
        FenZhanBLL bll = new FenZhanBLL();
        DataTable dt = bll.GetFenZhanById(Id);
        if (dt != null && dt.Rows.Count > 0)
        {
            FenZhanName = dt.Rows[0]["FenZhanName"].ToString();
        }
        return FenZhanName;
    }

    public void InitFenZhan()
    {
        FenZhanBLL bll = new FenZhanBLL();
        DataTable dt = bll.GetFenZhanList();
        if (dt != null && dt.Rows.Count > 0)
        {
            ShowPosition.DataSource = dt;
            ShowPosition.DataValueField = "Id";
            ShowPosition.DataTextField = "FenZhanName";
            ShowPosition.DataBind();
        }

        ListItem item = new ListItem();
        item.Value = "0";
        item.Text = "所有分站";
        ShowPosition.Items.Insert(0, item);
    }

    public void DelVideoById(string Id)
    {
        if (bll.DelVideoById(Id))
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除成功!", "VideoList.aspx", false);
        else
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除失败!", "VideoList.aspx", false);
    }

    //搜索
    protected void Search_Click(object sender, EventArgs e)
    {
        string where = "";
        string Title = txtTitle.Value.Trim();
        string Position = ShowPosition.SelectedValue;
        string IsRecommend = DropRecommend.SelectedValue;

        if (!string.IsNullOrEmpty(Title))
        {
            where = "Title='" + Title + "' and ";
        }

        if (IsRecommend != "-1")
        {
            where = where + "IsRecommend='" + IsRecommend + "' and ";
        }

        if (Position != "-1")
        {
            where = where + "ShowId='" + Position + "' and ";
        }

        if (where.Length > 0)
        {
            where = where.Substring(0, where.LastIndexOf("and")).Trim();
        }
        dataBind(where);
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind("");
    }

    protected void dataBind(string where)
    {
        try
        {
            int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
            int PageNum = 20;
            int TotalCount = 1;
            int PageCount = 1;
            AspNetPager1.PageSize = PageNum;
            DataTable dt = bll.GetVideoList("VideoInfo", "Id", "*", where, "Id desc", ref PageCurrent, PageNum, ref TotalCount);
            if (dt != null)
            {
                this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
                this.VideoList.DataSource = dt.DefaultView;

                this.VideoList.DataBind();

                if (TotalCount % PageNum > 0)
                    PageCount = TotalCount / PageNum + 1;
                else
                    PageCount = TotalCount / PageNum;
                this.pinfo.InnerText = Convert.ToString(TotalCount);//总条数
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void Del_Click(object sender, EventArgs e)
    {
        string Id = "";
        if (VideoList.Items.Count > 0)
        {
            for (int i = 0; i < VideoList.Items.Count; i++)
            {
                CheckBox Cbox = VideoList.Items[i].FindControl("Cbox") as CheckBox;
                if (Cbox.Checked)
                {
                    Id = Id + Cbox.ToolTip + ",";
                }
            }
            if (Id.Length > 0)
            {
                Id = Id.Remove(Id.Length - 1, 1);
                if (bll.DelVideoByIds(Id))
                {
                    MessageBox.Show(this.Page, "删除成功!");
                }
                else
                {
                    MessageBox.Show(this.Page, "删除失败!");
                }
            }
        }
        dataBind("");
    }

    //生成视频首页
    protected void ButCreateIndex_Click(object sender, EventArgs e)
    {
        string ErrorMessage = "";
        if (DropType.SelectedValue == "0")
        {
            ErrorMessage = CreateVidoeIndex();
        }
        else if (DropType.SelectedValue == "1")
        {
            ErrorMessage = CreateZhuantiIndex();
        }

        if (ErrorMessage != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, ErrorMessage);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功!");
        }
    }

    //专题
    public string CreateZhuantiIndex()
    {
        string ErrorMessage = "";
        bool isError = false;
        int Count = 0;
        string str = "";
        string Title = "";
        string Url = "";
        string Img = "";
        StreamReader sr = null;
        StreamWriter sw = null;
        Encoding code = Encoding.GetEncoding("gb2312");
        try
        {
            string Path=Server.MapPath("../Video/index.html");
            sr = new StreamReader(Path, code);
            str = sr.ReadToEnd();
            if (str.Length > 0)
            {
                DataTable Hot = bll.GetHotVideo(8, 1);
                //热门专题
                Count = Hot.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder Hot1 = new StringBuilder();
                    StringBuilder Hot2 = new StringBuilder();
                    Hot1.Append("<ul class=\"ul_pic\">");
                    Hot2.Append("<ul class=\"ul_pic\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = Hot.Rows[i]["Title"].ToString();
                        Url = Hot.Rows[i]["VideoUrl"].ToString();
                        Img = Hot.Rows[i]["ImgUrl"].ToString();
                        if (i < 4)
                        {
                            Hot1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Hot1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Hot1.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else
                        {
                            Hot2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Hot2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Hot2.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                    }
                    Hot1.Append("</ul>");
                    Hot2.Append("</ul>");
                    str = str.Replace("$Hot1$", Hot1.ToString());
                    str = str.Replace("$Hot2$", Hot2.ToString());
                }

                //政府招商
                DataTable Zs = bll.GetZsVideo(12, 1);
                Count = Zs.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder Zs1 = new StringBuilder();
                    StringBuilder Zs2 = new StringBuilder();
                    StringBuilder Zs3 = new StringBuilder();
                    Zs1.Append("<ul class=\"ul_pic\">");
                    Zs2.Append("<ul class=\"ul_pic\">");
                    Zs3.Append("<ul class=\"ul_pic\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = Zs.Rows[i]["Title"].ToString();
                        Url = Zs.Rows[i]["VideoUrl"].ToString();
                        Img = Zs.Rows[i]["ImgUrl"].ToString();
                        if (i < 4)
                        {
                            Zs1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Zs1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Zs1.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else if (i >= 4 && i < 8)
                        {
                            Zs2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Zs2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Zs2.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else
                        {
                            Zs3.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Zs3.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Zs3.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                    }
                    Zs1.Append("</ul>");
                    Zs2.Append("</ul>");
                    Zs3.Append("</ul>");
                    str = str.Replace("$Zs1$", Zs1.ToString());
                    str = str.Replace("$Zs2$", Zs2.ToString());
                    str = str.Replace("$Zs3$", Zs3.ToString());
                }

                //融资
                DataTable Rz = bll.GetRzVideo(12, 1);
                Count = Rz.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder Rz1 = new StringBuilder();
                    StringBuilder Rz2 = new StringBuilder();
                    StringBuilder Rz3 = new StringBuilder();
                    Rz1.Append("<ul class=\"ul_pic\">");
                    Rz2.Append("<ul class=\"ul_pic\">");
                    Rz3.Append("<ul class=\"ul_pic\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = Rz.Rows[i]["Title"].ToString();
                        Url = Rz.Rows[i]["VideoUrl"].ToString();
                        Img = Rz.Rows[i]["ImgUrl"].ToString();
                        if (i < 4)
                        {
                            Rz1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Rz1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Rz1.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else if (i >= 4 && i < 8)
                        {
                            Rz2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Rz2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Rz2.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else
                        {
                            Rz3.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Rz3.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Rz3.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                    }
                    Rz1.Append("</ul>");
                    Rz2.Append("</ul>");
                    Rz3.Append("</ul>");
                    str = str.Replace("$Rz1$", Rz1.ToString());
                    str = str.Replace("$Rz2$", Rz2.ToString());
                    str = str.Replace("$Rz3$", Rz3.ToString());
                }


                //投资
                DataTable Tz = bll.GetTzVideo(8, 1);
                Count = Tz.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder Tz1 = new StringBuilder();
                    StringBuilder Tz2 = new StringBuilder();
                    Tz1.Append("<ul class=\"ul_pic\">");
                    Tz2.Append("<ul class=\"ul_pic\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = Tz.Rows[i]["Title"].ToString();
                        Url = Tz.Rows[i]["VideoUrl"].ToString();
                        Img = Tz.Rows[i]["ImgUrl"].ToString();
                        if (i < 4)
                        {
                            Tz1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Tz1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Tz1.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else
                        {
                            Tz2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Tz2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Tz2.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                    }
                    Tz1.Append("</ul>");
                    Tz2.Append("</ul>");
                    str = str.Replace("$Tz1$", Tz1.ToString());
                    str = str.Replace("$Tz2$", Tz2.ToString());
                }

                //展会
                DataTable Zh = bll.GetZhVideo(12, 1);
                Count = Zh.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder Zh1 = new StringBuilder();
                    StringBuilder Zh2 = new StringBuilder();
                    StringBuilder Zh3 = new StringBuilder();
                    Zh1.Append("<ul class=\"ul_pic\">");
                    Zh2.Append("<ul class=\"ul_pic\">");
                    Zh3.Append("<ul class=\"ul_pic\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = Zh.Rows[i]["Title"].ToString();
                        Url = Zh.Rows[i]["VideoUrl"].ToString();
                        Img = Zh.Rows[i]["ImgUrl"].ToString();
                        if (i < 4)
                        {
                            Zh1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Zh1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Zh1.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else if (i >= 4 && i < 8)
                        {
                            Zh2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Zh2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Zh2.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else
                        {
                            Zh3.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Zh3.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Zh3.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                    }
                    Zh1.Append("</ul>");
                    Zh2.Append("</ul>");
                    Zh3.Append("</ul>");
                    str = str.Replace("$Zh1$", Zh1.ToString());
                    str = str.Replace("$Zh2$", Zh2.ToString());
                    str = str.Replace("$Zh3$", Zh3.ToString());
                }

                //资金贷款
                DataTable Zjdk = bll.GetZjdkVideo(8, 1);
                Count = Zjdk.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder Zjdk1 = new StringBuilder();
                    StringBuilder Zjdk2 = new StringBuilder();
                    Zjdk1.Append("<ul class=\"ul_pic\">");
                    Zjdk2.Append("<ul class=\"ul_pic\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = Zjdk.Rows[i]["Title"].ToString();
                        Url = Zjdk.Rows[i]["VideoUrl"].ToString();
                        Img = Zjdk.Rows[i]["ImgUrl"].ToString();
                        if (i < 4)
                        {
                            Zjdk1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Zjdk1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Zjdk1.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                        else
                        {
                            Zjdk2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                            Zjdk2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" /></a></i>");
                            Zjdk2.Append("<i class=\"iTit\"><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                        }
                    }
                    Zjdk1.Append("</ul>");
                    Zjdk2.Append("</ul>");
                    str = str.Replace("$Zjdk1$", Zjdk1.ToString());
                    str = str.Replace("$Zjdk2$", Zjdk2.ToString());
                }


                //热门专题列表
                DataTable HotList = bll.GetHotVideoList(18, 1);
                Count = HotList.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder HotStr = new StringBuilder();
                    HotStr.Append("<ul class=\"ul_text\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = HotList.Rows[i]["Title"].ToString();
                        Url = HotList.Rows[i]["VideoUrl"].ToString();
                        HotStr.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
                    }
                    HotStr.Append("</ul>");
                    str = str.Replace("$HotList$", HotStr.ToString());
                }

                //招商专题列表
                DataTable ZsList = bll.GetZsVideoList(18, 1);
                Count = ZsList.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder ZsStr = new StringBuilder();
                    ZsStr.Append("<ul class=\"ul_text\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = ZsList.Rows[i]["Title"].ToString();
                        Url = ZsList.Rows[i]["VideoUrl"].ToString();
                        ZsStr.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
                    }
                    ZsStr.Append("</ul>");
                    str = str.Replace("$ZsList$", ZsStr.ToString());
                }

                //资金贷款专题列表
                DataTable ZjdkList = bll.GetZjdkVideoList(18, 1);
                Count = ZjdkList.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder ZjdkStr = new StringBuilder();
                    ZjdkStr.Append("<ul class=\"ul_text\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = ZjdkList.Rows[i]["Title"].ToString();
                        Url = ZjdkList.Rows[i]["VideoUrl"].ToString();
                        ZjdkStr.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
                    }
                    ZjdkStr.Append("</ul>");
                    str = str.Replace("$ZjdkList$", ZjdkStr.ToString());
                }

                //融资专题列表
                DataTable RzList = bll.GetRzVideoList(18, 1);
                Count = RzList.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder RzStr = new StringBuilder();
                    RzStr.Append("<ul class=\"ul_text\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = RzList.Rows[i]["Title"].ToString();
                        Url = RzList.Rows[i]["VideoUrl"].ToString();
                        RzStr.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
                    }
                    RzStr.Append("</ul>");
                    str = str.Replace("$RzList$", RzStr.ToString());
                }

                //投资专题列表
                DataTable TzList = bll.GetTzVideoList(18, 1);
                Count = TzList.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder TzStr = new StringBuilder();
                    TzStr.Append("<ul class=\"ul_text\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = TzList.Rows[i]["Title"].ToString();
                        Url = TzList.Rows[i]["VideoUrl"].ToString();
                        TzStr.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
                    }
                    TzStr.Append("</ul>");
                    str = str.Replace("$TzList$", TzStr.ToString());
                }

                //展会专题列表
                DataTable ZhList = bll.GetZhVideoList(18, 1);
                Count = ZhList.Rows.Count;
                if (Count > 0)
                {
                    StringBuilder ZhStr = new StringBuilder();
                    ZhStr.Append("<ul class=\"ul_text\">");
                    for (int i = 0; i < Count; i++)
                    {
                        Title = ZhList.Rows[i]["Title"].ToString();
                        Url = ZhList.Rows[i]["VideoUrl"].ToString();
                        ZhStr.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
                    }
                    ZhStr.Append("</ul>");
                    str = str.Replace("$ZhList$", ZhStr.ToString());
                }

                sw = new StreamWriter(@"J:zt/index.html", false, code);
                sw.Write(str);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            isError = true;
        }
        finally
        {
            if (sr != null)
                sr.Close();
            if (sw != null)
                sw.Close();
        }
        return ErrorMessage;
    }

    //视频
    public string CreateVidoeIndex()
    {
        string ErrorMessage = "";
        bool isError = false;
        Encoding code = Encoding.GetEncoding("gb2312");
        string str = null;
        string urls = "http://video.topfo.com/Template/index.html";
        StreamReader sr = null;
        //读取
        try
        {
            //读取远程路径
            WebRequest temp = WebRequest.Create(urls);
            WebResponse myTemp = temp.GetResponse();
            sr = new StreamReader(myTemp.GetResponseStream(), code);
            str = sr.ReadToEnd();
            if (str.Length > 0)
            {
                string tempStr = ReplaceTemplate(str);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(tempStr);
                VideoServices.WebService service = new VideoServices.WebService();
                isError = service.SaveVideoIndex(bytes);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            isError = true;
        }
        finally
        {
            if (sr != null)
                sr.Close();
        }

        if (isError)
        {
            ErrorMessage = "静态页面生成失败,错误消息:" + ErrorMessage;
        }
        return ErrorMessage;
    }

    public string ReplaceTemplate(string TemplateStr)
    {
        int Count = 0;
        string Title = "";
        string Url = "";
        string Img = "";
        //热门视频
        DataTable Hot = bll.GetHotVideo(5, 0);
        Count = Hot.Rows.Count;
        if (Hot != null && Count > 0)
        {
            StringBuilder HotStr = new StringBuilder();
            HotStr.Append("<ul class=\"ul_pic\">");
            for (int i = 0; i < Count; i++)
            {
                Title = Hot.Rows[i]["Title"].ToString();
                Url = Hot.Rows[i]["VideoUrl"].ToString();
                Img = Hot.Rows[i]["ImgUrl"].ToString();

                HotStr.Append("<li><i class=\"iPic\">");
                HotStr.Append("<a href=\"" + Url + "\" target=\"_blank\">");
                HotStr.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" />");
                HotStr.Append("</a></i><i class=\"iTit\">");
                HotStr.Append("<a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
            }
            HotStr.Append("</ul>");
            TemplateStr = TemplateStr.Replace("$HotVideo$", HotStr.ToString());
        }
        else
        {
            TemplateStr = TemplateStr.Replace("$HotVideo$", "");
        }

        //招商视频
        DataTable Zs = bll.GetZsVideo(8, 0);
        Count = Zs.Rows.Count;
        if (Zs != null && Count > 0)
        {
            StringBuilder ZsStr1 = new StringBuilder();
            StringBuilder ZsStr2 = new StringBuilder();
            ZsStr1.Append("<ul class=\"ul_pic\">");
            ZsStr2.Append("<ul class=\"ul_pic\">");
            for (int i = 0; i < Count; i++)
            {
                Title = Zs.Rows[i]["Title"].ToString();
                Url = Zs.Rows[i]["VideoUrl"].ToString();
                Img = Zs.Rows[i]["ImgUrl"].ToString();
                if (i >= 4)
                {
                    ZsStr2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                    ZsStr2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" />");
                    ZsStr2.Append("</a></i> <i class=\"iTit\">");
                    ZsStr2.Append("<a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                }
                else
                {
                    ZsStr1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                    ZsStr1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" />");
                    ZsStr1.Append("</a></i> <i class=\"iTit\">");
                    ZsStr1.Append("<a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                }
            }
            ZsStr1.Append("</ul>");
            ZsStr2.Append("</ul>");
            TemplateStr = TemplateStr.Replace("$ZsVideo1$", ZsStr1.ToString());
            TemplateStr = TemplateStr.Replace("$ZsVideo2$", ZsStr2.ToString());
        }
        else
        {
            TemplateStr = TemplateStr.Replace("$ZsVideo1$", "");
            TemplateStr = TemplateStr.Replace("$ZsVideo2$", "");
        }

        //融资视频
        DataTable Rz = bll.GetRzVideo(8, 0);
        Count = Rz.Rows.Count;
        if (Rz != null && Count > 0)
        {
            StringBuilder RsStr1 = new StringBuilder();
            StringBuilder RsStr2 = new StringBuilder();
            RsStr1.Append("<ul class=\"ul_pic\">");
            RsStr2.Append("<ul class=\"ul_pic\">");
            for (int i = 0; i < Count; i++)
            {
                Title = Rz.Rows[i]["Title"].ToString();
                Url = Rz.Rows[i]["VideoUrl"].ToString();
                Img = Rz.Rows[i]["ImgUrl"].ToString();
                if (i >= 4)
                {
                    RsStr2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                    RsStr2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" />");
                    RsStr2.Append("</a></i> <i class=\"iTit\">");
                    RsStr2.Append("<a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                }
                else
                {
                    RsStr1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                    RsStr1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" />");
                    RsStr1.Append("</a></i> <i class=\"iTit\">");
                    RsStr1.Append("<a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                }
            }
            RsStr1.Append("</ul>");
            RsStr2.Append("</ul>");
            TemplateStr = TemplateStr.Replace("$RzVideo1$", RsStr1.ToString());
            TemplateStr = TemplateStr.Replace("$RzVideo2$", RsStr2.ToString());
        }
        else
        {
            TemplateStr = TemplateStr.Replace("$RzVideo1$", "");
            TemplateStr = TemplateStr.Replace("$RzVideo2$", "");
        }

        //投资视频
        DataTable Tz = bll.GetTzVideo(8, 0);
        Count = Tz.Rows.Count;
        if (Tz != null && Count > 0)
        {
            StringBuilder TsStr1 = new StringBuilder();
            StringBuilder TsStr2 = new StringBuilder();
            TsStr1.Append("<ul class=\"ul_pic\">");
            TsStr2.Append("<ul class=\"ul_pic\">");
            for (int i = 0; i < Count; i++)
            {
                Title = Tz.Rows[i]["Title"].ToString();
                Url = Tz.Rows[i]["VideoUrl"].ToString();
                Img = Tz.Rows[i]["ImgUrl"].ToString();
                if (i >= 4)
                {
                    TsStr2.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                    TsStr2.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" />");
                    TsStr2.Append("</a></i> <i class=\"iTit\">");
                    TsStr2.Append("<a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                }
                else
                {
                    TsStr1.Append("<li><i class=\"iPic\"><a href=\"" + Url + "\" target=\"_blank\">");
                    TsStr1.Append("<img alt=\"" + Title + "\" src=\"" + Img + "\" width=\"135\" height=\"100\" />");
                    TsStr1.Append("</a></i> <i class=\"iTit\">");
                    TsStr1.Append("<a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></i></li>");
                }
            }
            TsStr1.Append("</ul>");
            TsStr2.Append("</ul>");
            TemplateStr = TemplateStr.Replace("$TzVideo1$", TsStr1.ToString());
            TemplateStr = TemplateStr.Replace("$TzVideo2$", TsStr2.ToString());
        }
        else
        {
            TemplateStr = TemplateStr.Replace("$TzVideo1$", "");
            TemplateStr = TemplateStr.Replace("$TzVideo2$", "");
        }

        //招商视频列表
        DataTable ZsVideoList = bll.GetZsVideoList(16, 0);
        Count = ZsVideoList.Rows.Count;
        if (Count > 0)
        {
            StringBuilder ZsStrs = new StringBuilder();
            ZsStrs.Append("<ul class=\"ul_text\">");
            for (int i = 0; i < Count; i++)
            {
                Title = ZsVideoList.Rows[i]["Title"].ToString();
                Url = ZsVideoList.Rows[i]["VideoUrl"].ToString();
                ZsStrs.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
            }
            ZsStrs.Append("</ul>");
            TemplateStr = TemplateStr.Replace("$ZsVideoList$", ZsStrs.ToString());
        }
        else
        {
            TemplateStr = TemplateStr.Replace("$ZsVideoList$", "");
        }

        //融资视频列表
        DataTable RzVideoList = bll.GetRzVideoList(16, 0);
        Count = RzVideoList.Rows.Count;
        if (Count > 0)
        {
            StringBuilder RzStrs = new StringBuilder();
            RzStrs.Append("<ul class=\"ul_text\">");
            for (int i = 0; i < Count; i++)
            {
                Title = RzVideoList.Rows[i]["Title"].ToString();
                Url = RzVideoList.Rows[i]["VideoUrl"].ToString();
                RzStrs.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
            }
            RzStrs.Append("</ul>");
            TemplateStr = TemplateStr.Replace("$RzVideoList$", RzStrs.ToString());
        }
        else
        {
            TemplateStr = TemplateStr.Replace("$RzVideoList$", "");
        }

        //投资视频列表
        DataTable TzVideoList = bll.GetTzVideoList(16, 0);
        Count = TzVideoList.Rows.Count;
        if (Count > 0)
        {
            StringBuilder TzStrs = new StringBuilder();
            TzStrs.Append("<ul class=\"ul_text\">");
            for (int i = 0; i < Count; i++)
            {
                Title = TzVideoList.Rows[i]["Title"].ToString();
                Url = TzVideoList.Rows[i]["VideoUrl"].ToString();
                TzStrs.Append("<li><a href=\"" + Url + "\" target=\"_blank\">" + Title + "</a></li>");
            }
            TzStrs.Append("</ul>");
            TemplateStr = TemplateStr.Replace("$TzVideoList$", TzStrs.ToString());
        }
        else
        {
            TemplateStr = TemplateStr.Replace("$TzVideoList$", "");
        }
        return TemplateStr;
    }
}
