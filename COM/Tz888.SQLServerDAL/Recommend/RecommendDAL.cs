using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Tz888.SQLServerDAL.Recommend
{
    public class RecommendDAL:Tz888.IDAL.Recommend.IRecommend
    {
        private readonly Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();

        #region IRecommend ³ÉÔ±

        public bool AddRecommend(Tz888.Model.Recommend.RecommendModel model)
        {
            string sql = "insert into Recommend(Title,Sort,Address,[Identity],Remarks,IsRecommend,ProvinceID) values(@Title,@Sort,@Address,@Identity,@Remarks,@IsRecommend,@ProvinceID)";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@Title",SqlDbType.VarChar,200),
               new SqlParameter("@Sort",SqlDbType.Int,4),
               new SqlParameter("@Address",SqlDbType.VarChar,200),
               new SqlParameter("@Identity",SqlDbType.Int,4),
               new SqlParameter("@Remarks",SqlDbType.VarChar,200),
               new SqlParameter("@IsRecommend",SqlDbType.Int,4),
               new SqlParameter("@ProvinceID",SqlDbType.Char,10)
            };
            Paras[0].Value = model.Title;
            Paras[1].Value = model.Sort;
            Paras[2].Value = model.Address;
            Paras[3].Value = model.Identity;
            Paras[4].Value = model.Remarks;
            Paras[5].Value = model.IsRecommend;
            Paras[6].Value = model.ProvinceID;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        public DataTable GetRecommendDetail(string Id)
        {
            string sql = "select * from Recommend where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = Id;
            return crm.GetDataSet(sql, Paras);
        }

        public bool ModfiyRecommend(Tz888.Model.Recommend.RecommendModel model)
        {
            string sql = "update Recommend set Title=@Title,Sort=@Sort,Address=@Address,[Identity]=@Identity,Remarks=@Remarks,IsRecommend=@IsRecommend,ProvinceID=@ProvinceID where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@Title",SqlDbType.VarChar,200),
               new SqlParameter("@Sort",SqlDbType.Int,4),
               new SqlParameter("@Address",SqlDbType.VarChar,200),
               new SqlParameter("@Identity",SqlDbType.Int,4),
               new SqlParameter("@Remarks",SqlDbType.VarChar,200),
               new SqlParameter("@IsRecommend",SqlDbType.Int,4),
               new SqlParameter("@ProvinceID",SqlDbType.Char,10),
               new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = model.Title;
            Paras[1].Value = model.Sort;
            Paras[2].Value = model.Address;
            Paras[3].Value = model.Identity;
            Paras[4].Value = model.Remarks;
            Paras[5].Value = model.IsRecommend;
            Paras[6].Value = model.ProvinceID;
            Paras[7].Value = model.Id;
            int row = crm.ExecuteSql(sql,Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        public bool DelRecommend(string Id)
        {
            string sql = "delete Recommend where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = Id;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        public DataTable GetRecommendList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = ObjectName;
            parameters[1].Value = Key;
            parameters[2].Value = ShowFiled;
            parameters[3].Value = Where;
            parameters[4].Value = OrderFiled;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = PageCurrent;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;

            DataSet ds = crm.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt32(parameters[7].Value);
                    PageCurrent = Convert.ToInt32(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt32(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        PageCurrent = 1;
                    }
                    else
                    {
                        PageCurrent = 0;
                    }
                }
            }
            return dt;
        }

        #endregion
    }
}
