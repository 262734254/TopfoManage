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
        /// 增加一条数据
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
        /// 根据用户名查找是否有记录数
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
        /// 更新一条数据
        /// </summary>
        public bool Update(PolicyModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PolicyModel GetModel(int policy)
        {

            return dal.GetModel(policy);
        }
    }
}
