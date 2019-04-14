<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.FileBrowserPage" %>
<html>
	<head>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
		<link rel="stylesheet" href='style.css'>
		<script src=dialog.js></script><script src=../_shared.js></script>
		<script src="filebrowserpage.js"></script>
		<script src="sorttable.js"></script>
		<script language="JavaScript">
		var OxO7bda=["disabled","srcElement","[[Disabled]]","[[SpecifyNewFolderName]]","","value","hiddenActionData","[[CopyMoveto]]","/","[[AreyouSureDelete]]","parentNode","text","isdir",".","[[SpecifyNewFileName]]","hiddenAction","rename","path","True","False",":","cancelBubble","backgroundColor","style","#eeeeee","tagName","INPUT","changedir","hiddenFile","url","TargetUrl"]; function CreateDir_click(){if(event[OxO7bda[0x1]][OxO7bda[0x0]]){ alert(OxO7bda[0x2]) ;return false;} ;var Ox2fb=prompt(OxO7bda[0x3],OxO7bda[0x4]);if(Ox2fb){ document.getElementById(OxO7bda[0x6])[OxO7bda[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Move_click(){if(event[OxO7bda[0x1]][OxO7bda[0x0]]){ alert(OxO7bda[0x2]) ;return false;} ;var Ox2fb=prompt(OxO7bda[0x7],OxO7bda[0x8]);if(Ox2fb){ document.getElementById(OxO7bda[0x6])[OxO7bda[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Copy_click(){if(event[OxO7bda[0x1]][OxO7bda[0x0]]){ alert(OxO7bda[0x2]) ;return false;} ;var Ox2fb=prompt(OxO7bda[0x7],OxO7bda[0x8]);if(Ox2fb){ document.getElementById(OxO7bda[0x6])[OxO7bda[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Delete_click(){if(event[OxO7bda[0x1]][OxO7bda[0x0]]){ alert(OxO7bda[0x2]) ;return false;} ;return confirm(OxO7bda[0x9]);}  ; function EditImg_click(Oxb9){if(Oxb9[OxO7bda[0x0]]){ alert(OxO7bda[0x2]) ;return false;} ; row=Oxb9[OxO7bda[0xa]][OxO7bda[0xa]] ;var Ox550=row[OxO7bda[0xb]];var name;if(row[OxO7bda[0xc]]){ name=prompt(OxO7bda[0x3],Ox550) ;} else {var i=Ox550.lastIndexOf(OxO7bda[0xd]);var Ox551=Ox550.substr(i);var Ox20=Ox550.substr(0x0,Ox550.lastIndexOf(OxO7bda[0xd])); name=prompt(OxO7bda[0xe],Ox20) ;if(name){ name=name+Ox551 ;} ;} ;if(name&&name!=row[OxO7bda[0xb]]){ document.getElementById(OxO7bda[0xf])[OxO7bda[0x5]]=OxO7bda[0x10] ; document.getElementById(OxO7bda[0x6])[OxO7bda[0x5]]=(row[OxO7bda[0xc]]?OxO7bda[0x12]:OxO7bda[0x13])+OxO7bda[0x14]+row[OxO7bda[0x11]]+OxO7bda[0x14]+name ; postback() ;} ; event[OxO7bda[0x15]]=true ;}  ; function row_over(Oxc3){ Oxc3[OxO7bda[0x17]][OxO7bda[0x16]]=OxO7bda[0x18] ;}  ; function row_out(Oxc3){ Oxc3[OxO7bda[0x17]][OxO7bda[0x16]]=OxO7bda[0x4] ;}  ; function row_click(Oxc3){if(Oxc3[OxO7bda[0xc]]){if(event[OxO7bda[0x1]][OxO7bda[0x19]]==OxO7bda[0x1a]){return ;} ; document.getElementById(OxO7bda[0xf])[OxO7bda[0x5]]=OxO7bda[0x1b] ; document.getElementById(OxO7bda[0x6])[OxO7bda[0x5]]=Oxc3.getAttribute(OxO7bda[0x11]) ; postback() ;} else {var Ox4f4=Oxc3.getAttribute(OxO7bda[0x11]); document.getElementById(OxO7bda[0x1c])[OxO7bda[0x5]]=Ox4f4 ;var Oxba=Oxc3.getAttribute(OxO7bda[0x1d]); document.getElementById(OxO7bda[0x1e])[OxO7bda[0x5]]=Oxba ; do_preview() ;} ;}  ; function postback(){ <%=Page.ClientScript.GetPostBackEventReference(hiddenAction,"")%> ;}  ;
		</script>
		<style>
		.row
		{
			height:22px;
		}
		.cb
		{
			vertical-align:middle;
		}
		.itemimg
		{
			vertical-align:middle;
		}
		.editimg
		{
			vertical-align:middle;
		}
		.cell1
		{
			vertical-align:middle;
		}
		.cell2
		{
			vertical-align:middle;
		}
		.cell3
		{
			vertical-align:middle;
		    
			text-align:right;
			padding-right:4px;
		}
		.cb
		{
		}
		</style>
	</head>
	<body>
		<form runat="server" enctype="multipart/form-data" id="Form1">
			<!-- start hidden -->
			<script>
        var OxO4c55=["onload","value","hiddenAlert","","hiddenAction","hiddenActionData"]; window[OxO4c55[0x0]]=reset_hiddens ; function reset_hiddens(){if(document.getElementById(OxO4c55[0x2])[OxO4c55[0x1]]){ alert(document.getElementById(OxO4c55[0x2]).value) ;} ; document.getElementById(OxO4c55[0x2])[OxO4c55[0x1]]=OxO4c55[0x3] ; document.getElementById(OxO4c55[0x4])[OxO4c55[0x1]]=OxO4c55[0x3] ; document.getElementById(OxO4c55[0x5])[OxO4c55[0x1]]=OxO4c55[0x3] ;}  ;
			</script>
			<input type="hidden" runat="server" id="hiddenDirectory" NAME="hiddenDirectory" />
			<input type="hidden" runat="server" id="hiddenFile" NAME="hiddenFile" /> <input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" NAME="hiddenAlert" />
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" onserverchange="hiddenAction_ServerChange"
				NAME="hiddenAction" /> <input type="hidden" runat="server" enableviewstate="false" id="hiddenActionData" NAME="hiddenActionData" />
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
							onmouseover="CuteEditor_ColorPicker_ButtonOver(this);">
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
				<tr>
					<td valign="top" nowrap width="250">
						<div style="BORDER: 1.5pt inset; VERTICAL-ALIGN: middle; OVERFLOW: auto; WIDTH: 250px; HEIGHT: 240px; BACKGROUND-COLOR: white">
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
								</asp:TableRow>
							</asp:Table>
						</div>
					</td>
					<td width="10">
					</td>
					<td valign="top">
						<div style="paddng: 0 0 0 0; BORDER: 1.5pt inset; VERTICAL-ALIGN: top; OVERFLOW: auto; BORDER-BOTTOM: 1.5pt inset; WIDTH: 280px; HEIGHT: 240px; BACKGROUND-COLOR: white; TEXT-ALIGN: center">
							<div id="divpreview" style="BACKGROUND-COLOR: white" height="100%" width="100%">
								&nbsp;</div>
						</div>
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="2" cellpadding="0" width="98%" align="center">
				<tr>
					<td valign="top">
						<fieldset style="width:480">
							<legend>
								[[Insert]]</legend>
							<table border="0" cellpadding="5" cellspacing="0">
								<tr>
									<td>
										<TABLE id="Table8" cellSpacing="0" cellPadding="2" border="0" class="normal">
											<TR>
												<TD vAlign="middle">URL:</TD>
												<td><input type="text" id="TargetUrl" style="width:400" name="TargetUrl" runat="server"></td>
											</TR>
										</TABLE>
									</td>
								</tr>
							</table>
						</fieldset>
						<fieldset style="width:480">
							<legend>
								[[Upload]] (Max file size allowed
								<%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxDocumentSize * 1024)%>
								)</legend>
							<table border="0" cellpadding="5" cellspacing="0">
								<tr>
									<td>
										<table border="0" cellpadding="2" cellspacing="0" class="normal">
											<tr>
												<td>[[Upload]]:</td>
												<td>
													<input id="InputFile" size="40" type="file" runat="server" style="height:20px">
													<asp:Label ID="Label_PictureUpload" Runat="server">&nbsp;</asp:Label>
													<asp:Button ID="uploadButton" Text="[[Upload]]" Runat="server" OnClick="uploadButton_Click" />&nbsp;
													<asp:Label ID="uploadResult" Runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td height="5" colspan="2">
												</td>
											</tr>
											<tr>
												<td colspan="2">
											<nobr>
											Max Upload folder size is : <%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxDocumentFolderSize * 1024)%>.
											Used: <%= CuteEditor.Impl.FileStorage.FormatSize(fs.GetDirectorySize(fs.VirtualRoot)) %>
											<span style="background-color:green;height:3px;width:40px;font-size:3px">
												<span style="background-color:red;height:3px;width:<%= GetUsedSpaceBarWidth() %>px;font-size:3px"></span>
											</span>
											</nobr>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</fieldset>
						<p align="center">
							<input class="inputbuttoninsert" type="button" value="[[OK]]" onclick="do_insert()" id="Button1"
								runat="server" NAME="Button1">&nbsp;&nbsp;&nbsp; <input class="inputbuttoncancel" type="button" value="[[Cancel]]" onclick="do_cancel()"
								id="Button2" runat="server" NAME="Button2">
						</p>
					</td>
				</tr>
			</table>
		</form>
	</body>
	<script runat="server">
	protected override void InitOfType()
	{
		fs.VirtualRoot=CuteEditor.EditorUtility.ProcessWebPath(Context,null,secset.FilesGalleryPath).TrimEnd('/')+"/";
	}
    protected override void GetFiles(ArrayList files)
    {
		files.AddRange(fs.GetFileItems(CurrentDirectory,secset.FileNamePrefix + "*.*"));
    }
    protected override bool AllowFileName(string filename)
    {
        filename = filename.ToLower();
        if(filename.EndsWith(".swf"))return true;
        foreach (string ext in secset.DocumentFilters)
        {
            if (ext == null || ext.Length == 0) continue;
            if(filename.EndsWith(ext.ToLower()))
                return true;
        }
        foreach (string ext in secset.ImageFilters)
        {
            if (ext == null || ext.Length == 0) continue;
            if(filename.EndsWith(ext.ToLower()))
                return true;
        }
        foreach (string ext in secset.MediaFilters)
        {
            if (ext == null || ext.Length == 0) continue;
            if(filename.EndsWith(ext.ToLower()))
                return true;
        }
        return false;
    }
    protected override string CheckUploadData(ref byte[] data)
    {	
		if (fs.GetDirectorySize(fs.VirtualRoot) >= secset.MaxDocumentFolderSize * 1024)
           return "File folder size exceeds the limit: "+ CuteEditor.Impl.FileStorage.FormatSize(secset.MaxDocumentFolderSize * 1024);

        if (data.Length >= secset.MaxDocumentSize * 1024)
            return "File size exceeds "+CuteEditor.Impl.FileStorage.FormatSize(secset.MaxDocumentSize * 1024)+" limit: "+ CuteEditor.Impl.FileStorage.FormatSize(data.Length);
        return null;
        
    }
    protected int GetUsedSpaceBarWidth()
    {
      int w = Convert.ToInt32(40*fs.GetDirectorySize(fs.VirtualRoot)/(secset.MaxDocumentFolderSize * 1024));
      if(w<1)
		w=1;
		
	  if(w>40)
		w=40;
		
      return w;      
    }
	</script>
	<script src="addvars.js"></script>
	<script>
var OxO5990=["innerHTML","","value","TargetUrl",".","\x3CIMG src=\x27","\x27\x3E","\x3COBJECT width=\x2290%\x22 height=\x2290%\x22 align=\x22\x22 src=\x22","\x22 xcodebase=","\x22http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab\x22"," classid=","\x22clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\x22\x3E"," \x3CPARAM name=\x22_cx\x22 value=\x224180\x22\x3E"," \x3CPARAM name=\x22_cy\x22 value=\x221455\x22\x3E"," \x3CPARAM name=\x22FlashVars\x22 value=\x224180\x22\x3E"," \x3CPARAM name=\x22Movie\x22 value=\x22","\x22\x3E"," \x3CPARAM name=\x22Src\x22 value=\x22"," \x3CPARAM name=\x22WMode\x22 value=\x22Window\x22\x3E"," \x3CPARAM name=\x22Play\x22 value=\x22-1\x22\x3E"," \x3CPARAM name=\x22Loop\x22 value=\x22-1\x22\x3E"," \x3CPARAM name=\x22Quality\x22 value=\x22height\x22\x3E"," \x3CPARAM name=\x22SAlign\x22 value=\x22\x22\x3E"," \x3CPARAM name=\x22Menu\x22 value=\x22-1\x22\x3E"," \x3CPARAM name=\x22Base\x22 value=\x22\x22\x3E"," \x3CPARAM name=\x22AllowScriptAccess\x22 value=\x22always\x22\x3E"," \x3CPARAM name=\x22Scale\x22 value=\x22ShowAll\x22\x3E"," \x3CPARAM name=\x22DeviceFont\x22 value=\x220\x22\x3E"," \x3CPARAM name=\x22EmbedMovie\x22 value=\x220\x22\x3E"," \x3CPARAM name=\x22SWRemote\x22 value=\x22\x22\x3E","\x3C/OBJECT\x3E","\x3Cembed name=\x22MediaPlayer1\x22 src=\x22","\x22 autostart=-1 showcontrols=-1  type=\x22application/x-mplayer2\x22 pluginspage=\x22http://www.microsoft.com/Windows/MediaPlayer\x22 \x3E\x3C/embed\x3E\x0A",".mp3",".mpg",".avi",".swf",".bmp",".png",".gif",".jpg",".jpeg","returnValue","zoom","style"]; do_preview() ; function do_preview(){ divpreview[OxO5990[0x0]]=OxO5990[0x1] ;var Oxba=document.getElementById(OxO5990[0x3])[OxO5990[0x2]];if(Oxba==OxO5990[0x1]){return ;} ;var Ox551=Oxba.substring(Oxba.lastIndexOf(OxO5990[0x4])).toLowerCase();switch(Ox551){case OxO5990[0x29]:case OxO5990[0x28]:case OxO5990[0x27]:case OxO5990[0x26]:case OxO5990[0x25]: divpreview[OxO5990[0x0]]=OxO5990[0x5]+Oxba+OxO5990[0x6] ;break ;case OxO5990[0x24]:var Ox563=OxO5990[0x7]+Oxba+OxO5990[0x8]+OxO5990[0x9]+OxO5990[0xa]+OxO5990[0xb]+OxO5990[0xc]+OxO5990[0xd]+OxO5990[0xe]+OxO5990[0xf]+Oxba+OxO5990[0x10]+OxO5990[0x11]+Oxba+OxO5990[0x10]+OxO5990[0x12]+OxO5990[0x13]+OxO5990[0x14]+OxO5990[0x15]+OxO5990[0x16]+OxO5990[0x17]+OxO5990[0x18]+OxO5990[0x19]+OxO5990[0x1a]+OxO5990[0x1b]+OxO5990[0x1c]+OxO5990[0x1d]+OxO5990[0x1e]; divpreview[OxO5990[0x0]]=Ox563 ;break ;case OxO5990[0x23]:case OxO5990[0x22]:case OxO5990[0x21]:var Oxbd=OxO5990[0x1f]+Oxba+OxO5990[0x20]; divpreview[OxO5990[0x0]]=Oxbd ;break ;;;;;;;;;;} ;}  ; function do_insert(){ top[OxO5990[0x2a]]=document.getElementById(OxO5990[0x3])[OxO5990[0x2]] ; top.close() ;}  ; function do_cancel(){ top[OxO5990[0x2a]]=null ; top.close() ;}  ; function Zoom_In(){if(divpreview[OxO5990[0x2c]][OxO5990[0x2b]]!=0x0){ divpreview[OxO5990[0x2c]][OxO5990[0x2b]]*=1.2 ;} else { divpreview[OxO5990[0x2c]][OxO5990[0x2b]]=1.2 ;} ;}  ; function Zoom_Out(){if(divpreview[OxO5990[0x2c]][OxO5990[0x2b]]!=0x0){ divpreview[OxO5990[0x2c]][OxO5990[0x2b]]*=0.8 ;} else { divpreview[OxO5990[0x2c]][OxO5990[0x2b]]=0.8 ;} ;}  ;
	</script>
</html>
