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
        /// �����û��������Ƿ��м�¼��
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
		/// ����һ������
		/// </summary>
        public int Add(GZS.Model.Person.PersonM model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public bool Update(GZS.Model.Person.PersonM model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public GZS.Model.Person.PersonM GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		#endregion  Method
	}
}

