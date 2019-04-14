using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.MyHome;
using Tz888.IDAL.MyHome;
namespace Tz888.SQLServerDAL.MyHome
{
  public  class HomeTypeService: IHomeType
    {

        #region 根据ID获取类型信息
      /// <summary>
      /// 根据ID获取类型信息
      /// </summary>
      /// <param name="Id"></param>
      /// <returns></returns>
        public MyHomeType GetAllTypeById(int Id)
        {
            string sql = "select TID,TypeName,LoginName,LoginID,sort,Datatimes from HomeType where TID=@Id";
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            MyHomeType model = new MyHomeType();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TID"].ToString() != "")
                {
                    model.TID = int.Parse(ds.Tables[0].Rows[0]["TID"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                if (ds.Tables[0].Rows[0]["LoginID"].ToString() != "")
                {
                    model.LoginID = int.Parse(ds.Tables[0].Rows[0]["LoginID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Datatimes"].ToString() != "")
                {
                    model.Datatimes = DateTime.Parse(ds.Tables[0].Rows[0]["Datatimes"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }

        }
        #endregion
    }
}
