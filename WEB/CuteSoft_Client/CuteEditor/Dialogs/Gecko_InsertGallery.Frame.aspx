<%@ Register TagPrefix="CC1" TagName="ThumbList" Src="ThumbList.ascx" %>
<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.InsertGalleryFrame" %>
<HTML>
	<HEAD>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href='Gecko_style.css'>
		<script src=Gecko_dialog.js></script><script src=../_shared.js></script>
		<script language="JavaScript">
			var OxOe537=["lightyellow","0px","-3px","all","getElementById","\x3Cdiv id=\x22tooltipdiv\x22 style=\x22visibility:hidden;background-color:","\x22 \x3E\x3C/div\x3E","left","offsetLeft","offsetTop","offsetParent","top","style","type","visibility","click","mouseover","compatMode","BackCompat","documentElement","body","rightedge","opera","clientWidth","scrollLeft","innerWidth","pageXOffset","offsetWidth","contentmeasure","x","clientHeight","scrollTop","innerHeight","pageYOffset","offsetHeight","y","event","cancelBubble","stopPropagation","tooltipdiv","innerHTML","visible","hidden","px","bottomedge","undefined","hidetip()"]; function cancel(){ top.close() ;}  ;var tipbgcolor=OxOe537[0x0];var disappeardelay=0xfa;var vertical_offset=OxOe537[0x1];var horizontal_offset=OxOe537[0x2];var ie4=document[OxOe537[0x3]];var ns6=document[OxOe537[0x4]]&&!document[OxOe537[0x3]];if(ie4||ns6){ document.write(OxOe537[0x5]+tipbgcolor+OxOe537[0x6]) ;} ; function getposOffset(Ox58f,Ox590){var Ox591=(Ox590==OxOe537[0x7])?Ox58f[OxOe537[0x8]]:Ox58f[OxOe537[0x9]];var Ox592=Ox58f[OxOe537[0xa]];while(Ox592!=null){ Ox591=(Ox590==OxOe537[0x7])?Ox591+Ox592[OxOe537[0x8]]:Ox591+Ox592[OxOe537[0x9]] ; Ox592=Ox592[OxOe537[0xa]] ;} ;return Ox591;}  ; function showhide(obj,e,Ox594,hidden){if(ie4||ns6){ dropmenuobj[OxOe537[0xc]][OxOe537[0x7]]=dropmenuobj[OxOe537[0xc]][OxOe537[0xb]]=-0x1f4 ;} ;if(e[OxOe537[0xd]]==OxOe537[0xf]&&obj[OxOe537[0xe]]==hidden||e[OxOe537[0xd]]==OxOe537[0x10]){ obj[OxOe537[0xe]]=Ox594 ;} else {if(e[OxOe537[0xd]]==OxOe537[0xf]){ obj[OxOe537[0xe]]=hidden ;} ;} ;}  ; function iecompattest(){return (document[OxOe537[0x11]]&&document[OxOe537[0x11]]!=OxOe537[0x12])?document[OxOe537[0x13]]:document[OxOe537[0x14]];}  ; function clearbrowseredge(obj,Ox597){var Ox598=(Ox597==OxOe537[0x15])?parseInt(horizontal_offset)*-0x1:parseInt(vertical_offset)*-0x1;if(Ox597==OxOe537[0x15]){var Ox599=ie4&&!window[OxOe537[0x16]]?iecompattest()[OxOe537[0x18]]+iecompattest()[OxOe537[0x17]]-0xf:window[OxOe537[0x1a]]+window[OxOe537[0x19]]-0xf; dropmenuobj[OxOe537[0x1c]]=dropmenuobj[OxOe537[0x1b]] ;if(Ox599-dropmenuobj[OxOe537[0x1d]]<dropmenuobj[OxOe537[0x1c]]){ Ox598=dropmenuobj[OxOe537[0x1c]]-obj[OxOe537[0x1b]] ;} ;} else {var Ox599=ie4&&!window[OxOe537[0x16]]?iecompattest()[OxOe537[0x1f]]+iecompattest()[OxOe537[0x1e]]-0xf:window[OxOe537[0x21]]+window[OxOe537[0x20]]-0x12; dropmenuobj[OxOe537[0x1c]]=dropmenuobj[OxOe537[0x22]] ;if(Ox599-dropmenuobj[OxOe537[0x23]]<dropmenuobj[OxOe537[0x1c]]){ Ox598=dropmenuobj[OxOe537[0x1c]]+obj[OxOe537[0x22]] ;} ;} ;return Ox598;}  ; function showTooltip(Ox59b,obj,e){if(window[OxOe537[0x24]]){ event[OxOe537[0x25]]=true ;} else {if(e[OxOe537[0x26]]){ e.stopPropagation() ;} ;} ; clearhidetip() ; dropmenuobj=document[OxOe537[0x4]]?document.getElementById(OxOe537[0x27]):tooltipdiv ; dropmenuobj[OxOe537[0x28]]=Ox59b ;if(ie4||ns6){ showhide(dropmenuobj.style,e,OxOe537[0x29],OxOe537[0x2a]) ; dropmenuobj[OxOe537[0x1d]]=getposOffset(obj,OxOe537[0x7]) ; dropmenuobj[OxOe537[0x23]]=getposOffset(obj,OxOe537[0xb]) ; dropmenuobj[OxOe537[0xc]][OxOe537[0x7]]=dropmenuobj[OxOe537[0x1d]]-clearbrowseredge(obj,OxOe537[0x15])+OxOe537[0x2b] ; dropmenuobj[OxOe537[0xc]][OxOe537[0xb]]=dropmenuobj[OxOe537[0x23]]-clearbrowseredge(obj,OxOe537[0x2c])+obj[OxOe537[0x22]]+OxOe537[0x2b] ;} ;}  ; function hidetip(e){if( typeof dropmenuobj!=OxOe537[0x2d]){if(ie4||ns6){ dropmenuobj[OxOe537[0xc]][OxOe537[0xe]]=OxOe537[0x2a] ;} ;} ;}  ; function delayhidetip(){if(ie4||ns6){ delayhide=setTimeout(OxOe537[0x2e],disappeardelay) ;} ;}  ; function clearhidetip(){if( typeof delayhide!=OxOe537[0x2d]){ clearTimeout(delayhide) ;} ;}  ;
		</script>
		<style>
			INPUT { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; FONT-SIZE: 8pt; VERTICAL-ALIGN: middle; BORDER-LEFT: black 1px solid; CURSOR: pointer; BORDER-BOTTOM: black 1px solid; FONT-FAMILY: MS Sans Serif }
			A:link { COLOR: #000099 }
			A:visited { COLOR: #000099 }
			A:active { COLOR: #000099 }
			A:hover { COLOR: darkred }
			#tooltipdiv{
			position:absolute;
			padding: 2px;
			border:1px solid black;
			font:menu;
			z-index:100;
			}
		</style>
	</HEAD>
	<body bottommargin="0" margin="0" marginheight="0" marginwidth="0" style="overflow:auto">
		<form runat="server" enctype="multipart/form-data" ID="Form1">
			<fieldset>
				<legend>
					[[ImageGalleryByBrowsing]]
				</legend>
				<div>
					<asp:Table runat="server"  Width="100%" ID="FoldersAndFiles">
						<asp:TableRow>
							<asp:TableCell Width="20" HorizontalAlign="right">
								<asp:Image runat="server" ImageUrl="../images/openfolder.gif" ID="Image1"></asp:Image>
							</asp:TableCell>
							<asp:TableCell HorizontalAlign="left" ColumnSpan="2">
								<asp:Label runat="server" ID="FolderDescription"></asp:Label>
							</asp:TableCell>
						</asp:TableRow>
					</asp:Table>
				</div>
				<table width="100%" cellspacing="2" cellpadding="0" border="0" align="center">
					<tr>
						<td class="normal" style="padding-left:3px">
							[[Size]]: <asp:DropDownList id="cbThumbSize" runat="server" AutoPostBack="True"></asp:DropDownList>
							[[Columns]]: <asp:DropDownList id="cbColumns" runat="server" AutoPostBack="True"></asp:DropDownList>
							[[Rows]]: <asp:DropDownList id="cbRows" runat="server" AutoPostBack="True"></asp:DropDownList>
							[[Type]]: <asp:DropDownList id="cbTypes" runat="server" AutoPostBack="True"></asp:DropDownList>
						</td>
					<tr>
						<td class="normal" style="padding-left:3px">
							<asp:Panel id="uploadpanel" runat="server" Font-Name="MS Sans Serif"  Font-Size="9pt" Visible="False">
  								<asp:label CssClass="normal" id="Label_PictureUpload" runat="server">:&nbsp;</asp:label>
  								<input id="myuploadFile" size="20" type="file" runat="server" name="myuploadFile" />&nbsp;
								<asp:button id="uploadButton" runat="server" />&nbsp;
								<asp:Label id="uploadResult" runat="server"></asp:Label>
							</asp:Panel>
						</td>
					</tr>
					<tr>
						<td>
							<CC1:ThumbList id="ThumbList1" runat="server"></CC1:ThumbList>
						</td>
					</tr>
				</table>
			</fieldset>
			<p align=right>
				<BUTTON type="reset" onclick="cancel()">[[Cancel]] </BUTTON>
			</p>
		</form>
	</body>
</HTML>
