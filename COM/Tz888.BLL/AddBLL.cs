using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL
{
    public class AddBLL
    {
        Add adda = new Add();
        /// <summary>
        /// ������Ϣ����ȡ�����
        /// </summary>
        /// <param name="beg"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string SelInfoID(string beg, string end)
        {
            return adda.SelInfoID(beg,end);
        }
        /// <summary>
        /// �жϱ���Ƿ�����ϵ�˱��д���
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
        public string SelInfoContact(int infoID)
        {
            return adda.SelInfoContact(infoID);
        }
        /// <summary>
        /// ���ݱ���ڻ�Ա���в鴦��Ϣ
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
        public string SelMember(string infoID)
        {
            return adda.SelMember(infoID);
        }
        /// <summary>
        /// ����Ϣ��ӵ���ϵ����
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="name"></param>
        /// <param name="add"></param>
        /// <param name="tel"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int addInfoContact(string infoID, string name, string add, string tel, string mobile, string email)
        {
            return adda.addInfoContact(infoID,name,add,tel,mobile,email);
        }
    }
}
