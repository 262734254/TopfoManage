<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeList.aspx.cs" Inherits="MyHome_HomeList" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>主页信息列表</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="on_table">
                <tr>
                    <td style="width: 100px; height: 18px;">
                        网站分类名：</td>
                    <td style="width: 100px; height: 18px;">
                        网站名称：</td>
                        <td style="width: 100px; height: 18px;">
                        网址：</td>
                        <td style="width: 100px; height: 18px;">
                        创建时间：</td>
                        <td style="width: 100px; height: 18px;">
                        创建人：</td>
                         <td style="width: 100px; height: 18px;">
                        操作：</td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                        <td style="width: 100px">
                        <%#ShowStateName(Eval("nid").ToString())%>
                             </td>
                            <td style="width: 100px">
                               <%#Eval("LName")%>
                       
                            <td style="width: 100px">
                                <%#Eval("Linkwww")%>
                            </td>
                            <td style="width: 100px">
                               <%#Eval("CreateTimes","{0:yyyy-MM-dd}")%>
                            </td>
                            <td style="width: 100px">
                                <%#Eval("LoginName")%>
                            </td>
                               <td style="width: 100px">
                            <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("LID")%>' CommandName="del"  runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
               <td style="text-align:right; width: 348px;">
             <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="2">
                                </cc1:AspNetPager>&nbsp;</td>
                  <td style="text-align: left; width: 74px;" >
                                <span id="pinfo" runat="server"></span>&nbsp;</td>
        </div>
      
    </form>
</body>
</html>
