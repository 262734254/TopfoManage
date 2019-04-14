<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysUser.aspx.cs" Inherits="System_SysUser" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加用户</title>
    <script type="text/javascript"  src="../js/Common.js"></script>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        //全选与反选
    function chkAll() 
    { 
        var a = document.getElementsByTagName("input"); 
        for (var i=0; i<a.length; i++) 
    	 if (a[i].type == "checkbox") 
    	    if(a[i].name=="checkboxRecord")
    		    a[i].checked =!a[i].checked; 
    }
    function chkAll2() 
    { 
        var a = document.getElementsByTagName("input"); 
    	for (var i=0; i<a.length; i++) 
    	 if (a[i].type == "checkbox") 
    	    if(a[i].name=="checkboxRecord")
    	        a[i].checked =true; 
    }
    
    
    //获取所选的值
    function GetChkValue()
	{
	
	//###暂未用
	//<td width="6%" align="center"><a href="javascript:;" onclick="GetValue('<%#Eval("loginname").ToString().Trim() %>')" >删除</a></td>
	
	//##暂未用，批量删除
	//<a href="javascript:;" onclick="GetChkValue()">批量删除</a>
	
	    var a = document.documentElement.getElementsByTagName("input");
		var str="";

		for (var i=0; i<a.length; i++) 
		{
			if (a[i].type == "checkbox")
			{
			    if(a[i].name=="checkboxRecord")
			    {
				    if(a[i].checked)
				    {
					    str+=a[i].value+",";
				    }
				}
			}
		}
		
		//##用于Ajax的方法删除数据，暂未用到
		//##DelData(str);
		
		//其它的删除方法
		location.href="DelUser.aspx?UserID="+str;
		
	}
	
	//获取单个值
	function GetValue(id)
	{
	    DelData(id);
	}
	
	
	//批量删除用户
	function plDelUser()
	{
	    if(confirm('是否彻底删除这些用户？ 删除后将无法恢复（物理删除）！'))
	    {
	        GetChkValue();
	    }
	}
	
	//更改状态
	function UpdateStatus(sid,audit)
	{
	    var iaudit=1;
	    var str="有效";
	    if(audit.toUpperCase()=="TRUE")
	    {
	        iaudit=0;
	        str="无效";
	    }
	    
	    if(confirm('是否真的将账号（'+ sid +'）的用户状态改为'+ str +'？'))
	    {
	        location.href="AuditUser.aspx?UserID="+sid+"&audit="+iaudit;
	    }
	}
	
    
    </script>
    
    <style type="text/css">
    /*网易风格*/
    .anpager .cpb {background:#1F3A87 none repeat scroll 0 0;border:1px solid #CCCCCC;color:#FFFFFF;font-weight:bold;margin:5px 4px 0 0;padding:4px 5px 0;}
    .anpager a {background:#FFFFFF none repeat scroll 0 0;border:1px solid #CCCCCC;color:#1F3A87;margin:5px 4px 0 0;padding:4px 5px 0;text-decoration:none}
    .anpager a:hover{background:#1F3A87 none repeat scroll 0 0;border:1px solid #1F3A87;color:#FFFFFF;}

    /*拍拍网风格*/
    .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 20px 10px 0; margin: 0px;}
    .paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
    .paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
    .paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
    .paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;}

    /*迅雷风格*/
    .pages { color: #999 }
    .pages a, .pages .cpb { text-decoration:none;float: left; padding: 0 5px; border: 1px solid #ddd;background: #ffff;margin:0 2px; font-size:11px; color:#000;}
    .pages a:hover { background-color: #E61636; color:#fff;border:1px solid #E61636; text-decoration:none;}
    .pages .cpb { font-weight: bold; color: #fff; background: #E61636; border:1px solid #E61636;}

    .code{font-weight:bold;color:blue}
    
    
    /*添加的的按钮样式*/
    .title h3{line-height:28px;font-size:14px;background:url(../image/crm_dh_04_1.gif) repeat-x 0 0;float:left;}
    .title h3 p{display:block;background:url(../image/crm_dh_03_1.gif) no-repeat left top;float:left;}
    .title h3 span{display:block;color:#000;background:url(../image/crm_dh_05_1.gif) no-repeat right top;font-weight:normal;}
    .title h3 span b{padding:2px 30px 0 40px;background:url(../image/dot-dot.jpg) no-repeat 18px center;font-weight:normal;}
    
    
    /* 搜索样式 */
     /* 搜索样式 */
    .tab1{ border:solid 1px ;border-color:rgb(136,185, 206);  height:30px;  border-collapse:collapse;  margin:5px 0px 5px 0px ; }
    .tab1 td{  background-color:#bcd9e7; border:1px solid;}
    
    </style>
</head>
<body  style="font-size:12px;">
    <form id="form1" runat="server">
    <div class="title"><p><h2><span><b>用户管理</b></span></h2></p>  
    <a href="EmployeeRegister.aspx" style="cursor:pointer; text-decoration:none;" ><p><h3><span><b>注册用户</b></span></h3></p></a></div>
    <div>
    
    <table class="tab1" width="99%" >
    <tr>
        <td  width="40px" align="center">账户：</td>
        <td>
            <input id="tbLoginName"  style="width:100px;" type="text" runat="server" /></td>
        <td  width="40px" align="center">部门：</td>
        <td>
            <asp:DropDownList ID="ddlDept" runat="server">
            </asp:DropDownList></td>
        <td  width="40px" align="center">角色：</td>
        <td>
            <asp:DropDownList ID="ddlRole" runat="server">
            </asp:DropDownList></td>
        <td  width="40px" align="center">岗位：</td>
        <td>
            <asp:DropDownList ID="ddlWorkType" runat="server">
            </asp:DropDownList></td>
        <td  width="40px" align="center">状态：</td>
        <td>
            <asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem Value="2">==所有状态==</asp:ListItem>
                <asp:ListItem Value="1">有效</asp:ListItem>
                <asp:ListItem Value="0">无效</asp:ListItem>
            </asp:DropDownList></td>
        <td   align="center">
            <asp:Button ID="btnSearch"  CssClass="btn" runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
    
    <table width="80%" border="0" cellpadding="0" cellspacing="0"   class="one_table two_table" >
    <tr style="background:#bcd9e7; height:27px;">
        <td style="height: 14px">全选</td>
        <td style="height: 14px">序</td>
        <td style="height: 14px">名称
        <asp:ImageButton ID="ibtName_p" ImageUrl="~/image/143_u.gif" runat="server" OnClick="ibtName_p_Click" />
        <asp:ImageButton ID="ibtName_n"  ImageUrl="~/image/143_n.gif"  runat="server" OnClick="ibtName_n_Click" /></td>
        <td style="height: 14px">部门
            <asp:ImageButton ID="ibtDept_p"  ImageUrl="~/image/143_u.gif" runat="server" OnClick="ibtDept_p_Click" />
            <asp:ImageButton ID="ibtDept_n"   ImageUrl="~/image/143_n.gif"  runat="server" OnClick="ibtDept_n_Click" /></td>
        <td style="height: 14px">岗位
            <asp:ImageButton ID="ibtWork_p"  ImageUrl="~/image/143_u.gif"  runat="server" OnClick="ibtWork_p_Click" />
            <asp:ImageButton ID="ibtWork_n"  ImageUrl="~/image/143_n.gif"   runat="server" OnClick="ibtWork_n_Click" /></td>
        <td style="height: 14px">角色</td>
        <td  align="center" style="height: 14px">状态
            <asp:ImageButton ID="ibtStauts_p" ImageUrl="~/image/143_u.gif"  runat="server" OnClick="ibtStauts_p_Click" />
            <asp:ImageButton ID="ibtStatus_n"   ImageUrl="~/image/143_n.gif"  runat="server" OnClick="ibtStatus_n_Click" /></td>
        <td  colspan="3" align="center" style="height: 14px">操作</td>
    </tr>
        <asp:Repeater ID="rptEmployeeList" runat="server"  EnableViewState="false" >
            <ItemTemplate >
             <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                <td width="3%"><input type="checkbox" name="checkboxRecord" value="<%#Eval("loginname").ToString().Trim() %>" /></td>
                <td width="4%"><%#Eval("ln").ToString().Trim() %></td>
                <td width="16%"><%#Eval("username").ToString().Trim() %></td>
                <td width="12%"><%# ConvertStr(Eval("deptname").ToString().Trim()) %></td>
                <td width="14%"><%# ConvertStr(Eval("worktypename").ToString().Trim()) %></td>
                <td width="18%"><%# GetRoleName(Eval("tem").ToString().Trim()) %></td>
                
                <td width="6%" align="center">
                <a href="javascript:UpdateStatus('<%#Eval("loginname").ToString().Trim() %>','<%#Eval("enable").ToString().Trim() %>');"> 
                <%#(Eval("enable").ToString().Trim()) == "True" ? "<font color='green'>有效</font>" : "<font color='red'>无效</font>"%> 
                </a>
                </td>
                
                <td width="6%" align="center"><%# GotoEdit(Eval("loginname").ToString())%>编辑</a></td>
                    <td width="8%"><a href='MemberAddRole.aspx?EmployeeID=<%#Eval("loginname").ToString() %>'>修改角色</a></td>  
                    <td width="6%" align="center">&nbsp;
                    <a href='deluser.aspx?UserID=<%#Eval("loginname").ToString().Trim() %>' onclick="javascript:return confirm('是否彻底删除该用户？ 删除后将无法恢复（物理删除）！');" >
                    <%#(Eval("enable").ToString().Trim()) == "True" ? " " : "删除"%></a>
                    </td>
             </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <br />
    <div>
    <a href="javascript:;" onclick="chkAll2()">全选</a>/<a href="javascript:;" onclick="chkAll()">反选</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:;"  onclick="plDelUser();">批量删除</a>
    
    &nbsp;&nbsp;&nbsp;&nbsp;共搜索到<span style="color:red;"><%=AspNetPager1.RecordCount%></span>条，共<span style="color:red;"><%=AspNetPager1.PageCount%></span>页
        每页显示<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem Selected="True">15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>条记录
        </div>
    
    </div>
        <cc1:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" CssClass="paginator" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
        </cc1:AspNetPager>
    </form>
</body>
</html>
