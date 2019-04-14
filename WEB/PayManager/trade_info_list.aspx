<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trade_info_list.aspx.cs" Inherits="PayManager_trade_info_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>资源交易订单管理</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
                  <script type="text/javascript"  src="../js/Common.js"></script>
         <script type="text/javascript" src="../js/CheckAll.js"></script>
              <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
     <script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
      <script language="javascript" type="text/javascript">
    function deletechk()
    {
        if(chkValue()!="")
        {
            if(confirm("确定删除此订单吗?请慎重操作!"))
            {
                Pay_strike_wait.DeleteOrder(chkValue(),backres);
            }
        }
        else
        {
            alert("请选择要删除的项");
        }
    }
    function backres(res)
    {
        if(res)
            window.location.reload();       
    }


function SelectAll()
{
    if(!document.getElementById("checkbox"))
        return;
    var obj = document.getElementById("checkbox");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="checkbox")
		{
		    if(elem[i].checked!=true)			
			    elem[i].click();
		}
    }
}

function ReSelect()
{
    if(!document.getElementById("checkbox"))
        return;
    var obj = document.getElementById("checkbox");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="checkbox")
		{
			    elem[i].click();
		}
    }
}




    </script>
      
      
</head>
<body>
     <form id="Form1" method="post" runat="server">

                <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    
            <tr>
               
                <td valign="top" width="100%">
                    <div >
                        
                        
                               <div class="title">
                            <h2>
                                <p>
                                    <span><a href="trade_info_wait.aspx"><b>订单管理</b></a></span></p>
                            </h2>
                            <h2>
                                <p>
                                    <span><b>已完成交易</b></span></p>
                            </h2>
               
            </div>
                        <div class="alltablebgH">
                              <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                                <tr>
                                    <td class="tdcenter f14b bg1" colspan="4">
                                        已完成交易查询</td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b">
                                        资源类型：</td>
                                    <td style="height: 30px">
                                        <select id="ddltype" name="select2" runat="server">
                                            <option value="" selected="selected">全部</option>
                                            <option value="Merchant">招商资源</option>
                                            <option value="Capital">投资资源</option>
                                            <option value="Project">项目资源</option>
                                        </select>
                                        <strong>会员类型：</strong><select id="ddluserType" name="select3" runat="server">
                                            <option value="" selected="selected">所有会员</option>
                                            <option value="1004">政府会员</option>
                                            <option value="1003">企业会员</option>
                                            <option value="1001">个人会员</option>
                                        </select><strong>支付方式：<select id="sType" runat="server" name="sType">
                                         <option value="Quick">银联</option>
                                            <option value="account">余额</option>
                                            <option value="pnr">天天付</option>
                                            <option value="ebilling">ebilling电话</option>
                                            <option value="alipay">支付宝</option>
                                            <option value="yeepay">yeepay电话</option>
                                            <option value="szx">神州行</option>
                                            <option value="PostOffice">邮局汇款</option>
                                            <option value="bank">银行汇款</option>
                                            <option selected="selected" value="">全部</option>
                                        </select></strong></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b">
                                        支付时间：</td>
                                     <td colspan="3">
                      <input runat="server" id="txtBeginTime" onClick="WdatePicker({lang:'zh-cn'})"/>
                        <img onclick="WdatePicker({el:$dp.$('txtBeginTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                        -
                        <input id="txtEndTime" runat="server" onClick="WdatePicker({lang:'zh-cn'})" />
                        <img onclick="WdatePicker({el:$dp.$('txtEndTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" /></td>
                                </tr>
                                <tr style="color: #0000ff">
                                    <td class="tdright f14b">
                                        关键字搜索：</td>
                                    <td colspan="3">
                                        <input class="tWidth200px borderCor5" name="textfield22" type="text" runat="server"
                                            id="txtTitle" /></td>
                                </tr>
                                <tr style="color: #0000ff">
                                    <td class="tdright f14b">
                                        资源编号：</td>
                                    <td colspan="3">
                                        <input class="tWidth200px borderCor5" name="textfield22" type="text" runat="server"
                                            id="txtInfoID" /></td>
                                </tr>
                                <tr style="color: #0000ff">
                                    <td class="tdright f14b">
                                        购买者：</td>
                                    <td colspan="3">
                                        <input class="tWidth200px borderCor5" name="textfield22" type="text" runat="server"
                                            id="txtLoginName" /></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="height: 30px">
                                        <asp:Button ID="btnSearch" class="buttomal" runat="server" Text="查  询" OnClick="btnSearch_Click"
                                            Width="112px" /></td>
                                </tr>
                            </table>
                        </div>
                        <div class="hrline">
                        </div>
                    
                        <div class="pageturnBG">
                            <div class="llcont">
                            </div>
                            <div class="rrcont">
                                每页显示：<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>条
                                <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                                条 <a href="#">
                                    <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                                条
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="alltablebg">
                             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                                  <tr  style="background:#bcd9e7; height:27px;">
                                    <td class="bg1" width="5%" align="center">
                                        <a href="javascript:chkAll()">选择</a></td>
                                    <td class="bg1" width="7%" align="center">
                                        类别</td>
                                    <td class="bg1" width="36%" align="center">
                                        资源标题</td>
                                    <td class="bg1" width="8%" align="center">
                                        价格(元)
                                    </td>
                                    <td class="bg1" width="12%" align="center">
                                        购买用户
                                    </td>
                                    <td class="bg1" width="16%" align="center">
                                        完成时间</td>
                                    <td class="bg1" width="10%" align="center">
                                        查看</td>
                                </tr>
                                <asp:Repeater runat="server" ID="myList">
                                    <ItemTemplate>
                                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                                            <td align="center">
                                                <input name="checkbox" type="checkbox" value="<%#Eval("ID") %>" /></td>
                                            <td align="center">
                                                <%#Eval("InfoTypeName") %>
                                            </td>
                                            <td align="left">
                                                <a href="http://www.topfo.com/<%#Eval("HtmlFile")%>" target="_blank">
                                                    <%#Eval("sourcetype")%>
                                                </a>
                                            </td>
                                            <td align="center">
                                                <%#GetPoint(Eval("PointCount","{0:N}"),Eval("DisPointCount","{0:N}"))%>
                                                元</td>
                                            <td align="center">
                                                <%#GetIco(Eval("MemberGradeID")) %>
                                                <%#Eval("LoginName") %>
                                            </td>
                                            <td align="center">
                                                <%#Eval("ConsumeTime")%>
                                            </td>
                                            <td align="center">
                                                <a class="bluelink" href="trade_info_details.aspx?ID=<%#Eval("ID") %>&status=1"><span
                                                    style="color: #0000ff">明细</span></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="8">
                                        <table>
                                            <tr>
                                                <td>
                                                    <a class="bluelink" href="javascript:chkAll2()"><span style="color: #0000ff">全选</span></a>
                                                    / <a class="bluelink" href="javascript:chkAll()"><span style="color: #0000ff">反选</span></a>
                                                    <input name="Submit" type="button" onclick="alert('已完成订单不允许删除操作')" value="删 除" class="buttomal" />
                                                    <input name="Submit2" type="button" value="导 出" onclick="alert('功能开发中……')" class="buttomal" />
                                                </td>
                                                <td align="right">
                                                    <span style="color: #ff0033">资源交易总金额：</span><asp:Label ID="lblPoint" runat="server" ForeColor="Red"></asp:Label>
                                                    &nbsp;共<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                                                        ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                                                            runat="server" Text="0"></asp:Literal>页
                                                    <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>
                                                    <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>
                                                    <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                                                    <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton><span>转到
                                                        第<input id="txtPage" runat="server" name="textarea" type="text" style="width: 48px" />
                                                        页</span>
                                                    <input id="btnGo" runat="server" onserverclick="btnGo_ServerClick" type="button"
                                                        value="GO" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div class="tdright mar4">
                                &nbsp;</div>
                        </div>
                    </div>
                </td>
            </tr>
            
        </table>
    </form>
</body>
</html>
