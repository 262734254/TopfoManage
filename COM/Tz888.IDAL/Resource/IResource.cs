using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Resource
{
    public interface IResource
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="crm">CRM</param>
        /// <returns></returns>
        //bool AddResource(Tz888.Model.Resource.Resource resource);

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="crm">CRM</param>
        /// <returns></returns>
        bool ModfiyResource(string DeclarationId);

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="DeclarationId">DeclarationId</param>
        /// <returns></returns>
        DataTable GetResourceDetail(string DeclarationId);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="DeclarationId">DeclarationId</param>
        /// <returns></returns>
        bool DelResource(string DeclarationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjectName">��/��ͼ</param>
        /// <param name="Key">����</param>
        /// <param name="ShowFiled">��ʾ�ֶ�</param>
        /// <param name="Where">����</param>
        /// <param name="OrderFiled">�����ֶ�</param>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="PageSize">ҳ���С</param>
        /// <param name="TotalCount">������</param>
        /// <returns></returns>
        DataTable GetResourceList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled,
            ref int PageCurrent, int PageSize, ref int TotalCount);
    }
}
