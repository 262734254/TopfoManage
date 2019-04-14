using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Visit;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.Visit
{
    public class VisitInfoBLL
    {
        private readonly IVisitInfo dal = DataAccess.CreateVisitInfo();


        /// <summary>
        /// �����û�����������Ӧ����Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <return s></returns>
        public DataTable SelDataTable(string strWhere)
        {
            
            string sql = "select *from MemberInfoQueryVIW20110224 where "+strWhere+" ";
            return dal.SelDataTable(sql);
        }
        /// <summary>
        /// �����û����ҳ�����Ӧ����Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tz888.Model.Register.MemberInfoModel SelLogin(string name)
        {
            return dal.SelLogin(name);
        }
        /// <summary>
        /// �����ҷ���
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCountry(string num)
        {
            return dal.SelCountry(num);
        }
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCounty(string num)
        {
            return dal.SelCounty(num);
        }
        /// <summary>
        /// ��ʡ������
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelProvince(string num)
        {
            return dal.SelProvince(num);
        }
        /// <summary>
        /// ����������Ӧ�ĳ������Ʒ���
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCityID(string num)
        {
            return dal.SelCityID(num);
        }
        /// <summary>
        /// ����Ա���ͷ���
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelManageType(string num)
        {
            return dal.SelManageType(num);
        }
        /// <summary>
        /// ��ӻطü�¼
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        public int AddVisit(Tz888.Model.Visit.VisitInfoModel visit)
        {
            return dal.AddVisit(visit);
        }
        /// <summary>
        /// �޸Ļطü�¼
        /// </summary>
        /// <param name="visit"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyVisit(Tz888.Model.Visit.VisitInfoModel visit, string name)
        {
             return dal.ModfiyVisit(visit,name);
        }
        /// <summary>
        /// ����ID��ѯ����Ӧ�Ļطü�¼
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tz888.Model.Visit.VisitInfoModel SelVisit(string name)
        {
            return dal.SelVisit(name);
        }
        /// <summary>
        /// �ж��û����ڷ��ʼ�¼�����Ƿ����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelLoginName(string name)
        {
            return dal.SelLoginName(name);
        }
        /// <summary>
        /// �������ֶ�
        /// </summary>
        /// <returns></returns>
        public DataView SelManageTypeName()
        {
            return dal.SelManageTypeName();
        }
        /// <summary>
        /// ������Ч�ͻط�
        /// </summary>
        /// <param name="a"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelValidNew(int a, string name)
        {
            return dal.SelValidNew(a,name);
        }
    }
}
