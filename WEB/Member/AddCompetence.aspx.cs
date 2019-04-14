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
public partial class ManageSystem_AddCompetence : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        AjaxPro.Utility.RegisterTypeForAjax(typeof(ManageSystem_AddCompetence));
        if (!IsPostBack)
        {
            toLoad();

        }
    }

    protected void toLoad()
    {
        StringBuilder sb = new StringBuilder();
        Tz888.BLL.ManageSystem.CompetenceTabBLL bll = new Tz888.BLL.ManageSystem.CompetenceTabBLL();
        DataSet ds = bll.getCompetenceFatherList("MID,MName", "MenuTab", "where MCheck=1 and MParentCode=0 and MCode like 'M%'");

        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                sb.Append("<table class=\"one_table\">");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataSet dd = bll.getCompetenceFatherList("MID,MName", "MenuTab", "where MCheck=1 and MParentCode=" + ds.Tables[0].Rows[i]["MID"].ToString() + "");
                    sb.Append("<tr style=\"background-color: #E8F3F7;\"><td> <input id=\"CB" + ds.Tables[0].Rows[i]["MID"].ToString() + "\" type=\"checkbox\" name=\"M" + ds.Tables[0].Rows[i]["MID"].ToString() + "\" />" + ds.Tables[0].Rows[i]["MName"].ToString() + "</td></tr>");
                    if (dd != null && dd.Tables[0].Rows.Count > 0)
                    {
                        sb.Append("<tr ><td>");
                        for (int j = 0; j < dd.Tables[0].Rows.Count; j++)
                        {
                            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"CB" + dd.Tables[0].Rows[j]["MID"].ToString() + "\" type=\"checkbox\" onclick=\"chc(CB" + dd.Tables[0].Rows[j]["MID"].ToString() + ",CB" + ds.Tables[0].Rows[i]["MID"].ToString() + ")\" name=\"M" + dd.Tables[0].Rows[j]["MID"].ToString() + "*M" + ds.Tables[0].Rows[i]["MID"].ToString() + "\" />" + dd.Tables[0].Rows[j]["MName"].ToString() + "");
                            if ((j + 1) % 7== 0)
                            {
                                sb.Append("<br/>");
                            }
                        }
                        sb.Append("</td></tr>");
                    }
                }
                sb.Append("<tr><td align=\"center\"> <input id=\"Button1\" type=\"button\" value=\"确定\" class=\"btn\"  onclick=\"Sub(managetype,membertype)\"/></td></tr></table>");
            }
        }
        span1.InnerHtml = sb.ToString();

    }
    [AjaxPro.AjaxMethod]
    public string getName(string managetype, string membergradeid)
    {

        Tz888.BLL.ManageSystem.CompetenceTabBLL bll = new Tz888.BLL.ManageSystem.CompetenceTabBLL();
        DataSet ds = bll.getCompetenceFatherList("PCode", "SystemPermissionTab", "where ManageTypeID='" + managetype + "' and MemberGradeID='" + membergradeid + "'");
        string str = "";
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            str = ds.Tables[0].Rows[0]["PCode"].ToString();

        }


        return str;
    }
    [AjaxPro.AjaxMethod]
    public int Competence_Update(string ManageTypeID, string MemberGradeID, string PCode)
    {

        Tz888.BLL.ManageSystem.CompetenceTabBLL bll = new Tz888.BLL.ManageSystem.CompetenceTabBLL();
        return bll.Competence_Update(ManageTypeID, MemberGradeID, PCode);
    }
}
