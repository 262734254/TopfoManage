<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailSupervise.aspx.cs" Inherits="Mail_MailSupervise" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理页</title>
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
    url="MailSupervise.aspx?str="+id;
    window.location.href = url;
}

function shenhe(idd)
{

      url="MailSuperAuditing.aspx?str="+idd;
      window.location.href = url;
 

}


    </script>

    <style type="text/css">
#fulExcel{
	width:200px;
	height:20px;
	border:1px solid maroon;
}

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>用户列表</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td>
                        类型：<asp:DropDownList ID="ddrleixing" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        组：<asp:DropDownList ID="ddrzu" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        名称：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td rowspan="2">
                        <asp:Button ID="btnSearch" CssClass="btn" runat="server" Text="查 询" OnClick="btnSearch_Click" /></td>
                </tr>
                <tr>
                    <td>
                        地域：<asp:DropDownList ID="ddrprovice" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddrprovice_SelectedIndexChanged">
                        </asp:DropDownList>&nbsp
                        <asp:DropDownList ID="ddrcity" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        行业：<asp:DropDownList ID="ddrxingye" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        状态：<asp:DropDownList ID="ddrstatue" runat="server">
                            <asp:ListItem Selected="True" Value="-1">--请选择--</asp:ListItem>
                            <asp:ListItem Value="0">未审核</asp:ListItem>
                            <asp:ListItem Value="1">已审核</asp:ListItem>
                        </asp:DropDownList>
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
                        名称</th>
                    <th>
                        类型</th>
                    <th>
                        地域</th>
                    <th>
                        行业</th>
                    <th>
                        状态</th>
                    <th>
                        邮件</th>
                    <th>
                        管理</th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                            <td>
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("UserID")%>"  runat="server" />
                                </label>
                            </td>
                            <td>
                                <%#(Eval("UserID"))%>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("UserName")%>'></asp:Label></a>
                                </td>
                                <td>
                                    <asp:Label ID="labstatu" runat="server" Text='<%# GetType(Convert.ToInt32(Eval("typeID"))) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Getdiyu(Convert.ToInt32(Eval("ProvinceId")),Convert.ToInt32(Eval("CityId"))) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# GetXingye(Convert.ToInt32(Eval("industry"))) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Getstatu(Convert.ToInt32(Eval("Audit"))) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("Mial")%>'></asp:Label>
                                </td>
                                <td>
                                    <a href="javascript:shenhe(<%# Eval("UserID") %>);">审核</a> 
                                    <%--<a href='JavaScript:DelNav("<%#Eval("UserID") %>");' onclick="if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>--%>
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <div class="pagebox" style="text-align: left">
                <a href="Javascript:SelectAll();">全选</a>/<a href="Javascript:ReSelect();">反选</a>&nbsp;
               <div style="display:none"> <div style="display:none"><asp:Button
                    ID="Button1" runat="server" OnClick="Button1_Click" Text="批量删除" CssClass="btn" /></div>&nbsp;
                <input type="button" value="录入用户" class="btn" onclick="javascript:location.href='MailSuperInsert.aspx'" id="Button2" />
                </div>
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
