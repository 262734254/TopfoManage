using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Recommend
{
    public class RecommendModel
    {
        //���
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        //����
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        //���ӵ�ַ
        private string _Address;
        public string Address { get { return _Address; } set { _Address = value; } }

        //���
        private int _Sort;
        public int Sort { get { return _Sort; } set { _Sort = value; } }

        //��Ŀ����
        private int _Identity;
        public int Identity { get { return _Identity; } set { _Identity = value; } }

        //չʾλ��
        private string _ProvinceID;
        public string ProvinceID { get { return _ProvinceID; } set { _ProvinceID = value; } }

        //�Ƿ��Ƽ�(0->���Ƽ�  1->�Ƽ�)
        private int _IsRecommend;
        public int IsRecommend { get { return _IsRecommend; } set { _IsRecommend = value; } }

        //����
        private string _Remarks;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
    }
}
