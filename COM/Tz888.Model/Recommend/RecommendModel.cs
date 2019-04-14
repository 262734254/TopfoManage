using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Recommend
{
    public class RecommendModel
    {
        //编号
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        //标题
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        //链接地址
        private string _Address;
        public string Address { get { return _Address; } set { _Address = value; } }

        //序号
        private int _Sort;
        public int Sort { get { return _Sort; } set { _Sort = value; } }

        //项目类型
        private int _Identity;
        public int Identity { get { return _Identity; } set { _Identity = value; } }

        //展示位置
        private string _ProvinceID;
        public string ProvinceID { get { return _ProvinceID; } set { _ProvinceID = value; } }

        //是否推荐(0->不推荐  1->推荐)
        private int _IsRecommend;
        public int IsRecommend { get { return _IsRecommend; } set { _IsRecommend = value; } }

        //描述
        private string _Remarks;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
    }
}
