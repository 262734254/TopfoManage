<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrowTabUpdate.aspx.cs" Inherits="ErrowTabUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <link href="css/CRM.css" rel="stylesheet" type="text/css" />
    <title>错误修改审核页</title>
</head>
<body>
 <form id="form1" runat="server" action="">
    <div>
    <table border="0" cellpadding="0" cellspacing="0"    class="one_table">
    			<tr >
				<th colSpan="2">
					<div  align="center">错误修改</div>
				</th>
			</tr>
			<tr><td>链接地址：</td><td> <asp:TextBox ID="txtlinkurl" Enabled ="false" runat="server" Width="385px" ></asp:TextBox></td></tr>
			<tr><td>问题描述：</td><td><asp:TextBox ID="txtdescrption" runat="server" TextMode="MultiLine" Width="385px" Height="70px" Enabled ="false"></asp:TextBox></td></tr>
			<tr><td>联系方式：</td><td> <asp:TextBox ID="txtconnection" runat="server" Width="250px" Enabled ="false" ></asp:TextBox></td></tr>
			<tr><td>是否回复：</td><td>
                <asp:RadioButtonList ID="radiohuifu" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                  <asp:ListItem  Value="0">否</asp:ListItem>
                  <asp:ListItem  Value="1">是</asp:ListItem>
                </asp:RadioButtonList></td></tr>
			<tr><td>回复内容：</td><td><asp:TextBox ID="txtreturncontext" runat="server" TextMode="MultiLine" Width="385px" Height="70px"></asp:TextBox></td></tr>
			<tr><td>备注：</td><td><asp:TextBox ID="txtbeizhu" runat="server" Width="250px" ></asp:TextBox></td></tr>
			<tr><td colspan ="2" align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="回 复" OnClick="btnSave_Click" />&nbsp;&nbsp;<input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn" /></td></tr>
       </table>
    </div>
    </form>
    <%-- <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1135px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>--%>
</body>
</html>
