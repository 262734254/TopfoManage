<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndustryManage.aspx.cs" Inherits="Advertorial_IndustryManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/Common.js"></script>

    <script type="text/javascript" src="../js/CheckAll.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="title">
                <h2>
                    <p>
                        <span><b>第一级行业类型</b></span></p>
                </h2>
            </div>
            <asp:GridView ID="GridView1" runat="server" CssClass="one_table two_table" Width="99.5%"
                AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
                PageSize="25" Height="25px" EnableViewState="false">
                <Columns>
                    <asp:TemplateField HeaderText="行号" SortExpression="sid">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称" SortExpression="industryName">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("industryName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="状态" SortExpression="CheckiD">
                        <ItemTemplate>
                         <%#this.GetStatu(Convert.ToInt32(Eval("CheckiD")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <%--Response.Redirect("MenuList2.aspx?sid=" + sid);--%>
                            <%-- <asp:LinkButton ID="lkxia" runat="server" Font-Size="9pt" CommandName="xiaji" CommandArgument='<%#Eval("sid") %>'>下一级菜单</asp:LinkButton>--%>
                            <a href='IndustryManage1.aspx?sid=<%#Eval("industryID") %>'>下一级</a>
                            <%--<asp:LinkButton ID="lkModefiy" runat="server" CommandName="modefiy" CommandArgument='<%#Eval("sid") %>'
                                Font-Size="9pt"></asp:LinkButton>--%>
                            <%--Response.Redirect("ModefiyMenu.aspx?sid=" + sid + "&ji=1");--%>
                            <a href='ModefiyMenu.aspx?sid=<%#Eval("industryID") %>&ji=1'>修改</a>
                            <%--<asp:LinkButton ID="lkDel" runat="server" OnClientClick="javascript:return confirm('确定要删除此菜单么？')"
                                Font-Size="9pt" CommandName="Del" CommandArgument='<%#Eval("sid") %>'>删除</asp:LinkButton>--%>
                            <%--<a  onclick="javascript:return confirm('确定要删除此菜单么')" href='DelMenu.aspx?sid=<%#Eval("Sid") %>'>删除</a>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle Height="22px" />
            </asp:GridView>
            <br />
            <table width="99.5%">
                <tr>
                    <td valign="bottom">
                        <asp:Button ID="btnAdd" runat="server" CssClass="btn" Text="添加行业" OnClick="btnAdd_Click" />
                    </td><td style="width: 15%;" valign="bottom">
                        <%-- <input type="button" id="btn" value="返回" class="btn" onclick="javascript:history.back()" />--%>
                    </td>
                    <td valign="bottom" style="width: 44%;" align="right">
                        <asp:Label ID="lblCurrentPage" runat="server" Font-Size="9pt"></asp:Label></td>
                    <td valign="top" style="width: 34%;" align="center">
                        <%--    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" PrevPageText="上一页" ShowInputBox="Always" SubmitButtonText="转到"
                            OnPageChanging="AspNetPager1_PageChanging" PageSize="15" Font-Size="9pt" >
                        </webdiyer:AspNetPager>--%>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
