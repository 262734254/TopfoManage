<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModfiyProductType.aspx.cs" Inherits="productType_ModfiyProductType" %>

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
        function _Check()
        {
           var TypeName=document.getElementById("txtTypeName");
           if(js.Trim(TypeName.value)=="")
           {
               alert("产品类别不能为空!");
               TypeName.focus();
               return false;
           }
           return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2><p><span><b><a href="ProductTypeManage.aspx">产品类别管理</a></b></span></p></h2>
            <h2><p><span><b>修改产品类别</b></span></p></h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>类别名称：</td>
                <td><input id="txtTypeName" runat="server" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>序号：</td>
                <td><input id="txtOrder" runat="server" onkeyup="value=value.replace(/[^0-9]/g,'');" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClientClick="_Check();"
                        CssClass="btn" Text="修改" OnClick="BtnSvae_Click" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='ProductTypeManage.aspx';"
                        value="返回" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>


