<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="MerchantManage_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
   <script type="text/javascript" src="code1.js">

    </script>

</head>
<body>
    <form id="Form2" name="salefrm" method="post" runat="server">
        <asp:TextBox ID="abc" runat="server" Text="输入您要推荐的用户" onfocus="if(this.value=='输入您要推荐的用户'){this.value='';this.style.color='#333333'}" Width="138px" Height="22px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ToolTip="工工"></asp:TextBox>
    </form>
     <script type="text/javascript" language="javascript">
oo.Create(document.getElementById('<%=abc.ClientID %>'));
    </script>

</body>
</html>