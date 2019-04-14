using System;
using System.Data;
using Tz888.Model.Info;
namespace Tz888.IDAL.Recomm
{
	/// <summary>
	/// 接口层IrecommResourceIDAL 
	/// </summary>
	public interface recommResourceIDAL
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int RecommID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Tz888.Model.Recomm.recommResourceM model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        bool Update(Tz888.Model.Recomm.recommResourceM model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int RecommID);
		bool DeleteList(string RecommIDlist );
        /// <summary>
        /// 推荐 从主表中获取数据 title ,url
        /// 连接的数据库不同
        /// </summary>
        /// <param name="infoid"></param>
        /// <returns></returns>
        DataSet GetTitleAndUrlByInfoId(string infoid);
         /// <summary>
        /// 由于数据已经推荐过，只需更新时间
        /// </summary>
        /// <returns></returns>
        int UpdateTimeByRecommId(int recommId);
        /// <summary>
        /// 根据条件查询是否存在数据
        /// </summary>
        /// <param name="RecommTypeID">资源类型1,招商、融资、投资2,人才3,机构4, 服务</param>
        /// <param name="RecommToUser">推荐用户</param>
        /// <param name="ResourecId">推荐资源ID</param>
        /// <returns></returns>
        int ExistsByWhere(int RecommTypeID, string RecommToUser, long ResourecId);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Tz888.Model.Recomm.recommResourceM GetModel(int RecommID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	}
}
