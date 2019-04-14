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
		/// ����һ������
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
		/// ����һ������
		/// </summary>
		public bool Update(TZLinkM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int linkId)
		{
			
			return dal.Delete(linkId);
		}
		/// <summary>
		/// ɾ��һ������
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
		/// �õ�һ������ʵ��
		/// </summary>
		public TZLinkM GetModel(int linkId)
		{
			
			return dal.GetModel(linkId);
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
		public List<TZLinkM> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

