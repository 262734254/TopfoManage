<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="System_UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="title"><h2><p><span><b>角色用户</b></span></p></h2></div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="one_table two_table">
            <Columns>
              <asp:BoundField DataField="EmployeeName" HeaderText="用户名称" />
              <asp:BoundField DataField="NickName" HeaderText="用户昵称" />
             <asp:BoundField DataField="Mobile" HeaderText="移动电话" />
              <asp:BoundField DataField="Email" HeaderText="电子邮箱" />
           
            </Columns>
        
        </asp:GridView>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="返回" CssClass="btn" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
