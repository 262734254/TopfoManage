using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.advertise;
using Tz888.SQLServerDAL.advertise;
using Tz888.DALFactory;
using Tz888.IDAL.advertise;

namespace Tz888.BLL.advertise
{
    public class ADMessageInfoBLL
    {
        private readonly IADMessageInfo dal = DataAccess.CreateADMessageInfo();
        #region IADMessageInfo ��Ա
        /// <summary>
        /// ��ӹ����Ϣ
        /// </summary>
        /// <returns></returns>
        public long AddMessage(Tz888.Model.advertise.ADMessageInfo message)
        {
            return dal.AddMessage(message);
        }
        /// <summary>
        /// �޸Ĺ����Ϣ
        /// </summary>
        /// <returns></returns>
        public long UpdateMessage(Tz888.Model.advertise.ADMessageInfo message, int id)
        {
            return dal.UpdateMessage(message,id);
        }
        /// <summary>
        /// ���ҹ��Ƶ��
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public DataView SelChange()
        {
            return dal.SelChange();
        }
        /// <summary>
        /// ���������ڵĹ��Ƶ��
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public string SelName(int bid)
        {
            return dal.SelName(bid);
        }
        /// <summary>
        /// ��������Ӧ�Ĺ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tz888.Model.advertise.ADMessageInfo SelMessage(int id)
        {
            return dal.SelMessage(id);
        }
        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <returns></returns>
        public long DelMessage(int id)
        {
            return dal.DelMessage(id);
        }
        public string TypdName(int id)
        {
            return dal.TypdName(id);
        }
        #endregion
    }
}
