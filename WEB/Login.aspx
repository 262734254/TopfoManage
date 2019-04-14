<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/logincss.css" rel="stylesheet" type="text/css" />
        
    <script type="text/javascript">
    function ChangeValidCode(imgID)
    {
        document.getElementById(imgID).src = "ValidateNumber_V1.aspx?r="+Math.random();
        document.getElementById("txtValidator").focus();
        document.getElementById("txtValidator").select();
    }
    
    function GoLogin(id)
    {
        if (event.keyCode ==13)
        {
            document.getElementById(id).focus();   
        }
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="login" >
<%--<img src="image/index_03.jpg"/>--%>
	<div class="login_bg"  >
	  <div class="login_input" >
          <input id="tbLoginName" type="text" class="input"  style="padding-left:3px; "    runat="server" /><br/>
          <input id="tbPassword" type="password" class="input" runat="server"   style="width:148px; padding-left:3px;" /><br/>
         <input type="text" id="txtValidator" name="txtValidator" runat="server" class="input" style="float:left; width:80px; padding-left:3px;" title="验证码区分大小写" onclick="GoLogin('ibtnLogin');" />
            &nbsp;&nbsp;<img id="imgID" src="ValidateNumber_v1.aspx" alt="" />
            &nbsp;&nbsp;<a href="javascript:" onclick="ChangeValidCode('imgID');return false;">换一张图片</a>
		 <asp:ImageButton ID="ibtnLogin" runat="server" ImageUrl="~/image/index_01.jpg" OnClick="ibtnLogin_Click" CssClass="dl" />
	  </div>
	</div>
	<div class="foot">版权所有111111111f &copy;  2009 粤ICP备号07048888 </div>
</div>

<script type="text/javascript">
ChangeValidCode('imgID');
</script>
    </form>
</body>
</html>
