<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModefiyPassword.aspx.cs"
    Inherits="System_ModefiyPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>
                            <asp:Literal ID="lbmenu" runat="server"></asp:Literal></b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table" style="width: 612px;
                height: 124px">
                <tr>
                    <td style="width: 23%" align="center">
                        用户名：</td>
                    <td align="left" style="width: 333px; display: inline;" valign="middle">
                        <asp:TextBox ID="txtUserName" runat="server"  Height="21px"
                            Width="163px" AutoCompleteType="Email" ReadOnly="true" ></asp:TextBox>&nbsp;
                        <div style="display: inline; text-align: left; font-size: 13px;">
                            &nbsp;<span id="message"></span>&nbsp;</div>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 23%">
                        旧密码：</td>
                    <td align="left" style="display: inline; width: 333px" valign="middle">
                        <asp:TextBox ID="txtOldPwd" runat="server" AutoCompleteType="Email" Height="21px"
                            ReadOnly="true" Width="163px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" style="width: 23%; height: 39px">
                        新密码：</td>
                    <td align="left" style="height: 39px" valign="middle">
                        <asp:TextBox ID="txtPassword" runat="server" Height="20px" Width="161px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                            ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="新密码不能为空"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="密码由6－16个英文字母或数字组成,并区分英文字母大小写。" ValidationExpression="^[a-zA-Z0-9]\w{5,16}$"
                            Display="Dynamic"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td align="center" style="width: 23%; height: 39px">
                        重复输入密码：</td>
                    <td align="left" style="height: 39px" valign="middle">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" Height="20px" Width="161px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                            ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="重复输入密码不能为空" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cpvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="重复输入密码必须与密码一致" ControlToCompare="txtPassword" Display="Dynamic"></asp:CompareValidator></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button2" runat="server" Text="修改" OnClick="Button1_Click"
                            CssClass="btn" />
                        &nbsp;&nbsp;
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
