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
        /// ��Ӱ�����Ϣ
        /// </summary>
        /// <param name="mainInfoModel">����</param>
        /// <param name="casesInfoModel">������</param>
        /// <param name="shortInfoModel">���ű�</param>
        /// <param name="infoResourceModels">ͼƬ</param>
        /// <returns></returns>
        public long insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.CasesInfoTab casesInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            return dal.insert(mainInfoModel,casesInfoModel,shortInfoModel,infoResourceModels);
        }
        /// <summary>
        /// �޸İ�����Ϣ
        /// </summary>
        /// <param name="mainInfoModel">����</param>
        /// <param name="casesInfoModel">������</param>
        /// <param name="shortInfoModel">���ű�</param>
        /// <param name="infoResourceModels">ͼƬ</param>
        /// <returns></returns>
        public long update(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.CasesInfoTab casesInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels, int infodd)
        {
            return dal.update(mainInfoModel, casesInfoModel, shortInfoModel, infoResourceModels,infodd);
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
        /// <summary>
        /// ���Ұ�������
        /// </summary>
        /// <returns></returns>
        public DataView setCases()
        {
            return dal.setCases();
        }
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.Info.MainInfoModel selMainInfo(int infoId)
        {
            return dal.selMainInfo(infoId) ;
        }
        /// <summary>
        /// ����ű���Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ShortInfoModel selShortInfo(int infoId)
        {
            return dal.selShortInfo(infoId);
        }
        /// <summary>
        /// �鰸����Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.CasesInfoTab selcaseInfo(int infoId)
        {
            return dal.selcaseInfo(infoId);
        }
        /// <summary>
        /// ����Ϣ��Դ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public List<Tz888.Model.Info.InfoResourceModel> selInfoResource(int infoId)
        {
            return dal.selInfoResource(infoId);
        }
         /// <summary>
        /// �޸����״̬
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public long UpdateStatus(int infoId,string htmlFile,int status)
        {
            return dal.UpdateStatus(infoId,htmlFile,status);
        }
        /// <summary>
        /// �жϾ�̬ҳ���Ƿ����
        /// </summary>
        /// <param name="infoId"></param>
        public string PaperExeists(int infoId)
        {
           return dal.PaperExeists(infoId);
        }
    }
}
