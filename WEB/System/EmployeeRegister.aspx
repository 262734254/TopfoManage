<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeRegister.aspx.cs"
    Inherits="EmployeeRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户注册</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/text.js"></script>

    <script type="text/javascript" src="../js/Common.js"></script>

    <script type="text/javascript" src="../js/wpCalendar.js"></script>

    <script type="text/javascript">
		function CheckLogin()
		{
		   var strLoginName=document.getElementById("txtLoginName").value;
		   if(trim(strLoginName)!="")
		   {
		        CheckLoginName(strLoginName);
		       //CheckLoginUserName(strLoginName)；
		   }
		}
    </script>

    <style type="text/css">
		.btn2 {width:126px;height:23px;background:url(../image/40_1.gif) no-repeat left top;border:none;cursor:pointer;}
		.tr1 {text-align:right;padding-right:5px;}
		.tr2 {text-align:left;padding-left:5px;}
		</style>
</head>
<body style="font-size: 10pt;">
    <form id="form1" runat="server">
        <div>
            <table style="border-color: #678897; border-style: solid; border-collapse: collapse;
                height: 640px;" bordercolor="#004f71" cellspacing="0" cellpadding="3" width="768"
                border="1" align="center" class="">
                <tbody>
                    <div class="title">
                        <h2>
                            <p>
                                <span><b>[用 户&nbsp;注 册]</b></span></p>
                        </h2>
                    </div>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp; 用户登录名<font face="宋体" color="red"><font face="宋体" color="#ff0000">*</font></font></td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtLoginName" Height="19px" runat="server" MaxLength="16" Width="176px"></asp:TextBox>
                            <input id="btnCheckLogin" type="button" class="btn2" value="检测用户名是否可用" onclick="CheckLogin();" />
                            <asp:RequiredFieldValidator ID="rfvLoginName" runat="server" ControlToValidate="txtLoginName"
                                ErrorMessage="登录名不能为空" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                            <asp:RegularExpressionValidator ID="revLoginName" runat="server" ControlToValidate="txtLoginName"
                                ErrorMessage="用户登录名只能由（4－16个）数字或英文组成,不支持中文" ValidationExpression="^[a-zA-Z0-9]\w{3,16}$"
                                Display="Dynamic"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 密码<font face="宋体" color="red"><font
                                face="宋体" color="#ff0000">*</font></font></td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtPassword" Height="19px" runat="server" MaxLength="16" Width="176px"
                                TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="密码不能为空" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="密码由6－16个英文字母或数字组成,并区分英文字母大小写。" ValidationExpression="^[a-zA-Z0-9]\w{5,16}$"
                                Display="Dynamic"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            <font face="宋体">&nbsp;&nbsp;&nbsp;重复输入密码<font face="宋体" color="#ff0000">*</font></font></td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="16" Width="176px"
                                Height="19px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                ErrorMessage="重复输入密码不能为空" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cpvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                ErrorMessage="重复输入密码必须与密码一致" ControlToCompare="txtPassword" Display="Dynamic"></asp:CompareValidator>
                            <font face="宋体"><font face="宋体" color="#ff0000"></font></font>
                        </td>
                    </tr>
                    <%--  暂不用
						<tr>
							<td><FONT face="宋体">&nbsp;&nbsp; 密码提示问题<FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
							<td><FONT face="宋体"><FONT face="宋体" color="#ff0000">&nbsp;
										<asp:textbox id="txtPasswordQuestion" runat="server" MaxLength="50" Width="176px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvPasswordQuestion" runat="server" ControlToValidate="txtPasswordQuestion"
											ErrorMessage="密码提示问题不能为空" Display="Dynamic"></asp:requiredfieldvalidator>
											<asp:RegularExpressionValidator ID="revPasswordQuestion" runat="server" ControlToValidate="txtPasswordQuestion"
											ErrorMessage="密码查询问题不能少于2个字符" ValidationExpression="^.{2,}$"  Display="Dynamic"></asp:RegularExpressionValidator>
									</FONT></FONT>
							</td>
						</tr>
						<tr>
							<td>&nbsp;&nbsp; 提示问题答案<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
							<td><FONT face="宋体" color="#ff0000">&nbsp;
									<asp:textbox id="txtPasswordAnswer" runat="server" MaxLength="50" Width="176px"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvPasswordAnswer" runat="server" 
                                    ControlToValidate="txtPasswordAnswer" ErrorMessage="密码答案不能为空" Display="Dynamic"></asp:requiredfieldvalidator><FONT face="宋体" color="#ff0000">
										<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="txtPasswordAnswer"
											ErrorMessage="密码答案不能少于2个字符" ValidationExpression="^.{2,}$"  Display="Dynamic"></asp:regularexpressionvalidator></FONT></FONT></td>
						</tr>
						--%>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 真实姓名<font face="宋体" color="#ff0000"><font face="宋体"
                                color="#ff0000">*</font> </font>
                        </td>
                        <td class="tr2">
                            <font face="宋体" color="#ff0000">
                                <asp:TextBox ID="txtEmployeeName" runat="server" Height="19px" MaxLength="20" Width="176px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMemberName" runat="server" ControlToValidate="txtEmployeeName"
                                    ErrorMessage="真实姓名不能为空" Display="Dynamic"></asp:RequiredFieldValidator><font face="宋体"
                                        color="#ff0000">
                                        <asp:RegularExpressionValidator ID="revMemberName" runat="server" ControlToValidate="txtEmployeeName"
                                            ErrorMessage="真实姓名为2-20个字符" ValidationExpression="^[\u4e00-\u9fa5a-zA-Z0-9]{2,50}$"
                                            Display="Dynamic"></asp:RegularExpressionValidator></font></font></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 性别<font face="宋体" color="#ff0000">&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></font>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" Height="24px">
                                <asp:ListItem Value="False" Selected="True">男</asp:ListItem>
                                <asp:ListItem Value="True">女</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 呢称<font face="宋体" color="#ff0000">&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></font></td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtNickName" runat="server" Height="19px" MaxLength="20" Width="216px"></asp:TextBox>&nbsp;
                            <%--<asp:requiredfieldvalidator id="rfvNickName" runat="server" ControlToValidate="txtNickName" ErrorMessage="呢称不能为空"></asp:requiredfieldvalidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 出生日期<font face="宋体" color="#ff0000">&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></font></td>
                        <td>
                            &nbsp;
                            <input id="tbDate" type="text" runat="server" onfocus="showCalendar(this);" readonly />
                            <font face="宋体">
                                <%--<asp:requiredfieldvalidator id="rfvCertificateNumber0" runat="server" ControlToValidate="tbDate"
									ErrorMessage="出生日期不能为空"></asp:requiredfieldvalidator>--%>
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 证件类型<font face="宋体" color="#ff0000">&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></font></td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlCertificateID" runat="server" DataTextField="CertificateName"
                                DataValueField="CertificateID">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 证件号码<font face="宋体" color="#ff0000">&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></font></td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtCertificateNumber" Height="19px" runat="server" MaxLength="20"
                                Width="272px"></asp:TextBox>
                            <%--<asp:requiredfieldvalidator id="rfvCertificateNumber" runat="server" ControlToValidate="txtCertificateNumber"
									ErrorMessage="证件号码不能为空"></asp:requiredfieldvalidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 详细地址<font face="宋体" color="#ff0000">&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></font>
                        </td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="25" Height="19px" Width="416px"></asp:TextBox>
                            <%--<asp:requiredfieldvalidator id="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="详细地址不能为空"></asp:requiredfieldvalidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            <font face="宋体"><font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                邮编<font face="宋体" color="#ff0000">&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></font></font></font></td>
                        <td>
                            <font face="宋体"><font face="宋体">&nbsp;<asp:TextBox ID="txtPostCode" Height="19px"
                                runat="server" MaxLength="6" Width="60px"></asp:TextBox>
                                <%--<asp:requiredfieldvalidator id="rfvPostCode" runat="server" ControlToValidate="txtPostCode" ErrorMessage="邮编不能为空"  Display="Dynamic"></asp:requiredfieldvalidator>--%>
                                <asp:RegularExpressionValidator ID="revPostCode" runat="server" ControlToValidate="txtPostCode"
                                    ErrorMessage="邮编为六位数字" ValidationExpression="^\d{6}$" Display="Dynamic"></asp:RegularExpressionValidator></font></font></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 联系电话&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></font></td>
                        <td>
                            <font face="宋体">&nbsp; 国家代码
                                <asp:TextBox ID="txtCountryCode" Height="19px" runat="server" MaxLength="10" Width="40px">+86</asp:TextBox>&nbsp;区号
                                <asp:TextBox ID="txtAreaCode" Height="19px" runat="server" MaxLength="4" Width="88px"></asp:TextBox>&nbsp;电话
                                <asp:TextBox ID="txtTelPhone" Height="19px" runat="server" MaxLength="13" Width="128px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revCountryCode" runat="server" ControlToValidate="txtCountryCode"
                                    ErrorMessage="国家代码为'＋'加2-3个数字" ValidationExpression="^\+\d{2,}$" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revAreaCode" runat="server" ControlToValidate="txtAreaCode"
                                    ErrorMessage="区号为3-4个数字" ValidationExpression="^\d{0,}$" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revTelPhone" runat="server" ErrorMessage="电话7~8位(分机加“-”,如xxxxxxxx-xxx)"
                                    ControlToValidate="txtTelPhone" ValidationExpression="^\d{7,}(-\d{2,8})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                <%--<asp:requiredfieldvalidator id="rfvAddress0" runat="server" 
                                    ControlToValidate="txtAreaCode" ErrorMessage="区号不能为空"></asp:requiredfieldvalidator>--%>
                                <%--<asp:requiredfieldvalidator id="rfvAddress1" runat="server" 
                                    ControlToValidate="txtTelPhone" ErrorMessage="电话不能为空"></asp:requiredfieldvalidator>--%>
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 手机&nbsp</td>
                        <td>
                            <font face="宋体">&nbsp<asp:TextBox ID="txtMobile" Height="19px" MaxLength="11" runat="server"
                                Width="168px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revMoible" runat="server" ControlToValidate="txtMobile"
                                    ErrorMessage="手机号码格式有误" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 传真&nbsp;
                        </td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtFax" Height="19px" runat="server" MaxLength="13" Width="168px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ControlToValidate="txtFax"
                                ErrorMessage="传真为7~8位(分机加“-”,如xxxxxxxx-xxx)" ValidationExpression="^\d{7,}(-\d{2,8})?$"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 电子邮箱&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtEmail" Height="19px" runat="server" MaxLength="50" Width="272px"></asp:TextBox>
                            <%--<asp:requiredfieldvalidator id="rfcEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="电子邮箱不能为空"  Display="Dynamic"></asp:requiredfieldvalidator>--%>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="电子邮箱范例为webmaster@topfo.com" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlDept" runat="server" DataTextField="DeptName" DataValueField="DeptID">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 职位&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlWorkType" runat="server" DataTextField="WorkTypeName" DataValueField="WorkType">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 学历&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlDegree" runat="server" DataTextField="DegreeName" DataValueField="DegreeID">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="tr1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 角色&nbsp;<%--<FONT face="宋体" color="#ff0000">*</FONT>--%></td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlRole" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr align="center">
                        <td colspan="2">
                            <asp:Button ID="btnRegister" runat="server" CssClass="btn" Text=" 注 册 " OnClick="btnRegister_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
