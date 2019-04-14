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
        /// ������ҵID������ҵ����
        /// </summary>
        public string IndustryOpportunityName(int IndustryOpportunityId)
        {
            return dal.IndustryOpportunityName(IndustryOpportunityId);
        }
        /// <summary>
        /// �̻���Ϣ����
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
        /// ������ҵ
        /// </summary>
        public DataView GetIndustry()
        {
            return dal.GetIndustry();
        }
        /// <summary>
        /// �̻����
        /// </summary>
        public DataView GetOpportun()
        {
            return dal.GetOpportun();
        }
         /// <summary>
        /// ��Ϣ����
        /// </summary>
        public DataView GetFixPrice()
        {
            return dal.GetFixPrice();
        }
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public DataView GetGrade()
        {
            return dal.GetGrade();
        }
         /// <summary>
        /// �޸���Ϣ����������
        /// </summary>
        public long GradeFixModify(string GradeID, string FixPriceID, int infoId)
        {
            return dal.GradeFixModify(GradeID, FixPriceID, infoId);
        }
        /// <summary>
        /// ��������Ϣ��
        /// </summary>
        public MainInfoModel SetMainInfo(int infoId)
        {
            return dal.SetMainInfo(infoId);
        }
        /// <summary>
        /// �����̻���Ϣ��
        /// </summary>
        public OpportunityInfoModel SetOpportunity(int infoId)
        {
            return dal.SetOpportunity(infoId);
        }
        /// <summary>
        /// ���Ҷ�����Ϣ��
        /// </summary>
        public ShortInfoModel SetShortInfo(int infoId)
        {
            return dal.SetShortInfo(infoId);
        }
        /// <summary>
        /// �޸�״̬��ģ��·��
        /// </summary>
        public long UpdateState(string HtmlFile, int status, int infoId)
        {
            return dal.UpdateState(HtmlFile,status,infoId);
        }
        /// <summary>
        /// �޸��̻���Ϣ
        /// </summary>
        public long HasModify(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.OpportunityInfoModel opportunity,
           Tz888.Model.Info.ShortInfoModel shortInfoModel, int infodd)
        {
            return dal.HasModify(mainInfoModel,opportunity,shortInfoModel,infodd);
        }
        /// <summary>
        /// �жϾ�̬ҳ���Ƿ����
        /// </summary>
        /// <param name="infoId"></param>
        public string PaperExeists(int infoId)
        {
            return dal.PaperExeists(infoId);
        }
        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public long delete(int infoId)
        {
            return dal.delete(infoId);
        }
    }
}
