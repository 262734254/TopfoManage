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
using System.Collections.Generic;
using Tz888.Model;
using Tz888.BLL;

public partial class UserControl_RoleControl: System.Web.UI.UserControl
{

    /// <summary>
    /// 最大允许选择角色数

    /// </summary>
    private int _maxCount = 10;
    /// <summary>
    /// 已选择角色数

    /// </summary>
    private int _selectCount = 0;
    /// <summary>
    /// 已选中的角色集合(用于读取)
    /// </summary>
    ///Tz888.Model.Sys.SysRoleTab model = new Tz888.Model.Sys.SysRoleTab();
    //private List<Tz888.Model.Common.IndustryModel> _industryModels = new List<Tz888.Model.Common.IndustryModel>();
    private List<Tz888.Model.Sys.SysRoleTab> _roleModels = new List<Tz888.Model.Sys.SysRoleTab>();

    /// <summary>
    /// 选中角色的代码集合(用于设置)
    /// </summary>
    private string _industryString;

    /// <summary>
    /// 最大选择角色数

    /// </summary>
    public int MaxCount
    {
        get { return _maxCount; }
        set { _maxCount = value; }
    }
    /// <summary>
    /// 已选择角色数

    /// </summary>
    public int SelectCount
    {
        get { return _selectCount; }
    }

    /// <summary>
    /// 已选择角色集合(只读)
    /// </summary>
    public List<Tz888.Model.Sys.SysRoleTab> IndustryModels
    {
        get
        {
            //this._industryModels = new List<Tz888.Model.Common.IndustryModel>();
            this._roleModels = new List<Tz888.Model.Sys.SysRoleTab>();

            string SelectValue = this.hdselectValue.Value.Trim();//获取所有已选择的角色

            if (!string.IsNullOrEmpty(SelectValue))
            {
                string[] IndustryList = SelectValue.Split('|');
                for (int i = 0; i < IndustryList.Length; i++)
                {
                    string[] TmpList = IndustryList[i].ToString().Split(',');
                    //Tz888.Model.Common.IndustryModel model = new Tz888.Model.Common.IndustryModel();
                    Tz888.Model.Sys.SysRoleTab model = new Tz888.Model.Sys.SysRoleTab();
                    try
                    {
                       //model.IndustryBName = TmpList[0].ToString();
                        model.SRName = TmpList[0].ToString();
                        //model.IndustryBID = TmpList[1].ToString();
                        model.SRoleID =Convert.ToInt16(TmpList[1].ToString());
                        //this._industryModels.Add(model);
                        this._roleModels.Add(model);  
                    }
                    catch { }
                }
            }
            //return _industryModels;
            return _roleModels;
        }
    }

    public string IndustryString
    {
        get
        {
            this._industryString = "";
            string SelectValue = this.hdselectValue.Value.Trim();//获取所有已选择的角色

            if (!string.IsNullOrEmpty(SelectValue))
            {
                string[] IndustryList = SelectValue.Split('|');
                for (int i = 0; i < IndustryList.Length; i++)
                {
                    string[] TmpList = IndustryList[i].ToString().Split(',');
                    try
                    {
                        this._industryString += TmpList[1].ToString().Trim() + ",";
                    }
                    catch { }
                }
            }
            return this._industryString;
        }
        set
        {
            _industryString = value;
            if (!string.IsNullOrEmpty(_industryString))
            {
               // Tz888.BLL.Common.IndustryBLL bll = new Tz888.BLL.Common.IndustryBLL();
                Tz888.SQLServerDAL.Sys.SysRoleTab dal = new Tz888.SQLServerDAL.Sys.SysRoleTab();
                string IndustryList = "";
                int count = 0;
                string[] IndustryIDList = _industryString.Split(',');
                this.sltIndustryName_Select.Items.Clear();
                for (int i = 0; i < IndustryIDList.Length; i++)
                {
                    string IndustryID = IndustryIDList[i].Trim();
                    if (!string.IsNullOrEmpty(IndustryID))
                    {
                        string IndustryName = "";
                        IndustryName =dal.GetNameByID(IndustryID);
                        string temp = IndustryName + "," + IndustryID + "|";
                        IndustryList += temp;

                        ListItem tmpLi = new ListItem();
                        tmpLi.Value = IndustryID;
                        tmpLi.Text = IndustryName;

                        this.sltIndustryName_Select.Items.Add(tmpLi);
                        this.sltIndustryName_all.Items.Remove(tmpLi);
                        count++;
                    }
                }
                this._selectCount = count;
                this.hdselectValue.Value = IndustryList;
            }
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindIndustry();
        }

        if (IsPostBack)
        {
            string tmp = this.IndustryString;
            this.IndustryString = tmp;
        }
    }

    /// <summary>
    /// 绑定所有角色类型信息到页面
    /// </summary>
    private void BindIndustry()
    {
       // Tz888.BLL.Common.IndustryBLL objIndustry = new Tz888.BLL.Common.IndustryBLL();
        Tz888.SQLServerDAL.Sys.SysRoleTab role = new Tz888.SQLServerDAL.Sys.SysRoleTab();
        this.sltIndustryName_all.DataSource =role.dvGetAllIndustry();
        this.sltIndustryName_all.DataTextField = "SRName";
        this.sltIndustryName_all.DataValueField = "SRoleID";
        this.sltIndustryName_all.DataBind();
    }
}
