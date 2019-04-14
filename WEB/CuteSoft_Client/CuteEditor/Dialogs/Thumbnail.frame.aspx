<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.ThumbnailPage" %>
<html>
	<head>
		<title>[[AutoThumbnail]] 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
		<link rel=stylesheet href='style.css' >
		<script src=dialog.js></script><script src=../_shared.js></script>
	</head>
	<body style="margin:0px;border-width:0px;padding:4px;">
		<form runat=server>
			
			<!-- start hidden -->
			<script>
				var OxO87b7=["onload","value","hiddenAction","","hiddenAlert","returnValue"]; window[OxO87b7[0x0]]=reset_hiddens ; function reset_hiddens(){if(document.getElementById(OxO87b7[0x2])[OxO87b7[0x1]]!=OxO87b7[0x3]){if(document.getElementById(OxO87b7[0x4])[OxO87b7[0x1]]){ alert(document.getElementById(OxO87b7[0x4]).value) ;} ; top[OxO87b7[0x5]]=document.getElementById(OxO87b7[0x2])[OxO87b7[0x1]] ; top.close() ;} else { document.getElementById(OxO87b7[0x4])[OxO87b7[0x1]]=OxO87b7[0x3] ;} ;}  ;
			</script>
			<input type="hidden" runat="server" id="hiddenDirectory" NAME="hiddenDirectory"> 
			<input type="hidden" runat="server" id="hiddenFile" NAME="hiddenFile">
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" NAME="hiddenAlert"> 
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" NAME="hiddenAction">
		<table border="0" cellpadding="4" cellspacing="0" width="100%">
			<tr>
				<td>
					<table border="0" cellpadding="1" cellspacing="4" class="normal">
					<tr>
						<td nowrap valign="top">
							<fieldset style="height:80px;">
								<table border="0" cellpadding="1" cellspacing="0" class="normal">
									<tr>
										<td width="60" nowrap>[[Width]]:</td>
										<td>
											<input runat=server id="inp_width" value="80" MaxLength="3" onkeyup="checkConstrains('width');"  ONKEYPRESS="event.returnValue=IsDigit();" style="WIDTH : 70px">
										</td>
										<td rowspan="2" align="right" valign="middle"><img src="../images/locked.gif" id="imgLock" width="25" height="32" alt="Constrained Proportions" /></td>
									</tr>
									<tr>
										<td nowrap>[[Height]]:</td>
										<td>
											<input runat=server id="inp_height" value="80" MaxLength="3" onkeyup="checkConstrains('height');"  ONKEYPRESS="event.returnValue=IsDigit();" style="WIDTH : 70px">
										</td>
									</tr>
									<tr>
										<td colspan="2">
											<input type="checkbox" id="constrain_prop" checked onclick="javascript:toggleConstrains();" />
											Constrain Proportions</td>
									</tr>
								</table>
							</fieldset>		
						</td>
						<td valign="top" nowrap>
							<div style="width:100px; height:80px; vertical-align:top;overflow:hidden;BACKGROUND-COLOR: #ffffff;BORDER-RIGHT: buttonhighlight 1px solid;BORDER-TOP: buttonshadow 1px solid;BORDER-LEFT: buttonshadow 1px solid;BORDER-BOTTOM: buttonhighlight 1px solid;">
								<img id="img_demo" src="../images/1x1.gif">
							</div>
						</td>
					</tr>	
					<tr>
						<td>
							<div style="margin-top:8px;text-align:center">
								<asp:Button ID="okButton" Text="  [[OK]]  " Runat="server" OnClick="thumbnailButton_Click" />
								&nbsp;&nbsp;
								<input type="button" value="[[Cancel]]" onclick="top.returnValue=false;top.close()">
							</div>
						</td>
					</tr>				
				</table>
			</td>
		</tr>
		</table>
	</form>			
	</body>
</html>
	
		<script language="JavaScript">
			var OxO88e8=["dialogArguments","img_demo","inp_width","inp_height","src","width","height","[[ImagetooSmall]]","value","hiddenFile","returnValue","imgLock","constrain_prop","checked","../images/locked.gif","../images/1x1.gif","preview_image","DIV","cssText","style","position:absolute","body","","offsetWidth","offsetHeight","length"];var src=top[OxO88e8[0x0]];var img_demo=document.getElementById(OxO88e8[0x1]);var inp_width=document.getElementById(OxO88e8[0x2]);var inp_height=document.getElementById(OxO88e8[0x3]);var defaultwidth=<%= secset.ThumbnailWidth %>;var defaultheight=<%= secset.ThumbnailHeight %>; SyncToView() ; function SyncToView(){if(src){var Oxb9= new Image(); Oxb9[OxO88e8[0x4]]=src ; img_demo[OxO88e8[0x4]]=src ;var p1=parseInt(Oxb9[OxO88e8[0x5]]/defaultwidth);var Ox317=parseInt(Oxb9[OxO88e8[0x6]]/defaultheight);if(p1>Ox317){if(Oxb9[OxO88e8[0x5]]<defaultwidth){ alert(OxO88e8[0x7]) ; inp_width[OxO88e8[0x8]]=Oxb9[OxO88e8[0x5]] ; inp_height[OxO88e8[0x8]]=Oxb9[OxO88e8[0x6]] ;} else { inp_width[OxO88e8[0x8]]=defaultwidth ;var Ox2e2=parseInt(defaultwidth*Oxb9[OxO88e8[0x6]]/Oxb9.width); inp_height[OxO88e8[0x8]]=Ox2e2 ;} ;} else {if(Oxb9[OxO88e8[0x6]]<defaultheight){ alert(OxO88e8[0x7]) ; inp_width[OxO88e8[0x8]]=Oxb9[OxO88e8[0x5]] ; inp_height[OxO88e8[0x8]]=Oxb9[OxO88e8[0x6]] ;} else { inp_height[OxO88e8[0x8]]=defaultheight ;var Ox81=parseInt(defaultwidth*Oxb9[OxO88e8[0x5]]/Oxb9.height); inp_width[OxO88e8[0x8]]=Ox81 ;} ;} ; document.getElementById(OxO88e8[0x9])[OxO88e8[0x8]]=src ; do_preview() ;} ;}  ; function insert_link(){ top[OxO88e8[0xa]]=arr ; top.close() ;}  ; function toggleConstrains(){var Ox5b2=document.getElementById(OxO88e8[0xb]);var Ox5b3=document.getElementById(OxO88e8[0xc]);if(Ox5b3[OxO88e8[0xd]]){ Ox5b2[OxO88e8[0x4]]=OxO88e8[0xe] ; checkConstrains(OxO88e8[0x5]) ;} else { Ox5b2[OxO88e8[0x4]]=OxO88e8[0xf] ;} ;}  ;var checkingConstrains=false; function checkConstrains(Ox197){if(checkingConstrains){return ;} ; checkingConstrains=true ;try{var Ox5b3=document.getElementById(OxO88e8[0xc]);if(Ox5b3[OxO88e8[0xd]]){var Ox69a=document.getElementById(OxO88e8[0x10]);if(Ox69a){var div=document.createElement(OxO88e8[0x11]); div[OxO88e8[0x13]][OxO88e8[0x12]]=OxO88e8[0x14] ; document[OxO88e8[0x15]].appendChild(div) ; div.appendChild(Ox69a) ; Ox69a.removeAttribute(OxO88e8[0x5]) ; Ox69a.removeAttribute(OxO88e8[0x6]) ; Ox69a[OxO88e8[0x13]][OxO88e8[0x5]]=OxO88e8[0x16] ; Ox69a[OxO88e8[0x13]][OxO88e8[0x6]]=OxO88e8[0x16] ; original_width=Ox69a[OxO88e8[0x17]] ; original_height=Ox69a[OxO88e8[0x18]] ; div.removeNode(true) ;} else {var Ox5b6= new Image(); Ox5b6[OxO88e8[0x4]]=src ; original_width=Ox5b6[OxO88e8[0x5]] ; original_height=Ox5b6[OxO88e8[0x6]] ;} ;if((original_width>0x0)&&(original_height>0x0)){ width=inp_width[OxO88e8[0x8]] ; height=inp_height[OxO88e8[0x8]] ;if(Ox197==OxO88e8[0x5]){if(width[OxO88e8[0x19]]==0x0||isNaN(width)){ inp_width[OxO88e8[0x8]]=OxO88e8[0x16] ; inp_height[OxO88e8[0x8]]=OxO88e8[0x16] ;} else { height=parseInt(width*original_height/original_width) ; inp_height[OxO88e8[0x8]]=height ;} ;} ;if(Ox197==OxO88e8[0x6]){if(height[OxO88e8[0x19]]==0x0||isNaN(height)){ inp_width[OxO88e8[0x8]]=OxO88e8[0x16] ; inp_height[OxO88e8[0x8]]=OxO88e8[0x16] ;} else { width=parseInt(height*original_width/original_height) ; inp_width[OxO88e8[0x8]]=width ;} ;} ;} ;} ; do_preview() ;} finally{ checkingConstrains=false ;} ;}  ; function do_preview(){ img_demo[OxO88e8[0x5]]=inp_width[OxO88e8[0x8]] ; img_demo[OxO88e8[0x6]]=inp_height[OxO88e8[0x8]] ;}  ;	
			
		</script>
