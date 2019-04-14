<%@ Page Language="C#" AutoEventWireup="true" CodeFile="typeManage.aspx.cs" Inherits="wyzs_typeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>物业类型列表</title>
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
    url="typeManage.aspx?str="+id;
    window.location.href = url;
}

function shenhe(idd)
{

      url="AddWyzsType.aspx?alt=1&id="+idd;
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
                        <span><b>物业类型列表</b></span></p>
                </h2>
            </div>
           
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr style="background: #bcd9e7; height: 27px;">
                    <%--<th>
                        选择</th>--%>
                    <th>
                        编号</th>
                    <th>
                        物业类型</th>
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
                                <%#(Eval("Id"))%>
                                <td align="center">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("typeName") %>'></asp:Label>
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
            <div class="pagebox" style="text-align: left">
                <input type="button" value="录入信息" class="btn" onclick="javascript:location.href='AddWyzsType.aspx'"
                    id="Button2" />
            </div>
        </div>
    </form>
  
</body>
</html>
