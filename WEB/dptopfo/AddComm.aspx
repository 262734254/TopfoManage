<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddComm.aspx.cs" Inherits="admin_AddComm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
   <%-- <link rel="stylesheet" type="text/css" href="http://dp.topfo.com/css/common.css" />
    <link rel="stylesheet" type="text/css" href="http://dp.topfo.com/css/overview.css" />--%>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
        <input type="hidden" id="policyId" runat="server" />
        <div class="contact2">
            <h1>
                给对方发留言</h1>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="14%" align="right">
                        姓名：</td>
                    <td style="width: 29%">
                        <label>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </label>
                    </td>
                    <td width="11%" align="right">
                        联系方式</td>
                    
                        <td width="46%">
                            <asp:TextBox ID="txtOther" runat="server"></asp:TextBox>
                            &nbsp;</td>
                </tr>
                <tr>
                <td align="right">
                    留言内容：</td>
                <td colspan="3">
                    <asp:TextBox ID="txtContent" TextMode="MultiLine" runat="server" Width="404px" Height="77px"></asp:TextBox>
                </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" height="60">
                     <asp:ImageButton ID="ImageButton1" OnClick="Button1_Click" Width="55" Height="23"
                            runat="server" ImageUrl="http://dp.topfo.com/images/contact_18.jpg" OnClientClick="return CheckForm()" />
                        <asp:ImageButton ID="ImageButton2" Width="55" Height="23" runat="server" ImageUrl="http://dp.topfo.com/images/contact_20.jpg" />
                    </td>
                </tr>
            </table>
        </div>

        <script language="javascript" type="text/javascript">
        function $(id)
        {
            return document.getElementById(id);
        }
        function CheckForm(){
            
            if($("<%=txtContent.ClientID %>").value==""){alert('留言内容不能为空');$("<%=txtContent.ClientID %>").focus();return false;}
           
        }    </script>

    </form>
</body>
</html>
