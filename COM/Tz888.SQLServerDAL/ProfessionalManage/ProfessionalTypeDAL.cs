using System;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using Tz888.DBUtility;//请先添加引用
using System.Text;
namespace Tz888.SQLServerDAL.ProfessionalManage
{
    public class ProfessionalTypeDAL : ProfessionalTypeIDAL
    {
        public DataSet GetTypeAll()
        {
            string sql = "SELECT * FROM ProfessionalTypeTbl";
            return DbHelperSQL.Query(sql);
        }
        public ProfessionalTypeTbl GetModel(int typeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 typeId,typeName,OrderId from ProfessionalTypeTbl ");
            strSql.Append(" where typeId=@typeId");
            SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4)
};
            parameters[0].Value = typeId;

            ProfessionalTypeTbl model = new ProfessionalTypeTbl();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["typeId"].ToString() != "")
                {
                    model.typeId = int.Parse(ds.Tables[0].Rows[0]["typeId"].ToString());
                }
                model.typeName = ds.Tables[0].Rows[0]["typeName"].ToString();
                if (ds.Tables[0].Rows[0]["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}

