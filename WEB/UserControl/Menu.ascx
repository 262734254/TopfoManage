<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="UserControl_Menu" %>

<script language="javascript">
    function tick() {
        var hours, minutes, seconds, xfile;
        var intHours, intMinutes, intSeconds;
        var today, theday;
        today = new Date();
        function initArray() {
            this.length = initArray.arguments.length
            for (var i = 0; i < this.length; i++)
                this[i + 1] = initArray.arguments[i]
        }
        var d = new initArray("星期日","星期一","星期二","星期三","星期四","星期五","星期六");
        theday = today.getYear() + "年" + [today.getMonth() + 1] + "月" + today.getDate() + "日 " + d[today.getDay() + 1];
        intHours = today.getHours();
        intMinutes = today.getMinutes();
        intSeconds = today.getSeconds();
        if (intHours == 0) {
            hours = "12:";
            xfile = "午夜";
        } else if (intHours < 12) {
            hours = intHours + ":";
            xfile = "上午";
        } else if (intHours == 12) {
            hours = "12:";
            xfile = "正午";
        } else {
            intHours = intHours - 12
            hours = intHours + ":";
            xfile = "下午";
        }
        if (intMinutes < 10) {
            minutes = "0" + intMinutes + ":";
        } else {
            minutes = intMinutes + ":";
        }
        if (intSeconds < 10) {
            seconds = "0" + intSeconds + " ";
        } else {
            seconds = intSeconds + " ";
        }
        timeString = theday + " " + xfile + " " + hours + minutes + seconds;
        
        Clock.innerHTML = timeString;
        window.setTimeout("tick();", 100);
    }
    window.onload = tick;
</script>

<style type="text/css">
		.btn2 {width:126px;height:23px;background:url(../image/40_2.gif) no-repeat left top;border:none;cursor:pointer;}
		.tr1 {text-align:right;padding-right:5px;}
		.tr2 {text-align:left;padding-left:5px;}
</style>

<div id="menu1" class="menu" runat="server">
    <%--<ul>
			<li><a href="#">资源中心</a></li>
			<li><a href="#">财务组</a></li>
			<li><a href="#">人事组</a></li>
			<li><a href="#">客户组</a></li>
			<li><a href="#">业务组</a></li>
			<li><a href="#">分站组</a></li>
			<li><a href="#">管理组</a></li>
			<li><a href="#">联盟组</a></li>
		</ul>
	--%>
        <table width="100%">
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= this.LoginName%>
                    &nbsp;&nbsp;欢迎登录后台综合管理系统 &nbsp;&nbsp;</td>
            <td  align="right" style=" padding-bottom:10px;">
                今天是&nbsp;<span id="Clock"></span> &nbsp;&nbsp;<asp:Button
                ID="Button1" runat="server" OnClick="Button1_Click" Text="  退出系统  " CssClass="btn2" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        </table>
        </div>
