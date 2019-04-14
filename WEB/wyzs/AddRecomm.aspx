<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRecomm.aspx.cs" Inherits="wyzs_AddRecomm" %>

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
function upPicture(file){ 
  var ImageFileExtend = ".gif,.png,.jpg,.bmp"; 
      if(file.value.length>0)   
       {
　　        //判断后缀        
　　        var fileExtend=file.value.substring(file.value.lastIndexOf('.')).toLowerCase();
　　        if(ImageFileExtend.indexOf(fileExtend)>-1)      
　　        {   
　　            //显示预览 
　　            
                return true;      
　　        }  
　　         else       
　　        {          
                alert("请上传" + ImageFileExtend + "格式的图片");  
                return false;    
　　        }  
　　　 }
 }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>添加</b></span></p>
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
                        类型 :</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlTypeName" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="0" >--请选择--</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                      
                </tr>
                <tr id="imageDis" runat="server" style="display: none">
                        <td>
                            图片：
                        </td>
                        <td valign="middle" align="left">
                            <asp:Image ID="Image1" runat="server" Height="106px" Width="98px"></asp:Image>
                            <%-- <asp:label id="lblImages" runat="server" backcolor="White" bordercolor="White" forecolor="#C00000"></asp:label>--%>
                        </td>
                </tr>
                <tr>
                    <td>
                        个人照片：</td>
                    <td align="left">
                        <asp:FileUpload ID="uploadPic" onchange="upPicture(this)" runat="server" Width="235px" />
                        &nbsp;<asp:Button ID="btnUpload2" runat="server"  OnClick="btnUpload2_Click" Text="上 传" />
                        <asp:Label ID="LblMessage2" runat="server" BackColor="White" BorderColor="White"
                            ForeColor="#C00000"></asp:Label>
                        <br />
                        <span class="hui">(图片须为jpg、bmp、gif格式，大小不超过500K )</span>
                    </td>
                    <td>
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
                    <td>
                        网址:</td>
                    <td align="left">
                        <asp:TextBox ID="txtSite" runat="server" Width="228px" Height="22px"></asp:TextBox></td>
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
