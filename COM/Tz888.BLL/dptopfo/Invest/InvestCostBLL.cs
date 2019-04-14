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
		/// �Ƿ���ڸü�¼
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
		/// ����һ������
		/// </summary>
		public int Add(GZS.Model.Invest.InvestCostM model)
		{
		return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(InvestCostM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Costid)
		{
			return dal.Delete(Costid);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string Costidlist )
		{
			return dal.DeleteList(Costidlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
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
		public List<GZS.Model.Invest.InvestCostM> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

