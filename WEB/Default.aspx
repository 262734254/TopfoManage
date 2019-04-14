<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="UserControl/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<%@ Register Src="UserControl/Left.ascx" TagName="Left" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>topfo后台综合管理系统</title>
    <link href="css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="css/CRM_right.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="js/twoCalendar.js"></script>
    <script type="text/javascript">
         function resetFrameHeight() {
	        var frm = document.getElementById("ManagerMain");
	        var subWeb = document.frames ? document.frames["ManagerMain"].document: frm.contentDocument;
	        try{
	            if (frm != null && subWeb != null) {
		            frm.style.height = "880px"; 
		            frm.style.height = subWeb.documentElement.scrollHeight + 20 + "px";            	
	            }
	        }
	        catch(ex){}
        } 
        function h5_Click(obj)
        {  
//            var div = document.getElementsByTagName("div");  
//                
//            for(var i=0;i<div.length;i++)
//            {
//                if(div[i].className == "left_list"){
//                 div[i].style.display = "none";
//                 }
//            }     
            var ManagerMain = obj.nextSibling;
            
            if(ManagerMain !=null)
            {
                if(ManagerMain.style.display == "none" && ManagerMain.className!="title_h5")
                {
                    ManagerMain.style.display ="block";
                }
                else if(ManagerMain.style.display == "block" && ManagerMain.className!="title_h5")
                {
                    ManagerMain.style.display ="none";
                }
            }
        }
       // window.setInterval("resetFrameHeight()", 200)
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <!--<div id="header">
            <div class="header">
                <p>
                    <span id="usernameid" runat="server"></span>
                    <asp:LinkButton runat="server" ID="lbtLoginOut" OnClick="lbtLoginOut_Click">退出系统</asp:LinkButton></p>
                <img src="image/logo.gif" title="topfo" /></div>
        </div>-->
        <div id="menu">
            <uc2:Menu ID="Menu1" runat="server"></uc2:Menu>
            <%-- <uc1:Men ID="Men1" runat="server" />--%>
            <%--<div id="menu1" class="menu" runat="server">
		<%--<ul>
			<li><a href="#">资源中心</a></li>
			<li><a href="#">财务组</a></li>
			<li><a href="#">人事组</a></li>
			<li><a href="#">客户组</a></li>
			<li><a href="#">业务组</a></li>
			<li><a href="#">分站组</a></li>
			<li><a href="#">管理组</a></li>
			<li><a href="#">联盟组</a></li>
		</ul>--%>
            <%--</div>--%>
        </div>
        <div id="content">
            <div id="left_bar">
                <uc1:Left ID="Left1" runat="server"></uc1:Left>
            </div>
            <div id="right_bar">
                <iframe id="ManagerMain" name="ManagerMain" src="#" width="100%" frameborder="0"
                    scrolling="auto" style="float: right;" onload="resetFrameHeight()"></iframe>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <!--
        <div id="footer">
            <p>
                版权所有</p>
        </div>-->
    </form>
</body>
</html>
