<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DuiyinList.aspx.cs" Inherits="tuijian_DuiyinList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" CssClass="one_table two_table" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
         <asp:BoundField DataField="InfoID" HeaderText="ID"/>
        <asp:BoundField DataField="Title" HeaderText="资源名称"/>
         
  
   
          <asp:TemplateField HeaderText="资源类型"> 
                                               <ItemTemplate> 
                        <asp:Label ID="lbname" runat="server" Text='<%#Listtype(Eval("InfoTypeID").ToString())%>'>
                                                  
                                                  </asp:Label>                 
               </ItemTemplate> 
                 <HeaderStyle HorizontalAlign="Center" /> 
                  </asp:TemplateField>
                  <asp:BoundField DataField="PublishT" HeaderText="发布时间"/>
        </Columns>
        <PagerSettings FirstPageText="首页" LastPageText="末页"
                NextPageText="下一页" PreviousPageText="上一页" />
        </asp:GridView>
        <br/>
        <asp:Button ID="Button" CssClass="btn"  runat="server" Text="返回" OnClick="Button_Click" />
    </div>
    </form>
</body>
</html>
