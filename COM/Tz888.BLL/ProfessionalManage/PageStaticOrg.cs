using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Tz888.Model.ProfessionalManage;
using Tz888.BLL.ProfessionalManage;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web;

namespace Tz888.BLL.ProfessionalManage
{
   public class PageStaticOrg
    {
        string ProPath = ConfigurationManager.AppSettings["PSAppPath"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["ORGTem"].ToString(); //其他成功案例模版存放位置



        ProfessionalinfoBLL infoBll = new ProfessionalinfoBLL();
        ProfessionalLinkBLL linkBll = new ProfessionalLinkBLL();
        ProfessionalPleaseBLL viewBll = new ProfessionalPleaseBLL();
        OrganizationTypebLL typeBll = new OrganizationTypebLL();
        ProfessionalinfoTab infoModel = new ProfessionalinfoTab();
        ProfessionalLink linkModel = new ProfessionalLink();
        ProfessionalPlease plModel = new ProfessionalPlease();
        ProfessionalTypeTbl typeModel = new ProfessionalTypeTbl();
        public int StaticHtml(int professionalid)
        {
            try
            {
                infoModel = infoBll.GetModel(professionalid);
                linkModel = linkBll.GetModel(professionalid);
                plModel = viewBll.GetModel(professionalid);
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;
                string ProviceName = linkBll.GetProvinceNameByCode(plModel.ProvinceID.ToString()).Trim();//区域
                string typeName = typeBll.GetList("institutionsID=" + plModel.institutionsID).Tables[0].Rows[0]["TypeName"].ToString();   //机构类别
                if (ProviceName.Trim() == "")
                {
                    ProviceName = "中国";
                }
                
                string price = string.Empty;
                if (infoModel.chargeId == 0)
                {
                    price = "免费资源";
                }
                else
                {
                    price = infoModel.price + "元";
                }
                string xiangxi = GetTop3Data(plModel.ProvinceID.ToString());
                string desc = Gettop6Data();
                TempSoure = TempSoure.Replace("$ProfessionalID$", infoModel.ProfessionalID.ToString().Trim());
                TempSoure = TempSoure.Replace("$title$", infoModel.Titel.ToString().Trim());
                TempSoure = TempSoure.Replace("$AreaName$", ProviceName);
                TempSoure = TempSoure.Replace("$typeName$", typeName);
                TempSoure = TempSoure.Replace("$Enterprisesize$", plModel.Enterprisesize);//企业规模
                TempSoure = TempSoure.Replace("$funds$", plModel.funds);//注册资金
                TempSoure = TempSoure.Replace("$CreateTime$", plModel.companydate.ToString("yyyy-MM-dd"));//创建时间
                TempSoure = TempSoure.Replace("$turnover$", plModel.turnover);//营业额
                TempSoure = TempSoure.Replace("$charge$", price); //资源类型
                TempSoure = TempSoure.Replace("$Content1$", plModel.description.ToString());
                TempSoure = TempSoure.Replace("$KeyWord$", plModel.keywords.ToString().Trim());
                TempSoure = TempSoure.Replace("$DisplayTitle$", plModel.title.ToString().Trim());

                //TempSoure = TempSoure.Replace("$CompanyName$", linkModel.CompanyName.ToString().Trim());
                TempSoure = TempSoure.Replace("$Content$", xiangxi);//相关项目信息
                TempSoure = TempSoure.Replace("$Content2$", desc);
                string inPathTo = "/dservice";
                if (string.IsNullOrEmpty(infoModel.htmlUrl))
                {
                    infoModel.htmlUrl = "dservice/" + DateTime.Now.ToString("yyyyMM") + "/dservice" + DateTime.Now.ToString("yyyyMMdd") + "_" + professionalid + ".shtml";
                }
                string htmlFile = infoModel.htmlUrl.ToString().Trim();
                string[] html = htmlFile.Split('/');
                string[] nn = html[2].Split('_');
                string cc = nn[0].Substring(nn[0].Length - 8);

                string folder = ProPath + html[1].Replace("dservice", "");
                if (Directory.Exists(folder) == false)
                {
                    Directory.CreateDirectory(folder);
                }
                string htmlpaths = folder + inPathTo + cc + "_" + professionalid + ".shtml";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
       protected string Gettop6Data()
       {
           
           StringBuilder sb = new StringBuilder();
           sb.Append("<div class=\"con3_tit\"><ul>");
           DataTable dt = viewBll.GetTop3ModelByProvinceID(6, " auditId=1 and typetID=2 order by createdate");
           if ((dt != null) && dt.Rows.Count > 0)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   sb.Append("<li>·<a on href='http://www.topfo.com/" + dr["htmlurl"].ToString() + "' target=\"_blank\">");
                   sb.Append(dr["titel"].ToString());
                   sb.Append("</a></li>");
               }
           }
           sb.Append("</ul>");
           sb.Append(" <div class=\"clear\"></div>");
           sb.Append("</div>");
           return sb.ToString();

       }
        public string GetTop3Data(string proviceID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tab1\">");
            sb.Append("<tr>");
            sb.Append("<td class=\"xiangguanxinxi\">资金标题</td>");
            sb.Append("<td class=\"xiangguanxinxi\">机构类别</td>");
            sb.Append("<td class=\"xiangguanxinxi\">所在地域</td>");
            sb.Append("<td class=\"xiangguanxinxi\">创建时间</td>");
            sb.Append("<td class=\"xiangguanxinxi\">注册资金</td>");
            sb.Append("</tr>");
            DataTable dt = viewBll.GetTop3ModelByProvinceID(3, " auditId=1 and typetID=2 and ProvinceID='" + proviceID + "'");
            if ((dt != null) && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string ProviceName = linkBll.GetProvinceNameByCode(dr["provinceId"].ToString());
                    string typeName = typeBll.GetList(" institutionsID=" + dr["institutionsID"].ToString()).Tables[0].Rows[0]["TypeName"].ToString();   //机构类别
                    
                    
                    sb.Append("<tr ><td align=\"center\">");
                    sb.Append("<a href='http://www.topfo.com/" + dr["htmlurl"].ToString() + "' target=\"_blank\">");
                    sb.Append(dr["Titel"].ToString());
                    sb.Append("</a></td>");
                    sb.Append("<td align=\"center\">"); sb.Append(typeName); sb.Append("</td>");
                    sb.Append("<td align=\"center\">"); sb.Append(ProviceName); sb.Append("</td>");
                    sb.Append("<td align=\"center\">"); sb.Append(Convert.ToDateTime(dr["CreateDate"]).ToString("yyyy-MM-dd")); sb.Append("</td>");
                    sb.Append("<td align=\"center\">"); sb.Append(dr["funds"].ToString()); sb.Append("</td></tr>");
                }
            }
            else
            {
                sb.Append("<tr><td  align=\"center\">"); sb.Append("暂无数据"); sb.Append("</td>");
                sb.Append("<td align=\"center\">"); sb.Append("暂无数据"); sb.Append("</td>");
                sb.Append("<td align=\"center\">"); sb.Append("暂无数据"); sb.Append("</td>");
                sb.Append("<td align=\"center\">"); sb.Append("暂无数据"); sb.Append("</td>");
                sb.Append("<td align=\"center\">"); sb.Append("暂无数据"); sb.Append("</td></tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }

    }
}
