using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL.advertise;
using Tz888.Model.advertise;

namespace Tz888.SQLServerDAL.advertise
{
    public class ADMessageInfoDAL:IADMessageInfo
    {
        #region IADMessageInfo 成员
        /// <summary>
        /// 添加广告信息
        /// </summary>
        /// <returns></returns>
        public long AddMessage(Tz888.Model.advertise.ADMessageInfo message)
        {
            string sql = "insert into ADMessageInfo(BID,TypeName,SerialID,size,price,giving,note,checkid) values"
                + "(@BID,@TypeName,@SerialID,@size,@price,@giving,@note,@checkid)";
            SqlParameter[] para ={ 
                new SqlParameter("@BID",SqlDbType.Int,4),
                new SqlParameter("@TypeName",SqlDbType.VarChar,100),
                new SqlParameter("@SerialID",SqlDbType.VarChar,10),
                new SqlParameter("@size",SqlDbType.VarChar,50),
                new SqlParameter("@price",SqlDbType.Float,50),
                new SqlParameter("@giving",SqlDbType.DateTime,50),
                new SqlParameter("@note",SqlDbType.VarChar,1000),
                new SqlParameter("@checkid",SqlDbType.Int,2)
            };
            para[0].Value = message.BID;
            para[1].Value = message.TypeName;
            para[2].Value = message.SerialID;
            para[3].Value = message.size;
            para[4].Value = message.price;
            para[5].Value = message.giving;
            para[6].Value = message.note;
            para[7].Value = message.checkid;
            
            object info =DbHelperSQL.GetSingle(sql,para);
            if (info == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(info);
            }
        }
        /// <summary>
        /// 修改广告信息
        /// </summary>
        /// <returns></returns>
        public long UpdateMessage(Tz888.Model.advertise.ADMessageInfo message, int id)
        {
            long info;
            string sql = "update ADMessageInfo set BID=@BID,TypeName=@TypeName,SerialID=@SerialID,"
                +"size=@size,price=@price,giving=@giving,note=@note,checkid=@checkid where positionID=@id";
            SqlParameter[] para ={ 
                new SqlParameter("@id",SqlDbType.Int,8),
                new SqlParameter("@BID",SqlDbType.Int,4),
                new SqlParameter("@TypeName",SqlDbType.VarChar,100),
                new SqlParameter("@SerialID",SqlDbType.VarChar,10),
                new SqlParameter("@size",SqlDbType.VarChar,50),
                new SqlParameter("@price",SqlDbType.Float,50),
                new SqlParameter("@giving",SqlDbType.DateTime,50),
                new SqlParameter("@note",SqlDbType.VarChar,1000),
                new SqlParameter("@checkid",SqlDbType.Int,2)
            };
            para[0].Value = id;
            id = message.positionID;
            para[1].Value = message.BID;
            para[2].Value = message.TypeName;
            para[3].Value = message.SerialID;
            para[4].Value = message.size;
            para[5].Value = message.price;
            para[6].Value = message.giving;
            para[7].Value = message.note;
            para[8].Value = message.checkid;

             info =(long) DbHelperSQL.ExecuteSql(sql, para);
            return info;
        }
        /// <summary>
        /// 查找广告频道
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public DataView SelChange()
        {
            string sql = "select BID,BName from ADchannelInfo ";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 查找所对于的广告频道
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public string SelName(int bid)
        {
            string name;
            string sql = "select BName from ADchannelInfo where BID=@bid";
            SqlParameter[] para ={ 
                new SqlParameter("@bid",SqlDbType.Int,8)
            };
            para[0].Value = bid;
            name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            return name;
        }
        /// <summary>
        /// 查找所对应的广告信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tz888.Model.advertise.ADMessageInfo SelMessage(int id)
        {
            ADMessageInfo message = new ADMessageInfo();
            string sql = "select BID,TypeName,SerialID,size,price,giving,note,checkid from ADMessageInfo where positionID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            DataSet ds = DbHelperSQL.Query(sql,para);
            if (ds != null || ds.Tables[0].Rows.Count > 0)
            {
                message.BID =Convert.ToInt32(ds.Tables[0].Rows[0]["BID"].ToString());
                message.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                message.SerialID = ds.Tables[0].Rows[0]["SerialID"].ToString();
                message.size = ds.Tables[0].Rows[0]["size"].ToString();
                message.price =float.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                message.giving = Convert.ToDateTime(ds.Tables[0].Rows[0]["giving"].ToString());
                message.note = ds.Tables[0].Rows[0]["note"].ToString();
                message.checkid=Convert.ToInt32(ds.Tables[0].Rows[0]["checkid"].ToString());
            }
            return message;
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns></returns>
        public long DelMessage(int id)
        {
            long info;
            string sql = "delete from ADMessageInfo where positionID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            info = (long)DbHelperSQL.ExecuteSql(sql,para);
            return info; 
        }
        #endregion

        #region IADMessageInfo 成员


        

        #endregion

        #region IADMessageInfo 成员


        public string TypdName(int id)
        {
            string name;
            string sql = "select TypeName from ADMessageInfo where positionID=@id";
            SqlParameter[] para ={ 
                new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            return name;
        }

        #endregion
    }
}
