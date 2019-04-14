using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.ProfessionalManage;
using Tz888.IDAL.ProfessionalManage;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.ProfessionalManage
{
    public class ProfessionalTypeBLL
    {
        ProfessionalTypeIDAL typeIdal = DataAccess.CreateTypeInfo();
        /// <summary>
        /// 获得服务类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetTypeAll()
        {
            return typeIdal.GetTypeAll();
        }
        public ProfessionalTypeTbl GetModel(int typeId)
        {
            return typeIdal.GetModel(typeId);
        }
        
    }
}
