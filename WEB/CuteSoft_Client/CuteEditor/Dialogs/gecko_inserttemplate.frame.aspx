<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.TemplateBrowserPage" %>
<HTML>
	<HEAD>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href='gecko_style.css'>
		<script src="Gecko_dialog.js"></script>
		<script src="../_shared.js"></script>
		<script src="filebrowserpage.js"></script>
		<script src="sorttable.js"></script>
		<script language="JavaScript">
		var OxObfda=["disabled","target","[[Disabled]]","[[SpecifyNewFolderName]]","","value","hiddenActionData","[[SpecifyNewFileName]]","[[_CuteEditorResource_]]Dialogs/OuterEditorFull.aspx?\x3C%= Request.ServerVariables[","] %\x3E\x26f=","width=740,height=420,resizable=0,toolbars=0,menubar=0,status=0","returnValue","href","location","[[CopyMoveto]]","/","[[AreyouSureDelete]]","parentNode","text","isdir",".","hiddenAction","rename","path","True","False",":","cancelBubble","width=760,height=420,resizable=0,toolbars=0,menubar=0,status=0","backgroundColor","style","#eeeeee","tagName","INPUT","changedir","htmlcode","hiddenFile","url","TargetUrl",".aspx","src","framepreview"]; window.resizeTo(0x28a,0x1a4) ; function CreateDir_click(){if(event){if(event[OxObfda[0x1]][OxObfda[0x0]]){ alert(OxObfda[0x2]) ;return false;} ;} ;var Ox2fb=prompt(OxObfda[0x3],OxObfda[0x4]);if(Ox2fb){ document.getElementById(OxObfda[0x6])[OxObfda[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function NewTemplate_Click(){var Ox2fb=prompt(OxObfda[0x7],OxObfda[0x4]);if(Ox2fb){var Ox567=OxObfda[0x8]; QUERY_STRING ; OxObfda[0x9]+Ox2fb+OxObfda[0x4] ; showModalDialog(Ox567,null,OxObfda[0xa],function (Ox2dc,Ox18d){if(Ox18d[OxObfda[0xb]]){ window[OxObfda[0xd]][OxObfda[0xc]]=window[OxObfda[0xd]][OxObfda[0xc]] ;} ;} ) ;return true;} else {return false;} ;}  ; function Move_click(){if(event){if(event[OxObfda[0x1]][OxObfda[0x0]]){ alert(OxObfda[0x2]) ;return false;} ;} ;var Ox2fb=prompt(OxObfda[0xe],OxObfda[0xf]);if(Ox2fb){ document.getElementById(OxObfda[0x6])[OxObfda[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Copy_click(){if(event){if(event[OxObfda[0x1]][OxObfda[0x0]]){ alert(OxObfda[0x2]) ;return false;} ;} ;var Ox2fb=prompt(OxObfda[0xe],OxObfda[0xf]);if(Ox2fb){ document.getElementById(OxObfda[0x6])[OxObfda[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Delete_click(){if(event[OxObfda[0x1]][OxObfda[0x0]]){ alert(OxObfda[0x2]) ;return false;} ;return confirm(OxObfda[0x10]);}  ; function RenImg_click(Oxb9){if(Oxb9[OxObfda[0x0]]){ alert(OxObfda[0x2]) ;return false;} ; row=Oxb9[OxObfda[0x11]][OxObfda[0x11]] ;var Ox550=row[OxObfda[0x12]];var name;if(row[OxObfda[0x13]]){ name=prompt(OxObfda[0x3],Ox550) ;} else {var i=Ox550.lastIndexOf(OxObfda[0x14]);var Ox551=Ox550.substr(i);var Ox20=Ox550.substr(0x0,Ox550.lastIndexOf(OxObfda[0x14])); name=prompt(OxObfda[0x7],Ox20) ;if(name){ name=name+Ox551 ;} ;} ;if(name&&name!=row[OxObfda[0x12]]){ document.getElementById(OxObfda[0x15])[OxObfda[0x5]]=OxObfda[0x16] ; document.getElementById(OxObfda[0x6])[OxObfda[0x5]]=(row[OxObfda[0x13]]?OxObfda[0x18]:OxObfda[0x19])+OxObfda[0x1a]+row[OxObfda[0x17]]+OxObfda[0x1a]+name ; postback() ;} ;if(event){ event[OxObfda[0x1b]]=true ;} ;}  ; function EditImg_click(Oxb9){ row=Oxb9[OxObfda[0x11]][OxObfda[0x11]] ;if(row.getAttribute(OxObfda[0x17])){var Ox567=OxObfda[0x8]; QUERY_STRING ; OxObfda[0x9]+row.getAttribute(OxObfda[0x17])+OxObfda[0x4] ; showModalDialog(Ox567,null,OxObfda[0x1c],function (Ox2dc,Ox18d){if(Ox18d[OxObfda[0xb]]){ window[OxObfda[0xd]][OxObfda[0xc]]=window[OxObfda[0xd]][OxObfda[0xc]] ;} ;} ) ;return true;} else {return false;} ;}  ; function row_over(Oxc3){ Oxc3[OxObfda[0x1e]][OxObfda[0x1d]]=OxObfda[0x1f] ;}  ; function row_out(Oxc3){ Oxc3[OxObfda[0x1e]][OxObfda[0x1d]]=OxObfda[0x4] ;}  ; function row_click(Oxc3){if(Oxc3[OxObfda[0x13]]){if(event){if(event[OxObfda[0x1]]&&event[OxObfda[0x1]][OxObfda[0x20]]==OxObfda[0x21]){return ;} ;} ; document.getElementById(OxObfda[0x15])[OxObfda[0x5]]=OxObfda[0x22] ; document.getElementById(OxObfda[0x6])[OxObfda[0x5]]=Oxc3.getAttribute(OxObfda[0x17]) ; postback() ;} else {var Ox4f4=Oxc3.getAttribute(OxObfda[0x17]);var htmlcode=Oxc3.getAttribute(OxObfda[0x23]); document.getElementById(OxObfda[0x24])[OxObfda[0x5]]=Ox4f4 ;var Oxba=Oxc3.getAttribute(OxObfda[0x25]); document.getElementById(OxObfda[0x26])[OxObfda[0x5]]=Oxba ; Oxba=Oxba.toLowerCase() ;if(Oxba.indexOf(OxObfda[0x27])!=-0x1){try{ document.getElementById(OxObfda[0x29])[OxObfda[0x28]]=Oxba ;} catch(e){} ;} ; document.getElementById(OxObfda[0x26])[OxObfda[0x5]]=Oxba ; do_preview(htmlcode) ; pageurl=Oxba ;} ;}  ; function postback(){ <%=Page.ClientScript.GetPostBackEventReference(hiddenAction,"")%> ;}  ;
		</script>
		<style>
		.row { HEIGHT: 22px }
		.cb { VERTICAL-ALIGN: middle }
		.itemimg { VERTICAL-ALIGN: middle }
		.editimg { VERTICAL-ALIGN: middle }
		.cell1 { VERTICAL-ALIGN: middle }
		.cell2 { VERTICAL-ALIGN: middle }
		.cell3 { PADDING-RIGHT: 4px; VERTICAL-ALIGN: middle; TEXT-ALIGN: right }
		.cb { }		
		#framepreview {
			width: 100%;
			height: 100%;
			overflow:hidden;
			text-align: left;
			vertical-align: top;
			padding: 0px;
			margin: 0px;
			border:0;
			background-color: white;
		}
		</style>
	</HEAD>
	<body>
		<form runat="server" enctype="multipart/form-data" id="Form1">
			<!-- start hidden -->
			<script>
        var OxO5c2a=["onload","value","hiddenAlert","","hiddenAction","hiddenActionData"]; window[OxO5c2a[0x0]]=reset_hiddens ; function reset_hiddens(){if(document.getElementById(OxO5c2a[0x2])[OxO5c2a[0x1]]){ alert(document.getElementById(OxO5c2a[0x2]).value) ;} ; document.getElementById(OxO5c2a[0x2])[OxO5c2a[0x1]]=OxO5c2a[0x3] ; document.getElementById(OxO5c2a[0x4])[OxO5c2a[0x1]]=OxO5c2a[0x3] ; document.getElementById(OxO5c2a[0x5])[OxO5c2a[0x1]]=OxO5c2a[0x3] ;}  ;
			</script>
			<input type="hidden" runat="server" id="hiddenDirectory" NAME="hiddenDirectory">
			<input type="hidden" runat="server" id="hiddenFile" NAME="hiddenFile"> <input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" NAME="hiddenAlert">
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" onserverchange="hiddenAction_ServerChange"
				NAME="hiddenAction"> <input type="hidden" runat="server" enableviewstate="false" id="hiddenActionData" NAME="hiddenActionData">
			<!-- end hidden -->
			<table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
				<tr>
					<td width="20">
						<asp:Image ID="Image1" Runat="server" ImageUrl="../images/openfolder.gif"></asp:Image>
					</td>
					<td width="240" class="normal">
						<asp:Label Runat="server" ID="FolderDescription"></asp:Label>
					</td>
					<td>
						<asp:ImageButton ID="CreateDir" Runat="server" AlternateText="[[Createdirectory]]" ImageUrl="../images/newfolder.gif"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true" OnClick="CreateDir_Click" />
						<asp:ImageButton ID="Copy" Runat="server" AlternateText="[[Copyfiles]]" ImageUrl="../images/Copy.gif"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true" OnClick="Copy_Click" />
						<asp:ImageButton ID="Move" Runat="server" AlternateText="[[Movefiles]]" ImageUrl="../images/move.gif"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true" OnClick="Move_Click" />
						<asp:ImageButton ID="NewTemplate" Runat="server" AlternateText="[[NewTemplate]]" ImageUrl="../images/newtemplate.gif"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true" OnClick="NewTemplate_Click" />
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
				<tr>
					<td valign="top" nowrap width="250">
						<div style="BORDER-RIGHT: 1.5pt inset; PADDING-RIGHT: 0px; BORDER-TOP: 1.5pt inset; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; VERTICAL-ALIGN: middle; OVERFLOW: auto; BORDER-LEFT: 1.5pt inset; WIDTH: 100%; PADDING-TOP: 0px; BORDER-BOTTOM: 1.5pt inset; HEIGHT: 240px; BACKGROUND-COLOR: white">
							<asp:Table ID="FoldersAndFiles" Runat="server" CellSpacing="1" CellPadding="1" Width="100%"
								CssClass="sortable">
								<asp:TableRow BackColor="#f0f0f0">
									<asp:TableHeaderCell Width="16px">
										<asp:ImageButton ID="Delete" Runat="server" AlternateText="Delete the selected files/directories"
											onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" ImageUrl="../images/s_cut.gif" Visible="true"
											OnClick="Delete_Click" />
									</asp:TableHeaderCell>
									<asp:TableHeaderCell Width="16px">
										<asp:ImageButton ID="DoRefresh" Runat="server" AlternateText="[[Refresh]]" ImageUrl="../images/s_refresh.gif"
											onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true" OnClick="DoRefresh_Click" />
									</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="name_Cell" Width="136px" CssClass="filelistHeadCol" Font-Bold="False">[[Name]]</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="size_Cell" Width="72px" CssClass="filelistHeadCol" Font-Bold="False">[[Count]]/[[Size]]</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="op_Cell" Width="16px">&nbsp;</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="op_Cell2" Width="16px">&nbsp;</asp:TableHeaderCell>
								</asp:TableRow>
							</asp:Table>
						</div>
					</td>
					<td width="10">
					</td>
					<td valign="top">
						<div style="BORDER-RIGHT: 1.5pt inset; PADDING-RIGHT: 0px; BORDER-TOP: 1.5pt inset; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; VERTICAL-ALIGN: middle; OVERFLOW: auto; BORDER-LEFT: 1.5pt inset; WIDTH: 100%; PADDING-TOP: 0px; BORDER-BOTTOM: 1.5pt inset; HEIGHT: 240px; BACKGROUND-COLOR: white;WIDTH: 360px;">
							<iframe id="framepreview" src="../template.aspx"></iframe>
						</div>
					</td>
				</tr>
			</table>
			<br>
			<table border="0" cellspacing="2" cellpadding="0" width="98%" align="center">
				<tr>
					<td valign="top">
					</td>
					<td width="10">
					</td>
					<td valign="top">
						<input type="hidden" id="TargetUrl" size="40" name="TargetUrl" runat="server">
						<fieldset runat="server" id="fieldsetUpload">
							<legend>
								[[Upload]] (Max file size allowed
								<%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateSize * 1024)%>
								)</legend>
							<table border="0" cellspacing="2" cellpadding="0" width="98%" align="center" class="normal">
								<tr>
									<td valign="top" width="54%" style="FONT-SIZE: 8pt; VERTICAL-ALIGN: middle">
										<asp:Label ID="Label_PictureUpload" Runat="server">&nbsp;</asp:Label>
										<input id="InputFile" size="40" type="file" runat="server" style="HEIGHT:20px" NAME="InputFile">&nbsp;&nbsp;<asp:Button ID="uploadButton" Text="[[Upload]]" Runat="server" OnClick="uploadButton_Click" />&nbsp;
									</td>
								</tr>
								<tr>
									<td height="5">
									</td>
								</tr>
								<tr>
									<td>
										<table cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td>
													<nobr>Max Upload folder size is :
														<%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateFolderSize * 1024)%>
														. Used:
														<%= CuteEditor.Impl.FileStorage.FormatSize(fs.GetDirectorySize(fs.VirtualRoot)) %>
													</nobr>
												</td>
												<td>
													<div style="FONT-SIZE:3px;WIDTH:40px;HEIGHT:3px;BACKGROUND-COLOR:green">
														<div style="FONT-SIZE:3px;HEIGHT:3px;BACKGROUND-COLOR:red"></div>
													</div>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</fieldset>
						<p align="center">
							<input class="inputbuttoninsert" type="button" value="[[Insert]]" onclick="do_insert()"
								id="Button1" runat="server" NAME="Button1">&nbsp;&nbsp;&nbsp; <input class="inputbuttoncancel" type="button" value="[[Cancel]]" onclick="do_cancel()"
								id="Button2" runat="server" NAME="Button2">
						</p>
					</td>
				</tr>
			</table>
		</form>
		<script runat="server">
	protected override void InitOfType()
	{
		fs.VirtualRoot=CuteEditor.EditorUtility.ProcessWebPath(Context,null,secset.TemplateGalleryPath).TrimEnd('/')+"/";
	}
    protected override void GetFiles(ArrayList files)
    {
        files.AddRange(fs.GetFileItems(CurrentDirectory, secset.FileNamePrefix + "*.htm"));
    }
    protected override bool AllowFileName(string filename)
    {
        filename = filename.ToLower();
        return filename.EndsWith(".htm") || filename.EndsWith(".html");
    }
    protected override string CheckUploadData(ref byte[] data)
    {
		if (fs.GetDirectorySize(fs.VirtualRoot) >= secset.MaxTemplateFolderSize * 1024)
           return "Template folder size exceeds the limit: "+ CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateFolderSize * 1024);

		if (data.Length >= secset.MaxTemplateSize * 1024)
            return "Template size exceeds "+CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateSize * 1024)+" limit: "+ CuteEditor.Impl.FileStorage.FormatSize(data.Length);
        return null;
    }
    
     protected int GetUsedSpaceBarWidth()
    {
      int w = Convert.ToInt32(40*fs.GetDirectorySize(fs.VirtualRoot)/(secset.MaxTemplateFolderSize * 1024));
      if(w<1)
		w=1;
		
	  if(w>40)
		w=40;
		
      return w;      
    }
    
		</script>
		<script src="addvars.js"></script>
		<script>
		var OxOce51=["","dialogArguments","contentWindow","framepreview","DIV","innerHTML","body","document",".aspx"];var htmlcode=OxOce51[0x0];var pageurl=OxOce51[0x0];var editor=top[OxOce51[0x1]];var framepreview=document.getElementById(OxOce51[0x3])[OxOce51[0x2]]; function do_preview(Oxaf){ htmlcode=Oxaf ;var div=document.createElement(OxOce51[0x4]); div[OxOce51[0x5]]=Oxaf ; htmlcode=div[OxOce51[0x5]] ;try{ framepreview[OxOce51[0x7]][OxOce51[0x6]][OxOce51[0x5]]=div[OxOce51[0x5]] ;} catch(er){ htmlcode=OxOce51[0x0] ;} ;}  ; function do_insert(){if(pageurl.indexOf(OxOce51[0x8])!=-0x1){ htmlcode=framepreview[OxOce51[0x7]][OxOce51[0x6]][OxOce51[0x5]] ;var div=document.createElement(OxOce51[0x4]); div[OxOce51[0x5]]=htmlcode ;try{ htmlcode=div[OxOce51[0x5]] ;} catch(er){ htmlcode=OxOce51[0x0] ;} ;} ; editor.PasteHTML(htmlcode) ; top.close() ;}  ; function do_cancel(){ top.close() ;}  ;
		</script>
	</body>
</HTML>
