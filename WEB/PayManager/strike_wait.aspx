<%@ Page Language="C#" AutoEventWireup="true" CodeFile="strike_wait.aspx.cs" Inherits="PayManager_strike_wait" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>充值管理</title>
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
            
                <td width="3" >
                </td>
                <td valign="top" width="100%">
                    <div>
                      <div class="title">
                            <h2>
                                <p>
                                    <span><b>充值订单</b></span></p>
                            </h2>
                            <h2>
                                <p>
                                    <span><a href="strike_end.aspx"><b>已完成的充值</b></a></span></p>
                            </h2>
               
            </div>
                        <div class="alltablebgH">
                            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                                <tr>
                                    <td >
                                        充值帐户：</td>
                                    <td >
                                        <input id="txtStrikeLoginName" type="text" name="textfield2" class="tWidth100px borderCor5" runat="server" /></td>
                               
                                    <td id="txtLoginName">
                                        充值人：</td>
                                    <td>
                                        <input type="text" name="textfield2" class="tWidth100px borderCor5" id="txtLoginName" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td c>
                                        充值方式：</td>
                                    <td >
                                        <select id="sType" runat="server" name="sType">
                                            <option value="pnr">天天付</option>
                                            <option value="ebilling">ebilling电话</option>
                                            <option value="alipay">支付宝</option>
                                            <option value="yeepay">yeepay电话</option>
                                            <option value="szx">神州行</option>
                                            <option value="PostOffice">邮局汇款</option>
                                            <option value="bank">银行汇款</option>
                                            <option selected="selected" value="">---请选择---</option>
                                        </select>
                                    </td>
                               
                                   
                                    <td>
                                        生成时间：<td style="width: 477px">
                        
                        <input runat="server" id="txtBeginTime" onClick="WdatePicker({lang:'zh-cn'})"/>
                        <img onclick="WdatePicker({el:$dp.$('txtBeginTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                        -
                        <input id="txtEndTime" runat="server" onClick="WdatePicker({lang:'zh-cn'})" />
                        <img onclick="WdatePicker({el:$dp.$('txtEndTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                        </td>
                                        
                                        
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="Button1" runat="server" Text="查   询" CssClass="buttomal" Width="105px" OnClick="Button1_Click1" />&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                        <div class="hrline">
                        </div>
                          
                    <%--    <div class="btnstyle">
                            <ul>
                                <li class="on"> </li>
                                <li><a href="strike_end.aspx">已完成的充值</a></li>
                            </ul>
                            <div class="clear">
                            </div>
                        </div>--%>
                        <div class="alltablebg">
                           <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                                 <tr  style="background:#bcd9e7; height:27px;">
                                    <td width="6%" class="bg1">
                                        <a href="javascript:;" onclick="SelectAll()">选择</a></td>
                                    <td width="13%" class="bg1">
                                        充值账户</td>
                                        <td width="13%" class="bg1">
                                        充值人</td>
                                    <td width="10%" class="bg1">
                                        充值金额(元)</td>
                                    <td width="19%" class="bg1">
                                        生成时间</td>
                                    <td width="10%" class="bg1">
                                        状态</td>
                                    <td width="13%" class="bg1">
                                        充值方式</td>
                                    <td width="15%" class="bg1">
                                        操作</td>
                                </tr>
                                <asp:Repeater runat="server" ID="myList">
                                    <ItemTemplate>
                                        <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                                            <td style="height: 28px">
                                                <input type="checkbox" name="checkbox" id="checkbox" value="<%#Eval("OrderNo") %>" /></td>
                                            <td style="height: 28px">
                                                <%#Eval("StrikeLoginName") %>
                                            </td>
                                             <td style="height: 28px">
                                                <%#Eval("LoginName") %>
                                            </td>
                                            <td style="height: 28px">
                                                <%#Eval("TransMoney","{0:N}") %>
                                            </td>
                                            <td style="height: 28px">
                                                <%#Eval("OrderTime") %>
                                            </td>
                                            <td style="height: 28px">
                                                未支付
                                            </td>
                                            <td style="height: 28px">
                                                <%#GetPayType(Eval("PayType")) %>
                                            </td>
                                            <td style="height: 28px">
                                                <a href="strike_details.aspx?order_no=<%#Eval("OrderNo") %>" class="bluelink">查看明细</a>
                                          <%--      <a href="strike_confirmed.aspx?ID=<%#Eval("OrderNo") %>" class="bluelink">确认充值</a>--%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                              
                                <tr>
                                    <td colspan="8">
                                    <table>
                                            <tr>
                                                <td>
                                                    &nbsp;<input type="button" name="Submit2" onclick="SelectAll()" value="全选" class="buttomal" />
                                        <input type="button" name="Submit23" onclick="ReSelect()" value="反选" class="buttomal" />
                                        <input type="button" name="Submit" onclick="deletechk()" value="删 除" class="buttomal" /><a class="bluelink"
                                                        href="javascript:chkAll2()"><span style="color: #0000ff"></span></a></td>
                                                <td align="right">
                                                    <span style="color: #ff0000">充值订单总金额：</span><asp:Label ID="lblPoint" runat="server"
                                                        Text="0.00" ForeColor="Red"></asp:Label><span style="color: #ff0000">元</span>
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
                                        &nbsp;
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
