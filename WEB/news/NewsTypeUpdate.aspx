<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsTypeUpdate.aspx.cs" Inherits="news_NewsTypeUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title >资讯类型修改页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
     <script  src="../js/JScriptloans.js" type ="text/javascript" language="javascript"></script>
         <script type ="text/javascript" language ="javascript">
           function postnewtabs()
   {
  if(document.getElementById ("txtnewsTitle").value.length==0)
   {
     document.getElementById ("showtxtnewsTitle").innerHTML="*";
     document.getElementById ("showtxtnewsTitle").style .display ="inline";
     document.getElementById ("txtnewsTitle").focus();
     return false;
   }
   else
   {
    document.getElementById ("imgLoding").style .display ="";
  return true;
}
}
         </script>
</head>
<body>
    <form id="form1" runat="server" action="">
    <div>
    <table border="0" cellpadding="0" cellspacing="0"    class="one_table">
    			<tr >
				<th colSpan="2">
					<div  align="center">资讯类型修改</div>
				</th>
			</tr>
    <tr><td><span style ="color:Red">*</span>名称：</td><td >
        <asp:TextBox ID="txtnewsTitle"  onblur="outpostcode(this,'showtxtnewsTitle')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showtxtnewsTitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td>是否启用：</td><td >
        <asp:RadioButtonList ID="radiocaozuo" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
            <asp:ListItem  Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
        </asp:RadioButtonList></td></tr>
            <tr><td>对外类型：</td><td >
        <asp:RadioButtonList ID="radiotuijian" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
            <asp:ListItem  Value="0">总站</asp:ListItem>
            <asp:ListItem  Value="1">拓富中心</asp:ListItem>
        </asp:RadioButtonList></td></tr>
    <tr><td colspan="2" align="center">
        <asp:Button ID="btnSave" runat="server" OnClientClick="return postnewtabs()" CssClass="btn"  Text="修 改" OnClick="btnSave_Click" /> &nbsp;&nbsp;<input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn" /></td></tr>
    </table>
    </div>
    </form>
     <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1135px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>
</body>
</html>

