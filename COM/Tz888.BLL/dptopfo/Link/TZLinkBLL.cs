using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Link;
using GZS.DAL.Link;
namespace GZS.BLL.Link
{
	/// <summary>
	/// TZLinkBLL
	/// </summary>
	public class TZLinkBLL
	{
        TZLinkDAL dal = new TZLinkDAL();

		public TZLinkBLL()
		{}
		#region  Method
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TZLinkM model)
		{
			return dal.Add(model);
		}
        public bool ExistsName(string loginName)
        {
            return dal.ExistsName(loginName);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TZLinkM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int linkId)
		{
			
			return dal.Delete(linkId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string linkIdlist )
		{
			return dal.DeleteList(linkIdlist );
		}
        public TZLinkM GetModelByLoginName(string loginName)
        {
            return dal.GetModelByLoginName(loginName);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TZLinkM GetModel(int linkId)
		{
			
			return dal.GetModel(linkId);
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
		public List<TZLinkM> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TZLinkM> DataTableToList(DataTable dt)
		{
			List<TZLinkM> modelList = new List<TZLinkM>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TZLinkM model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TZLinkM();
					if(dt.Rows[n]["linkId"].ToString()!="")
					{
						model.linkId=int.Parse(dt.Rows[n]["linkId"].ToString());
					}
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Tel=dt.Rows[n]["Tel"].ToString();
					model.Phone=dt.Rows[n]["Phone"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					model.OtherMode=dt.Rows[n]["OtherMode"].ToString();
					model.Address=dt.Rows[n]["Address"].ToString();
					if(dt.Rows[n]["createTime"].ToString()!="")
					{
						model.createTime=DateTime.Parse(dt.Rows[n]["createTime"].ToString());
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

