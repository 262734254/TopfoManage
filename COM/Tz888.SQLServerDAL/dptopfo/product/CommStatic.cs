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
        #region 产品优势
        /// <summary>
        /// 产品优势
        /// desgin by longbin
        /// 根据用户名获取产品优势（index）
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
        #region 投资成本
        /// <summary>
        /// 投资成本
        ///author: desgin by longbin
        ///createdate: 2011-05-09
        ///description: 根据用户名获取投资成本（index）
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
        #region 优惠政策
        /// <summary>
        /// 优惠政策
        ///author: desgin by longbin
        ///createdate: 2011-05-09
        ///description: 根据用户名获取优惠政策（index）
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
                str.Append("<a target='_blank' href='http://" + loginName + ".topfo.com/Preferentialpolicies.htm'>[详细]</a></p>");

                //str.Append("</ul>");
            }
            return str.ToString();
        }
        #endregion
        #region 园区特色
        /// <summary>
        /// 园区特色
        ///author: desgin by longbin
        ///createdate: 2011-05-09
        ///description: 根据用户名获取园区特色（index）
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
        /// 作用：友情链接静态生成
        /// 参数：用户名
        /// 作者：颜品庄
        /// 日期：2011-05-09
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
        /// 作用：投资环境链接静态生成
        /// 参数：用户名
        /// 作者：颜品庄
        /// 日期：2011-05-09
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
        /// 作用：相册的图片展示静态生成
        /// 参数：用户名
        /// 作者：颜品庄
        /// 日期：2011-05-09
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
        /// 作用：区域概况的展示静态生成
        /// 参数：用户名
        /// 作者：颜品庄
        /// 日期：2011-05-10
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetAreaList(string loginName)
        {
            GZS.DAL.AreaTabDAL dal = new AreaTabDAL();
            GZS.Model.AreaTab model = dal.GetModelCountByLogName(loginName);
            StringBuilder ste = new StringBuilder();

            ste.Append("<p>" + StrLength(NoHTML(model.Chineseintroduced.Trim()), 84) + "<a target=\"_blank\" href=http://" + loginName + ".topfo.com/" + model.Htmlurl + ">[详细]</a></p>");

            return ste.ToString().Trim();
        }
        /// <summary>
        /// 作用：去掉HTML标签
        /// 参数：含有HTML标签的字符串
        /// 作者：颜品庄
        /// 日期：2011-05-12
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public string NoHTML(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring) == true)
            {
                return "";
            }
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
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
            //防止有漏掉的HTML代码
            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /// <summary>
        /// 作用：新闻资讯概况的展示静态生成
        /// 参数：用户名
        /// 作者：颜品庄
        /// 日期：2011-05-10
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

        //截取字符用
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
