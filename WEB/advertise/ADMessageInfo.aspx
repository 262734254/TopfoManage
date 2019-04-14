<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADMessageInfo.aspx.cs" Inherits="advertise_ADMessageInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>广告页面显示</title>
        <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
        <script language="javascript" type="text/javascript">
        function modifyNavigate(status,id,Bid,cc)
        {
            if(cc==1)
            {
            var url="";
            url="ADMessageUA.aspx?fid="+id+"&status="+status;
            window.location.href=url;
            }
            else if(cc==2)
            {
              var url="";
            url="AddDlaunchInfo.aspx?Bid="+Bid+"&fid="+id+"&status="+status;
            window.location.href=url;
            }
            else if(cc==3)
            {
              var url="";
            url="ADlaunchInfoList.aspx?Sid="+status+"&Bid="+Bid+"&fid="+id+"&status="+status;
            window.location.href=url;
            }
            else if(cc==4)
            {
               var url="";
               url="channelInfoList.aspx";
               window.location.href=url;
            }
        }
        function DelNav(id)
        {
           var url="";
           url="ADMessageInfo.aspx?PostID="+id;
           window.location.href=url;
        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

       <div class="title" align="center">
             <h2><p><span><b>广告频道管理</b></span></p></h2>
             <h2><p><span><b><a href="#" onclick="modifyNavigate('insert','','',1);">添加广告信息</a></b></span></p></h2>
             </div>
        <div class=" cshibiank">
        
            <table width="100%" border="0" align="center" class="one_table"  cellpadding="0" cellspacing="0">
                <tr>
                    <th width="8%" align="center" class="tabtitle" style="height: 32px">
                        序号                   </th>
                    <th width="24%" align="center" class="tabtitle" style="height: 32px">
                        广告名称                    </th>
                     <th width="10%" align="center" class="tabtitle" style="height: 32px">
                       频道名称                   </th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        尺寸大小                  </th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        价格</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                    赠送日期</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                    激活状态</th>
                    <th width="15%" align="center" class="tabtitle" style="height: 32px">
                        管理
                    </th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#(Eval("SerialID"))%>
                            </td>
                             <td align="center">
                               <%#(Eval("TypeName"))%>
                            </td>
                            <td align="center">
                                 <%#this.ADName(Convert.ToInt32(Eval("BID")))%>
                          </td>
                            <td align="center">
                                <%#(Eval("size"))%>
                          </td>
                            <td>
                            <%#Eval("price")%>
                          </td>
                             <td align="center">
                                <%#Convert.ToDateTime(Eval("giving")).ToString("yyyy-MM-dd")%>
                          </td>
                           <td>
                            <%#this.Check(Convert.ToInt32(Eval("checkid")))%>
                          </td>
                            <td align="center">
                            
                            <a href='JavaScript:modifyNavigate("status","<%#Eval("positionID") %>","",1);'>修改</a>

                           <a href='JavaScript:DelNav("<%#Eval("positionID") %>");' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                            <a href='JavaScript:modifyNavigate("DlaunchInfo","<%#Eval("positionID") %>","<%#Eval("BID") %>",2);'>添加广告主</a>
                            <a href='JavaScript:modifyNavigate("SInfo","<%#Eval("positionID") %>","<%#Eval("BID") %>",3);'>查看广告主</a>

                            </td>
                    </ItemTemplate>
                </asp:Repeater>
          </table>
        </div>
        <div class="pagebox">

            <div class="right" style="text-align:right">
            <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                PagerStyle="CustomAndNumeric" ControlToPaginate="RfList" PagingMode="NonCached"
                UseCustomDataSource="False" ShowCount="True" SortColumn="PublishT" SortType="DESC"
                TableViewName="MainInfoVIW" KeyColumn="InfoID"
                ShowPageCount="False"></cc1:Pager>
                &nbsp;</div>
                
           <div class="clear">
           <input id="btnAdd" class="btn" runat="server" onclick="modifyNavigate('insert','','',1);"
                    type="button" value="添加" />
                    <input id="btnfanhui" class="btn" type="button" value="返回" onclick="modifyNavigate('','','',4)" />
           </div>
        </div>
    </div>
    
    </form>
</body>
</html>
