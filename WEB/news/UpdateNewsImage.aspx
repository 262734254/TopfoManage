<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateNewsImage.aspx.cs" Inherits="news_UpdateNewsImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>删除图片页</title>
  <script  type="text/javascript" language="javascript">
    function s (ithis)
    {
       window.close();
       window.opener.document.getElementById("showidUpdatePerson").value=ithis;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:DataList ID="DataList1" runat="server" CaptionAlign="Bottom" 
            HorizontalAlign="Center" RepeatColumns="5" RepeatDirection="Vertical" >
        <ItemTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <img alt='<%# Eval("Descript") %>' src='<%# Eval("Descript","http://news.topfo.com/imgs/{0}") %>'   height ="75px" width ="100px"/><br />
<%--                        <asp:CheckBox ID="chckimage" runat="server"  CausesValidation ="true"/>
                        <asp:HiddenField ID="HiddenField1" Value ='<%# Eval("Descript") %>' runat="server" />--%>
                    </td>
                </tr>

            </table>
        </ItemTemplate>
        </asp:DataList>
    </div>
                <div align="center"><%--<asp:Button ID="btnsave" runat="server" Text="删除选中图片" OnClick="btnsave_Click" />--%></div>
                
    </form>
</body>
</html>
