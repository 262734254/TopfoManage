using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TradeShow;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.TradeShow
{
    public class TradeShowDAL
    {
        private readonly Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();

        public bool Add(TradeShowModel TradeShow)
        {
            string sql = "insert into TradeShow(Title,Img,Sort,Types,PublishTime,UserName,Job,Remark) values(@Title,@Img,@Sort,@Types,@PublishTime,@UserName,@Job,@Remark)";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                new SqlParameter("@Img",SqlDbType.VarChar,200),
                new SqlParameter("@Sort",SqlDbType.Int),
                new SqlParameter("@Types",SqlDbType.Int),
                new SqlParameter("@PublishTime",SqlDbType.DateTime),
                new SqlParameter("@UserName",SqlDbType.VarChar,50),
                new SqlParameter("@Job",SqlDbType.VarChar,50),
                new SqlParameter("@Remark",SqlDbType.VarChar,8000)
            };
            Paras[0].Value = TradeShow.Title;
            Paras[1].Value = TradeShow.Img;
            Paras[2].Value = TradeShow.Sort;
            Paras[3].Value = TradeShow.Types;
            Paras[4].Value = TradeShow.PublishTime;
            Paras[5].Value = TradeShow.UserName;
            Paras[6].Value = TradeShow.Job;
            Paras[7].Value = TradeShow.Remark;
            int row = crm.ExecuteQuerySQL(sql, ref Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        public bool Modify(TradeShowModel TradeShow)
        {
            string sql = "update TradeShow set Title=@Title,Img=@Img,Sort=@Sort,Types=@Types,PublishTime=@PublishTime,UserName=@UserName,Job=@Job,Remark=@Remark where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                new SqlParameter("@Img",SqlDbType.VarChar,200),
                new SqlParameter("@Sort",SqlDbType.Int),
                new SqlParameter("@Types",SqlDbType.Int),
                new SqlParameter("@PublishTime",SqlDbType.DateTime),
                new SqlParameter("@UserName",SqlDbType.VarChar,50),
                new SqlParameter("@Job",SqlDbType.VarChar,50),
                new SqlParameter("@Remark",SqlDbType.VarChar,8000),
                new SqlParameter("@Id",SqlDbType.Int)
            };
            Paras[0].Value = TradeShow.Title;
            Paras[1].Value = TradeShow.Img;
            Paras[2].Value = TradeShow.Sort;
            Paras[3].Value = TradeShow.Types;
            Paras[4].Value = TradeShow.PublishTime;
            Paras[5].Value = TradeShow.UserName;
            Paras[6].Value = TradeShow.Job;
            Paras[7].Value = TradeShow.Remark;
            Paras[8].Value = TradeShow.Id;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        public bool Del(int Id)
        {
            string sql = "delete TradeShow where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            Paras[0].Value = Id;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        public bool Del(string Ids)
        {
            string sql = "delete TradeShow where Id in(" + Ids + ")";
            int row = crm.ExecuteSql(sql);
            if (row > 0)
                return true;
            else
                return false;
        }

        public DataTable GetTradeShowById(string Id)
        {
            string sql = "select * from TradeShow where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int)
            };
            Paras[0].Value = Id;
            return crm.GetDataSet(sql, Paras);
        }

        public DataTable GetTradeShowList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
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
    }
}
