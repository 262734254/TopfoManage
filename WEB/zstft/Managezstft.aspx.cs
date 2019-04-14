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
using System.Text;
using System.IO;

public partial class zstft_Managezstft : System.Web.UI.Page
{

    private readonly Tz888.BLL.zstft.zstftBLL bll = new Tz888.BLL.zstft.zstftBLL();
    string CategoryValue = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                {
                    Del(Id);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
                }
            }
            BindData("");
        }
    }


    public void Del(string Id)
    {
        if (bll.Delete(Id))
        {
            string path = GetSaveImgPath(Request.QueryString["Category"].ToString()) + Request.QueryString["Picture"];
            Tz888.BLL.zstft.UpFile.DelFile(path);
            Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
        }
    }

    public void BindData(string where)
    {
        try
        {
            int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
            int PageNum = 20;
            int TotalCount = 1;
            int PageCount = 1;
            AspNetPager1.PageSize = PageNum;
            DataTable dt = bll.GetzstftList("zstft", "Id", "*", where, "Id desc", ref PageCurrent, PageNum, ref TotalCount);
            if (dt != null)
            {
                this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
                this.zstft.DataSource = dt.DefaultView;
                zstft.DataBind();
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


    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData("");
    }

    protected void BtnDel_Click(object sender, EventArgs e)
    {
        string Id = "";
        string Picture = "";
        string Category = "";
        if (zstft.Items.Count > 0)
        {
            for (int i = 0; i < zstft.Items.Count; i++)
            {
                CheckBox Cbox = zstft.Items[i].FindControl("Cbox") as CheckBox;
                if (Cbox.Checked)
                {
                    Id = Id + Cbox.ToolTip + ",";
                    Picture = Picture + (zstft.Items[i].FindControl("Picture") as Label).Text + "|";
                    Category = Category + (zstft.Items[i].FindControl("Category") as Label).Text + "|";
                }
            }
            if (Id.Length > 0)
            {
                Id = Id.Remove(Id.Length - 1, 1);
                if (bll.DelzstftByIds(Id))
                {
                    string[] str = Picture.Split('|');
                    string[] str1 = Category.Split('|');

                    for (int i = 0; i < str.Length - 1; i++)
                    {
                        Tz888.BLL.zstft.UpFile.DelFile(GetSaveImgPath(str1[i].ToString()) + str[i].ToString());
                    }
                    Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
                }
            }
        }
        BindData("");
    }


    private void DeleteInDir(string szDirPath)
    {
        if (szDirPath.Trim() == "" || !Directory.Exists(szDirPath))
            return;
        DirectoryInfo dirInfo = new DirectoryInfo(szDirPath);

        FileInfo[] fileInfos = dirInfo.GetFiles();
        if (fileInfos != null && fileInfos.Length > 0)
        {
            foreach (FileInfo fileInfo in fileInfos)
            {
                File.Delete(fileInfo.FullName);
            }
        }

        //DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
        //if (dirInfos != null && dirInfos.Length > 0)
        //{
        //    foreach (DirectoryInfo childDirInfo in dirInfos)
        //    {
        //        this.DeleteInDir(childDirInfo.ToString());
        //    }
        //}
    }

    private string  CreatePageNumber(int CurrentPage,int PageCount)
    {
        string NextPage = "";
        string UpPage="";
        int temp = 0;

        if (PageCount > 1)
        {
            if (CurrentPage == 1)
            {
                NextPage = "index1.html";
                UpPage = "index.html";
            }
            else if (CurrentPage >= PageCount)
            {
                temp = PageCount - 1;
                NextPage = "index" + temp.ToString() + ".html";

                temp = PageCount - 2;
                UpPage = "index" + ((temp.ToString() == "0") ? "" : temp.ToString()) + ".html";
            }
            else
            {
                NextPage = "index" + CurrentPage + ".html";

                temp = CurrentPage - 2;
                UpPage = "index" + ((temp.ToString() == "0") ? "" : temp.ToString()) + ".html";
            }
        }
        else
        {
            NextPage = "index.html";
            UpPage = "index.html";
        }
        

        StringBuilder sb = new StringBuilder();
        sb.Append("<div class=\"page_sub\">");
        sb.Append("<a href=\"index.html\" target=\"_parent\">首页</a>");
        sb.Append("<a href=\"" + UpPage.ToString() + "\" target=\"_parent\">&lt;</a>");
        for (int i = 1; i <= PageCount; i++)
        {
            if (CurrentPage == i)
            {
                sb.Append("<span>"+CurrentPage.ToString()+"</span>");
            }
            else
            {
                if (i == 1)
                {
                    sb.Append("<a href=\"index.html\" target=\"_parent\">" + i.ToString() + "</a>");
                }
                else
                {
                    int num = i - 1;
                    sb.Append("<a href=\"index" + num.ToString() + ".html\" target=\"_parent\">" + i.ToString() + "</a>");
                }
            }
        }
        
        if (PageCount > 1)
        {
            temp = PageCount - 1;
        }

        sb.Append("<a href=\"" + NextPage.ToString() + "\" target=\"_parent\">&gt;</a>");
        sb.Append("<a href=\"index" + ((temp.ToString() == "0") ? "" : temp.ToString()) + ".html\" target=\"_parent\">尾页</a>");
        sb.Append("</div>");
        sb.Append("<div class=\"page_data\">每页30个 第<span class=\"f_red strong\">" + CurrentPage + "</span>页/共" + PageCount + "页</div>");
        sb.Append("<div class=\"clear\"></div>");
        sb.Append("</div>");
        return sb.ToString();
    }

    public string GetSaveImgPath(string CategoryValue)
    {
        string SaveImgPath = "";
        if (CategoryValue == "招商")
        {
            SaveImgPath = @"J:\topfo\zs\zsimge\";
        }
        else if (CategoryValue == "融资")
        {
            SaveImgPath = @"J:\topfo\rz\rzimge\";
        }
        else if (CategoryValue == "投资")
        {
            SaveImgPath = @"J:\topfo\tz\tzimge\";
        }
        return SaveImgPath;
    }

    //获取图片的路劲
    public string GetImgPath(string CategoryValue)
    {
        string ImgPath = "";
        if (CategoryValue == "招商")
        {
            ImgPath = @"http://zs.topfo.com/zsimge/";
        }
        else if (CategoryValue == "融资")
        {
            ImgPath = @"http://rz.topfo.com/rzimge/";
        }
        else if (CategoryValue == "投资")
        {
            ImgPath = @"http://tz.topfo.com/tzimge/";
        }
        return ImgPath;
    }

    //获取文件保存的路劲
    public string GetFilePath(string CategoryValue)
    {
        string FilePath = "";
        if (CategoryValue == "招商")
        {
            FilePath = @"J:\topfo\zs\zstft\";
        }
        else if (CategoryValue == "融资")
        {
            FilePath = @"J:\topfo\rz\rztft\";
        }
        else if (CategoryValue == "投资")
        {
            FilePath = @"J:\topfo\tz\tztft\";
        }

        if (!Directory.Exists(FilePath))
            Directory.CreateDirectory(FilePath);

        return FilePath;
    }

    //获取模板路径
    public string GetTemplatePath(string CategoryValue)
    {
        string TemplatePath = "";
        if (CategoryValue == "招商")
        {
            TemplatePath = @"J:\topfo\zs\zstft\Template\index.html";
        }
        else if (CategoryValue == "融资")
        {
            TemplatePath = @"J:\topfo\rz\rztft\Template\index.html";
        }
        else if (CategoryValue == "投资")
        {
            TemplatePath = @"J:\topfo\tz\tztft\Template\index.html";
        }
        return TemplatePath;
    }


    protected void StaticPage_Click(object sender, EventArgs e)
    {
        CategoryValue = DropCategory.SelectedValue;
        if (string.IsNullOrEmpty(CategoryValue))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要生成的类别!");
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            string img = GetImgPath(CategoryValue);
            string ErrorMessage = "";
            string Template = Read(GetTemplatePath(CategoryValue));
            try
            {
                int Count = bll.GetCount(CategoryValue);
                DataTable dt = bll.GetAllzstft(CategoryValue);
                DeleteInDir(GetFilePath(CategoryValue));
                if (Count <= 30)
                {
                    sb.Length = 0;
                    sb.Append("<ul>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        sb.Append("<li><a href=\"" + row["Address"].ToString() + "\" target=\"_blank\"><img src=\"" + img + row["Picture"].ToString() + "\" alt=\"" + row["Title"].ToString() + "\">" + row["Title"].ToString() + "</a></li>");
                    }
                    sb.Append("</ul>");
                    string str = Template;
                    Writer(str, "", 1, 1, sb);
                }
                else if (Count % 30 == 0)
                {
                    int PageNumber = Count / 30;
                    for (int i = 0; i < PageNumber; i++)
                    {
                        sb.Length = 0;
                        sb.Append("<ul>");
                        for (int j = i * 30; j < ((i + 1) * 30); j++)
                        {
                            DataRow row = dt.Rows[j];
                            sb.Append("<li><a href=\"" + row["Address"].ToString() + "\" target=\"_blank\"><img src=\"" + img + row["Picture"].ToString() + "\" alt=\"" + row["Title"].ToString() + "\">" + row["Title"].ToString() + "</a></li>");
                        }
                        sb.Append("</ul>");
                        string str = Template;
                        Writer(str, ((i == 0) ? "" : i.ToString()) + ".html", i + 1, PageNumber, sb);
                    }
                }
                else
                {
                    int num = Count % 30;
                    int PageNumber = Count / 30 + 1;
                    for (int i = 0; i < PageNumber; i++)
                    {
                        sb.Length = 0;
                        sb.Append("<ul>");
                        for (int j = i * 30; j < ((i + 1) * 30); j++)
                        {
                            if (j >= Count)
                            {
                                break;
                            }
                            else
                            {
                                DataRow row = dt.Rows[j];
                                sb.Append("<li><a href=\"" + row["Address"].ToString() + "\" target=\"_blank\"><img src=\"" + img + row["Picture"].ToString() + "\" alt=\"" + row["Title"].ToString() + "\">" + row["Title"].ToString() + "</a></li>");
                            }
                        }
                        sb.Append("</ul>");
                        string str = Template;
                        Writer(str, ((i == 0) ? "" : i.ToString()) + ".html", i + 1, PageNumber, sb);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                if (ErrorMessage != "")
                {
                    Tz888.Common.MessageBox.Show(this.Page, ErrorMessage = "静态页面生成失败,错误消息:" + ErrorMessage);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成成功!");
                }
            }
        }
    }

    public void Writer(string str,string path,int CurrentPage,int PageNumber,StringBuilder sb)
    {
        str = str.Replace("$zstftVideo$", (sb.ToString() == "") ? "暂无数据" : sb.ToString());
        str = str.Replace("$PageNumber$", CreatePageNumber(CurrentPage, PageNumber));
        Encoding code = Encoding.GetEncoding("gb2312");
        path = GetFilePath(CategoryValue) + "index" + ((path == "") ? ".html" : path);
        StreamWriter sw = new StreamWriter(path, false, code);
        sw.Write(str);
        sw.Close();
        sw.Dispose();
    }


    public string Read(string TemplatePath)
    {
        Encoding code = Encoding.GetEncoding("gb2312");
        StreamReader sr = new StreamReader(TemplatePath, code);
        string str = sr.ReadToEnd();
        sr.Close();
        sr.Dispose();
        return str;
    }
}
