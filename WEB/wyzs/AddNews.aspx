<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="wyzs_AddNews"  ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
//     function ConAudit(i)
//    { 
//        switch(i)
//        {
//       
//            case 0:
//                document.getElementById("show").style.display = "none";
//                break;
//            case 1:
//                document.getElementById("show").style.display = "";
//                break;
//            default:
//                break;
//        }
//}
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>添加资讯信息</b></span></p>
                </h2>
                <h2>
                    <p>
                        <span><b><a href="WyzsManage.aspx">资源管理</a></b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table"  style="height:210px;">
              <tr>
                    <td>
                        标题:</td>
                    <td align="left">
                        <asp:TextBox ID="txtTitle" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                
              <tr>
                    <td>
                        位置:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlPosition" runat="server">
                            <asp:ListItem Value="all">--请选择--</asp:ListItem>
                            <asp:ListItem Value="物业招商">物业招商</asp:ListItem>
                            <asp:ListItem Value="物业投资">物业投资</asp:ListItem>
                            <asp:ListItem Value="行业新闻">行业新闻</asp:ListItem>
                            <asp:ListItem Value="会展信息">会展信息</asp:ListItem>
                            <asp:ListItem Value="风水">风水</asp:ListItem>
                             <asp:ListItem Value="合作加盟 ">合作加盟 </asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        内容 :</td>
                    <td align="left">
                         <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="300" BasePath="~/Vfckeditor/">
        </FCKeditorV2:FCKeditor>
                        </td>
                      
                </tr>
               
                
                
               
                <tr>
                    <td>
                        排序:</td>
                    <td align="left">
                        <asp:TextBox ID="txtorder" onkeyup="value=value.replace(/[^\d]/g,'') " runat="server" Width="153px" Height="22px"></asp:TextBox>
                        <span style="color: #808080">(请输入数字)</span>
                        </td>
                </tr>
               
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAudit" runat="server" CssClass="btn" Text="修改" OnClick="btnAudit_Click" />
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="添加" OnClick="btnSubmit_Click" />
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
