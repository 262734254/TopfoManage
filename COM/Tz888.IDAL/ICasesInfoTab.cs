using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.IDAL
{
    public interface ICasesInfoTab
    {
        /// <summary>
        /// 添加案例信息
        /// </summary>
        /// <param name="mainInfoModel">主表</param>
        /// <param name="casesInfoModel">案例表</param>
        /// <param name="shortInfoModel">短信表</param>
        /// <param name="infoResourceModels">图片</param>
        /// <returns></returns>
        long insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.CasesInfoTab casesInfoModel,
             Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);
        /// <summary>
        /// 修改案例信息
        /// </summary>
        /// <param name="mainInfoModel">主表</param>
        /// <param name="casesInfoModel">案例表</param>
        /// <param name="shortInfoModel">短信表</param>
        /// <param name="infoResourceModels">图片</param>
        /// <returns></returns>
        long update(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.CasesInfoTab casesInfoModel,
             Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels,
            int infoId);
        /// <summary>
        /// 删除案例信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        long delete(int infoId);
        /// <summary>
        /// 查找案例名称
        /// </summary>
        /// <returns></returns>
        DataView setCases();
        /// <summary>
        /// 查主表信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        Tz888.Model.Info.MainInfoModel selMainInfo(int infoId);
        /// <summary>
        /// 查短信表信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        Tz888.Model.Info.ShortInfoModel selShortInfo(int infoId);
        /// <summary>
        /// 查案例信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        Tz888.Model.CasesInfoTab selcaseInfo(int infoId);
        /// <summary>
        /// 查信息资源
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        List<Tz888.Model.Info.InfoResourceModel> selInfoResource(int infoId);
        
        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        long UpdateStatus(int infoId,string htmlFile,int status);
        /// <summary>
        /// 判断静态页面是否存在
        /// </summary>
        /// <param name="infoId"></param>
        string PaperExeists(int infoId);

    }
}
