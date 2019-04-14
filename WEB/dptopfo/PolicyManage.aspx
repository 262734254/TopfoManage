<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolicyManage.aspx.cs" Inherits="dptopfo_PolicyManage" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>优惠政策列表信息</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/Common.js"></script>

    <script type="text/javascript" src="../js/CheckAll.js"></script>

    <script type="text/javascript">

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
//1服务2机构3专业人才
function modifyNavigate(pid)
{
    var url="";
   
       url="Addpolicy.aspx?loginName="+pid;
    
    window.location.href=url;
}
function DelNav(id,typeid)
{
    var url="";
    url="ProfessionalManage.aspx?ProfessionalID="+id+"&typeId="+typeid;
    window.location.href = url;
}
    </script>

    <style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:30px;}
        .content p{line-height:30px;        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>优惠政策列表</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    
                    <td align="center" style="height: 24px">
                        编号：
                        <input id="txtNuber" style="width: 100px;" type="text" runat="server" /></td>
                    <td align="center" style="height: 24px">
                        帐号：<input id="txtLoginName" style="width: 100px;" type="text" runat="server" />
                    </td>
                    <td align="center" style="height: 24px">
                        <asp:Button ID="btnSearch" CssClass="btn" runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr style="background: #bcd9e7; height: 27px;">
                   <%-- <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                        选择</th>--%>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        编号</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        帐号</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        发布日期</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        管理</th>
                </tr>
                <asp:Repeater ID="NewsList" OnItemDataBound="NewsList_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                           <%-- <td >
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("policyId")%>" />
                                </label>
                            </td>--%>
                            <td>
                                <%#Eval("policyId")%>
                            </td>
                            <td>
                                <%#Eval("loginName")%>
                            </td>
                            <td>
                                <%#Convert.ToDateTime(Eval("createdate")).ToString("yyyy-MM-dd (hh:mm)")%>
                            </td>
                            <td>
                            <a href='http://<%#Eval("loginName") %>.topfo.com/Preferentialpolicies.htm'; target="_blank">查看</a> 
                                <a href='JavaScript:modifyNavigate("<%#Eval("loginName") %>");'>修改</a> 
                               <%-- <a href='JavaScript:DelNav("<%#Eval("policyId") %>");');' onclick="return confirm('确认要删除吗？') ">删除</a>--%>
                              
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <div>
                <%--<a href="Javascript:SelectAll();">全选</a>/<a href="Javascript:ReSelect();">反选</a>&nbsp;将选中的信息<asp:Button
                    ID="Button1" runat="server" OnClick="Button1_Click" Text="删除" CssClass="btn" />--%>
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
            <td style="text-align: right; width: 348px;">
                &nbsp;&nbsp;</td>
            <td style="text-align: left; width: 74px;">
                <span id="pinfo" runat="server"></span>&nbsp;</td>
            <th align="center" colspan="8" style="height: 32px">
                <cc1:AspNetPager ID="AspNetPager" runat="server" ShowFirstLast="false" NextPageText="下一页"
                    CssClass="anpager" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页"
                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="20">
                </cc1:AspNetPager>
            </th>
        </div>
    </form>
</body>
</html>
