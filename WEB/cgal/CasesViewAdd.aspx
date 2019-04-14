<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="CasesViewAdd.aspx.cs" Inherits="cgal_CasesViewAdd" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc3" %>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <style type="text/css" >
    .hong{color:Red;}
    </style>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script language="javascript" type="text/javascript">
    function btnAdd()
    {
       if(document.getElementById("txtTitle").value=="")
       {
           alert("标题不能为空");
           document.getElementById("txtTitle").focus();
           return false;
       }
       if(document.getElementById("txtKeyWord").value=="")
       {
          alert("为了方便搜索，\r请填写关键字");
          document.getElementById("txtKeyWord").focus();
           return false;
       }  
       
       if(document.getElementById("FreeTextBox1").value=="")
       {
          alert("内容不能为空");
          document.getElementById("FreeTextBox1").focus();
          return false;
       }
        var rdlValiditeTermID = "<%=this.rdlValiditeTerm.ClientID %>";//项目有效期
	    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
        {
           alert("项目有效期不能为空！");
           
           return false;
        }
    }
    
    function GetCheckNum(checkobjectname)
    {
        var truei2 = 0;
        checkobject = document.getElementsByName(checkobjectname);
        var inum = checkobject.length;
        if (isNaN(inum))
        {
	        inum = 0;
        }
        for(i=0;i<inum;i++){
	        if (checkobject[i].checked == 1){
		        truei2 = truei2 + 1;
	        }
        }
        return truei2;
    }
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <table id="Table3" cellSpacing="1" cellPadding="3" class="one_table" width="97%" align="center"  border="0">				
		<tbody>
			<tr >
				<th colSpan="2">
					<div  align="center">成功案例 信息发布</div>
				</th>
			</tr>
			<tr >
				<td  align="right"><span class="hong" >*</span>标题</td>
				<td>
					<div align="left">&nbsp;
						<asp:TextBox id="txtTitle" onblur="Show(this.value);" runat="server" Columns="50"></asp:TextBox>(文章标题)</div>
				</td>
			</tr>
			<tr>
				<td align="right"><span class="hong">*</span>关键字</td>
				<td align="left">&nbsp;
					<asp:TextBox id="txtKeyWord" runat="server" Columns="50"></asp:TextBox>
                    (文章搜索关键字)</td>
			</tr>
			<tr>
				<td align="right">网页描述</td>
				<td align="left">&nbsp;
					<asp:TextBox id="txtDescript" runat="server" Columns="50" TextMode="MultiLine"></asp:TextBox>
                    (网页搜索描述)</td>
			</tr>
			<tr>
				<td  align="right">显示标题</td>
				<td  align="left">&nbsp;
					<asp:TextBox id="txtDisplayTitle" runat="server" Columns="50"></asp:TextBox>(网页标题)</td>
			</tr>
			<tr>
				<td align="right"><span class="hong"></span>来源于</td>
				<td align="left">&nbsp;
					<asp:TextBox id="txtShortTitle" runat="server" Columns="50"></asp:TextBox>
					</td>
			</tr>
			<tr>
				<td  align="right">作者</td>
				<td align="left">&nbsp;
					<asp:TextBox id="txtShortContent" runat="server" Columns="50"></asp:TextBox>(头条简介)</td>
			</tr>
			<tr>
				<td align="right"><span class="hong"></span>分类</td>
				<td>
					<div align="left" >&nbsp;
						<asp:DropDownList id="ddlCasesTypeID" runat="server" DataTextField="CasesTypeName" DataValueField="CasesTypeID"></asp:DropDownList></div>
				</td>
			</tr>
			<tr>
				<td align="right"><span class="hong">*</span>内容</td>
				<td>
					<div align="left"> &nbsp;
						<FTB:FreeTextBox ID="FreeTextBox1"  runat="server">
                    </FTB:FreeTextBox><br>
						&nbsp;
						</div>
				</td>
			</tr>
			
	  <tbody>
				<tr>
					<td align="right"><span class="hong">*</span>有效期</td>
					<td align="left">
					自发布之日起<asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
 ></asp:RadioButtonList>
         </td>
				</tr>
				
				<asp:Panel ID="divStatu1" runat="server" Visible="true" >
				<tr>
					<td align="right">操作</td>
					<td align="left">&nbsp;
						<asp:CheckBox id="cbAuditing" runat="server" Text="直接审核通过"></asp:CheckBox></td>
			
				</tr>
				</asp:Panel>
				<asp:Panel ID="divStatu2" runat="server" Visible="false">
					<tr>
						<td  align="right"><span class="hong">*</span>审核状态</td>
						<td align="left">
							<div align="left"><span class="style4">&nbsp;
									<asp:RadioButtonList id="rblAuditing" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
										<asp:ListItem Value="0">未审核</asp:ListItem>
										<asp:ListItem Value="1">审核通过</asp:ListItem>
										<asp:ListItem Value="2">审核未通过</asp:ListItem>
									</asp:RadioButtonList> </span>
							</div>
						</td>
					</tr>

					<tr>
						<td align="right"><span >*</span>点击数</td>
						<td>
							<div align="left">&nbsp;
								<asp:TextBox id="txtHit" runat="server"></asp:TextBox>
								</div>
						</td>
						
					</tr>
					</asp:Panel>
	        <tr>
		        <td colSpan="2">
			        <div align="center"><asp:button id="btnPublish" runat="server"  OnClick="btnPublish_Click" OnClientClick="return btnAdd();" CssClass="btn"></asp:button>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <input type="button" id="btnFH" value="返回" class="btn" onclick="window.location.href='CasesView.aspx'" /></div>
		        </td>
	        </tr>
		</table>
		
        
    </form>
</body>
</html>
