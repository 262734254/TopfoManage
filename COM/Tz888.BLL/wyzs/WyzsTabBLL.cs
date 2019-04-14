using System;
using System.Data;
using System.Collections.Generic;
using Tz888.BLL.wyzs;
namespace Tz888.BLL.wyzs
{
	/// <summary>
	/// WyzsTabBLL
	/// </summary>
	public partial class WyzsTabBLL
	{
        private readonly Tz888.SQLServerDAL.wyzs.WyzsTabDAL dal = new Tz888.SQLServerDAL.wyzs.WyzsTabDAL();
		public WyzsTabBLL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tz888.Model.wyzs.WyzsModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Tz888.Model.wyzs.WyzsModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tz888.Model.wyzs.WyzsModel GetModel(int id)
		{
			
			return dal.GetModel(id);
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
        public List<Tz888.Model.wyzs.WyzsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Tz888.Model.wyzs.WyzsModel> DataTableToList(DataTable dt)
		{
            List<Tz888.Model.wyzs.WyzsModel> modelList = new List<Tz888.Model.wyzs.WyzsModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tz888.Model.wyzs.WyzsModel model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tz888.Model.wyzs.WyzsModel();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.title=dt.Rows[n]["title"].ToString();
					if(dt.Rows[n]["typeid"].ToString()!="")
					{
						model.typeid=int.Parse(dt.Rows[n]["typeid"].ToString());
					}
					model.type=dt.Rows[n]["type"].ToString();
					model.htmlurl=dt.Rows[n]["htmlurl"].ToString();
                    model.status = dt.Rows[n]["status"].ToString();
                    model.descript = dt.Rows[n]["descript"].ToString();
					if(dt.Rows[n]["orderid"].ToString()!="")
					{
						model.orderid=int.Parse(dt.Rows[n]["orderid"].ToString());
					}
                    if (dt.Rows[n]["pageAddress"].ToString() != "")
					{
                        model.pageAddress = int.Parse(dt.Rows[n]["pageAddress"].ToString());
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

