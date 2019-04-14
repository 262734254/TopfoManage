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

public partial class ErrowTabUpdate : System.Web.UI.Page
{
    private int Id
    {
        get
        {
            return (int)ViewState["Id"];
        }
        set
        {
            ViewState["Id"] = value;
        }
    }
    Tz888.BLL.ErrowTabBLL bll = new Tz888.BLL.ErrowTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Id=int.Parse(Request .QueryString ["str"]);
            BindShow();
        }
    }

    private void BindShow()
    {
        Tz888.Model.ErrowTab model = bll.GetModel(Id);
        this.txtlinkurl.Text = model.LinkURL.Trim();
        this.txtdescrption.Text = model.QuestionDescript.Trim();
        this.txtconnection.Text = model.Connetions.Trim();
        this.radiohuifu.Items.FindByValue(model .BoolReturn.ToString ().Trim ()).Selected =true ;
        this.txtreturncontext.Text = model.ReturnContext.Trim();
        this.txtbeizhu.Text = model.Descript.Trim();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.Model.ErrowTab model = new Tz888.Model.ErrowTab();
        model.Id = Id;
        model.ReturnContext = txtreturncontext.Text.Trim();
        model .BoolReturn=Convert .ToInt32(this.radiohuifu .SelectedValue);
        model.Descript = txtbeizhu.Text.Trim();
        model.BoolChuLi = 1;
        model.updatetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        int result = bll.Update(model);
        if (result > 0)
        {
            Response.Redirect("ErrowTabManage.aspx");
        }
        else
        {
            Response.Write("<script>alert('回复失败！');</script>");
        }
    }
}
