using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface IOpportunityInfo
    {
        /// <summary>
        /// ������ҵID������ҵ����
        /// </summary>
        string IndustryOpportunityName(int IndustryOpportunityId);
        /// <summary>
        /// �����̻���Ϣ
        /// </summary>
        long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,//����Ϣ��
            Tz888.Model.Info.OpportunityInfoModel opportunity,//�̻���
            Tz888.Model.Info.ShortInfoModel shortInfoModel
            );//���ű�
        /// <summary>
        /// ������ҵ
        /// </summary>
        DataView GetIndustry();

        /// <summary>
        /// �̻����
        /// </summary>
        DataView GetOpportun();
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        DataView GetFixPrice();
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        DataView GetGrade();
        /// <summary>
        /// ��������Ϣ��
        /// </summary>
        Tz888.Model.Info.MainInfoModel SetMainInfo(int infoId);
        /// <summary>
        /// �����̻���Ϣ��
        /// </summary>
        Tz888.Model.Info.OpportunityInfoModel SetOpportunity(int infoId);
        /// <summary>
        /// ���Ҷ�����Ϣ��
        /// </summary>
        Tz888.Model.Info.ShortInfoModel SetShortInfo(int infoId);
        /// <summary>
        /// �޸��̻�
        /// </summary>
        long HasModify(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.OpportunityInfoModel opportunity,
           Tz888.Model.Info.ShortInfoModel shortInfoModel, int infoID);
        /// <summary>
        /// �޸���Ϣ����������
        /// </summary>
        long GradeFixModify(string GradeID,string FixPriceID,int infoId);
        /// <summary>
        /// �޸�״̬��ģ��·��
        /// </summary>
        long UpdateState(string HtmlFile, int status, int infoId);
        /// <summary>
        /// �жϾ�̬ҳ���Ƿ����
        /// </summary>
        string PaperExeists(int infoId);
        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        long delete(int infoId);
    }
}
