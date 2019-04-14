<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddResDong.aspx.cs" Inherits="tuijian_AddResDong" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
      <link href="../css/style.css" type="text/css" rel="stylesheet">
        <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table style="border-color:#678897; border-style:solid;  border-collapse:collapse; height:180px; "
					borderColor="#004f71" cellSpacing="0" cellPadding="3" border="1" align="center" class="">
                <tr><td >推荐资源列表名称：</td><td >
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
                <tr><td >状态：</td><td >
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" valign="top" Height="1px" Width="174px">
                    <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
                    <asp:ListItem Value="0">禁用</asp:ListItem>
                    </asp:RadioButtonList></td></tr>
                    <tr><td >列表ID</td><td >
                        <asp:TextBox ID="TextList" runat="server"></asp:TextBox></td></tr>
                <tr><td >备注：</td><td >
                    <textarea id="TextBei" runat="server" ></textarea></td></tr>
                <tr><td >&nbsp;</td><td style="width: 357px">
                    <asp:Button ID="Button1" runat="server" Text="确认添加" OnClick="Button1_Click" CssClass="btn" /></td></tr>
                </table>
    </div>
    </form>
</body>
</html>
