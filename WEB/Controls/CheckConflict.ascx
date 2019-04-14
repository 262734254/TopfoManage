<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckConflict.ascx.cs"
    Inherits="Controls_CheckConflict" %>
<table width="100%" border="0" align="center" cellpadding="1" bgcolor="#4DA6FF" cellspacing="1">
    <tr bgcolor="#EFF6FF">
        <td style="height:30%; text-align:center;">
            <asp:Label ID="lbMessage" runat="server" />
        </td>
    </tr>
</table>
<asp:Panel ID="plDisplay" runat="server">
    <table width="100%" border="0" align="center" cellpadding="1" bgcolor="#4DA6FF" cellspacing="1">
        <tr bgcolor="#99ccff">
            <td width="6%" align="center" class="tabtitle" style="height: 29px">
                ID
            </td>
            <td width="36%" align="center" class="tabtitle" style="height: 29px">
                标题
            </td>
            <td width="10%" align="center" class="tabtitle" style="height: 29px">
                发布人
            </td>
            <td width="15%" align="center" class="tabtitle" style="height: 29px">
                发布时间</td>
        </tr>
        <asp:Repeater ID="rpCheck" OnItemDataBound="rpCheck_ItemDataBound" runat="server">
            <ItemTemplate>
                <tr bgcolor="#EFF6FF">
                    <td align="center" class="taba" style="height: 5px">
                        <label>
                            <%#Eval("InfoID") %>
                        </label>
                    </td>
                    <td align="left" class="taba" style="height: 5px">
                        <label>
                            &nbsp;<asp:HyperLink ID="hlkTitle" runat="server"></asp:HyperLink>
                        </label>
                    </td>
                    <td align="center" class="taba" style="height: 5px">
                        <%#Eval("LoginName")%>
                    </td>
                    <td align="center" class="taba" style="height: 5px">
                        <label title="<%#this.GetValiditeInfo(Eval("InfoOverdueTime")) %>">
                            <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd(dd:mm)") %>
                        </label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Panel>
</div> 