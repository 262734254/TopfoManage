<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Member_Test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜单信息</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>菜单设置</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td colspan="3">
                        菜单名称</td>
                    <td colspan="2" style="width: 97px">
                        <a href="AddMenu.aspx">添加一级菜单</a>
                    </td>
                </tr>
                <asp:Repeater ID="rpMax" runat="server" OnItemCommand="rpMax_ItemCommand" EnableViewState="false">
                    <ItemTemplate>
                        <tr style="background-color: #E8F3F7;">
                            <td>
                                <asp:Label ID="lblMenuName" runat="server" Text='<%# Eval("MName") %>'></asp:Label>
                            </td>
                            <td>
                                <a href='AddMenu.aspx?MParentCode=<%# Eval("MID") %>'>添加二级菜单</a>
                            </td>
                            <td>
                                <%--<asp:LinkButton ID="lkCheck" runat="server" CommandArgument='<%# Eval("MID") %>'
                                    Text='<%# getCheckType(Eval("MCheck")) %>' CommandName="check" ToolTip='<%# Eval("MCheck") %>'></asp:LinkButton>--%>
                                <a href='checkMenu.aspx?MID=<%# Eval("MID") %>&MParentCode=<%# getCheckType(Eval("MCheck")) %>'>
                                    <%# getCheckType(Eval("MCheck")) %></a>
                            </td>
                            <td>
                                <a href='AddMenu.aspx?MID=<%# Eval("MID") %>'>修改</a>
                            </td>
                            <td>
                                <%--<asp:LinkButton ID="lkDelete" runat="server" CommandArgument='<%# Eval("MID") %>'
                                    Text="删除" CommandName="delete" ToolTip='<%# Eval("MParentCode") %>' OnClientClick='return confirm("删除后无法恢复!")'></asp:LinkButton>--%>
                                <a href='DeleteMenuInfo.aspx?MID=<%# Eval("MID") %>&MParentCode=<%# Eval("MParentCode") %>'
                                    onclick='return confirm("删除后无法恢复!")'>删除</a>
                            </td>
                        </tr>
                        <asp:Repeater ID="rpMini" runat="server" DataSource='<%# GetDataSourceByMID(DataBinder.Eval(Container.DataItem,"MID").ToString()) %>'
                            OnItemCommand="rpMini_ItemCommand" EnableViewState="false">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMenuName" runat="server" Text='<%# Eval("MName") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <%-- <asp:LinkButton ID="lkCheck" runat="server" CommandArgument='<%# Eval("MID") %>'
                                            Text='<%# getCheckType(Eval("MCheck")) %>' CommandName="check"></asp:LinkButton>--%>
                                        <a href='checkMenu.aspx?MID=<%# Eval("MID") %>&MParentCode=<%# getCheckType(Eval("MCheck")) %>'>
                                            <%# getCheckType(Eval("MCheck")) %></a>
                                    </td>
                                    <td colspan="2">
                                        <a href='AddMenu.aspx?MID=<%# Eval("MID") %>&MParentCode=<%# Eval("MParentCode") %>'>
                                            修改</a>
                                    </td>
                                    <td>
                                        <%--<asp:LinkButton ID="lkDelete" runat="server" CommandArgument='<%# Eval("MID") %>'
                                            Text="删除" CommandName="delete" OnClientClick='return confirm("删除后无法恢复!")'></asp:LinkButton>--%>
                                        <a href='DeleteMenuInfo.aspx?MID=<%# Eval("MID") %>&MParentCode=<%# Eval("MParentCode") %>'
                                            onclick='return confirm("删除后无法恢复!")'>删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
