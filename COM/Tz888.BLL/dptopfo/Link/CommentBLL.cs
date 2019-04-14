using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Link;
using GZS.DAL.Link;
namespace GZS.BLL.Link
{
	/// <summary>
	/// CommentBLL
	/// </summary>
	public class CommentBLL
	{
        CommentDAL dal = new CommentDAL();
		public CommentBLL()
		{}
		#region  Method
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CommentM model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CommentM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CommentId)
		{
			
			return dal.Delete(CommentId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CommentIdlist )
		{
			return dal.DeleteList(CommentIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CommentM GetModel(int CommentId)
		{
			
			return dal.GetModel(CommentId);
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
		public List<CommentM> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CommentM> DataTableToList(DataTable dt)
		{
			List<CommentM> modelList = new List<CommentM>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CommentM model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CommentM();
					if(dt.Rows[n]["CommentId"].ToString()!="")
					{
						model.CommentId=int.Parse(dt.Rows[n]["CommentId"].ToString());
					}
					model.description=dt.Rows[n]["description"].ToString();
					if(dt.Rows[n]["CommDate"].ToString()!="")
					{
						model.CommDate=DateTime.Parse(dt.Rows[n]["CommDate"].ToString());
					}
					model.SendName=dt.Rows[n]["SendName"].ToString();
					model.LinkMode=dt.Rows[n]["LinkMode"].ToString();
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

