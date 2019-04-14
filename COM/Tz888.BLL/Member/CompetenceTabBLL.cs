using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.BLL.ManageSystem
{
  public   class CompetenceTabBLL
    {
      Tz888.SQLServerDAL.ManageSystem.CompetenceTabDAL dal = new Tz888.SQLServerDAL.ManageSystem.CompetenceTabDAL();

      public DataSet getCompetenceFatherList(string FileName, string TableName, string Where)
      {
          return dal.getCompetenceFatherList(FileName, TableName, Where);
      }
      /// <summary>
      /// 根据角色和角色组更新权限
      /// </summary>
      /// <param name="ManageTypeID">角色ID</param>
      /// <param name="MemberGradeID">角色组ID</param>
      /// <param name="PCode">权限值</param>
      /// <returns></returns>
      public int Competence_Update(string ManageTypeID, string MemberGradeID, string PCode)
      {
          return dal.Competence_Update(ManageTypeID, MemberGradeID, PCode);
      }
    }
}
