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
		/// 增加一条数据
		/// </summary>
		public int  Add(IndustryFrom model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(IndustryFrom model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int industryId)
		{
			
			return dal.Delete(industryId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string industryIdlist )
		{
			return dal.DeleteList(industryIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public IndustryFrom GetModel(int industryId)
		{
			
			return dal.GetModel(industryId);
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
		public List<IndustryFrom> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
