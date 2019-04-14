using System;
using System.Collections.Generic;
using System.Text;
using GZS.DAL;

namespace GZS.BLL
{
    public class AreaIndexBLL
    {
        AreaIndexDAL area = new AreaIndexDAL();
        public void AreaHtml(string name, int num)
        {
            area.AreaHtml(name,num);
        }
    }
}
