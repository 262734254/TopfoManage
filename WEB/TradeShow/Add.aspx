<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="TradeShow_Add" %>

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
       function Trim(str)
       {
           var reg = /\s*$|^\s*/g;
           return str.replace(reg, "");
       }
       
       function CheckNull()
       {
          var Title=document.getElementById("txtTitle");
          if(Trim(Title.value)=="")
          {
              alert("标题不能为空!");
              Title.focus();
              return false;
          }
          
          var Types=document.getElementById("DropTypes");
          if(Trim(Types.options[Types.selectedIndex].value)=="")
          {
              alert("请选择类别!");
              Types.focus();
              return false;
          }
          
          var UserName=document.getElementById("txtUserName");
          if(Trim(UserName.value)=="")
          {
              alert("拟邀人员不能为空!");
              UserName.focus();
              return false();
          }
          
          var Job=document.getElementById("txtJob");
          if(Trim(Job.value)=="")
          {
              alert("职务不能为空!");
              Job.focus();
              return false;
          }
          return true;
       }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2><p><span><b><a href="Manage.aspx">参会名单管理</a></b></span></p></h2>
            <h2><p><span><b>添加参会名单</b></span></p></h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span> 标题：</td>
                <td><input id="txtTitle" runat="server" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>类别：</td><td>
                    <asp:DropDownList ID="DropTypes" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="">请选择</asp:ListItem>
                       <asp:ListItem Value="1">拟要上市公司</asp:ListItem>
                       <asp:ListItem Value="2">资本机构</asp:ListItem>
                       <asp:ListItem Value="3">融资项目</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span> 拟邀人员：</td>
                <td><input id="txtUserName" runat="server" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span> 职务：</td>
                <td><input id="txtJob" runat="server" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td align="right" class="f_td">序号：</td>
                <td><input id="txtSort" runat="server" onblur="value=value.replace(/[^0-9]/g,'')" onkeyup="value=value.replace(/[^0-9]/g,'')" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
              <td align="right" class="f_td">备注：</td>
                <td>
                  <textarea id="Remark" runat="server" cols="40" rows="8" onkeyup="if(value.length>200){value.substring(0,100);}">
                  </textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClientClick="return CheckNull();" CssClass="btn" Text="添加" OnClick="BtnSvae_Click" />
                    &nbsp;&nbsp;
                    <input type="button" class="btn" onclick="location.href='Manage.aspx';" value="返回" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
