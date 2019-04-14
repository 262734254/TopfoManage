using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Company;

namespace Tz888.IDAL.Company
{
    public interface ICompanyMade
    {
        /// <summary>
        /// 根据编号查找所对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyMadeModel SelGetMade(int id);
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateMade(CompanyMadeModel model, int id);
        /// <summary>
        /// 删除广告定制信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int MadeDelete(int id);
        /// <summary>
        /// 删除窄告信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int NarrowDelete(int id);
        /// <summary>
        /// 查询所对应的窄告条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        NarrowModel SelNarrow(int id);
    }
}
