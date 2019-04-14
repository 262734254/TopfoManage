using System;
using System.Data;
using System.Collections.Generic;
using Tz888.BLL.wyzs;
namespace Tz888.BLL.wyzs
{
	/// <summary>
	/// WyzsTypeBLL
	/// </summary>
	public partial class WyzsTypeBLL
	{
        private readonly Tz888.SQLServerDAL.wyzs.WyzsTypeDAL dal = new Tz888.SQLServerDAL.wyzs.WyzsTypeDAL();
		public WyzsTypeBLL()
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
		public int  Add(Tz888.Model.wyzs.WyzsType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Tz888.Model.wyzs.WyzsType model)
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
        public Tz888.Model.wyzs.WyzsType GetModel(int id)
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
        public List<Tz888.Model.wyzs.WyzsType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Tz888.Model.wyzs.WyzsType> DataTableToList(DataTable dt)
		{
            List<Tz888.Model.wyzs.WyzsType> modelList = new List<Tz888.Model.wyzs.WyzsType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tz888.Model.wyzs.WyzsType model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tz888.Model.wyzs.WyzsType();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.typeName=dt.Rows[n]["typeName"].ToString();
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

