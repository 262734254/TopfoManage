<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyWyzsInfo.aspx.cs" Inherits="wyzs_ModifyWyzsInfo" %>

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
               alert("标题不能为空!");
               Title.focus();
               return false;
          }
          
          var TelePhone=document.getElementById("txtTelePhone");
          if(Trim(TelePhone.value)=="")
          {
             alert("联系电话不能为空!");
             TelePhone.focus();
             return false;
          }
          
          var Email=document.getElementById("txtEmail");
          if(Trim(Email.value)=="")
          {
             alert("邮箱不能为空!");
             Email.focus();
             return false;
          }
          
          if(!isEmail(Email.value))
          {
             alert("邮箱格式错误!");
             Email.focus();
             return false;
          }
          
          var LinkMan=document.getElementById("txtLinkMan");
          if(Trim(LinkMan.value)=="")
          {
             alert("联系人不能为空!");
             LinkMan.focus();
             return false;
          }
          
          var Types=document.getElementById("txtTypes");
          if(Types.options[Types.selectedIndex].value=="0")
          {
              alert("请选择类别!");
              Types.focus();
              return false;
          }
          
          var Source=document.getElementById("txtSource");
          if(Source.options[Source.selectedIndex].value=="0")
          {
              alert("来源不能为空!");
              Source.focus();
              return false;
          }
          
          var Purpose=document.getElementById("txtPurpose");
          if(Purpose.options[Purpose.selectedIndex].value=="0")
          {
              alert("用途不能为空!");
              Purpose.focus();
              return false;
          }
          
          var Floor=document.getElementById("txtFloor");
          if(Floor.options[Floor.selectedIndex].value=="0")
          {
              alert("楼层不能为空!");
              Floor.focus();
              return false;
          }
          
          var Hire=document.getElementById("txtHire");
          if(Hire.options[Hire.selectedIndex].value=="0")
          {
              alert("租金不能为空!");
              Hire.focus();
              return false;
          }
          
          var Area=document.getElementById("txtArea");
          if(Area.options[Area.selectedIndex].value=="0")
          {
              alert("面积不能为空!");
              Area.focus();
              return false;
          }
          
          var Fitment=document.getElementById("txtFitment");
          if(Fitment.options[Fitment.selectedIndex].value=="0")
          {
              alert("装修不能为空!");
              Fitment.focus();
              return false;
          }
          
          var Elevator=document.getElementById("txtElevator");
          if(Elevator.options[Elevator.selectedIndex].value=="0")
          {
              alert("电梯不能为空!");
              Elevator.focus();
              return false;
          }
          
          return true;
       }
       
       function Trim(str)
       {
           var reg = /\s*$|^\s*/g;
           return str.replace(reg, "");
       }
       
       function isEmail(str)
       {
          var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
          return reg.test(str);
       }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2><p><span><b><a href="WyzsInfoManage.aspx">物业信息管理</a></b></span></p></h2>
            <h2><p><span><b>修改物业信息</b></span></p></h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>标题：</td>
                <td><input id="txtTitle" runat="server" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td align="right" class="f_td" style="height: 28px"><span class="f_red">*</span>联系电话：</td>
                <td style="height: 28px"><input id="txtTelePhone" onkeyup="value=value.replace(/[^0-9]/g,'')" onblur="value=value.replace(/[^0-9]/g,'')" runat="server" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>邮箱：</td>
                <td><input id="txtEmail" runat="server" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>联系人：</td>
                <td><input id="txtLinkMan" runat="server" type="text" style="width: 238px; height: 20px" /></td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>类型：</td>
                <td>
                     <asp:DropDownList ID="txtTypes" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">==请选择==</asp:ListItem>
                       <asp:ListItem Value="1">求租</asp:ListItem>
                       <asp:ListItem Value="2">购买</asp:ListItem>
                       <asp:ListItem Value="3">出租</asp:ListItem>
                       <asp:ListItem Value="4">出售</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>来源：</td><td>
                    <asp:DropDownList ID="txtSource" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">==请选择==</asp:ListItem>
                       <asp:ListItem Value="1">业主</asp:ListItem>
                       <asp:ListItem Value="2">需求</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>用途：</td><td>
                    <asp:DropDownList ID="txtPurpose" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">==请选择==</asp:ListItem>
                       <asp:ListItem Value="1">门面</asp:ListItem>
                       <asp:ListItem Value="2">办公</asp:ListItem>
                       <asp:ListItem Value="3">商住两用</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>楼层：</td><td>
                    <asp:DropDownList ID="txtFloor" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">==请选择==</asp:ListItem>
                       <asp:ListItem Value="1">1-5楼</asp:ListItem>
                       <asp:ListItem Value="2">5-8楼</asp:ListItem>
                       <asp:ListItem Value="3">8楼以上</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>租金：</td><td>
                    <asp:DropDownList ID="txtHire" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">==请选择==</asp:ListItem>
                       <asp:ListItem Value="1">40-60元/平方米</asp:ListItem>
                       <asp:ListItem Value="2">60-80元/平方米</asp:ListItem>
                       <asp:ListItem Value="3">3->80元以上</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>面积：</td><td>
                    <asp:DropDownList ID="txtArea" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">==请选择==</asp:ListItem>
                       <asp:ListItem Value="1">100平米以内</asp:ListItem>
                       <asp:ListItem Value="2">100-200平米</asp:ListItem>
                       <asp:ListItem Value="3">200平米以上</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>装修：</td><td>
                    <asp:DropDownList ID="txtFitment" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">==请选择==</asp:ListItem>
                       <asp:ListItem Value="1">简装</asp:ListItem>
                       <asp:ListItem Value="2">无</asp:ListItem>
                       <asp:ListItem Value="3">豪装</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td"><span class="f_red">*</span>电梯：</td><td>
                    <asp:DropDownList ID="txtElevator" Width="200" runat="server" Style="width: 238px;height: 20px">
                       <asp:ListItem Value="0">==请选择==</asp:ListItem>
                       <asp:ListItem Value="1">有</asp:ListItem>
                       <asp:ListItem Value="2">无</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnModify" OnClientClick="return CheckNull();" CssClass="btn" Text="修改" OnClick="BtnModify_Click" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='WyzsInfoManage.aspx';" value="返回" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
