using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.ProfessionalManage;
namespace Tz888.IDAL.ProfessionalManage
{
    public interface ProfessionalinfoIDAL
    {
        /// <summary>
        /// 删除跟主表相关的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelInfoById(int id);
        ProfessionalinfoTab GetModel(int id);
        /// <summary>
        /// 判断静态页面是否存在
        /// </summary>
        /// <param name="infoId"></param>
        string PaperExeists(int ProfessionalID);
/// <summary>
        /// 访问率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ModfiyHit(int id);
        

    }
}
