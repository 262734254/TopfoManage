using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;
using System.Data;


namespace Tz888.BLL
{
    public class CasesInfoTabBLL
    {
        private readonly ICasesInfoTab dal = DataAccess.CreateCasesInfoTab();

        /// <summary>
        /// 添加案例信息
        /// </summary>
        /// <param name="mainInfoModel">主表</param>
        /// <param name="casesInfoModel">案例表</param>
        /// <param name="shortInfoModel">短信表</param>
        /// <param name="infoResourceModels">图片</param>
        /// <returns></returns>
        public long insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.CasesInfoTab casesInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            return dal.insert(mainInfoModel,casesInfoModel,shortInfoModel,infoResourceModels);
        }
        /// <summary>
        /// 修改案例信息
        /// </summary>
        /// <param name="mainInfoModel">主表</param>
        /// <param name="casesInfoModel">案例表</param>
        /// <param name="shortInfoModel">短信表</param>
        /// <param name="infoResourceModels">图片</param>
        /// <returns></returns>
        public long update(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.CasesInfoTab casesInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels, int infodd)
        {
            return dal.update(mainInfoModel, casesInfoModel, shortInfoModel, infoResourceModels,infodd);
        }
        /// <summary>
        /// 删除案例信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public long delete(int infoId)
        {
            return dal.delete(infoId);
        }
        /// <summary>
        /// 查找案例名称
        /// </summary>
        /// <returns></returns>
        public DataView setCases()
        {
            return dal.setCases();
        }
        /// <summary>
        /// 查主表信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.Info.MainInfoModel selMainInfo(int infoId)
        {
            return dal.selMainInfo(infoId) ;
        }
        /// <summary>
        /// 查短信表信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ShortInfoModel selShortInfo(int infoId)
        {
            return dal.selShortInfo(infoId);
        }
        /// <summary>
        /// 查案例信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.CasesInfoTab selcaseInfo(int infoId)
        {
            return dal.selcaseInfo(infoId);
        }
        /// <summary>
        /// 查信息资源
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public List<Tz888.Model.Info.InfoResourceModel> selInfoResource(int infoId)
        {
            return dal.selInfoResource(infoId);
        }
         /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public long UpdateStatus(int infoId,string htmlFile,int status)
        {
            return dal.UpdateStatus(infoId,htmlFile,status);
        }
        /// <summary>
        /// 判断静态页面是否存在
        /// </summary>
        /// <param name="infoId"></param>
        public string PaperExeists(int infoId)
        {
           return dal.PaperExeists(infoId);
        }
    }
}
