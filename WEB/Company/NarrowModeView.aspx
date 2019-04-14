<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NarrowModeView.aspx.cs" Inherits="Company_NarrowModeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>窄告信息</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
<script language="javascript" type="text/javascript">
    function DelNav(id)
    {
       var url;
       url="NarrowModeView.aspx?AdId="+id+"";
       window.location.href=url;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

       <div class="title" align="center">
             <h2><p><span><b>窄告定制管理</b></span></p></h2>
             </div>
     <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
        <td align="center" >
            标题：
            <input id="txtTitle"   type="text"  runat="server" />
            </td>
            <td align="center">
            发布人：
            <input id="txtLoginName" type="text" runat="server" />
            </td>
           
            <td>
            <asp:Button runat="server" ID="btnOK" CssClass="btn" Text="确定" OnClick="btnOK_Click"  />
             </td>
    </tr>
    </table>
        <div class=" cshibiank">
        
          <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr >
                
                  <th align="center" width="22%" class="tabtitle" >
                            窄告标题</th>
                            <th align="center" width="8%" class="tabtitle">
                            发布时间</th>
                            <th align="center" width="10%" class="tabtitle" >
                             发布人</th>
                             <th align="center" width="10%" class="tabtitle" >
                             会员类型</th>
                             <th align="center" width="10%" class="tabtitle" >
                             所对应省份</th>
                             <th align="center" width="20%" class="tabtitle" >
                             管理</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                         <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >          
                        <td align="center">
                         <a href="NarrowSearch.aspx?AdID=<%#Eval("AdID") %>"><%#Eval("Title")%></a>
                        </td>            
                        <td  align="center">
                              <%#this.ReTime(Convert.ToString(Eval("CreateDate")))%>
                        </td>               
                         <td  align="center">
                               <%#Eval("UserName")%>
                          </td>
                         <td align="center">
                              <%#this.TypeName(Convert.ToString(Eval("InfoTypeName")))%>
                        </td>            
                        <td  align="center">
                              <%#this.ProvinceName(Convert.ToString(Eval("ProvinceID"))) == "" ? "全国" : this.ProvinceName(Convert.ToString(Eval("ProvinceID")))%>
                        </td>  
                        <td  align="center">
                           <a href="NarrowSelName.aspx?AdID=<%#Eval("AdID") %>" >查看</a>
                           <a href='JavaScript:DelNav(<%#Eval("AdID") %>);' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                           <a href="NarrowSearch.aspx?AdID=<%#Eval("AdID") %>">搜索条件</a>
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
