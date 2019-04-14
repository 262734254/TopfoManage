<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModfiyBrand.aspx.cs" Inherits="Brand_ModfiyBrand" %>
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
   function Trim(str)
   {
       var reg=/^\s*|\s*$/g;
       return str.replace(reg,"");
   }
   
   function CheckNull()
   {
           var Title=document.getElementById("<%=txtTitle.ClientID %>");
           if(Trim(Title.value)=="")
           {
              alert("请输入标题!");
              Title.foucs();
              return false;
           }
           
           var ImgReg=/^.*(.jpg|.bmp,.gif,.png)/g;
           var ImgPath=document.getElementById("<%=txtImgPath.ClientID %>");
           if(Trim(ImgPath.value)=="")
           {
              alert("请输入图片地址!");
              ImgPath.focus();
              return false;
           }
           
           if(!ImgReg.test(ImgPath.value))
           {
               alert("图片格式不正确!");
               ImgPath.focus();
               return false;
           }
           
           var UrlReg =/^.*(.com|.cn|.com.cn|.org|.net)$ig;
           var Url=document.getElementById("<%=txtUrl.ClientID %>");
           if(Trim(Url.value)=="")
           {
              alert("请输入Url地址!");
              Url.focus();
              return false;
           }
           
           if(!UrlReg.test(Url.value))
           {
               alert("Url格式错误!")
               Url.focus();
               return false;
           }
           
           var Position=document.getElementById("<%=ShowPosition.ClientID %>");
           var value=Position.options[Position.selectedIndex].value;
           if(value=="0")
           {
              alert("请选择展示位置!");
              Position.focus();
              return false;
           }
           return true;
   }
</script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="title" align="center">
             <h2><p><span><b><a href="BrandManage.aspx">品牌管理</a></b></span></p></h2>
             <h2><p><span><b>添加品牌</b></span></p></h2>
   </div>
       <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>标题：</td>
                    <td>
                        <input id="txtTitle" runat="server" type="text" style="width: 238px; height: 20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>图片地址：</td>
                    <td>
                        <input id="txtImgPath" runat="server" type="text" style="width: 238px; height: 20px" />
                        <span class="f_red">图片支持格式(jpg|gif|bmp|png)</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>链接地址：</td>
                    <td>
                        <input id="txtUrl" runat="server" type="text" style="width: 238px; height: 20px" />
                        <span class="f_red">(示例:http://www.topfo.com/) </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                      <span class="f_red">*</span>展示位置：</td>
                    <td>
                        <asp:DropDownList ID="ShowPosition" runat="server">
                           <asp:ListItem Value="0">-请选择-</asp:ListItem>
                           <asp:ListItem Value="全部">全部</asp:ListItem>
                           <asp:ListItem Value="首页">首页</asp:ListItem>
                           <asp:ListItem Value="分站">分站</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">序列号：</td>
                    <td><input id="txtSort" runat="server" onkeyup="value=value.replace(/[^0-9]/g,'')" type="text" style="width: 238px; height: 20px" /></td>
                </tr>
                <tr>
                    <td align="right" class="f_td">说明：</td>
                    <td>
                        <input id="txtRemarks" runat="server" type="text" style="width: 538px; height: 200px" />
                    </td>
                </tr>
                <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClick="BtnModfiy_Click" OnClientClick="return CheckNull();" CssClass="btn" Text="修改" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='BrandManage.aspx';" value="返回" />
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



