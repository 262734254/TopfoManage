using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.Model.report;
using System.Data;
using Tz888.IDAL.report;
namespace Tz888.BLL.report
{
    public class IndustryFromBLL
    {
        private readonly IndustryFromIDAL dal=DataAccess.CreateIndustryFrom();
		
		#region  Method
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(IndustryFrom model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(IndustryFrom model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int industryId)
		{
			
			return dal.Delete(industryId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string industryIdlist )
		{
			return dal.DeleteList(industryIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public IndustryFrom GetModel(int industryId)
		{
			
			return dal.GetModel(industryId);
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
		public List<IndustryFrom> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<IndustryFrom> DataTableToList(DataTable dt)
		{
			List<IndustryFrom> modelList = new List<IndustryFrom>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				IndustryFrom model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new IndustryFrom();
					if(dt.Rows[n]["industryId"].ToString()!="")
					{
						model.industryId=int.Parse(dt.Rows[n]["industryId"].ToString());
					}
					model.industryName=dt.Rows[n]["industryName"].ToString();
					model.LinkMan=dt.Rows[n]["LinkMan"].ToString();
					model.tel=dt.Rows[n]["tel"].ToString();
					model.email=dt.Rows[n]["email"].ToString();
					model.phone=dt.Rows[n]["phone"].ToString();
					model.fax=dt.Rows[n]["fax"].ToString();
					model.company=dt.Rows[n]["company"].ToString();
					model.address=dt.Rows[n]["address"].ToString();
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
