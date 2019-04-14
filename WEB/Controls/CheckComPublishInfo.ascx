<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckComPublishInfo.ascx.cs"
    Inherits="Controls_CheckComPublishInfo" %>

<table width="100%" border="0" align="center" cellpadding="1" bgcolor="#4DA6FF" cellspacing="1">
    <tr bgcolor="#EFF6FF">
        <td style="text-align: center;">
            <asp:Label ID="lbMessage" runat="server" />
            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Red" OnClick="LinkButton1_Click">关 闭</asp:LinkButton></td>
    </tr>
</table>
<asp:Panel ID="plDisplay" runat="server">
    <table width="100%" border="0" align="center" cellpadding="1" bgcolor="#4DA6FF" cellspacing="1" id="showList">
        <tr bgcolor="#99ccff">
            <td width="6%" align="center" class="tabtitle" style="height: 29px">
                ID
            </td>
            <td width="36%" align="center" class="tabtitle" style="height: 29px">
                标题
            </td>
            <td align="center" class="tabtitle" style="height: 29px; width: 10%;">
                发布人
            </td>
            <td align="center" class="tabtitle" style="height: 29px; width: 10%;">
                状态</td>
            <td align="center" class="tabtitle" style="height: 29px; width: 15%;">
                发布时间</td>
        </tr>
        <asp:Repeater ID="rpCheck" OnItemDataBound="rpCheck_ItemDataBound" runat="server">
            <ItemTemplate>
                <tr bgcolor="#EFF6FF">
                    <td align="center" class="taba">
                        <%#Eval("InfoID") %>
                    </td>
                    <td align="left" class="taba">
                        &nbsp;<asp:HyperLink ID="hlkTitle" runat="server"></asp:HyperLink>
                    </td>
                    <td align="center" class="taba">
                        <%#Eval("LoginName")%>
                    </td>
                    <td align="center" class="taba">
                        <%#GetStatus(Eval("AuditingStatus"))%>
                    </td>
                    <td align="center" class="taba">
                        <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd(dd:mm)") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="6" align="right">
                <p>
                    共<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                        ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                            runat="server" Text="0"></asp:Literal>页
                    <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>
                    <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                    <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton><span>
                </p>
            </td>
        </tr>
    </table>
</asp:Panel>
