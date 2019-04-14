<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertRoleTab.aspx.cs" Inherits="dp_InsertRoleTab" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>拓富中国</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form id="form1" runat="server">
      <div class="title"><h2><p><span><b>
               添加组</b></span></p></h2></div>
        <table border="0" cellpadding="0" cellspacing="0" class="one_table"  >
            <tr>
                <td style="width: 62px">
                    角色名称：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="TxtSrName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width:62px">
                    角色描述：</td>
                <td style="width: 100px">
                    
                    <textarea  id="TxtSRDoc" runat="server"  style="width:340px;height: 100px"></textarea>
                     </td>
            </tr>
            <tr>
                 <td colspan="2" style="height: 26px; text-align:center;">
                    <asp:Button ID="BtnInsert" runat="server" CssClass="btn" OnClick="BtnInsert_Click" Text="添加角色" />
                    <asp:Button ID="ButUpdate" runat="server" CssClass="btn" OnClick="ButUpdate_Click" Text="修改角色" />
                     <asp:Button ID="rebtn" runat="server" Text="返回" CssClass="btn" OnClick="rebtn_Click" />
                    </td>
            </tr>
        </table>
    
 
    </form>
</body>
</html>
