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
using System.IO;
using System.Collections.Generic;

public partial class news_UpdateNewsImaged : System.Web.UI.Page
{
    private string str
    {
        get
        {
            return ViewState["str"].ToString();
        }
        set
        {
            ViewState["str"] = value;
        }
    }
    private string strddd
    {
        get
        {
            return ViewState["strddd"].ToString();
        }
        set
        {
            ViewState["strddd"] = value;
        }
    }
    private string sed
    {
        get
        {
            return ViewState["sed"].ToString();
        }
        set
        {
            ViewState["sed"] = value;
        }
    }
    Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            str = this.Request.QueryString["strdod"].ToString().Trim();
            strddd = ConfigurationManager.AppSettings["UpimageNewss"].ToString();
            sed = "";
            BindShow(str);
        }
    }

    private void BindShow(string str)
    {

       sed = newstabbll.GetNewsTabByNewId(int.Parse(str)).Imagesurls.Trim();
        if (sed != "NULL")
        {
            List<Tz888.Model.news.UpImages> list = new List<Tz888.Model.news.UpImages>();
            string[] num = sed.Split('$');
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i].Trim() != "")
                {
                    Tz888.Model.news.UpImages imagemodel = new Tz888.Model.news.UpImages();
                    imagemodel.Descript = num[i].ToString().Trim();
                    list.Add(imagemodel);
                }
            }
            this.DataList1.DataSource = list;
            this.DataList1.DataBind();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string sdf = "";
        string[] num = sed.Split('$');
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i].Trim() != "")
            {
                foreach (DataListItem item in DataList1.Items)
                {
                    CheckBox ck = (CheckBox)item.FindControl("chckimage");
                    HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
                    if (ck.Checked == true)
                    {
                        int dsa = 0;
                        if (sdf != "")
                        {
                            string[] sdd = sdf.Split('$');

                            for (int t = 0; t < sdd.Length; t++)
                            {
                                if (sdd[t] == fid.Value)
                                {
                                    dsa = 1;
                                }
                            }
                        }
                        if (dsa == 0)
                        {
                            sdf += fid.Value.Trim() + "$";
                        }
                        string destinationFile = strddd + fid.Value.Trim();

                        if (File.Exists(destinationFile))
                        {

                            FileInfo fi = new FileInfo(destinationFile);

                            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)

                                fi.Attributes = FileAttributes.Normal;

                            File.Delete(destinationFile);

                        }


                    }
                }

            }
        }
        string b = "";
        if (sdf != "")
        {
            string strSplit = string.Empty;
            string[] dfs = sdf.Split('$');
            for (int i = 0; i < dfs.Length; i++)
            {
                if (dfs[i] != "")
                {
                    string n = dfs[i].ToString();
                    b = sed.Replace(n, "");
                    sed = b;

                }
            }
        }
        string sdq = "";
        string[] numddd = sed.Split('$');
        for (int i = 0; i < numddd.Length; i++)
        {
            if (numddd[i].Trim() != "")
            {
                sdq += numddd[i] + "$";
            }
        }
        int result = newstabbll.UpdateNewsTabImageUrl(sdq .Trim (),int.Parse (str));
        this.ClientScript.RegisterStartupScript(this.GetType(), "", "s('" + b + "');", true);

    }

}
