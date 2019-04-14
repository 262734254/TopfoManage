using System;
using System.Data;
using Tz888.Model.Info;
namespace Tz888.IDAL.Recomm
{
	/// <summary>
	/// �ӿڲ�IrecommResourceIDAL 
	/// </summary>
	public interface recommResourceIDAL
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int RecommID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Tz888.Model.Recomm.recommResourceM model);
		/// <summary>
		/// ����һ������
		/// </summary>
        bool Update(Tz888.Model.Recomm.recommResourceM model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(int RecommID);
		bool DeleteList(string RecommIDlist );
        /// <summary>
        /// �Ƽ� �������л�ȡ���� title ,url
        /// ���ӵ����ݿⲻͬ
        /// </summary>
        /// <param name="infoid"></param>
        /// <returns></returns>
        DataSet GetTitleAndUrlByInfoId(string infoid);
         /// <summary>
        /// ���������Ѿ��Ƽ�����ֻ�����ʱ��
        /// </summary>
        /// <returns></returns>
        int UpdateTimeByRecommId(int recommId);
        /// <summary>
        /// ����������ѯ�Ƿ��������
        /// </summary>
        /// <param name="RecommTypeID">��Դ����1,���̡����ʡ�Ͷ��2,�˲�3,����4, ����</param>
        /// <param name="RecommToUser">�Ƽ��û�</param>
        /// <param name="ResourecId">�Ƽ���ԴID</param>
        /// <returns></returns>
        int ExistsByWhere(int RecommTypeID, string RecommToUser, long ResourecId);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        Tz888.Model.Recomm.recommResourceM GetModel(int RecommID);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
