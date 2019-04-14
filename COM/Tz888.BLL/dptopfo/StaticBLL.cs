using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL
{
    public class StaticBLL
    {
        Static st = new Static();

        Tz888.SQLServerDAL.SearchStatic.SearchStatic stat = new Tz888.SQLServerDAL.SearchStatic.SearchStatic();

        public int StaticHtml(string Field, string num)
        {
           
           return st.StaticHtml(Field,num);
        }
        public string SelMerchant()
        {
            return st.SelMerchant();
        }
        public string SelProject()
        {
            return st.SelProject();
        }
        public string SelCapital()
        {
            return st.SelCapital();
        }
        public string SelFuWu()
        {
            return st.SelField();
        }

        #region 最新融资项目
        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
        public string SelProject1()
        {
            return stat.SelProject();
        }
        #endregion

        #region 最新投资项目
        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
        public string SelCapital1()
        {
            return stat.SelCapital();
        }
        #endregion

        #region 最新招商项目
        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
        public string SelMerchant1()
        {
            return stat.SelMerchant();
        }
        #endregion

 
    }
}
