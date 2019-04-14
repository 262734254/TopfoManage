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

public partial class System_management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Tz888.BLL.ServiesType objServ = new Tz888.BLL.ServiesType();
                DataView dv = new DataView();
                dv = objServ.GetServiesAllList();

                this.hidindex.Value = "";
                string servName = "";
                System.Text.StringBuilder strMess = new System.Text.StringBuilder();
                ViewState["Count"] = dv.Table.Rows.Count;
                for (int i = 0; i < dv.Table.Rows.Count; i++)
                {
                    if (dv.Table.Rows[i]["parentID"].ToString().Trim() == "")
                    {
                        strMess.Append("<li class=\"yuandian\">");
                    }
                    else
                    {
                        strMess.Append("<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                    servName = dv.Table.Rows[i]["ServiesName"].ToString();
                    if (servName.IndexOf("|-") != -1)
                    {
                        servName = servName.Substring(servName.IndexOf("|-") + 2, servName.Length - 2);
                    }
                    strMess.Append(servName);
                    strMess.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
                    strMess.Append("显示顺序");
                    strMess.Append(" &nbsp;&nbsp;&nbsp;<input name=\"txtSequence\"");
                    strMess.Append(" id=\"txtSequence" + i + "\"");
                    strMess.Append(" runat=\"Server\" type=\"text\"  value=\"" + dv.Table.Rows[i]["IndexNum"].ToString() + "\"");
                    strMess.Append(" size=\"2\" />");
                    string t = "";
                    if (dv.Table.Rows[i]["parentID"].ToString().Trim() == "")
                    {
                        strMess.Append(" [<a href=\"management_add.aspx?sid=" + dv.Table.Rows[i]["sid"].ToString() + "\"");
                        strMess.Append(">添加小类</a>]   ");
                    }
                    if (dv.Table.Rows[i]["parentID"].ToString().Trim() == "")
                    {
                        t = "b";//大类
                    }
                    else
                    {
                        t = "m";//小类
                    }
                    strMess.Append("[<a href=\"management_update.aspx?parentID=" + dv.Table.Rows[i]["parentID"].ToString());
                    strMess.Append("&sid=" + dv.Table.Rows[i]["sid"].ToString());
                    strMess.Append("&type=" + servName);
                    strMess.Append("&t=" + t);
                    strMess.Append("&index=" + dv.Table.Rows[i]["IndexNum"].ToString() + "\"");
                    strMess.Append(">编辑</a>]   ");
                    strMess.Append("[<a href=\"management.aspx?op=del&parentID=" + dv.Table.Rows[i]["parentID"].ToString());
                    strMess.Append("&sid=" + dv.Table.Rows[i]["sid"].ToString());
                    strMess.Append("\">删除</a>]</li><br/>");

                    this.hidparent.Value += dv.Table.Rows[i]["parentID"].ToString() + ",";
                    this.hidsid.Value += dv.Table.Rows[i]["sid"].ToString() + ",";
                    this.hidname.Value += servName + ",";
                    this.hidindex.Value += dv.Table.Rows[i]["IndexNum"].ToString() + ",";
                }
                this.lblMess.Text = strMess.ToString();
            }
            catch
            { }
        }
        if (Request.RawUrl.IndexOf("?op=del") > 0)
        {
            Delete();
        }
    }


    private void Delete()
    {
        try
        {
            string parentID = Request.QueryString["parentID"].ToString();
            int sid = Convert.ToInt32(Request.QueryString["sid"]);
            Tz888.BLL.ServiesType objServ = new Tz888.BLL.ServiesType();
            bool status = false;
            if (parentID.Trim() == "")
            {

                status = objServ.DeleteServiesB(sid);
                if (status)
                {
                    status = objServ.UpdateServiesIndex();
                    Response.Write("<script>alert('删除成功'); location.href='management.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败');</script>");
                }
            }
            else
            {
                status = objServ.DeleteServiesM(sid);
                if (status)
                {
                    status = objServ.UpdateServiesIndex();
                    Response.Write("<script>alert('删除成功'); location.href='management.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败');</script>");
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('参数传递失败。'); </script>");
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.BLL.ServiesType objserv = new Tz888.BLL.ServiesType();
        string parent = this.hidparent.Value.Trim();
        string index = this.hidindex.Value.Trim();
        string sid = this.hidsid.Value.Trim();
        string name = this.hidname.Value.Trim();
        string[] parentlst = parent.Split(',');
        string[] sidlst = sid.Split(',');
        string[] namelst = name.Split(',');
        string[] indexlst = index.Split(',');
        bool status = false;
        for (int i = 0; i < Convert.ToInt32(ViewState["Count"]); i++)
        {
            if (parentlst[i].ToString().Trim() == "")
            {
                status = objserv.UpdateServiesB(Convert.ToInt32(sidlst[i]), namelst[i].ToString(),
                    Convert.ToInt32(indexlst[i]));
                if (!status)
                {
                    Response.Write("<script>alert('保存失败1');</script>");
                    return;
                }
            }
            else
            {
                status = objserv.UpdateServiesM(Convert.ToInt32(sidlst[i]), namelst[i].ToString(), Convert.ToInt32(indexlst[i]));
                if (!status)
                {
                    Response.Write("<script>alert('保存失败2');</script>");
                    return;
                }
            }

        }
        status = objserv.UpdateServiesIndex();
        if (status)
        {
            Response.Write("<script>alert('保存成功'); location.href='management.aspx';</script>");
        }
    }
}
