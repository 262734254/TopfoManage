using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Menu;
namespace GZS.BLL.Menu
{
	/// <summary>
	/// SystemTemTab
	/// </summary>
	public class SystemTemTabBLL
	{
		private readonly GZS.DAL.Menu.SystemTemTabDAL dal=new GZS.DAL.Menu.SystemTemTabDAL();
		public SystemTemTabBLL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userid)
		{
			return dal.Exists(userid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GZS.Model.Menu.SystemTemTabM model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GZS.Model.Menu.SystemTemTabM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int userid)
		{
			
			return dal.Delete(userid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string useridlist )
		{
			return dal.DeleteList(useridlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GZS.Model.Menu.SystemTemTabM GetModel(int userid)
		{
			
			return dal.GetModel(userid);
		}
        public GZS.Model.Menu.SystemTemTabM GetModels(string userid)
        {

            return dal.GetModels(userid);
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
		public List<GZS.Model.Menu.SystemTemTabM> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GZS.Model.Menu.SystemTemTabM> DataTableToList(DataTable dt)
		{
			List<GZS.Model.Menu.SystemTemTabM> modelList = new List<GZS.Model.Menu.SystemTemTabM>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				GZS.Model.Menu.SystemTemTabM model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GZS.Model.Menu.SystemTemTabM();
					if(dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
					}
					model.levelName=dt.Rows[n]["levelName"].ToString();
					model.menuCode=dt.Rows[n]["menuCode"].ToString();
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

