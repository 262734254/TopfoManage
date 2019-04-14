<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyMadeView.aspx.cs" Inherits="Company_CompanyMadeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript">
    function DelNav(id)
    {
       var url;
       url="CompanyMadeView.aspx?MaId="+id+"";
       window.location.href=url;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

       <div class="title" align="center">
             <h2><p><span><b>广告定制管理</b></span></p></h2>
             </div>
     <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
        <td align="center" >
            帐号名称：
            <input id="txtLoginName"   type="text"  runat="server" />
            </td>
           
            <td>
            <asp:Button runat="server" ID="btnOK" CssClass="btn" Text="确定" OnClick="btnOK_Click"  />
             </td>
    </tr>
    </table>
        <div class=" cshibiank">
        
          <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr >
                
                  <th align="center" width="18%" class="tabtitle" >
                            定制名称</th>
                            <th align="center" width="8%" class="tabtitle">
                            总价格</th>
                            <th align="center" width="10%" class="tabtitle" >
                             发布时间</th>
                             <th align="center" width="10%" class="tabtitle" >
                             开始时间</th>
                             <th align="center" width="10%" class="tabtitle" >
                             结束时间</th>
                             <th align="center" width="10%" class="tabtitle" >
                             审核状态</th>
                             <th align="center" width="10%" class="tabtitle" >
                             发布人</th>
                             <th align="center" width="10%" class="tabtitle" >
                             审核人</th>
                             <th align="center" width="10%" class="tabtitle" >
                             管理</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                         <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >          
                        <td align="center">
                          <%#this.CompanyName(Convert.ToString(Eval("CompanyID")))%>
                        </td>            
                        <td  align="center">
                              <%#Eval("SumPrice")%>元
                        </td>               
                         <td  align="center">
                               <%#this.ReTime(Convert.ToString(Eval("CreateDate")))%>
                          </td>
                         <td align="center">
                              <%#this.ReTime(Convert.ToString(Eval("BeginTime")))%>
                        </td>            
                        <td  align="center">
                              <%#this.ReTime(Convert.ToString(Eval("EndTime")))%>
                        </td>  
                        
                        <td  align="center">
                              <%#this.Aduit(Convert.ToString(Eval("Audit")))%>
                        </td>  
                        <td  align="center">
                              <%#Eval("UserName")%>
                        </td>             
                         <td  align="center">
                             <%#Convert.ToString(Eval("AuditName")) == "" ? "暂无" : Convert.ToString(Eval("AuditName"))%>
                         </td>           
                        <td  align="center">
                           <a href="#" onclick="window.location.href='CompanyMadeMofiy.aspx?Ma=<%#Eval("MadeID") %>'"  >审核</a>
                           <a href='JavaScript:DelNav(<%#Eval("MadeID") %>);' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
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
    <%--<input id="btnProall" type="button" class="btn" value="批量生成" />--%>
    <div class="pagebox">
 
    </div>
    </form>
</body>
</html>
