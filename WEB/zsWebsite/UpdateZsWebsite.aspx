<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateZsWebsite.aspx.cs" Inherits="zsWebsite_UpdateZsWebsite" %>

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
          var WebsiteName=document.getElementById("txtWebsiteName");
          if(Trim(WebsiteName.value)=="")
          {
               alert("网站名称不能为空!");
               WebsiteName.focus();
               return false;
          }
          
          var WebsiteUrl=document.getElementById("txtWebsiteUrl");
          if(Trim(WebsiteUrl.value)=="")
          {
             alert("网站地址不能为空!");
             WebsiteUrl.focus();
             return false;
          }
          
          
          var Province=document.getElementById("Province");
          if(Province.options[Province.selected].value=="0")
          {
              alert("请选择所属区域!");
              Province.focus();
              return false;
          }
          
          return false;
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
                    <span><b><a href="ManageZsWebsite.aspx">各地政府招商网址</a></b></span></p>
            </h2>
            <h2>
                <p>
                    <span><b>修改各地政府招商网址</b></span></p>
            </h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>网站名称：</td>
                <td>
                    <input id="txtWebsiteName" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>网站地址：</td>
                <td>
                    <input id="txtWebsiteUrl" runat="server" type="text" style="width: 238px; height: 20px" />
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
                <td align="right" class="f_td">
                    网站汇总说明</td>
                <td>
                    &nbsp;<asp:TextBox ID="txtSiteContent" runat="server" Height="67px" TextMode="MultiLine"
                        Width="232px"></asp:TextBox></td>
            </tr>
              <tr>
                <td align="right" class="f_td" style="height: 19px">
                    备注</td>
                <td style="height: 19px">
                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Height="67px" TextMode="MultiLine"
                        Width="232px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClick="BtnUpdate_Click" OnClientClick="return CheckNull();"
                        CssClass="btn" Text="修改" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='ManageZsWebsite.aspx';"
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
