using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Product;
using GZS.DAL.product;
using System.Data;
using System.Configuration;
using System.IO;
using GZS.DAL.Menu;
namespace GZS.BLL.Product
{
    public class StaticProduct
    {
        ProductDominBLL doBll = new ProductDominBLL();
        ProductDominM doM = new ProductDominM();
        string path = ConfigurationManager.AppSettings["UpProductImage"].ToString();
        string ProductPath = ConfigurationManager.AppSettings["ProductSuccse"].ToString(); //成功案例生成页面存放位置
        string ProductTem = ConfigurationManager.AppSettings["ProductTemplate"].ToString(); //其他成功案例模版存放位置
        public int aaaa(string name)
        {
            string htmlpaths = ProductPath + "/aa.html" ;
            Compage.Writer(htmlpaths, "");
            return 1;
        }
        public int StaticHtml(int id, string loginName)
        {
            try
            {
                string TempFileName = ProductTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;

                ProductDominM doma = new ProductDominM();
                if (id==0)
                {
                    doma = doBll.GetProductByName(loginName);
                }
                else
                {
                    doma = doBll.GetModel(id);
                }
               
                if (doma!=null)
                {
                    TempSoure = TempSoure.Replace("$ProductID$", doma.productid.ToString().Trim());
                }
                else
                {
                    string a ="0";
                    TempSoure = TempSoure.Replace("$ProductID$", a);
                }
                string ids = "";
                int scriptId = 0;
                TempSoure = TempSoure.Replace("$typeName$", type(ref ids, ref scriptId, loginName));
                TempSoure = TempSoure.Replace("$loginName$", loginName);
                TempSoure = TempSoure.Replace("$ChinaName$", content(ids, loginName));
                //TempSoure = TempSoure.Replace("$ProductScript$", script(scriptId));
                TempSoure = TempSoure.Replace("$ProductScript$", scriptId.ToString());
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginName));
                if (string.IsNullOrEmpty(doM.htmlurl))
                {
                    doma.htmlurl = "industry.htm";
                    // doma.htmlurl = doma.loginName + "/" + DateTime.Now.ToString("yyyyMMdd") + "_" + id + ".shtml";
                }
                string htmlFile = "industry.htm";
                string wenjian = ProductPath + loginName;
                if (!Directory.Exists(wenjian))
                {
                    Directory.CreateDirectory(wenjian);
                }
                string htmlpaths = wenjian + "/" + htmlFile;
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        private string script(int id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<script language=\"javascript\" type=\"text/javascript\">");
            str.Append("SetBtn('cy'," + id + ")");
            str.Append("</script>");
            return str.ToString();
        }
        private string content(string id, string loginName)
        {
            StringBuilder str = new StringBuilder();
            string[] strId = id.Split(',');
            for (int j = 0; j < strId.Length - 1; j++)
            {
                doM = doBll.GetModel(int.Parse(strId[j]));
                if (doM != null)
                {
                    str.Append("<div id=\"cy_con_" + strId[j] + "\">");
                    str.Append("<div class=\"industry-con1\">");
                    str.Append(doM.Chineseintroduced.ToString() + "</div>");
                    str.Append("<div class=\"industry-con2\">");
                    str.Append(doM.Englishintroduction.ToString() + "</div>");
                    ProductImgBLL imbll = new ProductImgBLL();
                    ProductImgM imM = new ProductImgM();
                    if (doM.productid > 0)
                    {
                        DataSet ds = imbll.GetList(" productid=" + doM.productid);
                        if ((ds != null) && ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr = ds.Tables[0].Rows[i];
                                if (i == 0)
                                {
                                    str.Append("<div class=\"industry-img-left\">");//大图width=\"651\" height=\"399\"
                                    str.Append("<img src=\"http://dp.topfo.com/img/" + loginName + "/" + dr["imgName"].ToString() + "\"  id=\"placeholder" + doM.productid + "\" />");
                                    str.Append("</div>");
                                }
                                else
                                {
                                    str.Append("<div style='display:none;' class=\"industry-img-left\">");//大图width=\"651\" height=\"399\"
                                    str.Append("<img src=\"http://dp.topfo.com/img/" + loginName + "/" + dr["imgName"].ToString() + "\"  style=\"display:none\"  id=\"placeholder" + doM.productid + "\" />");
                                    str.Append("</div>");
                                }

                            }
                        }
                        if ((ds != null) && ds.Tables[0].Rows.Count > 0)
                        {
                            str.Append("<div class=\"industry-img-right\" id=\"ISL_Cont_1\"> <ul>");
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr = ds.Tables[0].Rows[i];
                                str.Append("<li>");
                                str.Append("<a href=\"http://dp.topfo.com/img/" + loginName + "/" + dr["imgName"].ToString() + "\"  onmouseover=\"showPic(this," + doM.productid + ");return false;\" alt='点击查看大图' target=\"_blank\">");
                                str.Append("<img alt='点击查看大图' src=\"http://dp.topfo.com/img/" + loginName + "/" + dr["imgName"].ToString() + "\" />");
                                str.Append("</a></li>");
                            }
                            str.Append("</ul></div>");
                        }
                    }
                    str.Append("</div>");
                }
                else
                {
                    str.Append("<div id=\"cy_con_" + strId[j] + "\">");
                    str.Append("暂无数据");
                    str.Append("</div>");
                }
            }
            return str.ToString();
        }
        private string type(ref string id, ref int scriptId, string loginname)
        {
            //ProductTypeBLL protype = new ProductTypeBLL();
            DataSet ds = doBll.GetList("loginname='" + loginname + "'");
            //DataSet ds = protype.GetList("");
            StringBuilder str = new StringBuilder();
            if ((ds != null) && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    if (i == 0)
                    {
                        scriptId = int.Parse(dr["productid"].ToString());
                    }
                    id += int.Parse(dr["productid"].ToString()) + ",";
                    int ids = int.Parse(dr["productid"].ToString());
                    if (i == 0)
                    {
                        str.Append("<li class=\"btn_on\" id=\"cy_btn_" + ids + "\" onmousemove=\"SetBtn('cy'," + ids + ")\";>");
                        str.Append(dr["productName"].ToString());
                        str.Append("</li>");
                    }
                    else
                    {
                        str.Append("<li id=\"cy_btn_" + ids + "\" onmousemove=\"SetBtn('cy'," + ids + ")\";>");
                        str.Append(dr["productName"].ToString());
                        str.Append("</li>");
                    }
                }
            }
            return str.ToString();
        }
    }
}
