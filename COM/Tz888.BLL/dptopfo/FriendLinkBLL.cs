using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model;

namespace GZS.BLL
{
    public class FriendLinkBLL
    {

        GZS.DAL.FriendLinkDAL dal = new GZS.DAL.FriendLinkDAL();
        public int Add(FriendLink model)
        {
            return dal.Add(model);
        }
        public int Update(FriendLink model)
        {
            return dal.Update(model);
        }
        public int Delete(int Linkid)
        {
            return dal.Delete(Linkid);
        }
        public FriendLink GetModel(int Linkid)
        {
            return dal.GetModel(Linkid);
        }
        public List<FriendLink> GetModelList(string loginName)
        {
            return dal.GetModelList(loginName);
        }
        public int Updates(FriendLink model)
        {
            return dal.Updates(model);
        }
        public int StaticHtml(string loginname)
        {
            return dal.StaticHtml(loginname);
        }
    }
}
