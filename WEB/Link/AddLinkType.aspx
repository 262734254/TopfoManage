﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddLinkType.aspx.cs" Inherits="Link_AddLinkType" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
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
       var ChannelName=document.getElementById("txtTypeName");
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
             <h2><p><span><b><a href="LinkTypeManage.aspx">友情连接类型管理</a></b></span></p></h2>
             <h2><p><span><b>添加友情连接类型</b></span></p></h2>
   </div>
       <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>类型名称：</td>
                    <td>
                        <input id="txtTypeName" runat="server" type="text" style="width: 238px; height: 20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">说明：</td>
                    <td>
                        <textarea runat="server" id="txtRemarks" style="width: 538px; height: 200px">
                       </textarea>
                    </td>
                </tr>
                <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClick="BtnSvae_Click" OnClientClick="return CheckNull()" CssClass="btn" Text="添加" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='LinkTypeManage.aspx';" value="返回" />
                </td>
                </tr>
            </table>
            
         <div id="imgLoding" Style="position: absolute; display:none; background-color: #A9A9A9; top: 0px; left: 0px; width: 104%;height:1652px; filter: alpha(opacity=60);">
               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
         </div>
    </form>
</body>
</html>

