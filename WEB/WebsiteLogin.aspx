<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebsiteLogin.aspx.cs" Inherits="WebsiteLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css"> 
body{margin:0 auto;background-color:#fff;font-size:14px;text-align:center;}
ul,li,h5,h6,form,p{margin:0;padding:0;}
h5{font-size:14px;margin:8px 0;}
h6{font-size:12px;}
ul,li{list-style:none;zoom:1;}
a{color:#00c;}
#nav{border-bottom:1px solid #c7e8bc;margin:5px 0;padding:0 0 0 10px;}
#navTab li{float:left;width:73px;height:26px;overflow:hidden;margin-right:6px;font:bold 14px/26px arial;text-align:center;background:url(http://img.baidu.com/img/iknow/bg_popbtn.gif) no-repeat -78px -185px;position:relative;top:1px;}
#navTab li.act a{text-decoration:none;}
#navTab li a:link,li a:visited{width:100%;padding-top:2px;color:#1d7a00;display:block;}
#navTab li.act{outline:none;background-position:0 -185px;}
#main{padding:0 10px;margin-bottom:12px;background:#fff;margin:0 auto;text-align:center;}
#loginPanel{margin:0 auto;text-align:left;width:320px;}
#regIframe{border:0;height:500px;width:530px;overflow:hidden;}
#errorInfo,#memInfo{font-size:12px;color:red;display:none;}
.clear{height:0;overflow:hidden;font-size:0;line-height:0;margin:0;padding:0;clear:both;}
.f14{font-size:14px;}
.f12{font-size:12px;}
.item{height:50px;margin-top:5px;}
.item label{width:60px;float:left;display:block;}
.item input{width:140px;text-align:left}
.buttons{text-align:left;padding-left:60px;}
.buttons input{height:24px;padding:2px;width:60px;}
.reg{font-size:14px;font-weight:bold;text-align:center;padding:10px 0;}
</style>
</head>
<body id="loginPage">
<form runat="server" id="frm">
    <div id="main">
        <div id="normalBody">
        <div id="nav">
            <ul id="navTab">
                <li class="act" ><a href="#login"  >登录</a></li>
                <li><a href="#reg"   >注册</a></li>
            </ul>
            <p class="clear"></p>
        </div>
        <div id="content">
            <div id="loginPanel">
            <div style=" text-align:center">请直接登陆</div>
            <div class="item">
              <label>用户名:</label><input type="text" id="txtLoginName" runat="server"/>
 <br />
              <label>密&nbsp;&nbsp;码:</label><input type="password" id="txtPassWord" runat="server"/>
            </div> 
            <div style="text-align:center" class="buttons"><asp:Button runat="server" CssClass="input" ID="btnLogin" Text="登陆" OnClick="btnLogin_Click" />
            <a href="#">忘记密码？</a></div>
            <div id="regDiv">
                    <hr size="0" style="border-top:1px solid #AAAAAA">
                    <div class="reg">没有招商网账号？<a href="#">立即注册账号</a></div>
                    <div align="center" style="color:Red" runat="server" id="divText"></div>
                </div>
            </div>
        </div>
    </div>
    </div>
    </form>

</body>
</html>
