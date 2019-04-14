using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.Model.Company;
using Tz888.IDAL.Company;
using Tz888.SQLServerDAL.Company;

namespace Tz888.BLL.Company
{
    public class CompanyMadeBLL
    {
        private readonly ICompanyMade dal = DataAccess.CreateCompanyMade();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyMadeModel SelGetMade(int id)
        {
            return dal.SelGetMade(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateMade(CompanyMadeModel model, int id)
        {
            return dal.UpdateMade(model,id);
        }
         /// <summary>
        /// 删除广告定制信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int MadeDelete(int id)
        {
            return dal.MadeDelete(id);
        }


        /// <summary>
        /// 删除窄告信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int NarrowDelete(int id)
        {
            return dal.NarrowDelete(id); ;
        }
        /// <summary>
        /// 查询所对应的窄告条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NarrowModel SelNarrow(int id)
        {
            return dal.SelNarrow(id);
        }
    }
}
