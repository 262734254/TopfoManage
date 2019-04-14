<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFenZhan.aspx.cs" Inherits="fenzhan_AddFenZhan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link type="text/css" href="../css/CRM.css" rel="stylesheet" />
<title></title>
<style type="text/css"> 
    .f_red{color:red}
    .f_td{width:15%;background-color:#f7f7f7;
}
</style>
<script language="javascript" type="text/javascript" src="../js/Common1.js"></script>
<script language="javascript" type="text/javascript">
  function ValidDate()
  {
     var txtName=js.$("txtName");
     if(js.Trim(txtName.value)=="")
     {
        alert("站点名称不能为空!");
        txtName.focus();
        return false;
     }
     
     var txtAddress=js.$("txtAddress");
     if(js.Trim(txtAddress.value)=="")
     {
        alert("站点地址不能为空!");
        txtAddress.focus();
        return false;
     }
     
     var Province=js.$("DropProvince");
     if(Province.options[Province.selectedIndex].value=="0")
     {
         alert("请选择所属城市!");
         Province.focus();
         return false;
     }
     
     return true;
  }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2><p><span><b><a href="FenZhanManage.aspx">分站管理</a></b></span></p></h2>
            <h2><p><span><b>添加分站</b></span></p></h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>分站名称：</td>
                <td>
                    <input id="txtName" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>分站地址：</td>
                <td>
                    <input id="txtAddress" runat="server" type="text" style="width: 238px; height: 20px" />
                    <span class="f_red">地址格式(http://bj.topfo.com)</span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>城市名称：</td>
                <td>
                    <asp:DropDownList ID="DropProvince" style="width: 238px; height: 20px" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClientClick="return ValidDate();" CssClass="btn" Text="添加" OnClick="BtnSvae_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>


