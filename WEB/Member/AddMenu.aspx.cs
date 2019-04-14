using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ManageSystem_Default : BasePage
{
    Tz888.Model.ManageSystem.MenuTabModel Model = new Tz888.Model.ManageSystem.MenuTabModel();
    Tz888.BLL.ManageSystem.MenuBLL MenuBLL = new Tz888.BLL.ManageSystem.MenuBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["MID"] != null)
        {

            if (!IsPostBack)
            {

                btUpdate.Visible = true;
                Button1.Visible = false;
                DataTable dt = MenuBLL.getMenuInfoListByMID(Request.QueryString["MID"].ToString());
                if (dt.Rows.Count > 0)
                {
                    tbMName.Text = dt.Rows[0]["MName"].ToString();
                    tbURL.Text = dt.Rows[0]["MURL"].ToString();
                    chTarget.SelectedValue = dt.Rows[0]["Target"].ToString();
                    txtOrder.Text = dt.Rows[0]["Sort"].ToString();
                }
            }
        }
        else
        {
            btUpdate.Visible = false;
            Button1.Visible = true;
        }
    }

    #region 添加菜单信息
    protected void Button1_Click(object sender, EventArgs e)
    {

        Model.MName = tbMName.Text.Trim();         //菜单名称
        Model.Murl = tbURL.Text.Trim();            //菜单地址
        Model.MCheck = "1";                        //菜单是否可用，默认可用
        Model.Sort = txtOrder.Text.Trim();

        if (Request.QueryString["MParentCode"] != null)
        {
            Model.MIsActive = 2;                   //二级菜单
            Model.MparentCode = int.Parse(Request.QueryString["MParentCode"].ToString()); //为二级菜单即为父级编号

        }
        else
        {
            Model.MIsActive = 1;                   //一级菜单

            Model.MparentCode = 0;                 //一级菜单码为0
        }
        Model.MCode = "M";                         //功能菜单
        Model.Target = chTarget.SelectedItem.Value;//页面打开方式
        Model.MDate = DateTime.Now;
        Model.Sort = txtOrder.Text.Trim();
        bool isOK = MenuBLL.addMenuInfo(Model);
        if (isOK)
        {
            Tz888.Common.MessageBox.ShowAndHref("菜单添加成功", "MenuInfo.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "菜单添加失败");
        }
    }
    #endregion

    #region 修改菜单信息
    protected void btUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.ManageSystem.MenuTabModel Model = new Tz888.Model.ManageSystem.MenuTabModel();
        Tz888.BLL.ManageSystem.MenuBLL MenuBLL = new Tz888.BLL.ManageSystem.MenuBLL();
        if (Request.QueryString["MID"] != null)
        {
            Model.Mid = int.Parse(Request.QueryString["MID"].ToString());
            Model.MName = Request["tbMName"];// tbMName.Text.Trim();         //菜单名称
            Model.Murl = Request["tbURL"];//tbURL.Text.Trim();            //菜单地址
            Model.MCheck = "1";                        //菜单是否可用，默认可用
            Model.Sort = txtOrder.Text.Trim();
            

            if (Request.QueryString["MParentCode"] != null)
            {
                Model.MIsActive = 2;                   //二级菜单
                Model.MparentCode = int.Parse(Request.QueryString["MParentCode"].ToString()); //为二级菜单即为父级编号

            }
            else
            {
                Model.MIsActive = 1;                   //一级菜单

                Model.MparentCode = 0;                 //一级菜单码为0
            }
            Model.MCode = "M";                         //功能菜单
            Model.Target = chTarget.SelectedItem.Value;//页面打开方式
            Model.MDate = DateTime.Now;
            Model.Sort = txtOrder.Text.Trim();

            bool isOK = MenuBLL.updateMenuInfo(Model);
            if (isOK)
            {
                Tz888.Common.MessageBox.ShowAndHref("菜单修改成功", "MenuInfo.aspx");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "菜单修改失败");
            }
        }
    }
    #endregion
}
