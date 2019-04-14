<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResDongList.aspx.cs" Inherits="tuijian_ResDongList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    //更改状态
	function UpdateStatus(sid,audit)
	{
	    var iaudit=1;
	    var str="有效";
	    
	    if(audit=="1")
	   {
	        iaudit=0;
	        str="无效";
	    }
	    
	    if(confirm('是否（'+ sid +'）的状态改为'+ str +'？'))
	    {
	        location.href="kaiqi.aspx?UserID="+sid+"&audit="+audit;
	    }
	}
    </script>
</head>
<body>
     <form id="form1" runat="server">
    <div>
        <asp:GridView ID="ResDongList" CssClass="one_table two_table" runat="server" AllowPaging="True" OnPageIndexChanging="ResDongList_PageIndexChanging" AutoGenerateColumns="False" OnRowDataBound="ResDongList_RowDataBound">
           <Columns>
        
         <asp:BoundField DataField="ResourceName" HeaderText="列表名称" />
        
         
         <asp:TemplateField HeaderText="状态"> 
                                               <ItemTemplate> 
                        <asp:Label ID="lbname" runat="server" Text='<%#Eval("StateID").ToString()=="1"?"已开启":"未开启"%>'>
                                                  
                                                  </asp:Label>                 
               </ItemTemplate> 
                 <HeaderStyle HorizontalAlign="Center" /> 
                  </asp:TemplateField>
                  
         <asp:BoundField DataField="TuijianID" HeaderText="列表ID" />
         <asp:BoundField DataField="FromSource" HeaderText="备注" />
           <asp:TemplateField HeaderText="审核">
                 
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                       <%-- <asp:LinkButton ID="LinkCheck" runat="server" CommandArgument='<%#Eval("ResourceID")%>'  OnClientClick="return confirm('确认开启！')" OnClick="LinkCheck_Click">开启</asp:LinkButton>
                       <a href="CheckGroup.aspx?SGID=<%# Eval("SGID") %>" onclick='return confirm("确认审核!")'>审核</a>--%>
                      
                  <a href="javascript:UpdateStatus('<%#Eval("ResourceID").ToString().Trim() %>','<%#Eval("StateID").ToString().Trim() %>');"> 
                 <%#Eval("StateID").ToString() == "1" ? "<font color='green'>已开启</font>" : "<font color='red'>未开启</font>"%>
                </a>
                      
                      
                    </ItemTemplate>
                  </asp:TemplateField>
                     <asp:TemplateField HeaderText="删除">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                      <asp:LinkButton ID="LinkDelete" runat="server" CommandArgument='<%# Eval("ResourceID") %>' OnClientClick="return confirm('是否删除！')" OnClick="LinkDelete_Click">删除</asp:LinkButton>
                      <%--<a href="DelGroup.aspx?SGID=<%#Eval("SGID")%>" onclick='return confirm("删除后无法恢复!")'>删除</a>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="查看推荐情况">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                         <%--<asp:LinkButton ID="LinkUpdate" runat="server" CommandArgument='<%# Eval("SGID") %>' OnClick="LinkUpdate_Click">修改/查看</asp:LinkButton>--%>
                    <a href="DuiyinList.aspx?SGID=<%#Eval("ResourceID") %>">查看</a>
                    
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="修改">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                         <%--<asp:LinkButton ID="LinkUpdate" runat="server" CommandArgument='<%# Eval("SGID") %>' OnClick="LinkUpdate_Click">修改/查看</asp:LinkButton>--%>
                    <a href="ModifyResDong.aspx?SGID=<%#Eval("ResourceID") %>">修改</a>
                    
                    </ItemTemplate>
                </asp:TemplateField>
                
         </Columns>
            <PagerSettings FirstPageText="首页" LastPageText="末页"
                NextPageText="下一页" PreviousPageText="上一页" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
