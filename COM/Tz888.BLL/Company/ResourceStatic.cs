using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using GZS.BLL.XHIndex;
using GZS.Model.Person;
using System.IO;
namespace Tz888.BLL.Company
{
    public class ResourceStatic
    {
        //��Դ������ҳ
        string PersonTem = ConfigurationManager.AppSettings["PersonTem"].ToString();
        //��Դ��������
        string PersonRZTem = ConfigurationManager.AppSettings["PersonRZTem"].ToString();
        //��Դ����Ͷ��
        string PersonTZTem = ConfigurationManager.AppSettings["PersonTZTem"].ToString();
        //��Դ��������
        string PersonZSTem = ConfigurationManager.AppSettings["PersonZSTem"].ToString();
        //��Դ����רҵ����
        string PersonPSTem = ConfigurationManager.AppSettings["PersonPSTem"].ToString();
        //��Դ������Ѷ
        string PersonZXTem = ConfigurationManager.AppSettings["PersonZXTem"].ToString();
        string PersonImg = ConfigurationManager.AppSettings["PersonImg"].ToString();
        string PersonSuccess = ConfigurationManager.AppSettings["PersonSuccess"].ToString();
        private void StaticHtmls(string loginName)
        {
            #region  ������Ŀ
            string PersonRZ = PersonRZTem.ToString();
            string TempSoure = Compage.Reader(PersonRZ);
            TempSoure = TempSoure.Replace("[userName]", loginName);
            string htmlpaths = PersonSuccess + "lm" + loginName + "\\rzindex.htm";
            if (!Directory.Exists(PersonSuccess + "lm" + loginName))
            {
                Directory.CreateDirectory(PersonSuccess + "lm" + loginName);

            }
            Compage.Writer(htmlpaths, TempSoure);
            #endregion
            #region  Ͷ����Ŀ
            string PersonTZ = PersonTZTem.ToString();
            string TempSoure1 = Compage.Reader(PersonTZ);
            TempSoure1 = TempSoure1.Replace("[userName]", loginName);
            htmlpaths = PersonSuccess + "lm" + loginName + "\\tzindex.htm";
            Compage.Writer(htmlpaths, TempSoure1);
            #endregion

            #region  ������Ŀ
            string PersonZS = PersonZSTem.ToString();
            string TempSoure2 = Compage.Reader(PersonZS);
            TempSoure2 = TempSoure2.Replace("[userName]", loginName);
            htmlpaths = PersonSuccess + "lm" + loginName + "\\zsindex.htm";
            Compage.Writer(htmlpaths, TempSoure2);
            #endregion
            #region  רҵ����
            string PersonPS = PersonPSTem.ToString();
            string TempSoure3 = Compage.Reader(PersonPS);
            TempSoure3 = TempSoure3.Replace("[userName]", loginName);
            htmlpaths = PersonSuccess + "lm" + loginName + "\\psindex.htm";
            Compage.Writer(htmlpaths, TempSoure3);
            #endregion
            #region  ������Ѷ
            string PersonZX = PersonZXTem.ToString();
            string TempSoure4 = Compage.Reader(PersonZX);
            TempSoure4 = TempSoure4.Replace("[userName]", loginName);
            htmlpaths = PersonSuccess + "lm" + loginName + "\\zxindex.htm";
            Compage.Writer(htmlpaths, TempSoure4);
            #endregion
        }
        public void StaticHtml(string LoginName,string Title,string KeyWord,string Descript)
        {
            PersonBLL perbll = new PersonBLL();
            PersonM model = perbll.GetModelByLoginName(LoginName);
            string PersonTems = PersonTem.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            if (model != null)
            {
                string img = "";
                if (string.IsNullOrEmpty(model.img.ToString()))
                {
                    img = "http://www.topfo.com/dservice/image/photo.jpg";
                }
                else
                {

                    img = "http://dp.topfo.com/img/" + LoginName + "/" + model.img.ToString();
                }
                string imgstr = "<img id=\"imgPerson\" src=" + img + " style=\"height:106px;width:155px;border-width:0px;\" />";
                //string strName = model.name + "&nbsp;" + model.birthDay.ToString("yyyy��MM��dd��") + "����&nbsp;" + model.address.ToString();
                string strName = model.name;// +"&nbsp;" + model.birthDay.ToString("yyyy��MM��dd��") + "����&nbsp;" + model.address.ToString();
                TempSoure = TempSoure.Replace("$Name$", strName);
                TempSoure = TempSoure.Replace("[userName]", LoginName);
                TempSoure = TempSoure.Replace("[����ͼƬ]", imgstr);
                TempSoure = TempSoure.Replace("[���޸���]", model.signature.ToString());
                TempSoure = TempSoure.Replace("[���޽���]", SubStr(model.description.ToString(), 185));
                TempSoure = TempSoure.Replace("$Title$", Title.ToString().Trim());
                TempSoure = TempSoure.Replace("$Description$", KeyWord.ToString().Trim());
                TempSoure = TempSoure.Replace("$KeyWords$", Descript.ToString().Trim());
            }
            else
            {
                string img = "http://www.topfo.com/dservice/image/photo.jpg";
                string imgstr = "<img id=\"imgPerson\" src=" + img + " style=\"height:106px;width:155px;border-width:0px;\" />";
                TempSoure = TempSoure.Replace("$Name$", "");
                TempSoure = TempSoure.Replace("[userName]", LoginName);
                TempSoure = TempSoure.Replace("[����ͼƬ]", imgstr);
                TempSoure = TempSoure.Replace("$Title$", Title.ToString().Trim());
                TempSoure = TempSoure.Replace("$Description$", KeyWord.ToString().Trim());
                TempSoure = TempSoure.Replace("$KeyWords$", Descript.ToString().Trim());
            }
            string htmlpaths = PersonSuccess + "lm" + LoginName + "\\index.htm";
            if (!Directory.Exists(PersonSuccess + "lm" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "lm" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);
            StaticHtmls(LoginName);
        }
        private string SubStr(string str, int len)
        {
            string msg = "";
            if (str.Length > len)
            {
                msg = str.Substring(0, len) + "....";
            }
            else
            {
                msg = str.ToString();
            }
            return msg;
        }
    }
}
