<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="db_UserList" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
         function CheckNull()
         {
            var UserName=document.getElementById("<%=txtUserName.ClientID %>");
            if(UserName.value=="")
            {
               alert("查询条件不能为空!");
               UserName.focus();
               return false;
            }
            return true;
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title"><h2><p><span><b>角色用户</b></span></p></h2></div>
     
    <div>
        <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                <tr>
                    <td align="center">
                    用户名：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td align="center">
                    <asp:Button runat="server" ID="Search" CssClass="btn" OnClientClick="return CheckNull();" Text="搜索" OnClick="Search_Click"/></td>
                </tr>
       </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="one_table two_table">
            <Columns>
              <asp:BoundField DataField="userName" HeaderText="用户名称" />
              <asp:BoundField DataField="typeName" HeaderText="类型" />
              <asp:BoundField DataField="Mobile" HeaderText="移动电话" />
              <asp:BoundField DataField="Email" HeaderText="电子邮箱" />
              <asp:BoundField DataField="StartTime" HeaderText="创建时间" />
            </Columns>
        </asp:GridView>
        <br/>
        <div class="pagebox">
            <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td style="width: 20%; height: 19px;" align="left">
                        共<span id="pinfo" style="color: Red" runat="server"></span>个数据
                    </td>
                    <td style="width: 80%; height: 19px;">
                        <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false" NextPageText="下一页"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowInputBox="Always"
                            Width="479px">
                        </cc1:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="返回" CssClass="btn" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
