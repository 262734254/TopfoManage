<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductTypeManage.aspx.cs" Inherits="productType_ProductTypeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
   <script language="javascript" type="text/jscript" src="../js/Common1.js"></script>
    <script language="javascript" type="text/javascript">

          function Modfiy(Id)
          {
             var url="ModfiyProductType.aspx?ProductId="+Id;
             window.location.href=url;
          }
          
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="mainconbox">
            <div class="title" align="center">
                <h2>
                    <p><span><b>产品类别管理</b></span></p>
                </h2>
            </div>
               <div class=" cshibiank">
                    <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table">
                          <tr>
                            <th width="10%" align="center" class="tabtitle" style="height: 29px"><a href="Javascript:js.IsSelect(true,'Cbox');">全</a>|<a href="Javascript:js.IsSelect(false,'Cbox');">反</a></th>
                            <th align="center" width="10%" class="tabtitle">序号</th>
                            <th align="center" width="50%" class="tabtitle">类别名称</th>
                            <th align="center" width="30%" class="tabtitle">管理</th>
                        </tr>    
                        <asp:Repeater ID="RepList" runat="server">
                            <ItemTemplate>
                                <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                                    <td align="center">
                                       <asp:CheckBox runat="server" ID="Cbox" ToolTip='<%# Eval("productTypeid") %>' />
                                    </td>
                                    <td align="center">
                                      <%# Eval("orderId") %>
                                    </td>
                                    <td align="center">
                                     <%# Eval("productName") %>
                                    </td>
                                    <td align="center">
                                        <a href='JavaScript:Modfiy(<%#Eval("productTypeid") %>)'>修改</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        <div style="margin-left:5px; margin-top:5px;">
           <input type="button" value="添加类别" class="btn" onclick="window.location.href='AddProductType.aspx';" />
        </div>
    </form>
</body>
</html>
