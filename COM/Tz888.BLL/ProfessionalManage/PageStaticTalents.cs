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
    public class PageStaticTalents
    {
        string ProPath = ConfigurationManager.AppSettings["PSAppPath"].ToString(); //�ɹ���������ҳ����λ��
        string CasesTem = ConfigurationManager.AppSettings["TALTem"].ToString(); //�����ɹ�����ģ����λ��
        ProfessionalinfoBLL infoBll = new ProfessionalinfoBLL();
        ProfessionalLinkBLL linkBll = new ProfessionalLinkBLL();
        ProfessionaltalentsBLL viewBll = new ProfessionaltalentsBLL();
        OrganizationTypebLL typeBll = new OrganizationTypebLL();
        ProfessionalTypeBLL typeBll1 = new ProfessionalTypeBLL();
        ProfessionalTalentsType talentsType = new ProfessionalTalentsType();
        ProfessionalinfoTab infoModel = new ProfessionalinfoTab();
        ProfessionalLink linkModel = new ProfessionalLink();
        Professionaltalents plModel = new Professionaltalents();
        ProfessionalTypeTbl typeModel = new ProfessionalTypeTbl();
        public int StaticHtml(int professionalid)
        {
            try
            {
                infoModel = infoBll.GetModel(professionalid);
                linkModel = linkBll.GetModel(professionalid);
                plModel = viewBll.GetModel(professionalid);
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //��ȡģ������
                string TempSoure = Tem;
                string ProviceName = linkBll.GetProvinceNameByCode(plModel.ProvinceID.ToString()).Trim();//����
                //string typeName = typeBll.GetList("institutionsID=" + plModel.institutionsID).Tables[0].Rows[0]["TypeName"].ToString();   //�������
                string typeName = talentsType.GetList("typeID=" + plModel.talentsTypeID).Tables[0].Rows[0]["TypeName"].ToString();   //�˲����
                string Servicetype = typeBll1.GetModel(int.Parse(plModel.servicetypeID.ToString())).typeName;
                if (ProviceName.Trim() == "")
                {
                    ProviceName = "�й�";
                }

                string price = string.Empty;
                if (infoModel.chargeId == 0)
                {
                    price = "�����Դ";
                }
                else
                {
                    price = infoModel.price + "Ԫ";
                }
                string xiangxi = GetTop3Data(plModel.ProvinceID.ToString());
                string desc = Gettop6Data();
                TempSoure = TempSoure.Replace("$ProfessionalID$", infoModel.ProfessionalID.ToString().Trim());
                TempSoure = TempSoure.Replace("$title$", linkModel.UserName.ToString());
                TempSoure = TempSoure.Replace("$AreaName$", ProviceName);
                TempSoure = TempSoure.Replace("$type$", typeName);
                TempSoure = TempSoure.Replace("$typeName$", Servicetype);
                TempSoure = TempSoure.Replace("$position$", plModel.position.ToString());
                TempSoure = TempSoure.Replace("$resume$ ", plModel.resume.ToString());
                TempSoure = TempSoure.Replace("$CreateTime$", plModel.companydate.ToString("yyyy-MM-dd"));//����ʱ��
                TempSoure = TempSoure.Replace("$specialty$", plModel.specialty.ToString());
                TempSoure = TempSoure.Replace("$ScuccCase$ ", plModel.ScuccCase.ToString());
                TempSoure = TempSoure.Replace("$KeyWord$", plModel.keywords.ToString().Trim());
                TempSoure = TempSoure.Replace("$DisplayTitle$", plModel.title.ToString().Trim());
                TempSoure = TempSoure.Replace("$image$", "http://www.topfo.com" + plModel.Images.ToString().Trim());
                TempSoure = TempSoure.Replace("$CompanyName$", linkModel.CompanyName.ToString().Trim());
                TempSoure = TempSoure.Replace("$Content$", xiangxi);//�����Ŀ��Ϣ
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
            DataTable dt = viewBll.GetTop3ModelByProvinceID(6, " auditId=1 and typetID=3 order by createdate");
            if ((dt != null) && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<li>��<a on href='http://www.topfo.com/" + dr["htmlurl"].ToString() + "' target=\"_blank\">");
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
            sb.Append("<td class=\"xiangguanxinxi\">�ʽ����</td>");
            sb.Append("<td class=\"xiangguanxinxi\">�˲����</td>");
            sb.Append("<td class=\"xiangguanxinxi\">���ڵ���</td>");
            sb.Append("<td class=\"xiangguanxinxi\">����ʱ��</td>");
            sb.Append("<td class=\"xiangguanxinxi\">ְλ</td>");
            sb.Append("</tr>");
            DataTable dt = viewBll.GetTop3ModelByProvinceID(3, " auditId=1 and typetID=3 and ProvinceID='" + proviceID + "'");
            if ((dt != null) && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string ProviceName = linkBll.GetProvinceNameByCode(dr["provinceId"].ToString());

                    string typeName = talentsType.GetList("typeID=" + dr["talentsTypeID"].ToString()).Tables[0].Rows[0]["TypeName"].ToString();   //�˲����

                    sb.Append("<tr ><td align=\"center\">");
                    sb.Append("<a href='http://www.topfo.com/" + dr["htmlurl"].ToString() + "' target=\"_blank\">");
                    sb.Append(dr["Titel"].ToString());
                    sb.Append("</a></td>");
                    sb.Append("<td align=\"center\">"); sb.Append(typeName); sb.Append("</td>");
                    sb.Append("<td align=\"center\">"); sb.Append(ProviceName); sb.Append("</td>");
                    sb.Append("<td align=\"center\">"); sb.Append(Convert.ToDateTime(dr["CreateDate"]).ToString("yyyy-MM-dd")); sb.Append("</td>");
                    sb.Append("<td align=\"center\">"); sb.Append(dr["position"].ToString()); sb.Append("</td></tr>");
                }
            }
            else
            {
                sb.Append("<tr><td  align=\"center\">"); sb.Append("��������"); sb.Append("</td>");
                sb.Append("<td align=\"center\">"); sb.Append("��������"); sb.Append("</td>");
                sb.Append("<td align=\"center\">"); sb.Append("��������"); sb.Append("</td>");
                sb.Append("<td align=\"center\">"); sb.Append("��������"); sb.Append("</td>");
                sb.Append("<td align=\"center\">"); sb.Append("��������"); sb.Append("</td></tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }
    }
}