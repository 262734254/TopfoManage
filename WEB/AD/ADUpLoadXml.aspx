<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADUpLoadXml.aspx.cs" Inherits="AD_XML_ADUpLoadXml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button3_onclick() {

}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title"><h2><p><span><b>管理菜单</b></span></p></h2></div>
    <div>
        <div style="text-align: center">
            <table style="width: 492px; height: 96px; font-size:12px;" class="one_table">
                <tr>
                    <td style="width: 5032px">
                        上传地址：</td>
                    <td align="left" style="width: 724px">
                        <asp:TextBox ID="txtUpLoadAdr" runat="server" Width="371px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 45px">
                        <asp:Button ID="Button1" runat="server" Text="确   定" CssClass="btn" OnClick="Button1_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="返   回" CssClass="btn" OnClick="Button2_Click"  /></td>
                </tr>
            </table>
        </div>
    
    </div>
        &nbsp;
    </form>
</body>
</html>
