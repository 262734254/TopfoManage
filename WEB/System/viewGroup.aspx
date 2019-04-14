<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewGroup.aspx.cs" Inherits="System_viewGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>组排列</title>
    <STYLE type="text/css">
    .btn{width:65px;height:23px;background:url(../image/40.gif) no-repeat left top;border:none;cursor:pointer;}
    </STYLE>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/style1.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<div class="title"><h2><p><span><b>管理组</b></span></p></h2></div>
    
        <asp:GridView ID="GroupGridView"  runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="one_table two_table" OnPageIndexChanging="GroupGridView_PageIndexChanging" DataKeyNames="SGID" OnRowDataBound="GroupGridView_RowDataBound1" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="SGID" HeaderText="编号" />
                <asp:BoundField DataField="SName" HeaderText="组名称" />
                <asp:BoundField DataField="SDescribe" HeaderText="组描述" />
                <asp:BoundField DataField="SysDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="添加时间" />
                <asp:TemplateField HeaderText="状态"> 
                                               <ItemTemplate> 
                        <asp:Label ID="lbname" runat="server" Text='<%#Eval("SysCheck").ToString()=="1"?"已通过":"未通过"%>'>
                                                  
                                                  </asp:Label>                 
               </ItemTemplate> 
                 <HeaderStyle HorizontalAlign="Center" /> 
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="所属角色"> 
                                               <ItemTemplate> 
                        <asp:Label ID="lbname1" runat="server" Text='<%# ReturnJiaose(Eval("SRoleID").ToString())%>'>
                                                  
                                                  </asp:Label>                 
               </ItemTemplate> 
                 <HeaderStyle HorizontalAlign="Center" /> 
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="审核">
                 
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                        <%--<asp:LinkButton ID="LinkCheck" runat="server" CommandArgument='<%# Eval("SGID") %>' OnClientClick="return confirm('确认审核！')" OnClick="LinkCheck_Click">审核</asp:LinkButton>--%>
                        <a href="CheckGroup.aspx?SGID=<%# Eval("SGID") %>" onclick='return confirm("确认审核!")'>审核</a>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="删除">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                       <%--<asp:LinkButton ID="LinkDelete" runat="server" CommandArgument='<%# Eval("SGID") %>' OnClientClick="return confirm('是否删除！')" OnClick="LinkDelete_Click">删除</asp:LinkButton>--%>
                     <a href="DelGroup.aspx?SGID=<%#Eval("SGID")%>" onclick='return confirm("删除后无法恢复!")'>删除</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改/查看">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                         <%--<asp:LinkButton ID="LinkUpdate" runat="server" CommandArgument='<%# Eval("SGID") %>' OnClick="LinkUpdate_Click">修改/查看</asp:LinkButton>--%>
                    <a href="ModifyGroup.aspx?SGID=<%#Eval("SGID") %>">修改/查看</a>
                    
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <PagerSettings FirstPageText="首页" LastPageText="末页"
                NextPageText="下一页" PreviousPageText="上一页" />
        
        </asp:GridView>
   
    <div style="margin-top:10px;">
    &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server"  CssClass="btn" Text="继续添加组" OnClick="Button1_Click" />
        <asp:Button ID="jiaose_Btn" runat="server"  CssClass="btn" Text="查看角色" OnClick="jiaose_Btn_Click" />
    </div>
 
    </form>
</body>
</html>
