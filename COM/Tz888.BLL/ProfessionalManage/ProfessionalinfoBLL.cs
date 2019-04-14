using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.ProfessionalManage
{
    public class ProfessionalinfoBLL
    {
        ProfessionalinfoIDAL dal = DataAccess.CreateMainInfo();
        /// <summary>
        /// 删除跟主表相关的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelInfoById(int id)
        {
            return dal.DelInfoById(id);
        }
        public ProfessionalinfoTab GetModel(int ProfessionalID)
        {
            return dal.GetModel(ProfessionalID);
        }
        /// <summary>
        /// 判断静态页面是否存在
        /// </summary>
        /// <param name="infoId"></param>
        public string PaperExeists(int ProfessionalID)
        {
            return dal.PaperExeists(ProfessionalID);
        }
        /// <summary>
        /// 访问率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyHit(int id)
        {
            return dal.ModfiyHit(id);
        }
    }
}
