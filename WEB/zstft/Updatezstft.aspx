<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updatezstft.aspx.cs" Inherits="zstft_Updatezstft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
    <title></title>
    <style type="text/css"> 
      .f_red{color:red}
      .f_td{width:15%;background-color:#f7f7f7;}
    </style>
    <script language="javascript" type="text/javascript">
       function CheckNull()
       {
          var Title=document.getElementById("txtTitle");
          if(Trim(Title.value)=="")
          {
               alert("网站名称不能为空!");
               Title.focus();
               return false;
          }
          
          var Address=document.getElementById("txtAddress");
          if(Trim(Address.value)=="")
          {
             alert("网站地址不能为空!");
             Address.focus();
             return false;
          }
          
          var Category=document.getElementById("txtCategory");
          if(Category.options[Category.selectedIndex].value=="0")
          {
              alert("请选择类别!");
              Category.focus();
              return false;
          }
          
           var Province=document.getElementById("Province");
          if(Province.options[Province.selectedIndex].value=="-1")
          {
              alert("请选择所属区域!");
              Province.focus();
              return false;
          }
          
          return true;
       }
       
       function Trim(str)
       {
           var reg = /\s*$|^\s*/g;
           return str.replace(reg, "");
       }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2>
                <p>
                    <span><b><a href="Managezstft.aspx">招商拓富通管理</a></b></span></p>
            </h2>
            <h2>
                <p><span><b>修改招商拓富通</b></span></p>
            </h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span> 网站名称：</td>
                <td>
                    <input id="txtTitle" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>网站地址：</td>
                <td>
                    <input id="txtAddress" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>类别：</td><td>
                    <asp:DropDownList ID="txtCategory" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">请选择</asp:ListItem>
                       <asp:ListItem Value="招商">招商</asp:ListItem>
                       <asp:ListItem Value="投资">投资</asp:ListItem>
                       <asp:ListItem Value="融资">融资</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>区域：</td>
                <td>
                    <asp:DropDownList ID="Province" Width="200" runat="server" Style="width: 238px;
                        height: 20px">
                    </asp:DropDownList>
                </td>
            </tr>
           <tr>
                <td align="right" class="f_td">序号：</td>
                <td>
                    <input id="txtSort" runat="server" onblur="value=value.replace(/[^0-9]/g,'')" onkeyup="value=value.replace(/[^0-9]/g,'')" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
             <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>图片：</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" style="width: 238px; height: 20px" />
                    <br />
                    <asp:Image ID="Img" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">说明：</td>
                <td>
                    <textarea runat="server" id="txtRemark" style="width: 456px; height: 209px"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClick="BtnUpdate_Click" OnClientClick="return CheckNull();"
                        CssClass="btn" Text="修改" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='Managezstft.aspx';"
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

