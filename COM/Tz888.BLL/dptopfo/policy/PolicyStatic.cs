using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GZS.Model.policy;
using GZS.DAL.policy;
using System.Configuration;
using GZS.DAL.product;
using GZS.DAL.Menu;
namespace GZS.BLL.policy
{
    public class PolicyStatic
    {
        PolicyDAL dal = new PolicyDAL();
        string PolicyPath = ConfigurationManager.AppSettings["PolicySuccse"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["PolicyTemplate"].ToString(); //其他成功案例模版存放位置
        string PolicyRightSuccse = ConfigurationManager.AppSettings["PolicyRightSuccse"].ToString(); //成功案例生成页面存放位置
        string PolicyRightTem = ConfigurationManager.AppSettings["PolicyRight"].ToString(); //其他成功案例模版存放位置

        public int StaticHtml(int id, string loginName)
        {

            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;
                PolicyModel policyModel = new PolicyModel();
                if (id == 0)
                {
                    policyModel = dal.GetPolicyByName(loginName);
                }
                else
                {
                    policyModel = dal.GetModel(id);
                }

                TempSoure = TempSoure.Replace("$PolicyID$", policyModel.policyId.ToString().Trim());
                TempSoure = TempSoure.Replace("$ChinaName$", policyModel.Chineseintroduced.ToString().Trim());
                TempSoure = TempSoure.Replace("$englishName$", policyModel.Englishintroduction.ToString().Trim());
                TempSoure = TempSoure.Replace("$loginName$", loginName);
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginName));
                if (string.IsNullOrEmpty(policyModel.htmlUrl))
                {
                    //policyModel.htmlUrl = policyModel.loginName + "/policy" + policyModel.loginName + ".htm";
                    policyModel.htmlUrl = "Preferentialpolicies.htm";
                }
                string htmlFile = "Preferentialpolicies.htm";
                string wenjian = PolicyPath + loginName;
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
        public int StaticHtml(string loginName)
        {

            try
            {
                string TempFileName = PolicyRightTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;
                CommStatic comm = new CommStatic();
                TempSoure = TempSoure.Replace("$Policy$", comm.GetPolicyListUIByLoginName(loginName));

                string htmlFile = "PolicyRight.htm";
                string wenjian = PolicyRightSuccse + loginName;
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
    }
}
