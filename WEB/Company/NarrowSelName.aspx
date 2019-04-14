<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NarrowSelName.aspx.cs" Inherits="Company_NarrowSelName" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>窄告信息</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>

</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

       <div class="title" align="center">
             <h2><p><span><b>窄告定制管理</b></span></p></h2>
             </div>

        <div class=" cshibiank">
        
          <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr >
                
                  <th align="center" width="22%" class="tabtitle" >
                            用户名</th>
                            <th align="center" width="8%" class="tabtitle">
                            发布时间</th>
                            
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                         <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >          
                        <td align="center">
                          <%#Eval("LoginName")%>
                        </td>            
                        <td  align="center">
                              <%#this.ReTime(Convert.ToString(Eval("CreateDate")))%>
                        </td>               
                         
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="pagebox">

            <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center"  >
                <tr>
                    <td style="width: 20%;" align="left">
                    共<span id="pinfo" style="color:Red" runat="server"></span>个数据
                    </td>
                    <td style="width:80%">
                    <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO"  Width="479px">
                                </cc1:AspNetPager>
                    </td>
                </tr>
            </table>
                
        </div>
    </div>
   
    </form>
</body>
</html>
