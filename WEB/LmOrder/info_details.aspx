<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info_details.aspx.cs" Inherits="LmOrder_info_details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
       <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
             <style type="text/css"> 
.f_red{color:red}
</style>

<script type="text/javascript">
 function checks(){

   var point= document.getElementById("txtyu").value;
    var cc= document.getElementById("txtMoney").value;

    var mobile=document.getElementById("<%=txtMoney.ClientID %>").value;
   if(mobile=="")
    {
        alert("提取的金额不能为空");
        
        return false; 
    }
   if(mobile!="")
    {
            if(cc<100)
            {
            alert("提取的金额不能少于100");
            return false;
            }
            if(cc>point)
            {
              alert("提取的金额不能大余总金额");
            return false;
            }
       
    }
    }
    </script>
   
</head>
<body>
   <form id="form2" runat="server">
   <input id="txtyu" type="hidden" runat="server"  />
      <input id="txtId" type="hidden" runat="server"  />

       &nbsp;<div class="list">
           <table width="100%" class="one_table" border="0" cellspacing="0" cellpadding="0">
               <tr>
                   <td align="center" style="width: 13%">
                    申请人：
                   </td>
                   <td>
                    <asp:Label ID="txtLoginName" runat="server" Height="21px" Width="160px" ></asp:Label>
                   </td>
               </tr>
                <tr>
                    <td align="center" style="width: 13%; height: 29px;">
                      提取金额：
                    </td>
                    <td style="height: 29px">
                      <asp:TextBox ID="txtMoney" runat="server" Height="21px" Width="160px" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox><span style="color: #ff0033">总金额：</span><asp:Label ID="lblPoint" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 13%" align="center">
                        银行名称：</td>
                    <td>
                        <div style="text-align: left;">
                            <asp:TextBox ID="txtBankName" runat="server" Height="21px" Width="160px"></asp:TextBox><span style="color: #666666;">(如:招商、建设银行)</span>
                        </div> 
                    </td>
                </tr>
                <tr>
                    <td style="width: 13%" align="center">
                        银行账号：</td>
                    <td>
                        <div style="text-align: left;">
                            <asp:TextBox ID="txtBankAccout" runat="server" Height="21px" Width="160px"></asp:TextBox><span style="color: #666666;">(如:7559  168  258  10901)</span>
                        </div>
                    </td>
               </tr>
                 <tr >
                    <td style="width: 13%; height: 29px;" align="center">
                        开户银行：</td>
                    <td style="height: 29px">
                        <div style="text-align: left;">
                            <asp:TextBox ID="txtDepositBank" runat="server" Height="21px" Width="160px"></asp:TextBox><span style="color: #666666;">(如:深圳科技园支行)</span>
                        </div>
                    </td>
               </tr>
                <tr>
                    <td style="width: 15%" align="center">
                        账号名称：</td>
                    <td align="left">
                        <asp:TextBox ID="txtAccountName" runat="server" Height="21px" Width="160px"></asp:TextBox><span style="color: #666666;">(如:张三)</span>
                        <%-- <FCKeditorV2:FCKeditor ID="txtChina" runat="server" Width="99%" Height="300px" BasePath="~/Vfckeditor/">
                        </FCKeditorV2:FCKeditor>--%>
                    </td>
                </tr>
                 <tr>
                    <td align="center" style="width: 15%; height: 21px;">
                    申请日期：
                    </td>
                    <td align="left" style="height: 21px">
                     <asp:Label ID="txtTime" runat="server" Height="21px" Width="160px" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 15%; height: 29px;">
                     手机号码：
                    </td>
                    <td align="left" style="height: 29px">
                     <asp:TextBox ID="txtMobile" runat="server" Height="21px" Width="160px" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td align="center" style="width: 15%; height: 17px;">
                    状态：</td>
                    <td align="left" style="height: 17px">
                   <asp:RadioButtonList id="rblAuditing" runat="server"   RepeatDirection="Horizontal" RepeatLayout="Flow">
						            <asp:ListItem Value="0" Selected="True">审核中</asp:ListItem>
						            <asp:ListItem Value="1">已结账</asp:ListItem>
						             <asp:ListItem Value="2">审核未通过</asp:ListItem>
						        
					               </asp:RadioButtonList> 
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%; height: 141px;" align="center">
                        备注：</td>
                    <td align="left" style="height: 141px">
                        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="133px" Width="95%"></asp:TextBox>
                        <%--<%--<FCKeditorV2:FCKeditor ID="txtDesc" Width="85%" Height="145px" runat="server" BasePath="~/Vfckeditor/">
                        </FCKeditorV2:FCKeditor>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center">
                            <asp:Button ID="Button1" Height="24px" runat="server" CssClass="button1" OnClick="Button1_Click"
                                OnClientClick="return checks()" Text="审核" Width="68px" />&nbsp;
                            
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
