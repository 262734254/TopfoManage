using System;
using System.Collections.Generic;
using System.Text;
using Tz888.SQLServerDAL.FenZhan;
using Tz888.Model.FenZhan;
using System.Data;

namespace Tz888.BLL.FenZhan
{
    public class FenZhanBLL
    {
        private readonly FenZhanDAL dal = new FenZhanDAL();
        /// <summary>
        /// ������վ
        /// </summary>
        /// <param name="Model">ʵ��</param>
        /// <returns></returns>
        public bool Add(FenZhanModel Model)
        {
            return dal.Add(Model);
        }

        /// <summary>
        /// �޸ķ�վ
        /// </summary>
        /// <param name="Model">ʵ��</param>
        public bool Modfiy(FenZhanModel Model)
        {
            return dal.Modfiy(Model);
        }

        /// <summary>
        /// ����ID��ȡ��ǰ��վ��Ϣ
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>DataTable</returns>
        public DataTable GetFenZhanById(string Id)
        {
            return dal.GetFenZhanById(Id);
        }

        /// <summary>
        /// ��ȡ���з�վ
        /// </summary>
        /// <returns></returns>
        public DataTable GetFenZhanList()
        {
            return dal.GetFenZhanList();
        }

        /// <summary>
        /// �޸���վ״̬
        /// </summary>
        /// <param name="SiteState">״̬��(SiteState=0->�ر�,SiteState=1->����)</param>
        /// <returns></returns>
        public bool ModfiySiteState(string SiteState)
        {
            return dal.ModfiySiteState(SiteState);
        }

        /// <summary>
        /// ��ȡ��վ����
        /// </summary>
        /// <param name="ProviceID"></param>
        /// <returns></returns>
        public string GetFenZhanName(string ProviceID)
        {
            return dal.GetFenZhanName(ProviceID);
        }
    }
}
