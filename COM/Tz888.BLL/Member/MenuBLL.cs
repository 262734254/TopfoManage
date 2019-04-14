using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.BLL.ManageSystem
{
    public class MenuBLL
    {
        Tz888.SQLServerDAL.ManageSystem.MenuTabDAL MenuDal = new Tz888.SQLServerDAL.ManageSystem.MenuTabDAL();
        public bool addMenuInfo(Tz888.Model.ManageSystem.MenuTabModel model)
        {
            return MenuDal.addMenuInfo(model);
        }

        public DataTable getMenuInfoList(string MparentCode)
        {
            return MenuDal.getMenuInfoList(MparentCode);
        }

        #region 审核
        public int MenuCheck(string MID, string MCheck)
        {
            return MenuDal.MenuCheck(MID, MCheck);
        }
        #endregion

        #region 删除
        public bool deletMenuInfoList(string MparentCode, string MID)
        {
            //proc_deleteMenuList 
            return MenuDal.deletMenuInfoList(MparentCode, MID);
        }
        #endregion

        #region 修改菜单
        public bool updateMenuInfo(Tz888.Model.ManageSystem.MenuTabModel model)
        {
            return MenuDal.updateMenuInfo(model);
        }
        #endregion

        #region 获取菜单列表ByID
        public DataTable getMenuInfoListByMID(string MID)
        {
            return MenuDal.getMenuInfoListByMID(MID);
        }
        #endregion
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return MenuDal.GetList(strWhere);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateJS(int id, int sort)
        {
            return MenuDal.UpdateSort(id, sort);
        }


    }
}
