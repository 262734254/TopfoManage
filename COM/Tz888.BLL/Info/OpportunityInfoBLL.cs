using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using Tz888.Model.Info;

namespace Tz888.BLL.Info
{
    public class OpportunityInfoBLL
    {
        private readonly IOpportunityInfo dal = DataAccess.CreateOpportunityInfo();
         /// <summary>
        /// 根据行业ID查找行业名称
        /// </summary>
        public string IndustryOpportunityName(int IndustryOpportunityId)
        {
            return dal.IndustryOpportunityName(IndustryOpportunityId);
        }
        /// <summary>
        /// 商机信息发布
        /// </summary>
        /// <returns></returns>
        public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.OpportunityInfoModel opportunity,
            Tz888.Model.Info.ShortInfoModel shortInfoModel
            )
        {
            return dal.Insert(mainInfoModel, opportunity, shortInfoModel);
        }
        /// <summary>
        /// 所属行业
        /// </summary>
        public DataView GetIndustry()
        {
            return dal.GetIndustry();
        }
        /// <summary>
        /// 商机类别
        /// </summary>
        public DataView GetOpportun()
        {
            return dal.GetOpportun();
        }
         /// <summary>
        /// 信息评定
        /// </summary>
        public DataView GetFixPrice()
        {
            return dal.GetFixPrice();
        }
        /// <summary>
        /// 信息评分
        /// </summary>
        public DataView GetGrade()
        {
            return dal.GetGrade();
        }
         /// <summary>
        /// 修改信息评定和评分
        /// </summary>
        public long GradeFixModify(string GradeID, string FixPriceID, int infoId)
        {
            return dal.GradeFixModify(GradeID, FixPriceID, infoId);
        }
        /// <summary>
        /// 查找主信息表
        /// </summary>
        public MainInfoModel SetMainInfo(int infoId)
        {
            return dal.SetMainInfo(infoId);
        }
        /// <summary>
        /// 查找商机信息表
        /// </summary>
        public OpportunityInfoModel SetOpportunity(int infoId)
        {
            return dal.SetOpportunity(infoId);
        }
        /// <summary>
        /// 查找短信信息表
        /// </summary>
        public ShortInfoModel SetShortInfo(int infoId)
        {
            return dal.SetShortInfo(infoId);
        }
        /// <summary>
        /// 修改状态和模版路径
        /// </summary>
        public long UpdateState(string HtmlFile, int status, int infoId)
        {
            return dal.UpdateState(HtmlFile,status,infoId);
        }
        /// <summary>
        /// 修改商机信息
        /// </summary>
        public long HasModify(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.OpportunityInfoModel opportunity,
           Tz888.Model.Info.ShortInfoModel shortInfoModel, int infodd)
        {
            return dal.HasModify(mainInfoModel,opportunity,shortInfoModel,infodd);
        }
        /// <summary>
        /// 判断静态页面是否存在
        /// </summary>
        /// <param name="infoId"></param>
        public string PaperExeists(int infoId)
        {
            return dal.PaperExeists(infoId);
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
    }
}
