using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.zx
{
    public class ZxSumBLL
    {
        ZxSumDAL sum = new ZxSumDAL();
        /// <summary>
        /// 判断总共有多少个页面数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int pageS(int type)
        {
            return sum.pageS(type);
        }
        /// <summary>
        /// 查询内容
        /// </summary>
        public void SelState(int num, int type, string title, string keyWords, string desc)
        {
            sum.SelState(num, type, title, keyWords, desc);
        }
    }
}
