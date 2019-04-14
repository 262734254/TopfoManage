using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GZS.DAL
{
   public class EnvironmentTypeDAL
    {
       public List<GZS.Model.EnvironmentTypeM> GetAllType()
       {

			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  EnvironmentTypeID,EnvironmentTypeName from EnvironmentType ");

            List<GZS.Model.EnvironmentTypeM> list = new List<GZS.Model.EnvironmentTypeM>();
			DataSet ds=DBHelper.Query(strSql.ToString());
			foreach(DataRow row in ds.Tables [0].Rows)
			{
                GZS.Model.EnvironmentTypeM model = new GZS.Model.EnvironmentTypeM();
				if(row["EnvironmentTypeID"].ToString()!="")
				{
					model.EnvironmentTypeID=int.Parse(row["EnvironmentTypeID"].ToString());
				}
				model.EnvironmentTypeName=row["EnvironmentTypeName"].ToString();
                list.Add(model);
			}
            return list;
		
       }
    }
}
