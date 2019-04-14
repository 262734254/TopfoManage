<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddchannelInfo.aspx.cs" Inherits="advertise_AddchannelInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>频道添加</title>
      <link href="../css/style.css" type="text/css" rel="stylesheet" />
        <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
 <script language="javascript" type="text/javascript">
  
	function chkBtn()
	{
	   if(document.getElementById("txtName").value=="")
	   {
	       alert("请输入频道名称");
	       document.getElementById("txtName").focus();
	       return false;
	   }
	   }
</script>

</head>
<body>
    <form id="form1" runat="server">
             <div class="title" align="center">
             <h2><p><span><b>广告频道添加</b></span></p></h2>
             <h2><p><span><b><a href="channelInfoList.aspx">频道管理</a></b></span></p></h2>
             </div>
    <div>
      <table  border="0" align="center" class="one_table"  cellpadding="0" cellspacing="0">
                <tr><td align="right">频道名称：</td><td >
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
                <tr><td align="right">备注：</td><td >
                    <textarea id="txtDoc"  runat="server" ></textarea></td></tr>
                <tr><td >&nbsp;</td><td >
                    <asp:Button ID="btnAdd" runat="server" Text="确认添加"    OnClientClick="return chkBtn();" OnClick="BtnAdd_Click" CssClass="btn" /></td></tr>
                </table>
    </div>
    </form>
</body>
</html>
