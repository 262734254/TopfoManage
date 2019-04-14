<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddVisit.aspx.cs" Inherits="Visit_AddVisit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加会员信息</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
    <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
    <script language="javascript" type="text/javascript">
function Add()
{
  var cblDisp="<%=this.cblDisposition.ClientID %>";
  if(!ChkCbl(cblDisp,"需求意向"))
  {
     return false;
  }
//   var filtMobile = /^(13|15|18)[0-9]{9}$/;
//    if(!filtMobile.test(document.getElementById("txtTel").value))
//    {
//        alert("请正确填写手机号码");
//        document.getElementById("txtTel").focus();
//        return false;
//    }
  if(document.getElementById("txtEmail").value=="")
    {
       alert("请输入电子邮箱");
       document.getElementById("txtEmail").focus();
       return false;
    } else  
    {
        var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
        if(!filtEmial.test(document.getElementById("txtEmail").value))
        {
   	         alert("电子邮箱格式不正确，请重新输入");
   	         document.getElementById("txtEmail").value="";
   	         document.getElementById("txtEmail").focus();
   	         return false;
   	     }
    }
  var time=document.getElementById("txtTime");
  if(time.value=="")
  {
      alert("请选择回访时间!");
      time.focus();
      return false;
  }
    
}


   function ChkCbl(kjID,kjName)
    {
        if(GetCheckBoxListCheckNum(kjID)<=0)
        {
            alert("请选择"+kjName);
            document.getElementById(kjID).focus();
            return false;
        }
        else
        {
            return true;
        }
    }
    function GetCheckBoxListCheckNum(checkobjectid)
    {
        var selectedItemCount = 0;
        var liIndex = 0;
        var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
        while (currentListItem != null)
        {
            if (currentListItem.checked) selectedItemCount++;
            liIndex++;
            currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
        }
        return selectedItemCount;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title" align="center">
             <h2><p><span><b><a href="SelVisit.aspx">会员频道管理</a></b></span></p></h2>
             <h2><p><span><b>查看会员信息</b></span></p></h2>
             </div>
     <table border="1" width="100%" cellpadding="0" cellspacing="0" class="one_table" >
            <tr>
                <th colSpan="2">
                  <div align="center">
                      用户详细信息</div>     
                </th>
            </tr>
             <tr>
                <td align="right" style="width: 20%">
                  <strong>用户名：</strong></td>
                <td align="left" width="80%">
                    <%--<input runat="server" id="txtTypeName"  type="text" />--%>
                    <span id="lblTypeName" runat="server" style="color:Red"></span>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 20%" >
                  <span > </span>  <strong>会员类型：</strong></td>
                <td align="left" width="80%">
                <span id="lblMemberType" runat="server"></span>
                </td>
            </tr>
           
            <tr>
                <td align="right" style="width: 20%">
                  <strong>昵称：</strong></td>
                <td align="left" width="80%">
                 <span id="lblNickName" runat="server"></span>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width: 20%">
                  <strong>地域：</strong></td>
                <td align="left" width="80%">
                <span id="lblCounty" runat="server"></span>
                    </td>
            </tr>
           
             <tr>
                <td align="right" style="width: 20%">
                  <strong>联系人：</strong></td>
                <td align="left" width="80%" >
                  <span id="lblMemberName" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 20%">
                   <strong>电话号码：</strong></td>
                <td align="left" width="80%">
                  <span id="lblTel" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 20%">
                    <strong>手机号码：</strong></td>
                <td align="left" width="80%">
                <span id="lblMobile" runat="server"> </span>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width: 20%">
                    <strong>电子邮箱：</strong></td>
                <td align="left" width="80%">
               <span id="lblEmail" runat="server"></span>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width: 20%">
                    <strong>联系地址：</strong></td>
                <td align="left" width="80%">
               <span id="lblAddress" runat="server"></span>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width: 20%">
                    <strong>邮政编号：</strong></td>
                <td align="left" width="80%">
                <span id="lblPostCode" runat="server"></span>
                    </td>
            </tr>
   </table>
       <table border="1" width="100%" cellpadding="0" cellspacing="0" class="one_table" > 
           <tr>
                <th colSpan="2">
                  <div align="center">
                      回访记录</div>     
                </th>
                 </tr>
                <tr>
                <td align="right" width="20%" >
                  <strong><span style="color:Red">*</span>需求意向：</strong></td>
                <td align="left" width="80%" >
                    <asp:CheckBoxList ID="cblDisposition" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">招商</asp:ListItem>
                        <asp:ListItem Value="1">投资</asp:ListItem>
                        <asp:ListItem Value="2">融资</asp:ListItem>
                        <asp:ListItem Value="3">创业</asp:ListItem>
                        <asp:ListItem Value="4">商机</asp:ListItem>
                    </asp:CheckBoxList></td>
            </tr>
            <tr>
                <td align="right" width="20%" >
                  <strong>手机号码：</strong></td>
                <td align="left" width="80%" >
                    <asp:TextBox ID="txtTel"  runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" width="20%" >
                  <strong><span style="color:Red">*</span>邮箱：</strong></td>
                <td align="left" width="80%" >
                    <asp:TextBox ID="txtEmail"  runat="server" ></asp:TextBox>
                    <span style="color:Red" id="spanID">请填写正确的邮箱,示例:abcc@xxx.com</span>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" >
                  <strong><span style="color:Red">*</span>回访时间：</strong></td>
                <td align="left" width="80%" >
                    <input runat="server" id="txtTime" type="text" onClick="WdatePicker({lang:'zh-cn'})" />
                    <img onclick="WdatePicker({el:$dp.$('txtTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                   
                </td>
            </tr>
            <tr>
                <td align="right"width="20%" >
                  <strong>需求说明：</strong></td>
                <td align="left" width="80%" >
                    <textarea id="txtCaption" rows="5" runat="server"  ></textarea>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" >
                  <strong>回访备注：</strong></td>
                <td align="left" width="80%" >
                    <textarea id="txtRemark" rows="5" runat="server"  ></textarea>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" >
                  <strong>是否有效：</strong></td>
                <td align="left" width="80%" >
                    <asp:RadioButtonList ID="rblVaild" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" width="20%" >
                  <strong>是否回访：</strong></td>
                <td align="left" width="80%" >
                    <asp:RadioButtonList ID="rblVaildNew" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" colspan="2" >
                  <asp:Button runat="server" ID="btnAdd" Text="确认" CssClass="btn" OnClientClick="return Add();" OnClick="btnAdd_Click" />
                  <asp:Button runat="server" ID="btnqu" Text="返回" CssClass="btn" OnClick="btnqu_Click" />
                  </td>
            </tr>
      </table>
    </form>
</body>
</html>
