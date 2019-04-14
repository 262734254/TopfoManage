using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL
{
    public class AddBLL
    {
        Add adda = new Add();
        /// <summary>
        /// 在主信息表中取出编号
        /// </summary>
        /// <param name="beg"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string SelInfoID(string beg, string end)
        {
            return adda.SelInfoID(beg,end);
        }
        /// <summary>
        /// 判断编号是否在联系人表中存在
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
        public string SelInfoContact(int infoID)
        {
            return adda.SelInfoContact(infoID);
        }
        /// <summary>
        /// 根据编号在会员表中查处信息
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
        public string SelMember(string infoID)
        {
            return adda.SelMember(infoID);
        }
        /// <summary>
        /// 将信息添加到联系表中
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
