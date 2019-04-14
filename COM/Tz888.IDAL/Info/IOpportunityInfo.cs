using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface IOpportunityInfo
    {
        /// <summary>
        /// 根据行业ID查找行业名称
        /// </summary>
        string IndustryOpportunityName(int IndustryOpportunityId);
        /// <summary>
        /// 发布商机信息
        /// </summary>
        long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,//主信息表
            Tz888.Model.Info.OpportunityInfoModel opportunity,//商机表
            Tz888.Model.Info.ShortInfoModel shortInfoModel
            );//短信表
        /// <summary>
        /// 所属行业
        /// </summary>
        DataView GetIndustry();

        /// <summary>
        /// 商机类别
        /// </summary>
        DataView GetOpportun();
        /// <summary>
        /// 信息评定
        /// </summary>
        DataView GetFixPrice();
        /// <summary>
        /// 信息评分
        /// </summary>
        DataView GetGrade();
        /// <summary>
        /// 查找主信息表
        /// </summary>
        Tz888.Model.Info.MainInfoModel SetMainInfo(int infoId);
        /// <summary>
        /// 查找商机信息表
        /// </summary>
        Tz888.Model.Info.OpportunityInfoModel SetOpportunity(int infoId);
        /// <summary>
        /// 查找短信信息表
        /// </summary>
        Tz888.Model.Info.ShortInfoModel SetShortInfo(int infoId);
        /// <summary>
        /// 修改商机
        /// </summary>
        long HasModify(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.OpportunityInfoModel opportunity,
           Tz888.Model.Info.ShortInfoModel shortInfoModel, int infoID);
        /// <summary>
        /// 修改信息评定和评分
        /// </summary>
        long GradeFixModify(string GradeID,string FixPriceID,int infoId);
        /// <summary>
        /// 修改状态和模版路径
        /// </summary>
        long UpdateState(string HtmlFile, int status, int infoId);
        /// <summary>
        /// 判断静态页面是否存在
        /// </summary>
        string PaperExeists(int infoId);
        /// <summary>
        /// 删除信息
        /// </summary>
        long delete(int infoId);
    }
}
