<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WyzsInfoManage.aspx.cs" Inherits="wyzs_WyzsInfoManage" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>物业列表</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/Common.js"></script>

    <script type="text/javascript" src="../js/CheckAll.js"></script>

    <script type="text/javascript" language="javascript">

            function Del(Id)
            {
                if(confirm('确认要删除吗？'))
                {
                    var url="WyzsInfoManage.aspx?MainId="+Id;
                    window.location.href = url;
                }
            }
            
            function Modify(Id,Types)
            {
                var url="ModifyWyzsInfo.aspx?MainId="+Id+"&Types="+Types;
                window.location.href = url;
            }
            
            function SelectAll(IsTure)
            {
                var Items = document.getElementsByTagName("input");
                if (Items.length > 0) {
                    for (var i = 0; i < Items.length; i++) {
                        var Item = Items[i];
                        if (Item.type == "checkbox" && Item.id.indexOf("CBox") > -1) {
                            Item.checked = IsTure;
                        }
                    }
                }
            }
            
    </script>

</head>
<body>
<form id="form1" runat="server">
        <div class="mainconbox">
            <div class="title" align="center">
                <h2>
                    <p><span><b>视各地政府招商网址管理</b></span></p>
                </h2>
            </div>
            <%-- <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                <tr>
                    <td align="center" >
                        标题：
                        <input id="txtTitle" type="text" runat="server" />
                        </td>
                        <td align="center">
                          是否推荐：
                         <asp:DropDownList ID="DropRecommend" runat="server">
                           <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                           <asp:ListItem Value="1">是</asp:ListItem>
                           <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td align="center">
                          展示位置:
                         <asp:DropDownList ID="ShowPosition" runat="server">
                        </asp:DropDownList>
                        </td>
                        <td align="center">
                        <asp:Button runat="server" ID="Search" CssClass="btn" Text="确定" OnClick="Search_Click"/></td>
                </tr>
            </table>--%>
               <div class=" cshibiank">
                <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr style="background: #bcd9e7; height: 27px;">
                    <th>
                        <a href="javascript:SelectAll(true);">全选</a>/<a href="javascript:SelectAll(false);">反选</a>
                    <th>
                        标题</th>
                    <th>
                        发布人</th>
                    <th>
                        类别</th>
                    <th>
                        状态</th>
                    <th>
                        发布时间</th>
                    <th>
                        管理</th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                            <td align="center">
                                <asp:CheckBox ID="CBox" runat="server" ToolTip='<%# Eval("Id") %>' />
                            </td>
                            <td align="center">
                                <%# Eval("title") %>
                            </td>
                            <td align="center">
                                <%#(Eval("MemberId"))%>
                            </td>
                            <td align="center">
                                <%# (Eval("Types").ToString() == "1" ? "求租" : Eval("Types").ToString() == "2" ? "购买" : Eval("Types").ToString() == "3" ? "出租" : "出售") %>
                            </td>
                            <td align="center">
                                <%# ((Eval("State").ToString() == "1") ? "已审核" : "未审核") %>
                            </td>
                            <td align="center">
                                <%#(Eval("PublishTime"))%>
                            </td>
                            <td align="center">
                                <a href='javascript:Modify(<%# Eval("Id") %>,"Modfiy");'>修改</a> 
                                <a href='javascript:Del(<%# Eval("Id") %>);'>删除</a>
                                <a href='javascript:Modify(<%# Eval("Id") %>,"Review");'>审核</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            </div>
            <div class="pagebox" style="margin-left:10px; margin-top:5px;">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td style="width: 10%;" align="left">
                            共<span id="pinfo" style="color: Red" runat="server"></span>个数据
                        </td>
                        <td style="width: 80%;">
                            <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false" NextPageText="下一页"
                                OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowInputBox="Always"
                                SubmitButtonText="GO" Width="479px">
                            </cc1:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="margin-left:10px; margin-top:5px;">
           <input type="button" value="录入信息" class="btn" onclick="window.location.href='AddWyzsInfo.aspx';" />
        </div>
    </form>
</body>
</html>

