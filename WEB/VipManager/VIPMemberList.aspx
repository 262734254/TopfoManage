<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VIPMemberList.aspx.cs" Inherits="VipManager_VIPMemberList" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Vip信息列表</title>
      <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
         <script type="text/javascript"  src="../js/Common.js"></script>
         <script type="text/javascript" src="../js/CheckAll.js"></script>
       <script type="text/javascript">

 </script> 
	<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:30px;}
        .content p{line-height:30px;        }
        
    </style>  
      
</head>
  
<body>
    <form id="form1" runat="server">
    <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>VIP会员列表</b></span></p>
                </h2>
               
            </div>
             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>

    
        
        <td  align="center" style="height: 24px">
            登录名：<input id="txtLoginName"  style="width:100px;" type="text"  runat="server" />
        </td>
       
      
        <td   align="center" style="height: 24px">
            <asp:Button ID="btSearch"  CssClass="btn"  runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr  style="background:#bcd9e7; height:27px;">


                        <td  width="10%" align="center"  class="tabtitle" style="height: 32px">
                        登录名</td>                   
                          <td width="10%" align="center" class="tabtitle" style="height: 32px">
                        申请日期</td>
                         <td width="10%" align="center" class="tabtitle" style="height: 32px">
                        到期日期</td>
                                 <td align="center" class="tabtitle" style="height: 32px; width: 10%;">
                        会员类型</td>
                          <td width="10%" align="center" class="tabtitle" style="height: 32px">
                        管理</td>
                       
                </tr>
                <asp:Repeater ID="VipList" runat="server">
                    <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                            <td style="width: 100px"  align="center">
                             <%#(Eval("LoginName"))%>
                           </td>                     
                            <td style="width: 100px"  align="center">
                              <%#(Eval("VIPValidateDate", "{0:yyyy-MM-dd}"))%>
                           </td>                                               
                           <td style="width: 100px"  align="center">
                            <%#(Eval("VipInvalidDate", "{0:yyyy-MM-dd}"))%>
                        
                           </td>
                             <td style="width: 100px"  align="center">
                                <%#this.Verify(Convert.ToInt32(Eval("ManageTypeID")))%>
                           </td>
                          <td style="width: 100px"   align="center">
                             查看
                           </td>

                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </table>
    
            <br />
            
    <div>

        &nbsp;&nbsp;&nbsp;&nbsp;共搜索到<span style="color:red;"><%=AspNetPager.RecordCount%></span>条，共<span style="color:red;"><%=AspNetPager.PageCount%></span>页
        
        </div>
               <td style="text-align:right; width: 348px;">
                   &nbsp;&nbsp;</td>
                  <td style="text-align: left; width: 74px;" >
                                <span id="pinfo" runat="server"></span>&nbsp;</td>
						 <th align="center"  colspan="8" style="height: 32px">
                <cc1:AspNetPager ID="AspNetPager" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" CssClass="anpager" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="20">
                                </cc1:AspNetPager>
                </th>
						</div>
						
      
    </form>
<%--     
       <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1000px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>--%>
</body>
</html>
