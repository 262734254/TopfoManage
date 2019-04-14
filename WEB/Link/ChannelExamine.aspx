<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChannelExamine.aspx.cs" Inherits="Link_ChannelExamine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
    <title>无标题页</title>
    <style type="text/css"> 
.f_red{color:red}
.f_td{width:15%;background-color:#f7f7f7;
}
</style>

    <script language="javascript" type="text/jscript">
   var Trim=/^\s*|\s*$/g;
   function CheckNull()
   {
       var ChannelName=document.getElementById("txtChannelName");
       if(ChannelName.value.replace(Trim,"")=="")
       {
          alert("频道名称不能为空!");
          ChannelName.focus();
          return false;
       }
       return true;
   }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2>
                <p>
                    <span><b><a href="ChannelManage.aspx">频道管理</a></b></span></p>
            </h2>
            <h2>
                <p>
                    <span><b>添加频道</b></span></p>
            </h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>频道名称：</td>
                <td>
                    <input id="txtChannelName" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    说明：</td>
                <td>
                    <input id="txtRemarks" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    审核：
                </td>
                <td>
                    <asp:RadioButtonList ID="rblAuditing" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="1">审核通过</asp:ListItem>
                        <asp:ListItem Value="2">审核未通过</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClick="BtnSvae_Click" OnClientClick="return CheckNull()"
                        CssClass="btn" Text="审核" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='ChannelManage.aspx';"
                        value="返回" />
                </td>
            </tr>
        </table>
        <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: 0px; left: 0px; width: 104%; height: 1652px; filter: alpha(opacity=60);">
            <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
            </div>
        </div>
    </form>
</body>
</html>
