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
      /// ���ݽ�ɫ�ͽ�ɫ�����Ȩ��
      /// </summary>
      /// <param name="ManageTypeID">��ɫID</param>
      /// <param name="MemberGradeID">��ɫ��ID</param>
      /// <param name="PCode">Ȩ��ֵ</param>
      /// <returns></returns>
      public int Competence_Update(string ManageTypeID, string MemberGradeID, string PCode)
      {
          return dal.Competence_Update(ManageTypeID, MemberGradeID, PCode);
      }
    }
}
