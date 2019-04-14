<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOther.aspx.cs" Inherits="wyzs_AddOther" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <%-- <script>
    function show()
    { 
        
        var longbin=document.getElementById("<%=ddlTypeName.ClientID %>").value;
        alert(longbin);
     }
        
        </script>--%>
</head>
<body>
    <form id="Form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>添加其它信息</b></span></p>
                </h2>
                <h2>
                    <p>
                        <span><b><a href="WyzsManage.aspx">资源管理</a></b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table" style="height: 210px;">
                <tr>
                    <td>
                        标题:</td>
                    <td align="left">
                        <asp:TextBox ID="txtTitle" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        类型 :</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlTypeName" runat="server" AutoPostBack="true" AutoPostBackAppendDataBoundItems="True"
                            OnSelectedIndexChanged="ddlTypeName_SelectedIndexChanged">
                            <asp:ListItem Value="0">--请选择--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        添加位置：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlPosition" runat="server">
                            <asp:ListItem Value="all">--请选择--</asp:ListItem>
                            <asp:ListItem Value="信息展示">信息展示</asp:ListItem>
                            <asp:ListItem Value="点击排行">点击排行</asp:ListItem>
                         <%--  <asp:ListItem Value="物业展示">物业展示</asp:ListItem>--%>
                            <asp:ListItem Value="底部信息">底部信息一</asp:ListItem>
                            <asp:ListItem Value="首页底部">底部信息二</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <%-- <tr id="show" runat="server" style="display:block;">
                    <td>
                        类型:</td>
                    <td align="left">
                        <asp:TextBox ID="txtType" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>--%>
                <tr>
                    <td>
                        排序:</td>
                    <td align="left">
                        <asp:TextBox ID="txtorder" onkeyup="value=value.replace(/[^\d]/g,'') " runat="server"
                            Width="153px" Height="22px"></asp:TextBox>
                        <span style="color: #808080">(请输入数字)</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        网址:</td>
                    <td align="left">
                        <asp:TextBox ID="txtSite" runat="server" Width="228px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAudit" runat="server" CssClass="btn" Text="修改" OnClick="btnAudit_Click" />
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="添加" OnClick="btnSubmit_Click" />
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
