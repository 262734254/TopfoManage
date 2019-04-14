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
		/// ����һ������
		/// </summary>
		public int  Add(CommentM model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(CommentM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int CommentId)
		{
			
			return dal.Delete(CommentId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string CommentIdlist )
		{
			return dal.DeleteList(CommentIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public CommentM GetModel(int CommentId)
		{
			
			return dal.GetModel(CommentId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CommentM> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

