<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndustryManage.aspx.cs" Inherits="report_IndustryManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>合作机构列表页</title>
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
    url="IndustryManage.aspx?str="+id;
    window.location.href = url;
}

function shenhe(idd)
{

      url="AddIndustry.aspx?alt=1&id="+idd;
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
                        <span><b>合作机构信息列表</b></span></p>
                </h2>
            </div>
            <%--<table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td>
                        标题：<asp:TextBox ID="txtnewstitle" runat="server"></asp:TextBox>
                        状态：
                        
                        &nbsp &nbsp<asp:Button ID="btnSearch" CssClass="btn" runat="server" Text="搜 索" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>--%>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr style="background: #bcd9e7; height: 27px;">
                    <%--<th>
                        选择</th>--%>
                    <th>
                        编号</th>
                    <th>
                        名称</th>
                    <th>
                        联系人</th>
                    <th>
                        Email</th>
                    <th>
                        管理</th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                           <%-- <td align="center">
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("industryId")%>" />
                                </label>
                            </td>--%>
                            <td>
                                <%#(Eval("industryId"))%>
                                <td align="center">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("industryName") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("LinkMan") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                                </td>
                                <td align="center">
                                    <a href="javascript:shenhe(<%# Eval("industryid") %>);">修改</a> <a href='JavaScript:DelNav("<%#Eval("industryid") %>");'
                                        onclick="if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <div class="pagebox" style="text-align: left">
                <%--<a href="Javascript:SelectAll();">全选</a>/<a href="Javascript:ReSelect();">反选</a>&nbsp;将选中的信息<asp:Button
                    ID="Button1" runat="server" OnClick="Button1_Click" Text="删除" CssClass="btn" />--%>
                <input type="button" value="录入信息" class="btn" onclick="javascript:location.href='AddIndustry.aspx'"
                    id="Button2" />
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
