<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADMessageUA.aspx.cs" Inherits="advertise_ADMessageUA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>广告页面处理</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
      <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
    <script language="javascript" type="text/javascript">
   function verify()
   {
     var name=document.getElementById("txtTypeName");
       if(name.value=="")
       {
          spTypeName.innerHTML="广告名称不能为空";
          name.focus();
          return false;
       }
       else
       {
          spTypeName.innerHTML="";
       }
       var ser=document.getElementById("txtSerial");
        if(ser.value=="")
        {
           spSerial.innerHTML="广告序号不能为空";
           ser.focus();
           return false;
        }
        else
        {
           spSerial.innerHTML="";
        }
        var pri=document.getElementById("txtprice");
        if(pri.value=="")
        {
           spPrice.innerHTML="价格不能为空";
           pri.focus();
           return false;
        }else
        {
           if(/\D/.test(pri.value))
           {
               spPrice.innerHTML="价格只能为数字";
               pri.value="";
               pri.focus();
               return false;
           }else
           {
             spPrice.innerHTML="";
            
           }
       }
   }
   
    </script>
</head>

<body id="mainbody">
    <form id="form1" runat="server">
    <div class="title" align="center">
             <h2><p><span><b><a href="ADMessageInfo.aspx">广告频道管理</a></b></span></p></h2>
             <h2><p><span><b>添加广告信息</b></span></p></h2>
             </div>
     <table border="1" cellpadding="0" cellspacing="0" class="one_table" >
            <tr>
                <th colSpan="2">
                  <div align="center">
                      广告信息</div>     
                </th>
            </tr>
             <tr>
                <td align="right" >
                  <strong>广告名称：</strong></td>
                <td align="left">
                    <asp:TextBox ID="txtTypeName"  runat="server" Width="270px" Height="21px"></asp:TextBox>
                    <span id="spTypeName" style="color:Red">请输入广告名称</span>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 24px" >
                  <span > </span>  <strong>频道名称：</strong></td>
                <td align="left" style="height: 24px">
                    <asp:DropDownList ID="ddlBName" runat="server">
                    </asp:DropDownList><span id="Span1"></span></td>
            </tr>
           
            <tr>
                <td align="right" >
                  <strong>广告序号：</strong></td>
                <td align="left">
                    <span id="Span8"></span>
                    <asp:TextBox ID="txtSerial"  runat="server" Height="24px"></asp:TextBox>
                    <span id="spSerial" style="color:Red">请输入广告序号</span>
                    </td>
            </tr>
            <tr>
                <td align="right">
                  <strong>尺寸大小：</strong></td>
                <td align="left">
                    <asp:TextBox ID="txtsize" runat="server" Height="24px"></asp:TextBox><span id="Span9"></span></td>
            </tr>
            <tr>
                <td align="right" >
                  <strong>价格：</strong></td>
                <td align="left">
                    <asp:TextBox ID="txtprice"  runat="server" Height="24px"></asp:TextBox>
                    <span id="spPrice" style="color:Red">请输入价格</span></td>
            </tr>
           
             <tr>
                <td align="right" >
                  <strong>赠送日期：</strong></td>
                <td align="left" >
                     <input  type="text" runat="server" id="txtgiving" onClick="WdatePicker({lang:'zh-cn'})" />
                     <img onclick="WdatePicker({el:$dp.$('txtgiving')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                </td>
            </tr>
            <tr>
                <td align="right" >
                   <strong>备注：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtnote" runat="server" Columns="50" Height="107px" TextMode="MultiLine" Width="327px"></asp:TextBox>
                    <span id="Span4"></span>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <strong>激活状态：</strong></td>
                <td align="left">
                   <asp:RadioButtonList id="rblcheck" runat="server"  RepeatDirection="Horizontal" RepeatLayout="Flow">
						<asp:ListItem Value="0" Selected="True">不激活</asp:ListItem>
						<asp:ListItem Value="1">激活</asp:ListItem>
					</asp:RadioButtonList> </td>
            </tr>
            
             <tr>
                <td align="center" style="height: 21px" colspan="2" >
                <asp:Button runat="server" ID="btnAdd" Text="发布" CssClass="btn" OnClientClick="return verify();"  OnClick="btnAdd_Click" />
                <asp:Button runat="server" ID="btnsel" Text="返回" CssClass="btn" OnClick="btnsel_Click" />
                  </td>
            </tr>
     
</table>
    </form>
</body>
</html>
