using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.policy;
using GZS.DAL.policy;
namespace GZS.BLL.policy
{
    public class PolicyBll
    {

        private readonly PolicyDAL dal = new PolicyDAL();

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(PolicyModel model)
        {
            return dal.Add(model);
        }
        public int ModfiyHit(int id)
        {
            return dal.ModfiyHit(id);
        }
        /// <summary>
        /// �����û��������Ƿ��м�¼��
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsName(string loginName)
        {
            return dal.ExistsName(loginName);
        
        }
         /// <summary>
        /// by user name get  data 
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public PolicyModel GetPolicyByName(string loginName)
        {
            return dal.GetPolicyByName(loginName);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(PolicyModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public PolicyModel GetModel(int policy)
        {

            return dal.GetModel(policy);
        }
    }
}
