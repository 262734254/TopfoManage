using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.MyHome;

namespace Tz888.IDAL.MyHome
{
    public interface IHomeType
    {
        /// <summary>
        /// 根据ID获取类型信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MyHomeType GetAllTypeById(int Id);
    }
}
