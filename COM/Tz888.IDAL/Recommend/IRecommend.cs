using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Recommend
{
    public interface IRecommend
    {
        /// <summary>
        /// 添加推荐项目
        /// </summary>
        /// <param name="model">推荐项目</param>
        /// <returns></returns>
        bool AddRecommend(Tz888.Model.Recommend.RecommendModel model);

        DataTable GetRecommendDetail(string Id);

        /// <summary>
        /// 修改推荐项目
        /// </summary>
        /// <param name="model">RecommendModel</param>
        /// <returns></returns>
        bool ModfiyRecommend(Tz888.Model.Recommend.RecommendModel model);

        /// <summary>
        /// 删除推荐项目
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        bool DelRecommend(string Id);

        /// <summary>
        /// RecommendList
        /// </summary>
        /// <param name="ObjectName">表/视图</param>
        /// <param name="Key">主键</param>
        /// <param name="ShowFiled">显示字段</param>
        /// <param name="Where">条件</param>
        /// <param name="OrderFiled">排序字段</param>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="PageSize">页码大小</param>
        /// <param name="TotalCount">总条数</param>
        /// <returns></returns>
        DataTable GetRecommendList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled,
          ref int PageCurrent, int PageSize, ref int TotalCount);
    }
}
