using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Invest;
namespace GZS.BLL.Invest
{
	/// <summary>
	/// InvestCost
	/// </summary>
	public class InvestCostBLL
	{
		private readonly GZS.DAL.Invest.InvestCostDAL dal=new GZS.DAL.Invest.InvestCostDAL();
		public InvestCostBLL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Costid)
		{
			return dal.Exists(Costid);
		}
        public bool ExistsName(string loginName)
        {
            return dal.ExistsName(loginName);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GZS.Model.Invest.InvestCostM model)
		{
		return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(InvestCostM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Costid)
		{
			return dal.Delete(Costid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Costidlist )
		{
			return dal.DeleteList(Costidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public InvestCostM GetModel(int Costid)
		{
			
			return dal.GetModel(Costid);
		}
        public GZS.Model.Invest.InvestCostM GetModels(string loginName)
        {
            return dal.GetModels(loginName);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GZS.Model.Invest.InvestCostM> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GZS.Model.Invest.InvestCostM> DataTableToList(DataTable dt)
		{
			List<InvestCostM> modelList = new List<InvestCostM>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GZS.Model.Invest.InvestCostM model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new InvestCostM();
					if(dt.Rows[n]["Costid"].ToString()!="")
					{
						model.Costid=int.Parse(dt.Rows[n]["Costid"].ToString());
					}
					model.loginName=dt.Rows[n]["loginName"].ToString();
					model.Chineseintroduced=dt.Rows[n]["Chineseintroduced"].ToString();
					model.Englishintroduction=dt.Rows[n]["Englishintroduction"].ToString();
					if(dt.Rows[n]["createdate"].ToString()!="")
					{
						model.createdate=DateTime.Parse(dt.Rows[n]["createdate"].ToString());
					}
					if(dt.Rows[n]["hits"].ToString()!="")
					{
						model.hits=int.Parse(dt.Rows[n]["hits"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

