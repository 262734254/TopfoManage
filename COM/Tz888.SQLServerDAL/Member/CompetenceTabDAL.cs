using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL.ManageSystem
{
  public  class CompetenceTabDAL
    {
      public DataSet getCompetenceFatherList(string FileName, string TableName, string Where)
      {
          SqlParameter[] parameters = {
                new SqlParameter("@tableName", SqlDbType.VarChar,300),
                new SqlParameter("@fieldName", SqlDbType.VarChar,1000),
                new SqlParameter("@where", SqlDbType.VarChar,500),
            };
          parameters[0].Value = TableName;
          parameters[1].Value =FileName ;
          parameters[2].Value = Where;

          DataSet ds = DbHelperSQL.RunProcedure("Conn", parameters, "Top");

          return ds;
      }
      /// <summary>
      /// 根据角色和角色组更新权限
      /// </summary>
      /// <param name="ManageTypeID">角色ID</param>
      /// <param name="MemberGradeID">角色组ID</param>
      /// <param name="PCode">权限值</param>
      /// <returns></returns>
      public int Competence_Update(string ManageTypeID,string MemberGradeID,string PCode)
      {
          
          SqlParameter[] parameters = {
                new SqlParameter("@ManageTypeID", SqlDbType.Char,10),
                new SqlParameter("@MemberGradeID", SqlDbType.Char,10),
                new SqlParameter("@PCode", SqlDbType.VarChar,3000),
            };
          parameters[0].Value = ManageTypeID;
          parameters[1].Value = MemberGradeID;
          parameters[2].Value = PCode;
          return DbHelperSQL.RunProcReturnNon("SystemPermissionTab_Competence_Update", parameters);
          
         
      }
    }
}
