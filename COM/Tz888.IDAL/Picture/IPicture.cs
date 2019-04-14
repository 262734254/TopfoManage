using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Picture;
using System.Data;

namespace Tz888.IDAL.Picture
{
    public interface IPicture
    {
        /// <summary>
        /// ���ͼƬ
        /// </summary>
        /// <param name="picture">picture</param>
        /// <returns></returns>
        bool AddPicture(PictureInfo Picture);

        /// <summary>
        /// �޸�ͼƬ
        /// </summary>
        /// <param name="picture">picture</param>
        /// <returns></returns>
        bool ModfiyPicture(PictureInfo Picture);

        /// <summary>
        /// ɾ��ͼƬ
        /// </summary>
        /// <param name="PictureId">PictureId</param>
        /// <returns></returns>
        bool DelPictureById(string PictureId);

        /// <summary>
        /// ͼƬ����
        /// </summary>
        /// <param name="PictureId">PictureId</param>
        /// <returns></returns>
        DataTable GetPictureDetail(string PictureId);

        /// <summary>
        /// ͼƬ�б�
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
        DataTable GetPictureList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled,
          ref int PageCurrent, int PageSize, ref int TotalCount);
    }
}
