<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Member_Test" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加菜单</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function Check()
        {
            flag = true;
            if(document.getElementById("tbMName").value == "")
            {
                alert("请填写菜单名称");
                flag = false;
            }
            return flag;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>添加菜单</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td style="width: 100px">
                        菜单名称：</td>
                    <td align="left" style="width: 100px">
                        <asp:TextBox ID="tbMName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        地址：</td>
                    <td align="left" style="width: 100px">
                        <asp:TextBox ID="tbURL" runat="server" Width="237px"></asp:TextBox></td>
                </tr>
                      <tr>
                    <td style="width: 23%; height: 35px;" align="center">
                        排序号：</td>
                    <td align="left"  valign="middle" style="height: 35px">
                        <div style="display:inline; text-align: left; font-size:13px;">
                        <asp:TextBox ID="txtOrder" runat="server" Width="163px" Height="19px"></asp:TextBox>
                        </div> 
                        
                        </td>
                </tr>
                <%--<tr>
                    <td style="width: 100px">
                        菜单类型：</td>
                    <td style="text-align:left;width:237px;">
                        <asp:RadioButton ID="rdMenuType1" runat="server" Text="功能菜单" Checked="true" GroupName="rdMenuType" />
                        <asp:RadioButton ID="rdMenuType2" runat="server" Text="权限菜单" GroupName="rdMenuType" />
                    </td>
                </tr>--%>
                <tr>
                    <td style="width: 100px">
                        页面打开方式：</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="chTarget" runat="server">
                            <asp:ListItem Text="当前页面" Value="_self" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="新页面" Value="_blank"></asp:ListItem>
                        </asp:DropDownList>                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="添加" CssClass="btn" OnClick="Button1_Click" OnClientClick="return Check();" />
                        <asp:Button ID="btUpdate" runat="server" Text="修改" CssClass="btn" OnClientClick="return Check();" Visible="false" OnClick="btUpdate_Click" />
                        <asp:Button ID="Button2" runat="server" Text="返回" CssClass="btn" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
