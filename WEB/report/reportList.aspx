<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportList.aspx.cs" Inherits="report_reportList" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>行业分析列表页</title>
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
    url="reportList.aspx?str="+id;
    window.location.href = url;
}

function shenhe(idd)
{

      url="AddReport.aspx?alt=1&id="+idd;
      window.location.href = url;
 

}
function Fun()
{
  document.getElementById("imgLoding").style.display="block";
  }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>行业信息列表</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td>
                        标题:<asp:TextBox ID="txtnewstitle" Width="472px" Height="21px" runat="server"></asp:TextBox>
                        状态：
                        <asp:DropDownList ID="ddrstuta" runat="server">
                            <asp:ListItem Selected="True" Value="-1">请选择</asp:ListItem>
                            <asp:ListItem Value="0">未审核</asp:ListItem>
                            <asp:ListItem Value="1">已审核</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp &nbsp<asp:Button ID="btnSearch" CssClass="btn" runat="server" Text="搜 索" OnClick="btnSearch_Click" />
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
                        是否推荐</th>
                    <th>
                        状态</th>
                    <th>
                        来源</th>
                    <th>
                        管理</th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                            <td align="center">
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("ReportID")%>" />
                                </label>
                            </td>
                            <td>
                                <%#(Eval("ReportID"))%>
                                <td align="center">
                                    <a href="http://sr.topfo.com/<%# Eval("Html") %>" target="_blank">
                                        <asp:Label ID="Label2" runat="server" Text='<%#  FormatNull(Convert.ToString(Eval("Reportname")), 35) %>'></asp:Label></a>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetComm(Convert.ToInt32(Eval("recommendID"))) %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label4" runat="server" Text='<%# GetStatu(Convert.ToInt32(Eval("Auditid"))) %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label5" runat="server" Text='<%# GetLaiyuan(Convert.ToInt32(Eval("FormID"))) %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <a href="javascript:shenhe(<%# Eval("ReportID") %>);">审核</a> <a href='JavaScript:DelNav("<%#Eval("ReportID") %>");'
                                        onclick="if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <div class="pagebox" style="text-align: left">
                <a href="Javascript:SelectAll();">全选</a>/<a href="Javascript:ReSelect();">反选</a>&nbsp;将选中的信息<asp:Button
                    ID="Button1" runat="server" OnClick="Button1_Click" Text="删除" CssClass="btn" />&nbsp;<asp:Button
                        ID="btnpublic" CssClass="btn" runat="server" OnClientClick="return Fun();" Text="批量生成"
                        OnClick="btnpublic_Click" />
                <input type="button" value="录入信息" class="btn" onclick="javascript:location.href='AddReport.aspx'"
                    id="Button2" />
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
    <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
        top: 0px; left: 0px; width: 100%; height: 1000px; filter: alpha(opacity=60);"
        runat="server">
        <div class="content" style="text-align: center; margin-top: 200px">
            <p>
                数据正在提交,请稍候...</p>
            <img src="../image/loading42.gif" alt="Loading" />
        </div>
    </div>
</body>
</html>
