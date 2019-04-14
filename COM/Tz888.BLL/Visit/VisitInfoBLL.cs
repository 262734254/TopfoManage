using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Visit;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.Visit
{
    public class VisitInfoBLL
    {
        private readonly IVisitInfo dal = DataAccess.CreateVisitInfo();


        /// <summary>
        /// 根据用户名条件所对应的信息
        /// </summary>
        /// <param name="name"></param>
        /// <return s></returns>
        public DataTable SelDataTable(string strWhere)
        {
            
            string sql = "select *from MemberInfoQueryVIW20110224 where "+strWhere+" ";
            return dal.SelDataTable(sql);
        }
        /// <summary>
        /// 根据用户名找出所对应的信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tz888.Model.Register.MemberInfoModel SelLogin(string name)
        {
            return dal.SelLogin(name);
        }
        /// <summary>
        /// 将国家翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCountry(string num)
        {
            return dal.SelCountry(num);
        }
        /// <summary>
        /// 将地区翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCounty(string num)
        {
            return dal.SelCounty(num);
        }
        /// <summary>
        /// 将省名翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelProvince(string num)
        {
            return dal.SelProvince(num);
        }
        /// <summary>
        /// 将地区所对应的城市名称翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCityID(string num)
        {
            return dal.SelCityID(num);
        }
        /// <summary>
        /// 将会员类型翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelManageType(string num)
        {
            return dal.SelManageType(num);
        }
        /// <summary>
        /// 添加回访记录
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        public int AddVisit(Tz888.Model.Visit.VisitInfoModel visit)
        {
            return dal.AddVisit(visit);
        }
        /// <summary>
        /// 修改回访记录
        /// </summary>
        /// <param name="visit"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyVisit(Tz888.Model.Visit.VisitInfoModel visit, string name)
        {
             return dal.ModfiyVisit(visit,name);
        }
        /// <summary>
        /// 根据ID查询所对应的回访记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tz888.Model.Visit.VisitInfoModel SelVisit(string name)
        {
            return dal.SelVisit(name);
        }
        /// <summary>
        /// 判断用户名在访问记录表中是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelLoginName(string name)
        {
            return dal.SelLoginName(name);
        }
        /// <summary>
        /// 绑定类型字段
        /// </summary>
        /// <returns></returns>
        public DataView SelManageTypeName()
        {
            return dal.SelManageTypeName();
        }
        /// <summary>
        /// 查找有效和回访
        /// </summary>
        /// <param name="a"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelValidNew(int a, string name)
        {
            return dal.SelValidNew(a,name);
        }
    }
}
