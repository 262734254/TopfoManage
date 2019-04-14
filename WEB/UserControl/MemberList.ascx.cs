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
using Tz888.Model;
using Tz888.BLL;
using System.Collections.Generic;

public partial class UserControl_MemberList: System.Web.UI.UserControl
{
    /// <summary>
    /// 最大允许选择员工数数
    /// </summary>
    private int _maxCount = 20;
    /// <summary>
    /// 已选择员工数数
    /// </summary>
    private int _selectCount = 0;
    /// <summary>
    /// 已选中的员工数集合(用于读取)
    /// </summary>
   
    //private List<Tz888.Model.Sys.SysRoleTab> _roleModels = new List<Tz888.Model.Sys.SysRoleTab>();
    private List<Tz888.Model.Sys.EmployeeInfoTab> _employModels = new List<Tz888.Model.Sys.EmployeeInfoTab>();
    /// <summary>
    /// 选中员工数的代码集合(用于设置)
    /// </summary>
    private string _industryString;

    /// <summary>
    /// 最大选择员工数数
    /// </summary>
    public int MaxCount
    {
        get { return _maxCount; }
        set { _maxCount = value; }
    }
    /// <summary>
    /// 已选择员工数数
    /// </summary>
    public int SelectCount
    {
        get { return _selectCount; }
    }

    /// <summary>
    /// 已选择员工数集合(只读)
    /// </summary>
    public List<Tz888.Model.Sys.EmployeeInfoTab> IndustryModels
    {
        get
        {
            
           // this._roleModels = new List<Tz888.Model.Sys.SysRoleTab>();
            this._employModels = new List<Tz888.Model.Sys.EmployeeInfoTab>();
            string SelectValue = this.hdselectValue.Value.Trim();//获取所有已选择的员工数
            if (!string.IsNullOrEmpty(SelectValue))
            {
                string[] IndustryList = SelectValue.Split('|');
                for (int i = 0; i < IndustryList.Length; i++)
                {
                    string[] TmpList = IndustryList[i].ToString().Split(',');
                    
                   //Tz888.Model.Sys.SysRoleTab model = new Tz888.Model.Sys.SysRoleTab();
                    Tz888.Model.Sys.EmployeeInfoTab model= new Tz888.Model.Sys.EmployeeInfoTab();
                    try
                    {
                       
                       //model.SRName = TmpList[0].ToString();
                        model.EmployeeName = TmpList[0].ToString();
                       
                       //model.SRoleID = Convert.ToInt16(TmpList[1].ToString());
                        model.EmployeeID = Convert.ToInt16(TmpList[1].ToString());
                        //this._roleModels.Add(model);
                        this._employModels.Add(model);
                    }
                    catch { }
                }
            }
           
           // return _roleModels;
              return _employModels;
        }
    }

    public string IndustryString
    {
        get
        {
            this._industryString = "";
            string SelectValue = this.hdselectValue.Value.Trim();//获取所有已选择的员工数
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
                //Tz888.BLL.Common.IndustryBLL bll = new Tz888.BLL.Common.IndustryBLL();
                //Tz888.SQLServerDAL.Common.RoleDAL dal = new Tz888.SQLServerDAL.Common.RoleDAL();
                Tz888.SQLServerDAL.Sys.EmployeeInfoTab dal = new Tz888.SQLServerDAL.Sys.EmployeeInfoTab();
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
                        IndustryName = dal.GetModel(int.Parse(IndustryID)).EmployeeName;
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
    /// 绑定所有员工数类型信息到页面

    /// </summary>
    private void BindIndustry()
    {
       
        //Tz888.SQLServerDAL.Common.RoleDAL role = new Tz888.SQLServerDAL.Common.RoleDAL();
        Tz888.SQLServerDAL.Sys.EmployeeInfoTab member = new Tz888.SQLServerDAL.Sys.EmployeeInfoTab();
        this.sltIndustryName_all.DataSource = member.GetList("");
        this.sltIndustryName_all.DataTextField = "EmployeeName";
        this.sltIndustryName_all.DataValueField = "EmployeeID";
        this.sltIndustryName_all.DataBind();
    }
}
