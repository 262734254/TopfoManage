<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelCompanyShow.aspx.cs" Inherits="Company_SelCompanyShow" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ҵ��Ƭ����</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />

    <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
           function SelectAll()
           {
            if(!document.getElementById("cbxSelect"))
                return;
            var obj = document.getElementById("cbxSelect");
            elem=obj.form.elements;
            for(i=0;i<elem.length;i++)
            {          
	            if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
	            {
	                if(elem[i].checked!=true)			
		                elem[i].click();
	            }
            }
           } 
            function ReSelect()
            {
                if(!document.getElementById("cbxSelect"))
                    return;
                var obj = document.getElementById("cbxSelect");
                elem=obj.form.elements;
                for(i=0;i<elem.length;i++)
                {          
                    if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
                    {
                            elem[i].click();
                    }
                }
            }
            
          function Modfiy(id,n)
          {
             if(n==0)
             {
                 var url;
                 url="CompanyShowAdd.aspx?CompanyId="+id+"";
                 window.location.href=url;
             }

             else if(n==1)
             {
                var url;
                url="SelCompanyShow.aspx?CompanyId="+id+"";
                window.location.href=url;
             }
          }
    </script>

    <script language="javascript" type="text/javascript" src="http://www.topfo.com/js/jquery.js"></script>

    <script language="javascript" type="text/javascript">
        
        function sendHit(cn)
        {
            var url="http://dp.topfo.com/Comm/Handler.ashx?userName='"+cn+"'&jsoncallback=?";
            $.getJSON(url,function(msg)
            {
                
            });
            alert('���ݻָ��ɹ�!');
        }
        
        function shows(cn,roleid)
        {
            if(roleid==1)
            {
                sendHit(cn);
            }
            else
            {
            window.location.href="SelCompanyShow.aspx?userName="+cn;
            }
        }
         
        function show()
        {
            var a=document.getElementById("namevalue").value;
            if(a!=null && a!="")
            {
                alert(a);
                sendHit(a);
                document.getElementById("namevalue").value="";
             }
        }
         
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="mainconbox">
            <input id="namevalue" runat="server" style="display: none" />
            <div class="title" align="center">
                <h2>
                    <p>
                        <span><b>��ҵչ������</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td style="width: 385px">
                        ��ʼʱ�䣺
                        <input runat="server" id="txtBeginTime" class="Wdate" onclick="WdatePicker({lang:'zh-cn'})"
                            style="width: 110px; height: 20px" />
                        &nbsp;����ʱ�䣺
                        <input id="txtEndTime" runat="server" class="Wdate" onclick="WdatePicker({lang:'zh-cn'})"
                            style="width: 110px; height: 20px" />
                    </td>
                    
                     <td align="center">
                        ��ɫ��
                        <asp:DropDownList runat="server" ID="ddlJs">
                            <asp:ListItem Value="-1">-��ѡ��-</asp:ListItem>
                            <asp:ListItem Value="1">�����ظ�ͨ</asp:ListItem>
                            <asp:ListItem Value="3">��Դ����</asp:ListItem>
                            <asp:ListItem Value="4">�����ظ�ͨ</asp:ListItem>
                            <asp:ListItem Value="5">Ͷ���ظ�ͨ</asp:ListItem>
                             
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        �ʺ����ƣ�
                        <input id="txtLoginName" type="text" runat="server" />
                    </td>
                    <td align="center">
                        ���ͣ�
                        <input id="txtCompanyName" type="text" runat="server" />
                    </td>
                    <td align="center">
                        ���״̬��
                        <asp:DropDownList runat="server" ID="ddlStatus">
                            <asp:ListItem Value="-1">-��ѡ��-</asp:ListItem>
                            <asp:ListItem Value="0">δ���</asp:ListItem>
                            <asp:ListItem Value="1">���ͨ��</asp:ListItem>
                            <asp:ListItem Value="2">���δͨ��</asp:ListItem>
                            <asp:ListItem Value="3">�ѹ���</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnOK" CssClass="btn" Text="ȷ��" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
            <div class=" cshibiank">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table">
                    <tr>
                        <th width="5%" align="center" class="tabtitle" style="height: 29px">
                            <a href="Javascript:SelectAll();">ȫѡ</a>|<a href="Javascript:ReSelect();">��ѡ</a>
                        </th>
                        <th align="center" width="9%" class="tabtitle">
                            �û���</th>
                        <th align="center" width="9%" class="tabtitle">
                            ����</th>
                        <th align="center" width="10%" class="tabtitle">
                            ����ʱ��</th>
                        <th align="center" width="10%" class="tabtitle">
                            ��ɫ</th>
                        <th align="center" width="8%" class="tabtitle">
                            ���״̬</th>
                        <th align="center" width="6%" class="tabtitle">
                            �����</th>
                        <th align="center" width="8%" class="tabtitle">
                            ��Ч����</th>
                              <th align="center" width="8%" class="tabtitle">
                            �ֺ����</th>
                        <th align="center" width="15%" class="tabtitle">
                            ����</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                                <td align="center">
                                    <label>
                                        <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("CompanyID") %>" />
                                    </label>
                                </td>
                                <td align="center">
                                    <%--<a href="http://<%#Eval("UserName")%>.topfo.com/" target="_blank">
                                        <%#Eval("UserName")%></a>--%>
                                         <asp:HyperLink ID="hlTitle" runat="server"></asp:HyperLink>
                                </td>
                                <td align="center">
                                    <%#Eval("TypeName")%>
                                </td>
                                <td align="center">
                                    <%#this.DateTime(Convert.ToString(Eval("StartTime")))%>
                                </td>
                                <td align="center">
                                    <%#GetRoleId(Convert.ToInt32(Eval("RoleId")))%>
                                </td>
                                <td align="center">
                                    <%#this.AuditName(Convert.ToInt32(Eval("Audit"))) %>
                                </td>
                                <td align="center">
                                    <%#Convert.ToString(Eval("Hit")) == "" ? "0" : Convert.ToString(Eval("Hit"))%>
                                </td>
                                <td align="center">
                                    <%#Eval("Valid") %>
                                    ����
                                </td>
                                     <td align="center">
                                    <%#Eval("MoneyCount") %>
                                 
                                </td>
                                <td align="center">
                                    <a href='JavaScript:Modfiy(<%#Eval("CompanyID") %>,0)'>���</a>&nbsp &nbsp
                                    <%--    <a href='JavaScript:Modfiy(<%#Eval("CompanyID") %>,1)'>ɾ��</a>  --%>
                                    <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("CompanyID")%>' CommandName="del"
                                        runat="server" OnCommand="LinkButton1_Command" ToolTip="���ɾ�̬ҳ��" OnClientClick="return confirm('ȷ�����ɴ��ļ�?');">���ɾ�̬</asp:LinkButton>
                                   <a href='JavaScript:shows("<%#Eval("UserName")%>",<%#Eval("RoleId")%>);'>���ݻָ�</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="pagebox">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td style="width: 20%;" align="left">
                            ��<span id="pinfo" style="color: Red" runat="server"></span>������
                        </td>
                        <td style="width: 80%">
                            <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false" NextPageText="��һҳ"
                                OnPageChanged="AspNetPager1_PageChanged" PrevPageText="��һҳ" ShowInputBox="Always"
                                SubmitButtonText="GO" Width="479px">
                            </cc1:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--<input id="btnProall" type="button" class="btn" value="��������" />--%>
        <div class="pagebox">
            &nbsp; &nbsp; &nbsp;
            <%--      &nbsp &nbsp
    <asp:Button runat="server" ID="btnRes" Text="���ݻָ�" CssClass="btn" OnClick="btnRes_Click"  />--%>
        </div>
    </form>
</body>
</html>
