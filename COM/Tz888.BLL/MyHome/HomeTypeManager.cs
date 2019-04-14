using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DALFactory;
using Tz888.IDAL;
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;

namespace Tz888.BLL.MyHome
{
  public  class HomeTypeManager
    {
      HomeTypeService type = new HomeTypeService();
        #region �鿴����
        /// <summary>
        /// ����ID�鿴����
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MyHomeType GetAllTypeById(int Id)
        {
            try
            {
                return type.GetAllTypeById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion
    }

}
