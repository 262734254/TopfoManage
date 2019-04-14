using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Recommend
{
    public interface IRecommend
    {
        /// <summary>
        /// ����Ƽ���Ŀ
        /// </summary>
        /// <param name="model">�Ƽ���Ŀ</param>
        /// <returns></returns>
        bool AddRecommend(Tz888.Model.Recommend.RecommendModel model);

        DataTable GetRecommendDetail(string Id);

        /// <summary>
        /// �޸��Ƽ���Ŀ
        /// </summary>
        /// <param name="model">RecommendModel</param>
        /// <returns></returns>
        bool ModfiyRecommend(Tz888.Model.Recommend.RecommendModel model);

        /// <summary>
        /// ɾ���Ƽ���Ŀ
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        bool DelRecommend(string Id);

        /// <summary>
        /// RecommendList
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
        DataTable GetRecommendList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled,
          ref int PageCurrent, int PageSize, ref int TotalCount);
    }
}
