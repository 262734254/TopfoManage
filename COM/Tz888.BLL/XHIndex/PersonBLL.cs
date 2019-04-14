using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Person;
namespace GZS.BLL.XHIndex
{
	/// <summary>
	/// PersonBLL
	/// </summary>
	public partial class PersonBLL
	{
        private readonly GZS.DAL.Person.PersonDAL dal = new GZS.DAL.Person.PersonDAL();
		public PersonBLL()
		{}
		#region  Method
	
         /// <summary>
        /// 根据用户名查找是否有记录数
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsName(string loginName)
        {
            return dal.ExistsName(loginName);
        }
        public GZS.Model.Person.PersonM GetModelByLoginName(string LoginName)
        {
            return dal.GetModelByLoginName(LoginName);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(GZS.Model.Person.PersonM model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(GZS.Model.Person.PersonM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public GZS.Model.Person.PersonM GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		#endregion  Method
	}
}

