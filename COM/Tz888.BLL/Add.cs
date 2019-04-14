using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL
{
    public  class Add
    {
        /// <summary>
        /// 在主信息表中取出编号
        /// </summary>
        /// <param name="beg"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string SelInfoID(string beg, string end)
        {
            StringBuilder builder = new StringBuilder();
            string sql = "select InfoID from MainInfoTab where InfoID>=@beg and InfoID<=@end";
            SqlParameter[] para ={
                new SqlParameter("@beg",SqlDbType.VarChar,8),
               new SqlParameter("@end",SqlDbType.VarChar,8)
           };
            para[0].Value = beg;
            para[1].Value = end;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    builder.Append("" + row["InfoID"].ToString() + ",");
                }

            }
            return builder.ToString();
        }
        /// <summary>
        /// 判断编号是否在联系人表中存在
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
        public string SelInfoContact(int infoID)
        {
            string htmlFile = "";
            string sql = "select InfoID from InfoContactTab where InfoID=@infoID";
            SqlParameter[] para ={ 
                new SqlParameter("@infoID",SqlDbType.Int,20)
            };
            para[0].Value = infoID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                htmlFile = "1";
            }
            else
            {
                htmlFile = "";
            }
            return htmlFile;
        }
        /// <summary>
        /// 根据编号在会员表中查处信息
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
        public string SelMember(string infoID)
        {
            StringBuilder builder = new StringBuilder();
            //string sql = "select distinct a.MemberName,a.Address,a.Tel,a.Mobile,a.Email from MemberInfoTab as a inner join "
            //    + " MainInfoTab as b on a.LoginName=b.LoginName inner join ProjectInfoTab as c on b.InfoID=c.InfoID  where b.InfoID=@infoID";
            string sql = "select distinct a.MemberName,a.Address,a.Tel,a.Mobile,a.Email from MemberInfoTab as a inner join "
                + " MainInfoTab as b on a.LoginName=b.LoginName where b.InfoID=@infoID";
            SqlParameter[] para ={ 
               new SqlParameter("@infoID",SqlDbType.VarChar,20)
            };
            para[0].Value = infoID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                string name = ds.Tables[0].Rows[0]["MemberName"].ToString().Trim();
                string add = ds.Tables[0].Rows[0]["Address"].ToString().Trim();
                string tel = ds.Tables[0].Rows[0]["Tel"].ToString().Trim();
                string mobile = ds.Tables[0].Rows[0]["Mobile"].ToString().Trim();
                string email = ds.Tables[0].Rows[0]["Email"].ToString().Trim();
                builder.Append("" + name + "&"+add+"&"+tel+"&"+mobile+"&"+email+"");
            }
            return builder.ToString();
        }
        /// <summary>
        /// 将信息添加到联系表中
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="name"></param>
        /// <param name="add"></param>
        /// <param name="tel"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int addInfoContact(string infoID, string name, string add, string tel, string mobile, string email)
        {
            string sql = "insert into InfoContactTab(InfoID,[Name],address,TelNum,Mobile,Email)values"
                +"(@infoID,@name,@add,@tel,@mobile,@email)";
            SqlParameter[] para ={ 
                new SqlParameter("@infoID",SqlDbType.VarChar,20),
                new SqlParameter("@name",SqlDbType.VarChar,20),
                new SqlParameter("@add",SqlDbType.VarChar,20),
                new SqlParameter("@tel",SqlDbType.VarChar,20),
                new SqlParameter("@mobile",SqlDbType.VarChar,20),
                new SqlParameter("@email",SqlDbType.VarChar,20)
            };
            para[0].Value = infoID;
            para[1].Value = name;
            para[2].Value = add;
            para[3].Value = tel;
            para[4].Value = mobile;
            para[5].Value = email;
            object info = DbHelperSQL.GetSingle(sql, para);
            if (info == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(info);
            }
        }
    }
}
