<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddLink.aspx.cs" Inherits="Link_AddLink" %>

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
   
   function Trim(str)
   {
       var reg=/^\s*|\s*$/g;
       return str.replace(reg,"");
   }
   
   function CheckNull()
   {
       var LinkName=document.getElementById("<%=txtLinkName.ClientID %>");
       if(Trim(LinkName.value)=="")
       {
          alert("链接名称不能为空!");
          LinkName.focus();
          return false;
       }
       
       var Channel=document.getElementById("<%=DropChannel.ClientID %>");
       if(Channel.options[Channel.selectedIndex].value=="0")
       {
          alert("请选择频道!");
          Channel.focus();
          return false;
       }
       
       var LinkType=document.getElementById("<%=DropLinkType.ClientID %>");
       if(LinkType.options[LinkType.selectedIndex].value=="0")
       {
          alert("链接类别不能为空!");
          LinkType.focus();
          return false;
       }
       
       var LinkUrl=document.getElementById("txtLinkUrl");
       if(Trim(LinkUrl.value)=="")
       {
          alert("请输入链接地址!");
          LinkUrl.focus();
          return false;
       }
       
//       var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/ig;//       if(!filter.test(LinkUrl.value))
//       {
//          alert("网站不正确，请重新输入!");
//          LinkUrl.focus();
//          return false;
//       }
       
       return true;
   }
   
   function CheckFile()
   {
      var File=document.getElementById("<%=File1.ClientID  %>");
      if(Trim(File.value)=="")
      {
         alert("文件名称不能为空");
         File.focus();
         return false;
      }
      
      var FileExtension=File.value.substring(File.value.indexOf("."));
      if(FileExtension!=".gif" && FileExtension!=".jpg" && FileExtension!=".png" && FileExtension!=".bmp")
      {
          alert("文件格式不正确，只支持gif,jpg,bmp,png格式");
          File.focus();
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
                    <span><b><a href="LinkManage.aspx">友情连接管理</a></b></span></p>
            </h2>
            <h2>
                <p>
                    <span><b>添加友情连接</b></span></p>
            </h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>链接名称：</td>
                <td>
                    <input id="txtLinkName" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>所属频道：</td>
                <td>
                    <asp:DropDownList ID="DropChannel" Width="150" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>所属类别：</td>
                <td>
                    <asp:DropDownList ID="DropLinkType" Width="150" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>链接地址：</td>
                <td>
                    <input id="txtLinkUrl" runat="server" type="text" style="width: 238px; height: 20px" />
                    <span class="f_red">(示例:http://www.topfo.com/) </span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    序列号：</td>
                <td>
                    <input id="txtSort" runat="server" type="text" onkeyup="value=value.replace(/[^0-9]/g,'')"
                        style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    Logo：</td>
                <td>
                    <asp:FileUpload runat="server" ID="File1" />&nbsp;&nbsp;
                    <asp:Button ID="UpLoadImg" runat="server" Text="上传" OnClientClick="return CheckFile();"
                        CssClass="btn" OnClick="UploadImg_Click" />
                    <br />
                    <span class="f_red">
                        <asp:Label ID="Message" runat="server"></asp:Label></span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    说明：</td>
                <td>
                    <textarea runat="server" id="txtRemarks" style="width: 538px; height: 200px">
                       </textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClick="BtnSvae_Click" OnClientClick="return CheckNull();"
                        CssClass="btn" Text="添加" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='LinkManage.aspx';"
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
