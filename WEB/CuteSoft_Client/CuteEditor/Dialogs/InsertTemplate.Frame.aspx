<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.TemplateBrowserPage" %>
<%
	string QUERY_STRING=Request.ServerVariables["QUERY_STRING"];
%>
<HTML>
	<HEAD>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
		<link rel="stylesheet" href='style.css'>
		<script src=dialog.js></script><script src=../_shared.js></script>
		<script src="../CuteEditorconstants.js"></script>
		<script src="sorttable.js"></script>
		<script src="sorttable.js"></script>
		<script language="JavaScript">
		var OxO3c16=["disabled","srcElement","[[Disabled]]","[[SpecifyNewFolderName]]","","value","hiddenActionData","[[SpecifyNewFileName]]","href","location","[[CopyMoveto]]","/","[[AreyouSureDelete]]","parentNode","text","isdir",".","hiddenAction","rename","path","True","False",":","cancelBubble","backgroundColor","style","#eeeeee","tagName","INPUT","changedir","htmlcode","hiddenFile","url",".aspx","src","framepreview","TargetUrl"]; function CreateDir_click(){if(event[OxO3c16[0x1]][OxO3c16[0x0]]){ alert(OxO3c16[0x2]) ;return false;} ;var Ox2fb=prompt(OxO3c16[0x3],OxO3c16[0x4]);if(Ox2fb){ document.getElementById(OxO3c16[0x6])[OxO3c16[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function NewTemplate_Click(){var Ox2fb=prompt(OxO3c16[0x7],OxO3c16[0x4]);if(Ox2fb){var arr=showModalDialog('[[_CuteEditorResource_]]Dialogs/OuterEditorFull.aspx?<%= QUERY_STRING %>&f='+Ox2fb+OxO3c16[0x4],window,_createtemplateDialogFeature);if(arr){ window[OxO3c16[0x9]][OxO3c16[0x8]]=window[OxO3c16[0x9]][OxO3c16[0x8]] ;} ;return true;} else {return false;} ;}  ; function Move_click(){if(event[OxO3c16[0x1]][OxO3c16[0x0]]){ alert(OxO3c16[0x2]) ;return false;} ;var Ox2fb=prompt(OxO3c16[0xa],OxO3c16[0xb]);if(Ox2fb){ document.getElementById(OxO3c16[0x6])[OxO3c16[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Copy_click(){if(event[OxO3c16[0x1]][OxO3c16[0x0]]){ alert(OxO3c16[0x2]) ;return false;} ;var Ox2fb=prompt(OxO3c16[0xa],OxO3c16[0xb]);if(Ox2fb){ document.getElementById(OxO3c16[0x6])[OxO3c16[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Delete_click(){if(event[OxO3c16[0x1]][OxO3c16[0x0]]){ alert(OxO3c16[0x2]) ;return false;} ;return confirm(OxO3c16[0xc]);}  ; function RenImg_click(Oxb9){if(Oxb9[OxO3c16[0x0]]){ alert(OxO3c16[0x2]) ;return false;} ; row=Oxb9[OxO3c16[0xd]][OxO3c16[0xd]] ;var Ox550=row[OxO3c16[0xe]];var name;if(row[OxO3c16[0xf]]){ name=prompt(OxO3c16[0x3],Ox550) ;} else {var i=Ox550.lastIndexOf(OxO3c16[0x10]);var Ox551=Ox550.substr(i);var Ox20=Ox550.substr(0x0,Ox550.lastIndexOf(OxO3c16[0x10])); name=prompt(OxO3c16[0x7],Ox20) ;if(name){ name=name+Ox551 ;} ;} ;if(name&&name!=row[OxO3c16[0xe]]){ document.getElementById(OxO3c16[0x11])[OxO3c16[0x5]]=OxO3c16[0x12] ; document.getElementById(OxO3c16[0x6])[OxO3c16[0x5]]=(row[OxO3c16[0xf]]?OxO3c16[0x14]:OxO3c16[0x15])+OxO3c16[0x16]+row[OxO3c16[0x13]]+OxO3c16[0x16]+name ; postback() ;} ; event[OxO3c16[0x17]]=true ;}  ; function EditImg_click(Oxb9){ row=Oxb9[OxO3c16[0xd]][OxO3c16[0xd]] ;if(row.getAttribute(OxO3c16[0x13])){var arr=showModalDialog('[[_CuteEditorResource_]]Dialogs/OuterEditorFull.aspx?<%= QUERY_STRING %>&f='+row.getAttribute(OxO3c16[0x13])+OxO3c16[0x4],window,_createtemplateDialogFeature);if(arr){ window[OxO3c16[0x9]][OxO3c16[0x8]]=window[OxO3c16[0x9]][OxO3c16[0x8]] ;} ;return true;} else {return false;} ;}  ; function row_over(Oxc3){ Oxc3[OxO3c16[0x19]][OxO3c16[0x18]]=OxO3c16[0x1a] ;}  ; function row_out(Oxc3){ Oxc3[OxO3c16[0x19]][OxO3c16[0x18]]=OxO3c16[0x4] ;}  ; function row_click(Oxc3){if(Oxc3[OxO3c16[0xf]]){if(event[OxO3c16[0x1]][OxO3c16[0x1b]]==OxO3c16[0x1c]){return ;} ; document.getElementById(OxO3c16[0x11])[OxO3c16[0x5]]=OxO3c16[0x1d] ; document.getElementById(OxO3c16[0x6])[OxO3c16[0x5]]=Oxc3.getAttribute(OxO3c16[0x13]) ; postback() ;} else {var Ox4f4=Oxc3.getAttribute(OxO3c16[0x13]);var htmlcode=Oxc3.getAttribute(OxO3c16[0x1e]); document.getElementById(OxO3c16[0x1f])[OxO3c16[0x5]]=Ox4f4 ;var Oxba=Oxc3.getAttribute(OxO3c16[0x20]); Oxba=Oxba.toLowerCase() ;if(Oxba.indexOf(OxO3c16[0x21])!=-0x1){try{ document.getElementById(OxO3c16[0x23])[OxO3c16[0x22]]=Oxba ;} catch(e){} ;} ; document.getElementById(OxO3c16[0x24])[OxO3c16[0x5]]=Oxba ; do_preview(htmlcode) ; pageurl=Oxba ;} ;}  ; function postback(){ <%=Page.ClientScript.GetPostBackEventReference(hiddenAction,"")%> ;}  ;
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
			zoom: 50%;
			background-color: white;
		}
		</style>
	</HEAD>
	<body bottomMargin="0" topMargin="10" leftmargin="3" marginwidth="0" marginheight="0">
		<form runat="server" enctype="multipart/form-data" id="Form1">
			<!-- start hidden -->
			<script>
        var OxO8d0f=["onload","value","hiddenAlert","","hiddenAction","hiddenActionData"]; window[OxO8d0f[0x0]]=reset_hiddens ; function reset_hiddens(){if(document.getElementById(OxO8d0f[0x2])[OxO8d0f[0x1]]){ alert(document.getElementById(OxO8d0f[0x2]).value) ;} ; document.getElementById(OxO8d0f[0x2])[OxO8d0f[0x1]]=OxO8d0f[0x3] ; document.getElementById(OxO8d0f[0x4])[OxO8d0f[0x1]]=OxO8d0f[0x3] ; document.getElementById(OxO8d0f[0x5])[OxO8d0f[0x1]]=OxO8d0f[0x3] ;}  ;
			</script>
			<input type="hidden" runat="server" id="hiddenDirectory" NAME="hiddenDirectory"> <input type="hidden" runat="server" id="hiddenFile" NAME="hiddenFile">
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" NAME="hiddenAlert"> <input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" onserverchange="hiddenAction_ServerChange" NAME="hiddenAction">
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenActionData" NAME="hiddenActionData">
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
							onMouseOver="CuteEditor_ColorPicker_ButtonOver(this);" Visible="true"
							OnClick="CreateDir_Click" />
						<asp:ImageButton ID="Copy" Runat="server" AlternateText="[[Copyfiles]]" ImageUrl="../images/Copy.gif"
							onMouseOver="CuteEditor_ColorPicker_ButtonOver(this);" Visible="true"
							OnClick="Copy_Click" />
						<asp:ImageButton ID="Move" Runat="server" AlternateText="[[Movefiles]]" ImageUrl="../images/move.gif"
							onMouseOver="CuteEditor_ColorPicker_ButtonOver(this);" Visible="true"
							OnClick="Move_Click" />
						<IMG src="../images/zoom_in.gif" onclick="Zoom_In();" Alt="[[ZoomIn]]" class="dialogButton"
							onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"> <IMG src="../images/zoom_out.gif" onclick="Zoom_Out();" Alt="[[ZoomOut]]" class="dialogButton"
							onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"><IMG src="../images/Actualsize.gif" onclick="Actualsize();" Alt="[[ActualSize]]" class="dialogButton"
							onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"> 
						<asp:ImageButton ID="NewTemplate" Runat="server" AlternateText="[[NewTemplate]]" ImageUrl="../images/newtemplate.gif"
							onMouseOver="CuteEditor_ColorPicker_ButtonOver(this);" Visible="true"
							OnClick="NewTemplate_Click" />
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="2" width="100%" align="center">
				<tr>
					<td valign="top" nowrap width="250">
						<div style="BORDER: 1.5pt inset;  VERTICAL-ALIGN: middle; OVERFLOW: auto; WIDTH: 250px; HEIGHT: 240px; Padding: 0 0 0 0; BACKGROUND-COLOR: white">
							<asp:Table ID="FoldersAndFiles" Runat="server" CellSpacing="1" CellPadding="1" Width="100%" CssClass="sortable">
								<asp:TableRow BackColor="#f0f0f0">
									<asp:TableHeaderCell Width="16px" >
						<asp:ImageButton ID="Delete" Runat="server" AlternateText="Delete the selected files/directories"
							onMouseOver="CuteEditor_ColorPicker_ButtonOver(this);" ImageUrl="../images/s_cut.gif"
							Visible="true" OnClick="Delete_Click" />
									</asp:TableHeaderCell>
									<asp:TableHeaderCell Width="16px" >
						<asp:ImageButton ID="DoRefresh" Runat="server" AlternateText="[[Refresh]]" ImageUrl="../images/s_refresh.gif"
							onMouseOver="CuteEditor_ColorPicker_ButtonOver(this);" Visible="true"
							OnClick="DoRefresh_Click" />
									</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="name_Cell" Width="136px" CssClass="filelistHeadCol" Font-Bold="False">[[Name]]</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="size_Cell" Width="72px" CssClass="filelistHeadCol" Font-Bold="False">[[Count]]/[[Size]]</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="op_Cell"  Width="16px">&nbsp;</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="op_Cell2"  Width="16px">&nbsp;</asp:TableHeaderCell>
								</asp:TableRow>
							</asp:Table>
						</div>
					</td>
					<td valign="top">						
						<div style="BORDER: 1.5pt inset; VERTICAL-ALIGN: top; OVERFLOW: auto;WIDTH: 380px; HEIGHT: 240px; BACKGROUND-COLOR: white;">
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
									<td valign="top" width="54%" style="FONT-SIZE: 8pt; VERTICAL-ALIGN: middle;">
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
										<nobr>
											Max Upload folder size is : <%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxTemplateFolderSize * 1024)%>.
											Used: <%= CuteEditor.Impl.FileStorage.FormatSize(fs.GetDirectorySize(fs.VirtualRoot)) %>
											<span style="background-color:green;height:3px;width:40px;font-size:3px">
												<span style="background-color:red;height:3px;width:<%= GetUsedSpaceBarWidth() %>px;font-size:3px"></span>
											</span>
										</nobr>
									</td>
								</tr>
							</table>
						</fieldset>
						<div align="center" style="padding-top:4px;">
							<input class="inputbuttoninsert" type="button" value="[[Insert]]" onclick="do_insert()"	id="Button1">&nbsp;&nbsp;&nbsp; 
							<input class="inputbuttoncancel" type="button" value="[[Cancel]]" onclick="do_cancel()"	id="Button2">
						</div>
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
		var OxO152f=["dialogArguments","","contentWindow","framepreview","innerHTML","body","document","zoom","style"];var editor=top[OxO152f[0x0]];var htmlcode=OxO152f[0x1];var pageurl=OxO152f[0x1];var framepreview=document.getElementById(OxO152f[0x3])[OxO152f[0x2]]; function do_preview(Oxaf){ htmlcode=Oxaf ; framepreview[OxO152f[0x6]][OxO152f[0x5]][OxO152f[0x4]]=htmlcode ;}  ; function do_insert(){ editor.PasteHTML(htmlcode) ; top.close() ;}  ; function do_cancel(){ top.close() ;}  ; function Zoom_In(){if(framepreview[OxO152f[0x6]][OxO152f[0x5]][OxO152f[0x8]][OxO152f[0x7]]!=0x0){ framepreview[OxO152f[0x6]][OxO152f[0x5]][OxO152f[0x8]][OxO152f[0x7]]*=1.1 ;} else { framepreview[OxO152f[0x6]][OxO152f[0x5]][OxO152f[0x8]][OxO152f[0x7]]=1.1 ;} ;}  ; function Zoom_Out(){if(framepreview[OxO152f[0x6]][OxO152f[0x5]][OxO152f[0x8]][OxO152f[0x7]]!=0x0){ framepreview[OxO152f[0x6]][OxO152f[0x5]][OxO152f[0x8]][OxO152f[0x7]]*=0.8 ;} else { framepreview[OxO152f[0x6]][OxO152f[0x5]][OxO152f[0x8]][OxO152f[0x7]]=0.8 ;} ;}  ; function Actualsize(){ framepreview[OxO152f[0x6]][OxO152f[0x5]][OxO152f[0x8]][OxO152f[0x7]]=0x1 ;}  ;
	</script>
	</body>
</HTML>
