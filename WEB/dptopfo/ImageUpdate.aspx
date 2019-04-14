<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageUpdate.aspx.cs" Inherits="admin_ImageUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>相册修改页</title>
    <style type="text/css">
#uploadPic{
	width:200px;
	height:20px;
	border:1px solid maroon;
}
</style>
    <%--<link rel="stylesheet" type="text/css" href="http://dp.topfo.com/css/common.css" />
    <link rel="stylesheet" type="text/css" href="http://dp.topfo.com/css/css.css" />--%>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
    function cheakall(ithis)
    {
    var items = document.getElementsByTagName("input");     
     for(i=0; i<items.length;i++)
     {       
       if(items[i].type=="checkbox")
       {
            items[i].checked =ithis.checked;
       }
     }
    }
    
    
    function showCheck()
    {
            if(document.getElementById("imgLoding").style.display=="none")
            {
            document.getElementById("imgLoding").style.display="block";
            }else
            {
            document.getElementById("imgLoding").style.display="none";
            }
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="title">
            <h2>
                <p>
                    <span><b>相册修改</b></span></p>
            </h2>
        </div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td>
                    相册名称：</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtImageName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    相册说明：</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtImageShuo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    上传图片：</td>
                <td style="text-align: left">
                    <asp:FileUpload ID="uploadPic" runat="server" />&nbsp
                    <asp:Button ID="btnUpdatefile" runat="server" Text="上 传" Height="20px" CssClass="btn"
                        onfocus="this.blur()" OnClick="btnUpdatefile_Click" OnClientClick="return showCheck()" />
                    <div id="imgLoding" style="display: none;">
                        <img src="http://www.topfo.com/Web13/images/down.gif" alt="Loading" />图片上传中
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    图片说明：</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtShuoming" runat="server"></asp:TextBox></td>
            </tr>
            <tr id="ed" style="display: none" runat="server">
                <td>
                    图片：</td>
                <td>
                    <asp:DataList ID="DataList1" Width="100%" RepeatColumns="3" runat="server" CaptionAlign="Bottom"
                        HorizontalAlign="Center" RepeatDirection="Vertical">
                        <HeaderTemplate>
                            <input type="checkbox" onclick="cheakall(this)" />全选/反选 &nbsp
                            <asp:Button ID="Button1" CssClass="button1" onfocus="this.blur()" runat="server"
                                Text="删除图片 " OnClick="btnsave_Click" /></HeaderTemplate>
                        <ItemTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <img alt='<%# Eval("Imagepath") %>' src='<%#GetType(Convert.ToString( Eval("Imagepath")))%>'
                                            height="75px" width="100px" /><br />
                                        <asp:CheckBox ID="chckimage" runat="server" CausesValidation="true" />
                                        <asp:HiddenField ID="HiddenField1" Value='<%# Eval("Imagepath") %>' runat="server" />
                                        <asp:HiddenField ID="HiddenField2" Value='<%# Eval("parktypeid") %>' runat="server" />
                                        <asp:HiddenField ID="HiddenField3" Value='<%# Eval("imgexplain") %>' runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="text-align: center">
                        <asp:Button ID="btnsa" runat="server" CssClass="btn" onfocus="this.blur()" Text="保 存"
                            OnClick="btnsa_Click" />&nbsp
                        <input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn"
                            onfocus="this.blur()" /></div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
