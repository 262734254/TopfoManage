<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowRoleList.aspx.cs" Inherits="ManageSystem_ShowRoleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>权限分配</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" EnableViewState="false">
                    <ItemTemplate>
                        <tr bgcolor="#C9DEF3">
                            <td style="width: 100px">
                                <%#Eval("ManageTypeName")%>
                            </td>
                            <td style="width: 100px"align="center">
                            <!--
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%#Eval("ManageTypeID")%>'
                                    CommandName='Edit'>编辑</asp:LinkButton>-->
                                    <a href="AddRole.aspx?RoleID=<%#Eval("ManageTypeID").ToString().Trim()%>&name='Edit'">编辑</a>
                            </td>
                            <td colspan="2">
                               <!-- <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("ManageTypeID")%>' CommandName="Add"
                                    runat="server">添加角色组</asp:LinkButton>-->
                                    <a href="AddRoleGrop.aspx?RoleID=<%#Eval("ManageTypeID")%>&name=Add">添加角色组</a>
                            </td>
                            <td style="width: 100px">
                               <!-- <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("ManageTypeID")%>'
                                    CommandName="IsCheck" Text='<%# getCheckType(Eval("IsCheck")) %>'></asp:LinkButton>-->
                                    <a href="IsCheck.aspx?IsCheck=<%#Eval("IsCheck") %>&RoleID=<%#Eval("ManageTypeID")%>"><%# getCheckType(Eval("IsCheck")) %></a>
                            </td>
                            <td style="width: 100px" align="center">
                                    <a href="DeleteRole.aspx?RoleID=<%#Eval("ManageTypeID").ToString().Trim()%>" onclick="javascript:return confirm('你确定要删除吗？');">删除</a>
                            </td>
                        </tr>
                        <asp:Repeater ID="Repeater2" runat="server" DataSource='<%# GetDataSourceByRoleID(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"ManageTypeID"))) %>' EnableViewState="false">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 100px">
                                        <%#Eval("MemberGradeName")%>
                                    </td>
                                    <td style="width: 100px">
                                    <!--
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Edit" CommandArgument='<%#Eval("MemberGradeID")%>'
                                            OnCommand="LinkButton1_Command">编辑</asp:LinkButton>-->
                                            <a href="AddRoleGrop.aspx?RoleID=<%#Eval("MemberGradeID").ToString().Trim()%>&name=Edit">编辑</a>
                                        <td style="width: 100px">
                                           <a href="ListVip.aspx?MemberGradeID=<%#Eval("MemberGradeID").ToString().Trim()%>&name=<%#Eval("MemberGradeName").ToString().Trim()%>">会员</a>
                                            </td>
                                        <td style="width: 100px">
                                            <a href="AddCompetence.aspx?MemberGradeID=<%#Eval("MemberGradeID").ToString().Trim()%>&ManageTypeID=<%#Eval("ManageTypeID").ToString().Trim()%>">
                                                权限</a>
                                        </td>
                                        <td style="width: 100px">
                                        <!--
                                            <asp:LinkButton ID="LinkButton6" runat="server" CommandName="IsKai" Text='<%#getSCheck(Eval("SCheck"))%>'
                                                CommandArgument='<%#Eval("MemberGradeID")%>' OnCommand="LinkButton1_Command"></asp:LinkButton>-->
                                             <a href="IsKaiTong.aspx?Id=<%#Eval("MemberGradeID")%>&IsKai=<%#Eval("SCheck")%>"><%#getSCheck(Eval("SCheck"))%></a>   
                                        </td>
                                        <td style="width: 100px">
                                            <!--
                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="delete" CommandArgument='<%#Eval("MemberGradeID")%>'
                                                OnCommand="LinkButton1_Command">删除</asp:LinkButton>-->
                                                
                                                <a href="Delete.aspx?Id=<%#Eval("MemberGradeID")%>" onclick="javascript:return confirm('你确定要删除吗？');">删除</a>
                                                
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
