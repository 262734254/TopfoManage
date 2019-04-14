<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddExpress.aspx.cs" Inherits="Express_AddExpress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加快讯内容</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    function a()
    {
    var a=document.getElementById("<%=txtUrlAdd.ClientID %>").value;
    if(a=="")
    {
    alert('快讯内容不能为空');return false;
    }
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <div align="center">
         <div class="title"><h2><p><span><b>添加快讯内容</b></span></p></h2></div>
          <table border="0" cellpadding="0" cellspacing="0" class="one_table" style="width: 612px; height: 124px">
               
                <tr>
                    <td style="width: 23%" align="center">
                        快讯内容：</td>
                    <td align="left"  valign="middle">
                        <asp:TextBox ID="txtUrlAdd" runat="server" Width="397px" Height="124px" TextMode="MultiLine"></asp:TextBox>
                        <div style="display:inline; text-align: left; font-size:13px;">&nbsp;<span id="message1"></span>&nbsp;</div> 
                        
                        </td>
                </tr>
                <tr>
                    <td style="width: 23%" align="center">
                        是否推荐：</td>
                    <td align="left">
                        <asp:RadioButton ID="rdoYes" GroupName="rdo" Checked="true" runat="server" Text="推荐" />
                        <asp:RadioButton ID="rdoNo" runat="server"  GroupName="rdo" Text="不推荐" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" OnClientClick="return a()" runat="server"  Text="添加" OnClick="Button1_Click" CssClass="btn" />
                        &nbsp;
                        <asp:Button ID="btnUpdate" runat="server"  Text="修改"  CssClass="btn" OnClick="btnUpdate_Click" Visible="False" />&nbsp;
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" /></td>
                    
                    
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
