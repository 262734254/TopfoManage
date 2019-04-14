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
/*
 此页面用于查看窄告信息以及所对应的搜索条件
 */
public partial class Company_NarrowSearch : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyMadeBLL pany = new Tz888.BLL.Company.CompanyMadeBLL();
    Tz888.Model.Company.NarrowModel mode = new Tz888.Model.Company.NarrowModel();
    Tz888.BLL.Common.ZoneSelectBLL zone = new Tz888.BLL.Common.ZoneSelectBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ad = Convert.ToInt32(Request["AdID"]);
            Narrow(ad);
        }
    }
    //根据编号查看所对应的信息
    private void Narrow(int id)
    {
        mode = pany.SelNarrow(id);//查询所对应的窄告信息
        txtTitle.InnerHtml = mode.Title.ToString().Trim();//标题
        txtDescript.Value = mode.Descript.ToString().Trim();//内容
        txtUrl.InnerHtml = mode.Url.ToString().Trim();//链接地址
        txtTime.InnerHtml = mode.CreateDate.ToString().Trim();//发布时间
        txtInfoType.InnerHtml =TypeName(mode.InfoTypeName.ToString().Trim());//所对应的类型
        if (mode.ProvinceID.ToString().Trim() == "")
        {
            txtProvince.InnerHtml = "";
        }
        else
        {
            txtProvince.InnerHtml = zone.GetProvinceNameByCode(mode.ProvinceID.ToString().Trim());//所对应的省份
        }
    }

    #region 将类型翻译出来
    private string TypeName(string name)
    {
        string num = "";
        if (name != "")
        {
            switch (name)
            {
                case "Project":
                    num = "项目方";
                    break;
                case "Merchant":
                    num = "招商方";
                    break;
                case "Capital":
                    num = "投资方";
                    break;
            }
        }
        return num;
    }
    #endregion
}
