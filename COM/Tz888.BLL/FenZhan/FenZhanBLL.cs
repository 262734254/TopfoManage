using System;
using System.Collections.Generic;
using System.Text;
using Tz888.SQLServerDAL.FenZhan;
using Tz888.Model.FenZhan;
using System.Data;

namespace Tz888.BLL.FenZhan
{
    public class FenZhanBLL
    {
        private readonly FenZhanDAL dal = new FenZhanDAL();
        /// <summary>
        /// 发布分站
        /// </summary>
        /// <param name="Model">实体</param>
        /// <returns></returns>
        public bool Add(FenZhanModel Model)
        {
            return dal.Add(Model);
        }

        /// <summary>
        /// 修改分站
        /// </summary>
        /// <param name="Model">实体</param>
        public bool Modfiy(FenZhanModel Model)
        {
            return dal.Modfiy(Model);
        }

        /// <summary>
        /// 根据ID获取当前分站信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>DataTable</returns>
        public DataTable GetFenZhanById(string Id)
        {
            return dal.GetFenZhanById(Id);
        }

        /// <summary>
        /// 获取所有分站
        /// </summary>
        /// <returns></returns>
        public DataTable GetFenZhanList()
        {
            return dal.GetFenZhanList();
        }

        /// <summary>
        /// 修改网站状态
        /// </summary>
        /// <param name="SiteState">状态码(SiteState=0->关闭,SiteState=1->开启)</param>
        /// <returns></returns>
        public bool ModfiySiteState(string SiteState)
        {
            return dal.ModfiySiteState(SiteState);
        }

        /// <summary>
        /// 获取分站名称
        /// </summary>
        /// <param name="ProviceID"></param>
        /// <returns></returns>
        public string GetFenZhanName(string ProviceID)
        {
            return dal.GetFenZhanName(ProviceID);
        }
    }
}
