<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrowTabManage.aspx.cs" Inherits="ErrowTabManage" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>错误页</title>
    <link href="css/CRM.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/Common.js"></script>

    <script type="text/javascript" src="js/CheckAll.js"></script>

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

      url="ErrowTabUpdate.aspx?str="+idd;
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
                        <span><b>错误列表</b></span></p>
                </h2>
            </div>
           
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr style="background: #bcd9e7; height: 27px;">
                    <th>
                        选择</th>
                    <th>
                        序号</th>
                    <th>
                        日期</th>
                    <th>
                        是否已处理</th>
                    <th>
                        管理</th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                            <td>
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("Id")%>" />
                                </label>
                            </td>
                            <td>
                                <%#(Eval("Id"))%>
                                <td>
                                   
                                        <asp:Label ID="Label2" runat="server" Text='<%#  CreateDate(Convert.ToString(Eval("createtime"))) %>'></asp:Label></a>
                                </td>
                                <td>
                                    <asp:Label ID="labstatu" runat="server" Text='<%# GetChuLi(Convert.ToInt32(Eval("BoolChuLi"))) %>'></asp:Label>
                                </td>
                                <td>
                                    <a href="javascript:shenhe(<%# Eval("Id") %>);">查看</a> 
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
          
            <br />
            <div class="pagebox" style="text-align: left">
                <a href="Javascript:SelectAll();">全选</a>/<a href="Javascript:ReSelect();">反选</a>&nbsp;将选中的资讯<asp:Button
                    ID="Button1" runat="server" OnClick="Button1_Click" Text="删除" CssClass="btn" />&nbsp;<asp:Button
                        ID="btnpublic" CssClass="btn" runat="server" Text="批量生成" OnClick="btnpublic_Click" />
                &nbsp;
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
