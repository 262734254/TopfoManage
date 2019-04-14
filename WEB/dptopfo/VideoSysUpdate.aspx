<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoSysUpdate.aspx.cs" Inherits="admin_VideoSysUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>视频修改页</title>
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
    function checks()
    {
      if(document.getElementById ("txttitle").value=="")
      {
       alert('请输入标题！');
       return false;
      }
      
      if(document.getElementById("txtVidoiName").value=="")
      {
            alert('请输入视频地址！');
            return false;
      }
//       else if(document.getElementById ("txtLaiYuan").value=="")
//      {
//       alert('请输入来源！');
//       return false;
//      }
      else{return true;}
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
                    <span><b>修改视频 </b></span>
                </p>
            </h2>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" class="one_table" style="width: 100%;">
            <tr>
                <td>
                    标题：<font style="color: Red">*</font></td>
                <td>
                    <asp:TextBox ID="txttitle" runat="server" Width="256px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    视频地址：<font style="color: Red">*</font></td>
                <td>
                    <asp:TextBox ID="txtVidoiName" runat="server" Width="256px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    介绍说明：</td>
                <td>
                    <asp:TextBox ID="txtJieShao" runat="server" TextMode="MultiLine" Height="102px" Width="456px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    来源：</td>
                <td>
                    <%--<asp:TextBox ID="txtLaiYuan" runat="server" Width="256px"></asp:TextBox>--%>
                    <asp:TextBox ID="txtLaiYuan" runat="server" Text="中国招商投资网" onfocus="if(this.value=='中国招商投资网'){this.value='';this.style.color='#333333'}"
                        onblur="if(this.value==''){this.value='中国招商投资网';this.style.color='#999999'};"
                        Width="256px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    更换图片：</td>
                <td>
                    <asp:FileUpload ID="uploadPic" runat="server" />&nbsp;<asp:Button ID="btnUpdatefile"
                        runat="server" OnClick="btnUpdatefile_Click" Height="20px" onfocus="this.blur()"
                        CssClass="btn" OnClientClick="return showCheck()" Text="上 传" />
                    <div id="imgLoding" style="display: none;">
                        <img src="http://www.topfo.com/Web13/images/down.gif" alt="Loading" />图片上传中
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    图片：
                </td>
                <td>
                    <asp:Image ID="Image1" Height="105px" Width="130px" runat="server" /></td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <div style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" Text="修 改" onfocus="this.blur()" OnClientClick="return checks()"
                            CssClass="btn" OnClick="btnSave_Click" />&nbsp
                        <input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn"
                            onfocus="this.blur()" /></div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
