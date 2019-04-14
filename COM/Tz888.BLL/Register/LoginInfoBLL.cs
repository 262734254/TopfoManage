using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;
using Tz888.IDAL.Register;
using Tz888.DALFactory;

namespace Tz888.BLL.Register
{
   public class LoginInfoBLL
    {
       private readonly LoginInfo dal = DataAccess.CreateLoginInfo();
        //��Աע��
       public void LogInfoAdd(Tz888.Model.Register.LoginInfoModel model)
       {
           dal.LogInfoAdd(model);
       }
    

       //��Ա��֤

       public void ValidUser(string loginname)
       {
           dal.ValidUser(loginname);
       }

       //��ȡ�û�����
       public string GetManagerType(string loginName)
       {
           return dal.GetManagerType(loginName);
       }

       //�����û�����

       public void ChangeEmail(string loginName, string newEmail)
       {
           dal.ChangeEmail(loginName, newEmail);
       }


       //��ȡ��Ա�ȼ�(��ͨ1001���ظ�ͨ1002���ظ�ͨ����1003)
       public string GetMemberGradeID(string loginName)
       {
           return dal.GetMemberGradeID(loginName).Trim();
       }

       //��ȡ�û�����(�������̻���2001��Ͷ�ʷ�2002����Ŀ��2003,�н����2004)
       public string GetManageTypeID(string loginName)
       {
           return dal.GetManageTypeID(loginName);
       }

       //��ȡ��Ա����ID(0:��ҵ;1:����;2:���̻���;3:�н����)
       public string GetPropertyID(string loginName)
       {
           return dal.GetPropertyID(loginName);
       }
       
       // ����ע��(���Ӽ�¼������)
       /// <summary>
       /// ���������ע��
       /// </summary>
       /// <param name="ip">������IP</param>
       /// <param name="email">����������</param>
       /// <param name="loginName">�����˵�½��</param>
       /// <returns></returns>
       public bool InviterRegiste(string ip, string email, string loginName)
       {
           return dal.InviterRegiste(ip, email, loginName);
       }
    }
}
