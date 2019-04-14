using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Visit
{
    public interface IVisitInfo
    {
        Tz888.Model.Register.MemberInfoModel SelLogin(string name);//�����û����ҳ�����Ӧ����Ϣ
        string SelCountry(string num);//�����ҷ���
        string SelCounty(string num);//����������
        string SelProvince(string num);//��ʡ������
        string SelCityID(string num);//����������Ӧ�ĳ������Ʒ���
        string SelManageType(string num);//����Ա���ͷ���
        int AddVisit(Tz888.Model.Visit.VisitInfoModel visit);//��ӻطü�¼
        int ModfiyVisit(Tz888.Model.Visit.VisitInfoModel visit, string name);//�޸Ļطü�¼
        Tz888.Model.Visit.VisitInfoModel SelVisit(string name);//����ID��ѯ����Ӧ�Ļطü�¼
        int SelLoginName(string name);// �ж��û����ڷ��ʼ�¼�����Ƿ����
        DataView SelManageTypeName();//�������ֶ�
        int SelValidNew(int a, string name);// ������Ч�ͻط�
        DataTable SelDataTable(string strWhere);

    }
}
