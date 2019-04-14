<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendEmail.aspx.cs" Inherits="Mail_SendEmail" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/Common.js"></script>

    <script type="text/javascript" src="../js/CheckAll.js"></script>

    <script type="text/javascript" language="javascript">

function chenk()
{
       
       var values=document.getElementById("txtCount").value;
       var reg=/^[1-9]{1,2}$/;
       if(reg.test(values))
       {
       return true;}
       else{alert("输入有误：只能输入数字1-99");
       return false;}
}

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
    url="MailInfoManage.aspx?str="+id;
    window.location.href = url;
}

function shenhe(idd)
{

      url="MailInfoShenHe.aspx?str="+idd;
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
                    <th style="height: 27px">
                        选择</th>
                    <th style="height: 27px">
                        编号</th>
                    <th style="height: 27px">
                        名称</th>
                    <th style="height: 27px">
                        类型</th>
                    <th style="height: 27px">
                        地域</th>
                    <th style="height: 27px">
                        行业</th>
                    <th style="height: 27px">
                        状态</th>
                    <th style="height: 27px">
                        邮件</th>
                  
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                            <td>
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("UserID")%>" />
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
                          
                               
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />    
            <div class="pagebox" style="text-align: left">
                <a href="Javascript:SelectAll();">全选</a>/<a href="Javascript:ReSelect();">反选</a>&nbsp; 邮件标题：  
                <asp:TextBox ID="TxtEmail" runat="server" Width="308px"></asp:TextBox>&nbsp;条数：
               
                <input type="text"  id="txtCount" runat="server"  style="width:50px" onkeyup="this.value=this.value.replace(/\[1-9]/g,'')" onafterpaste="this.value=this.value.replace(/\[1-9]/g,'')"/>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button
                    ID="Button3" runat="server"  class="btn"  Text="发送邮件" OnClick=" Button3_Click"  OnClientClick="return chenk()"  />
                    
                <div style="display:none;"><asp:Button
                    ID="Button1" runat="server" OnClick="Button1_Click" Text="批量删除" CssClass="btn" />
                  
                <input type="button" value="录入用户" class="btn" onclick="javascript:location.href='MailInfoInsert.aspx'" />
              &nbsp;&nbsp;<asp:Button ID="btnDaoChu" class="btn" runat="server" Text="导出数据" OnClick="btnDaoChu_Click" />&nbsp;&nbsp;
                <asp:FileUpload ID="fulExcel" runat="server" />&nbsp;&nbsp;<asp:Button ID="btnup"
                    runat="server" CssClass="btn" Text="上 传" OnClick="btnup_Click" />&nbsp;&nbsp;
                <asp:Button ID="btndaoru" runat="server" CssClass="btn" OnClientClick="if(confirm( '确认要导入数据吗？')){ return   true;}else{return   false;} "
                    Text="导入数据" OnClick="btndaoru_Click" />&nbsp;&nbsp;</div>
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