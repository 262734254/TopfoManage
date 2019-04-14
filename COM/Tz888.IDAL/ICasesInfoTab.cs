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
        /// ��Ӱ�����Ϣ
        /// </summary>
        /// <param name="mainInfoModel">����</param>
        /// <param name="casesInfoModel">������</param>
        /// <param name="shortInfoModel">���ű�</param>
        /// <param name="infoResourceModels">ͼƬ</param>
        /// <returns></returns>
        long insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.CasesInfoTab casesInfoModel,
             Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);
        /// <summary>
        /// �޸İ�����Ϣ
        /// </summary>
        /// <param name="mainInfoModel">����</param>
        /// <param name="casesInfoModel">������</param>
        /// <param name="shortInfoModel">���ű�</param>
        /// <param name="infoResourceModels">ͼƬ</param>
        /// <returns></returns>
        long update(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.CasesInfoTab casesInfoModel,
             Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels,
            int infoId);
        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        long delete(int infoId);
        /// <summary>
        /// ���Ұ�������
        /// </summary>
        /// <returns></returns>
        DataView setCases();
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        Tz888.Model.Info.MainInfoModel selMainInfo(int infoId);
        /// <summary>
        /// ����ű���Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        Tz888.Model.Info.ShortInfoModel selShortInfo(int infoId);
        /// <summary>
        /// �鰸����Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        Tz888.Model.CasesInfoTab selcaseInfo(int infoId);
        /// <summary>
        /// ����Ϣ��Դ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        List<Tz888.Model.Info.InfoResourceModel> selInfoResource(int infoId);
        
        /// <summary>
        /// �޸����״̬
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        long UpdateStatus(int infoId,string htmlFile,int status);
        /// <summary>
        /// �жϾ�̬ҳ���Ƿ����
        /// </summary>
        /// <param name="infoId"></param>
        string PaperExeists(int infoId);

    }
}
