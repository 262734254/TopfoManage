using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.ProfessionalManage;
namespace Tz888.IDAL.ProfessionalManage
{
    public interface ProfessionalTypeIDAL
    {
        /// <summary>
        /// ��÷������
        /// </summary>
        /// <returns></returns>
        DataSet GetTypeAll();
        ProfessionalTypeTbl GetModel(int typeId);
       
    }
}
