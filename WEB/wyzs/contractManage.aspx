<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contractManage.aspx.cs" Inherits="wyzs_contractManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>物业列表</title>
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
    url="contractManage.aspx?str="+id;
    window.location.href = url;
}

function shenhe(idd)
{

      url="Addcontract.aspx?alt=1&id="+idd;
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
                        <span><b>物业列表</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr style="background: #bcd9e7; height: 27px;">
                    <th>
                        编号</th>
                    <th>
                        排序号</th>
                    <th>
                        标题</th>
                    <th>
                        查看</th>
                    <th>
                        管理</th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                            <td>
                                <%#(Eval("Id"))%>
                            </td>
                            <td>
                                <%#(Eval("orderid"))%>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                            </td>
                            <td>
                                <a target="_blank"  href="http://wyzs.topfo.com/template/<%#(Eval("htmlurl"))%>">查看</a>
                            </td>
                            <td align="center">
                                <a href="javascript:shenhe(<%# Eval("id") %>);">修改</a> <a href='JavaScript:DelNav("<%#Eval("id") %>");'
                                    onclick="if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td style="height: 26px">
                        <div class="pagebox" style="text-align: left">
                            <input type="button" value="录入信息" class="btn" onclick="javascript:location.href='Addcontract.aspx'"
                                id="Button2" />
                        </div>
                    </td>
                    <td>
                        <div>
                            &nbsp;&nbsp;&nbsp;&nbsp;共搜索到<span style="color: red;"><%=AspNetPager.RecordCount%></span>条，共<span
                                style="color: red;"><%=AspNetPager.PageCount%></span>页 每页显示<asp:DropDownList ID="ddlPageSize"
                                    runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem Selected="True">15</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                </asp:DropDownList>条记录 &nbsp;
                        </div>
                    </td>
                    <td>
                        <cc1:AspNetPager ID="AspNetPager" runat="server" ShowFirstLast="false" NextPageText="下一页"
                            CssClass="anpager" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页"
                            ShowInputBox="Always" SubmitButtonText="GO" PageSize="20">
                        </cc1:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
