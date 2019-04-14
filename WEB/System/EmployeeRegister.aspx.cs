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
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data.SqlClient;



public partial class EmployeeRegister : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            //证件类型
            BindZjType();
            //邦定部门
            BindDept();
            //邦定职位
            BindWorkType();
            //邦定学历
            BindDegree();
            //邦定角色
            BindRole();
        }

        // txtLoginName.Attributes.Add("onblur", "CheckLogin();");
    }

    //邦定证件类型
    private void BindZjType()
    {
        Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
        DataTable dt = bll.GetList("SetCertificateTab", "*", "certificateid", 30, 1, 0, 0, "");
        ddlCertificateID.DataTextField = "certificatename";
        ddlCertificateID.DataValueField = "certificateid";
        ddlCertificateID.DataSource = dt;
        ddlCertificateID.DataBind();
    }

    //邦定部门
    private void BindDept()
    {
        Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
        DataTable dt = bll.GetList("SetDeptInfoTab", "*", "deptid", 30, 1, 0, 0, "");
        ddlDept.DataTextField = "deptname";
        ddlDept.DataValueField = "deptid";
        ddlDept.DataSource = dt;
        ddlDept.DataBind();
    }

    //邦定职位
    private void BindWorkType()
    {
        Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
        DataTable dt = bll.GetList("setworktypetab", " * ", "worktype", 50, 1, 0, 0, "");
        ddlWorkType.DataTextField = "worktypename";
        ddlWorkType.DataValueField = "worktype";
        ddlWorkType.DataSource = dt;
        ddlWorkType.DataBind();
    }

    //邦定学历
    private void BindDegree()
    {
        Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
        DataTable dt = bll.GetList("SetDegreeInfoTab", " * ", "degreeid", 50, 1, 0, 0, "");
        ddlDegree.DataTextField = "degreename";
        ddlDegree.DataValueField = "degreeid";
        ddlDegree.DataSource = dt;
        ddlDegree.DataBind();
    }

    //邦定角色
    private void BindRole()
    {
        Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
        DataTable dt = bll.GetList("sysroletab", " * ", "sroleid", 50, 1, 0, 0, "");
        ddlRole.DataTextField = "srname";
        ddlRole.DataValueField = "sroleid";
        ddlRole.DataSource = dt;
        ddlRole.DataBind();
    }



    //注册
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        InsertData();
        // 暂不用 SaveUserDoc();



    }

    //注册
    private void SaveUserDoc()
    {
        //检查登录名是否重名
        if (CheckLoginUserName(txtLoginName.Text.Trim()))
        {
            Tz888.Common.MessageBox.Show(this, "该用户名已经存在，请使用其它用户名！");
            txtLoginName.Focus();
            //txtLoginName.Text = "";
            return;
        }

        //Employeeinfotab表
        Tz888.BLL.Sys.EmployeeInfoTab empBll = new Tz888.BLL.Sys.EmployeeInfoTab();
        Tz888.Model.Sys.EmployeeInfoTab empModel = new Tz888.Model.Sys.EmployeeInfoTab();


        empModel.LoginName = txtLoginName.Text.Trim();
        empModel.EmployeeName = txtEmployeeName.Text.Trim();
        string strSex = rblSex.SelectedValue.Trim();
        empModel.Sex = Convert.ToBoolean(strSex);
        empModel.NickName = txtNickName.Text.Trim();
        if (string.IsNullOrEmpty(tbDate.Value.Trim()))
        {
            empModel.Birthday = Convert.ToDateTime(tbDate.Value.Trim());
        }
        else
        {
            empModel.Birthday = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        }
        empModel.CertificateID = ddlCertificateID.SelectedValue.ToString().Trim();
        empModel.CertificateNumber = txtCertificateNumber.Text.Trim();
        empModel.CountryCode = "CN";
        empModel.ProvinceID = "1098";
        empModel.CityID = "1099";
        empModel.CountyID = "1100";
        empModel.Address = txtAddress.Text.Trim();
        empModel.PostCode = txtPostCode.Text.Trim();
        empModel.Tel = txtCountryCode.Text.Trim() + "-" + txtAreaCode.Text.Trim() + "-" + txtTelPhone.Text.Trim();
        empModel.Mobile = txtMobile.Text.Trim();
        empModel.FAX = txtFax.Text.Trim();
        empModel.Email = txtEmail.Text.Trim();
        empModel.DeptID = ddlDept.SelectedValue.Trim();
        empModel.WorkType = ddlWorkType.SelectedValue.Trim();
        empModel.DegreeID = ddlDegree.SelectedValue.Trim();
        empModel.Enable = true; //有效


        //logininfotab表
        Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
        Tz888.Model.LoginInfo loginModel = new Tz888.Model.LoginInfo();
        SHA1 sha1 = SHA1.Create();
        byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(txtPassword.Text.Trim()));

        loginModel.LoginName = txtLoginName.Text.Trim();
        loginModel.Password = bytePassword;
        //loginModel.PasswordQuestion = txtPasswordQuestion.Text.Trim();
        //loginModel.PasswordAnswer = txtPasswordAnswer.Text.Trim();
        loginModel.RoleName = "2";
        loginModel.IsCheckUp = false;
        loginModel.NickName = txtNickName.Text.Trim();
        loginModel.Tel = txtCountryCode.Text.Trim() + "-" + txtAreaCode.Text.Trim() + "-" + txtTelPhone.Text.Trim();
        loginModel.Email = txtEmail.Text.Trim();
        loginModel.RequirInfo = "";
        loginModel.RealName = "";
        loginModel.ManageTypeID = "1001";
        loginModel.MemberGradeID = "1001";//和以前的项目一样
        loginModel.Enable = true;  //有效

        string sTem = ddlRole.SelectedValue.Trim();
        if (empBll.Add(loginModel, empModel, sTem) > 0)
        {
            //Tz888.Common.MessageBox.Show(this, "注册成功！");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('注册成功！'); location.href='SysUser.aspx'", true);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this, "注册失败！");
        }
    }

    private void InsertData()
    {
        //检查登录名是否重名
        if (CheckLoginUserName(txtLoginName.Text.Trim()))
        {
            Tz888.Common.MessageBox.Show(this, "该用户名已经存在，请使用其它用户名！");
            txtLoginName.Focus();
            //txtLoginName.Text = "";
            return;
        }

        //Employeeinfotab表
        Tz888.BLL.Sys.EmployeeInfoTab empBll = new Tz888.BLL.Sys.EmployeeInfoTab();
        Tz888.Model.Sys.EmployeeInfoTab empModel = new Tz888.Model.Sys.EmployeeInfoTab();

        //密码
        SHA1 sha1 = SHA1.Create();
        byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(txtPassword.Text.Trim()));

        empModel.LoginName = txtLoginName.Text.Trim();
        empModel.Password = bytePassword;
        empModel.EmployeeName = txtEmployeeName.Text.Trim();
        string strSex = rblSex.SelectedValue.Trim();
        empModel.Sex = Convert.ToBoolean(strSex);
        empModel.NickName = txtNickName.Text.Trim();
        if (!string.IsNullOrEmpty(tbDate.Value.Trim()))
        {
            empModel.Birthday = Convert.ToDateTime(tbDate.Value.Trim());
        }
        else
        {
            //empModel.Birthday = DateTime.Now.ToShortTimeString();
            empModel.Birthday = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            //Response.Write("<script>alert('" + empModel.Birthday + "')</script>");
        }
        empModel.CertificateID = ddlCertificateID.SelectedValue.ToString().Trim();
        empModel.CertificateNumber = txtCertificateNumber.Text.Trim();
        empModel.CountryCode = "CN";
        empModel.ProvinceID = "1098";
        empModel.CityID = "1099";
        empModel.CountyID = "1100";
        empModel.Address = txtAddress.Text.Trim();
        empModel.PostCode = txtPostCode.Text.Trim();
        empModel.Tel = txtCountryCode.Text.Trim() + "-" + txtAreaCode.Text.Trim() + "-" + txtTelPhone.Text.Trim();
        empModel.Mobile = txtMobile.Text.Trim();
        empModel.FAX = txtFax.Text.Trim();
        empModel.Email = txtEmail.Text.Trim();
        empModel.DeptID = ddlDept.SelectedValue.Trim();
        empModel.WorkType = ddlWorkType.SelectedValue.Trim();
        empModel.DegreeID = ddlDegree.SelectedValue.Trim();
        empModel.Enable = true; //有效

        string sTem = ddlRole.SelectedValue.Trim();
        //if (empBll.Insert(empModel,sTem) > 0)
        if (empBll.Insert_V1(empModel, sTem) > 0) //2010-8-9改为存储过程
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('注册成功！'); location.href='SysUser.aspx'", true);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this, "注册失败！");
        }
    }

    //检查登录用户名是否重名
    private bool CheckLoginUserName(string strName)
    {
        Tz888.BLL.Sys.EmployeeInfoTab empbll = new Tz888.BLL.Sys.EmployeeInfoTab();
        DataTable dt = empbll.CheckUserLoginName(strName).Tables[0];

        bool flg = false;
        if (dt != null && dt.Rows.Count > 0)
        {
            flg = true;
        }
        else
        {
            flg = false;
        }
        return flg;
    }
}
