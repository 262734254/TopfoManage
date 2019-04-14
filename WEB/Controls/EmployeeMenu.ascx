<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeMenu.ascx.cs" Inherits="Controls_EmployeeMenu" %>
        <style type="text/css">
    /*网易风格*/
    .anpager .cpb {background:#1F3A87 none repeat scroll 0 0;border:1px solid #CCCCCC;color:#FFFFFF;font-weight:bold;margin:5px 4px 0 0;padding:4px 5px 0;}
    .anpager a {background:#FFFFFF none repeat scroll 0 0;border:1px solid #CCCCCC;color:#1F3A87;margin:5px 4px 0 0;padding:4px 5px 0;text-decoration:none}
    .anpager a:hover{background:#1F3A87 none repeat scroll 0 0;border:1px solid #1F3A87;color:#FFFFFF;}

    /*拍拍网风格*/
    .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 20px 10px 0; margin: 0px;}
    .paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
    .paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
    .paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none} 
    .paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;}

    /*迅雷风格*/
    .pages { color: #999 }
    .pages a, .pages .cpb { text-decoration:none;float: left; padding: 0 5px; border: 1px solid #ddd;background: #ffff;margin:0 2px; font-size:11px; color:#000;}
    .pages a:hover { background-color: #E61636; color:#fff;border:1px solid #E61636; text-decoration:none;}
    .pages .cpb { font-weight: bold; color: #fff; background: #E61636; border:1px solid #E61636;}

    .code{font-weight:bold;color:blue}
    </style>
<table width="161" height="100%" border="0" align="center" cellpadding="0" cellspacing="0"
    class="liangbianlan" id="Table2">
    <tr>
        <td valign="top" width="160" background="http://img.tz888.cn/manageImg/images/xinxiguangli_12.gif">
            <img height="55" alt="" src="http://img.tz888.cn/manageImg/images/xinxiguangli_04.gif"
                width="160" align="top">
            <table id="Table3" cellspacing="0" cellpadding="0" width="160" border="0">
                <tbody>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="px13" align="center" background="http://img.tz888.cn/manageImg/images/xinxiguangli_07.gif">
                                        <strong>信息编辑管理</strong></td>
                                    <td width="51">
                                        <img height="34" alt="" src="http://img.tz888.cn/manageImg/images/xinxiguangli_09.gif"
                                            width="51"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td background="http://img.tz888.cn/manageImg/images/xinxiguangli_12.gif">
                            <table id="Table5" cellspacing="0" cellpadding="0" width="100%" border="0">
                            </table>
                            <asp:DataList ID="dlMainMenu" runat="server" Width="95%" OnItemDataBound="dlMainMenu_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="Table5" cellspacing="0" cellpadding="0" width="100%" border="0">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td height="6">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="17" valign="top" background="http://img.tz888.cn/manageImg/images/xinxiguangli_15.gif">
                                           &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hlItem" runat="server"></asp:HyperLink></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </TABLE>
                                </FooterTemplate>
                            </asp:DataList>
                        </td>
                        <tr>
                            <td align="center" height="25">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <font face="宋体"></font>
                                <asp:HyperLink ID="hlLogout" runat="server" ImageUrl="http://img.tz888.cn/manageImg/images/xinxiguangli_21.gif"
                                    NavigateUrl="/Logout.aspx"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="25">
                            </td>
                        </tr>
                </tbody>
            </table>
        </td>
    </tr>
</table>
