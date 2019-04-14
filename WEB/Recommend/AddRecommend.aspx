<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRecommend.aspx.cs" Inherits="Recommend_AddRecommend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="../js/Common1.js"></script>
    <title>无标题页</title>
    <style type="text/css"> 
        .f_red{color:red}
        .f_td{width:15%;background-color:#f7f7f7;}
    </style>
    <script language="javascript" type="text/javascript">
       function CheckNull()
       {
          var Title=js.$("<%=txtTitle.ClientID %>");
          if(js.Trim(Title.value)=="")
          {
             alert("请输入标题!");
             Title.focus();
             return false;
          }
          
          var Address=js.$("<%=txtAddress.ClientID %>");
          if(js.Trim(Address.value)=="")
          {
             alert("请输入链接地址!");
             Address.focus();
             return false;
          }
          
        
           
//           var Sort=js.$("<%=txtSort.ClientID %>");
//           if(js.Trim(Sort.value)=="")
//           {
//              alert("请输入序列号!");
//              Sort.focus();
//              return false;
//           }
          
           var Identity=js.$("<%=DropIdentity.ClientID %>");
           if(Identity.options[Identity.selectedIndex].value=="-1")
           {
             alert("请选择类型!");
             Identity.focus();
             return false;
           }
           return true;
       }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2>
                <p>
                    <span><b><a href="RecommendManage.aspx">项目推荐管理</a></b></span></p>
            </h2>
            <h2>
                <p>
                    <span><b>添加项目</b></span></p>
            </h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>标题：</td>
                <td>
                    <input id="txtTitle"  runat="server" type="text" style="width: 400px; height: 20px" />
                </td>
            </tr>
            <tr>
               <td align="right" class="f_td">
                    <span class="f_red">*</span>链接地址：</td>
                <td>
                    <input id="txtAddress"  runat="server" type="text" style="width: 400px; height: 20px" />
                    <span class="f_red">(示例:http://www.topfo.com/) </span>
                </td>
            </tr>
            <tr>
               <td align="right" class="f_td">序列号：</td>
                <td>
                    <input id="txtSort" onkeyup="value=value.replace(/[^0-9]/g,'')"  runat="server" type="text" style="width: 400px; height: 20px" />
                </td>
            </tr> 
            <tr>
              <td align="right" class="f_td"><span class="f_red">*</span>项目类型：</td>
              <td>
                 <asp:DropDownList ID="DropIdentity" Width="200" runat="server">
                   <asp:ListItem Value="-1">请选择</asp:ListItem>
                   <asp:ListItem Value="0">招商方</asp:ListItem>
                   <asp:ListItem Value="1">投资方</asp:ListItem>
                   <asp:ListItem Value="2">融资方</asp:ListItem>
                   <asp:ListItem Value="3">热点资源项目</asp:ListItem>
                   <asp:ListItem Value="4">重大热点资源项目</asp:ListItem>
                   <asp:ListItem Value="5">重大投资项目</asp:ListItem>
                 </asp:DropDownList>
              </td>
            </tr>       
            <tr>
              <td align="right" class="f_td"><span class="f_red">*</span>展示位置：</td>
              <td>
                 <asp:DropDownList ID="FenZhanList" Width="200" runat="server">
                 </asp:DropDownList>
              </td>
            </tr>
             <tr>
                <td align="right" class="f_td">
                    是否推荐：</td>
                <td>
                    <asp:RadioButtonList ID="RadioRecommend" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        runat="server">
                        <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
               <td align="right" class="f_td">项目描述：</td>
               <td>
                  <textarea id="txtRemarks" runat="server" style="width: 538px; height: 200px"></textarea>
               </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClick="BtnAdd_Click" OnClientClick="return CheckNull();"
                        CssClass="btn" Text="添加" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='RecommendManage.aspx';"
                        value="返回" />
                </td>
            </tr>
        </table>
        <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: 0px; left: 0px; width: 104%; height: 1652px; filter: alpha(opacity=60);">
            <div class="content">
                <p>数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
            </div>
        </div>
    </form>
</body>
</html>
