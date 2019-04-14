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

public partial class System_EmployeeModify :   BasePage 
{
    Tz888.BLL.Sys.EmployeeInfoTab empBll = new Tz888.BLL.Sys.EmployeeInfoTab();
    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();

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
            //BindRole();

            BindData();
        }
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

    ////邦定角色
    //private void BindRole()
    //{
    //    Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
    //    DataTable dt = bll.GetList("sysroletab", " * ", "sroleid", 50, 1, 0, 0, "");
    //    ddlRole.DataTextField = "srname";
    //    ddlRole.DataValueField = "sroleid";
    //    ddlRole.DataSource = dt;
    //    ddlRole.DataBind();
    //}

    //邦定数据
    private void BindData()
    {
        if (Request.QueryString["UserLoginName"] != null && Request.QueryString["UserLoginName"] != "")
        {
            string strName = Tz888.Common.DEncrypt.DESEncrypt.Decrypt(Request.QueryString["UserLoginName"].ToString());

            //获取employeeinfotab表数据
            Tz888.Model.Sys.EmployeeInfoTab empModel = new Tz888.Model.Sys.EmployeeInfoTab();
            empModel = empBll.GetModel(strName);

            //##暂不用
            ////获取logininfotab表数据
            //DataTable dt = loginBll.GetData(strName).Tables[0];

            txtLoginName.Text = empModel.LoginName;
            //txtPasswordQuestion.Text = dt.Rows[0]["passwordquestion"].ToString().Trim();
            //txtPasswordAnswer.Text = dt.Rows[0]["passwordanswer"].ToString().Trim();
            txtEmployeeName.Text = empModel.EmployeeName.Trim();

            txtNickName.Text = empModel.NickName.Trim();
            tbDate.Value = empModel.Birthday.ToShortDateString();
            ddlCertificateID.SelectedValue = empModel.CertificateID;
            txtCertificateNumber.Text = empModel.CertificateNumber.Trim();
            txtAddress.Text = empModel.Address.Trim();
            txtPostCode.Text = empModel.PostCode.Trim();

            //解联络电话字符串
            string strTel = empModel.Tel;
            string[] arr = strTel.Split('-');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr.Length > 0)
                    txtCountryCode.Text = arr[0].Trim();
                if (arr.Length > 1)
                    txtAreaCode.Text = arr[1].Trim();
                if (arr.Length > 2)
                    txtTelPhone.Text = arr[2].Trim();
            }

            txtMobile.Text = empModel.Mobile.Trim();
            txtFax.Text = empModel.FAX.Trim();
            txtEmail.Text = empModel.Email.Trim();
            ddlDept.SelectedValue = empModel.DeptID;
            ddlWorkType.SelectedValue = empModel.WorkType;
            ddlDegree.SelectedValue = empModel.DegreeID;
        }
    }

    //更新用户资料
    protected void UpdateData_Click(object sender, EventArgs e)
    {
        UpdateEmpTab();
        //UpdateUserDoc();  //暂不用
    }


    //更新数据
    private void UpdateUserDoc()
    {
        //Employeeinfotab表
        Tz888.BLL.Sys.EmployeeInfoTab empBll = new Tz888.BLL.Sys.EmployeeInfoTab();
        Tz888.Model.Sys.EmployeeInfoTab empModel = new Tz888.Model.Sys.EmployeeInfoTab();

        empModel.LoginName = txtLoginName.Text;
        empModel.EmployeeName = txtEmployeeName.Text.Trim();
        string strSex = rblSex.SelectedValue.Trim();
        empModel.Sex = Convert.ToBoolean(strSex);
        empModel.NickName = txtNickName.Text.Trim();
        empModel.Birthday = Convert.ToDateTime(tbDate.Value.Trim());
        empModel.CertificateID = ddlCertificateID.SelectedValue.ToString().Trim();
        empModel.CertificateNumber = txtCertificateNumber.Text.Trim();

        //*区域，这是修改内部会员资料，所以不更新它
        //*empModel.CountryCode = "CN";
        //*empModel.ProvinceID = "1098";
        //*empModel.CityID = "1099";
        //*empModel.CountyID = "1100";

        empModel.Address = txtAddress.Text.Trim();
        empModel.PostCode = txtPostCode.Text.Trim();
        empModel.Tel = txtCountryCode.Text.Trim() + "-" + txtAreaCode.Text.Trim() + "-" + txtTelPhone.Text.Trim();
        empModel.Mobile = txtMobile.Text.Trim();
        empModel.FAX = txtFax.Text.Trim();
        empModel.Email = txtEmail.Text.Trim();
        empModel.DeptID = ddlDept.SelectedValue.Trim();
        empModel.WorkType = ddlWorkType.SelectedValue.Trim();
        empModel.DegreeID = ddlDegree.SelectedValue.Trim();


        //logininfotab表
        Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
        Tz888.Model.LoginInfo loginModel = new Tz888.Model.LoginInfo();

        //######更新密码，暂不用
        //SHA1 sha1 = SHA1.Create();
        //byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(txtPassword.Text.Trim()));
        //loginModel.Password = bytePassword;
        //######

        loginModel.LoginName = txtLoginName.Text;
        //loginModel.PasswordQuestion = txtPasswordQuestion.Text.Trim();
        //loginModel.PasswordAnswer = txtPasswordAnswer.Text.Trim();
        loginModel.RoleName = "2";
        loginModel.IsCheckUp = false;
        loginModel.NickName = txtNickName.Text.Trim();
        loginModel.Tel = txtCountryCode.Text.Trim() + "-" + txtAreaCode.Text.Trim() + "-" + txtTelPhone.Text.Trim();
        loginModel.Email = txtEmail.Text.Trim();
        //*loginModel.RequirInfo = "";
        //*loginModel.RealName = "";
        //*loginModel.ManageTypeID = "1001";
        //*loginModel.MemberGradeID = "1001";//和以前的项目一样
        //*loginModel.Enable = true;  //有效

        string sTem = "";//不修改角色（有专门的修改页面）
        if (empBll.Update(loginModel, empModel, sTem) > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('资料修改成功！'); location.href='SysUser.aspx'", true);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this, "资料修改失败！");
        }
    }


    private void UpdateEmpTab()
    {
        //Employeeinfotab表
        Tz888.BLL.Sys.EmployeeInfoTab empBll = new Tz888.BLL.Sys.EmployeeInfoTab();
        Tz888.Model.Sys.EmployeeInfoTab empModel = new Tz888.Model.Sys.EmployeeInfoTab();

        empModel.LoginName = txtLoginName.Text;
        empModel.EmployeeName = txtEmployeeName.Text.Trim();
        string strSex = rblSex.SelectedValue.Trim();
        empModel.Sex = Convert.ToBoolean(strSex);
        empModel.NickName = txtNickName.Text.Trim();
        empModel.Birthday = Convert.ToDateTime(tbDate.Value.Trim());
        empModel.CertificateID = ddlCertificateID.SelectedValue.ToString().Trim();
        empModel.CertificateNumber = txtCertificateNumber.Text.Trim();

        //*区域，这是修改内部会员资料，所以不更新它
        //*empModel.CountryCode = "CN";
        //*empModel.ProvinceID = "1098";
        //*empModel.CityID = "1099";
        //*empModel.CountyID = "1100";

        empModel.Address = txtAddress.Text.Trim();
        empModel.PostCode = txtPostCode.Text.Trim();
        empModel.Tel = txtCountryCode.Text.Trim() + "-" + txtAreaCode.Text.Trim() + "-" + txtTelPhone.Text.Trim();
        empModel.Mobile = txtMobile.Text.Trim();
        empModel.FAX = txtFax.Text.Trim();
        empModel.Email = txtEmail.Text.Trim();
        empModel.DeptID = ddlDept.SelectedValue.Trim();
        empModel.WorkType = ddlWorkType.SelectedValue.Trim();
        empModel.DegreeID = ddlDegree.SelectedValue.Trim();

        if (empBll.UpdateEmpTab(empModel) > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('资料修改成功！'); location.href='SysUser.aspx'", true);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this, "资料修改失败！");
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

    //解联络电话字符串
    private void JiTel(string strTel)
    {
        string[] arr = strTel.Split('-');
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr.Length > 0)
                txtCountryCode.Text = arr[0].Trim();
            if (arr.Length > 1)
                txtAreaCode.Text = arr[1].Trim();
            if (arr.Length > 2)
                txtTelPhone.Text = arr[2].Trim();
        }
    }


}
