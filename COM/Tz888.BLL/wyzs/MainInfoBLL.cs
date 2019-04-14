using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.wyzs;
using Tz888.SQLServerDAL.wyzs;
using System.Data;

namespace Tz888.BLL.wyzs
{
    public class MainInfoBLL
    {
        private readonly MainInfoDAL dal = new MainInfoDAL();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="MainInfo"></param>
        /// <returns></returns>
        public bool Add(MainInfoTab MainInfo,DetailTab Detail)
        {
            return dal.Add(MainInfo, Detail);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="MainInfo"></param>
        /// <returns></returns>
        public bool Modify(MainInfoTab MainInfo,DetailTab Detail)
        {
            return dal.Modify(MainInfo, Detail);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id">Id(多个ID以逗号分隔)</param>
        /// <returns></returns>
        public bool Delete(string MainId)
        {
            return dal.Delete(MainId);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <returns></returns>
        public DataSet GetDetailById(string MainId)
        {
            return dal.GetDetailById(MainId);
        }

        public DataTable GetTradeShowList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            return dal.GetTradeShowList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrent, PageSize, ref TotalCount);
        }
    }
}
