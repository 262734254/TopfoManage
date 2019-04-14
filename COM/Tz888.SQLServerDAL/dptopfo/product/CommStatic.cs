using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GZS.DAL.Invest;
using GZS.DAL.Park;
using GZS.DAL.policy;
using GZS.Model.policy;
using System.Web;
using System.Text.RegularExpressions;
namespace GZS.DAL.product
{
    public class CommStatic
    {
        #region ��Ʒ����
        /// <summary>
        /// ��Ʒ����
        /// desgin by longbin
        /// �����û�����ȡ��Ʒ���ƣ�index��
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetListUIByloginName(string loginName)
        {
            ProductDominDAL dal = new ProductDominDAL();
            StringBuilder str = new StringBuilder();
            DataSet ds = dal.GetList(" loginName='" + loginName + "'");
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {

                str.Append("<ul>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    str.Append("<li><a target='_blank' href='http://" + loginName + ".topfo.com/industry.htm'>");
                    str.Append(dr["productname"].ToString());
                    str.Append("</a></li>");
                }
                str.Append("</ul>");
            }
            return str.ToString();
        }
        #endregion
        #region Ͷ�ʳɱ�
        /// <summary>
        /// Ͷ�ʳɱ�
        ///author: desgin by longbin
        ///createdate: 2011-05-09
        ///description: �����û�����ȡͶ�ʳɱ���index��
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetInvestListUIByLoginName(string loginName)
        {
           // TzchildTypDAL dal = new TzchildTypDAL();
            TzbigTypeDAL dal = new TzbigTypeDAL();
            StringBuilder str = new StringBuilder();
            //DataSet ds = dal.GetList(" loginName='" + loginName + "'");
            DataSet ds = dal.GetList("");
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {

                str.Append("<ul>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    string str1 = "";
                    if (dr["tztypeName"].ToString().Length > 5)
                    {
                        str1 = dr["tztypeName"].ToString().Substring(0, 5) + "..";

                    }
                    else
                    {
                        str1 = dr["tztypeName"].ToString();

                    }
                    str.Append("<li><a target='_blank' href='http://" + loginName + ".topfo.com/cost.htm'>");
                    str.Append(str1);
                    str.Append("</a></li>");
                }
                str.Append("</ul>");
            }
            return str.ToString();
        }
        #endregion
        #region �Ż�����
        /// <summary>
        /// �Ż�����
        ///author: desgin by longbin
        ///createdate: 2011-05-09
        ///description: �����û�����ȡ�Ż����ߣ�index��
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetPolicyListUIByLoginName(string loginName)
        {
            PolicyDAL dal = new PolicyDAL();
            PolicyModel model = new PolicyModel();
            StringBuilder str = new StringBuilder();
            model = dal.GetPolicyByName(loginName);
            if (model != null)
            {

                //str.Append("<ul>");
                string str1 = "";
                if (NoHTML(model.Chineseintroduced).Length > 82)
                {
                    str1 = NoHTML(model.Chineseintroduced).Substring(0, 82) + "...";
                }
                else
                {
                    str1 = NoHTML(model.Chineseintroduced);

                }
                str.Append("<p>" + str1);
                str.Append("<a target='_blank' href='http://" + loginName + ".topfo.com/Preferentialpolicies.htm'>[��ϸ]</a></p>");

                //str.Append("</ul>");
            }
            return str.ToString();
        }
        #endregion
        #region ԰����ɫ
        /// <summary>
        /// ԰����ɫ
        ///author: desgin by longbin
        ///createdate: 2011-05-09
        ///description: �����û�����ȡ԰����ɫ��index��
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetParkListUIByLoginName(string loginName)
        {
            ParkInfoDAL dal = new ParkInfoDAL();
            StringBuilder str = new StringBuilder();
            DataSet ds = dal.GetList(" loginName='" + loginName + "'");
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {

                str.Append("<ul>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    str.Append("<li><a target='_blank' href='http://" + loginName + ".topfo.com/Park.htm'>");
                    str.Append(dr["parkName"].ToString());
                    str.Append("</a></li>");
                }
                str.Append("</ul>");
            }
            return str.ToString();
        }
        #endregion
        /// <summary>
        /// ���ã��������Ӿ�̬����
        /// �������û���
        /// ���ߣ���Ʒׯ
        /// ���ڣ�2011-05-09
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetListFriend(string loginName)
        {
            FriendLinkDAL dal = new FriendLinkDAL();
            StringBuilder str = new StringBuilder();
            List<GZS.Model.FriendLink> list = dal.GetModelList(loginName);
            str.Append("<ul>");
            for (int i = 0; i < list.Count; i++)
            {
                if (i < 18)
                {
                    string child = "";
                    if (list[i].Linkname.Length>10)
                    {
                        child = list[i].Linkname.Substring(0, 10);
                    }
                    else
                    {
                        child = child = list[i].Linkname;
                    }
                    str.Append("<li><a target=\"_blank\" href=" + list[i].Linkurl + ">" + child + "</a></li>");
                }
            }
            str.Append("</ul>");
            return str.ToString().Trim();


        }
        /// <summary>
        /// ���ã�Ͷ�ʻ������Ӿ�̬����
        /// �������û���
        /// ���ߣ���Ʒׯ
        /// ���ڣ�2011-05-09
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetEnvironmenttab(string loginName)
        {
            EnvironmentTypeDAL dal = new EnvironmentTypeDAL();
            StringBuilder str = new StringBuilder();
            List<GZS.Model.EnvironmentTypeM> list = dal.GetAllType();
            str.Append("<ul>");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].EnvironmentTypeID == 5)
                {

                }
                else if (list[i].EnvironmentTypeID == 7)
                {

                }
                else
                {
                    if (i < 10)
                    {
                        str.Append("<li><a target=\"_blank\" href=Investmentenvironment.htm>" + list[i].EnvironmentTypeName + "</a></li>");
                    }
                }
            }
            str.Append("</ul>");
            return str.ToString().Trim();

        }
        /// <summary>
        /// ���ã�����ͼƬչʾ��̬����
        /// �������û���
        /// ���ߣ���Ʒׯ
        /// ���ڣ�2011-05-09
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetImageList(string loginName)
        {
            ImageTabMDAL dals = new ImageTabMDAL();
            ImageUrlTabMDAL dal = new ImageUrlTabMDAL();
            List<GZS.Model.ImageUrlTabM> list = dal.GetAlls(loginName);
            StringBuilder ste = new StringBuilder();
            ste.Append("<ul>");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    if (i < 6)
                    {
                        GZS.Model.ImageTabM dsd = dals.GetModel(Convert.ToInt32(list[i].Imageid));
                        List<GZS.Model.ImageUrlTabM> lists = dal.GetAllByImageIds(Convert.ToInt32(list[i].Imageid));
                        if (lists.Count > 0)
                        {
                            string imagetu = lists[0].Imagepath.Trim();
                            string miaoshu = list[i].imgexplain;
                            ste.Append("<li><a target=\"_blank\" href=\"http://" + loginName + ".topfo.com/" + dsd.Htmlurl + "\"><img src=\" http://dp.topfo.com/img/" + loginName + "/" + imagetu + "\" width=\"134\" alt=\"" + miaoshu + "\" height=\"92\" id=\"placeholder\"  /></a>  </li>");
                            ste.Append("<p><a target=\"_blank\" href=\"http://" + loginName + ".topfo.com/" + dsd.Htmlurl + "\">" + miaoshu + "</a></p>");
                        }
                    }
                }
            }
            ste.Append("</ul>");
            return ste.ToString().Trim();
        }

        /// <summary>
        /// ���ã�����ſ���չʾ��̬����
        /// �������û���
        /// ���ߣ���Ʒׯ
        /// ���ڣ�2011-05-10
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetAreaList(string loginName)
        {
            GZS.DAL.AreaTabDAL dal = new AreaTabDAL();
            GZS.Model.AreaTab model = dal.GetModelCountByLogName(loginName);
            StringBuilder ste = new StringBuilder();

            ste.Append("<p>" + StrLength(NoHTML(model.Chineseintroduced.Trim()), 84) + "<a target=\"_blank\" href=http://" + loginName + ".topfo.com/" + model.Htmlurl + ">[��ϸ]</a></p>");

            return ste.ToString().Trim();
        }
        /// <summary>
        /// ���ã�ȥ��HTML��ǩ
        /// ����������HTML��ǩ���ַ���
        /// ���ߣ���Ʒׯ
        /// ���ڣ�2011-05-12
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public string NoHTML(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring) == true)
            {
                return "";
            }
            //ɾ���ű�
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //ɾ��HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            //��ֹ��©����HTML����
            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /// <summary>
        /// ���ã�������Ѷ�ſ���չʾ��̬����
        /// �������û���
        /// ���ߣ���Ʒׯ
        /// ���ڣ�2011-05-10
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetNewList(string loginName)
        {
            GZS.DAL.news.NewsTabDAL dal = new GZS.DAL.news.NewsTabDAL();
            List<GZS.Model.news.NewsTab> lists = dal.GetNewsTabAllByUserName(loginName);

            StringBuilder ste = new StringBuilder();
            ste.Append("<ul>");
            for (int i = 0; i < lists.Count; i++)
            {

                if (i < 6)
                {
                    ste.Append("<li><a href='http://news.topfo.com/" + lists[i].Urlhtml + "' target=\"_blank\">" + StrLength(lists[i].NTitle.ToString().Trim(), 14) + "</a></li>");
                }
            }
            ste.Append("</ul>");
            return ste.ToString().Trim();
        }

        //��ȡ�ַ���
        protected string StrLength(object title, int count)
        {
            string name = "";
            name = title.ToString();
            if (name.Length > count)
            {
                name = name.Substring(0, count) + "...";
            }
            return name;
        }
    }
}
