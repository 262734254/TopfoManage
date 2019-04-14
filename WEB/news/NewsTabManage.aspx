<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsTabManage.aspx.cs" Inherits="news_NewsTabManage" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>录入管理页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/Common.js"></script>

    <script type="text/javascript" src="../js/CheckAll.js"></script>

    <script type="text/javascript" language="javascript">
    function SelectAll()
{
    if(!document.getElementById("cbxSelect"))
        return;
    var obj = document.getElementById("cbxSelect");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
		{
		    if(elem[i].checked!=true)			
			    elem[i].click();
		}
    }
}

function ReSelect()
{
    if(!document.getElementById("cbxSelect"))
        return;
    var obj = document.getElementById("cbxSelect");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
		{
			    elem[i].click();
		}
    }
}

function DelNav(id)
{
    var url="";
    url="NewsTabManage.aspx?str="+id;
    window.location.href = url;
}

function shenhe(idd)
{

      url="NewsTabShenHe.aspx?str="+idd;
      window.location.href = url;
 

}


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>录入信息列表</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td>
                        编号：
                        <input id="txtNuber" type="text" runat="server" /></td>
                    <td>
                        标题：<asp:TextBox ID="txtnewstitle" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        类型：
                        <asp:DropDownList ID="ddlType" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        状态：
                        <asp:DropDownList ID="ddrstuta" runat="server">
                            <asp:ListItem Selected="True" Value="-1">请选择</asp:ListItem>
                            <asp:ListItem Value="0">未审核</asp:ListItem>
                            <asp:ListItem Value="1">已审核</asp:ListItem>
                            <asp:ListItem Value="3">未通过审核</asp:ListItem>
                            <asp:ListItem Value="5">已删除</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        发布人：
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnSearch" CssClass="btn" runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr style="background: #bcd9e7; height: 27px;">
                    <th>
                        选择</th>
                    <th>
                        编号</th>
                    <th>
                        标题</th>
                    <th>
                        类型</th>
                    <th>
                        状态</th>
                    <th>
                        来源</th>
                    <th>
                        发布人</th>
                    <th>
                        发布日期</th>
                    <th>
                        管理</th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                            <td>
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("Newsid")%>" />
                                </label>
                            </td>
                            <td>
                                <%#(Eval("Newsid"))%>
                                <td>
                                    <a href="http://news.topfo.com/<%# Eval("Urlhtml") %>" target="_blank">
                                        <asp:Label ID="Label2" runat="server" Text='<%#  FormatNull(Convert.ToString(Eval("NTitle")), 10) %>'></asp:Label></a>
                                </td>
                                <td>
                                    <asp:Label ID="labstatu" runat="server" Text='<%# GetType(Convert.ToInt32(Eval("TypeID"))) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# GetStatu(Convert.ToInt32(Eval("Audit"))) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%# GetLaiyuan(Convert.ToInt32(Eval("FromID"))) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                </td>
                                <td>                                           
                                    <asp:Label ID="Label1" runat="server" Text='   <%#Convert.ToDateTime(Eval("createdate")).ToString("yyyy-MM-dd")%> '></asp:Label>
                                </td>
                                <td>
                                    <a href="javascript:shenhe(<%# Eval("Newsid") %>);">审核</a> <a href='JavaScript:DelNav("<%#Eval("Newsid") %>");'
                                        onclick="if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td align="left" style="height: 24px">
                        生成<span style="color: #FF00CC">新闻</span>首页：<asp:TextBox ID="txtIndex" runat="server"
                            Height="20px" Width="247px">http://news.topfo.com/index.aspx</asp:TextBox>&nbsp;
                        <asp:Button ID="btnIndexStatic" CssClass="btn" runat="server" Text=" 生成" OnClick="btnIndexStatic_Click" />&nbsp;
                    </td>
                </tr>
            </table>
            <br />
            <div class="pagebox" style="text-align: left">
                <a href="Javascript:SelectAll();">全选</a>/<a href="Javascript:ReSelect();">反选</a>&nbsp;将选中的资讯<asp:Button
                    ID="Button1" runat="server" OnClick="Button1_Click" Text="删除" CssClass="btn" />&nbsp;<asp:Button
                        ID="btnpublic" CssClass="btn" runat="server" Text="批量生成" OnClick="btnpublic_Click" />
                <input type="button" value="录入信息" class="btn" onclick="javascript:location.href='NewTabs.aspx'" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <div style="text-align: right">
                    <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                        PagerStyle="CustomAndNumeric" ControlToPaginate="RfList" PagingMode="NonCached"
                        UseCustomDataSource="False" ShowCount="True" SortColumn="PublishT" SortType="DESC"
                        TableViewName="MainInfoVIW" KeyColumn="InfoID" ShowPageCount="False"></cc1:Pager>
                    &nbsp;</div>
            </div>
        </div>
    </form>
</body>
</html>
