<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<html>
	<head>
		<title>[[InsertAnchor]] 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel=stylesheet href='Safari_style.css' >
		<script src=Gecko_dialog.js></script><script src=../_shared.js></script>
		<script language="JavaScript">
			var OxOaac0=["dialogArguments","editor","window","document","name","value","anchor_name","returnValue","allanchors","options","length","A","","OPTION","text"]; window.resizeTo(0x140,0xfa) ;var obj=top[OxOaac0[0x0]];var editor=obj[OxOaac0[0x1]];var editwin=obj[OxOaac0[0x2]];var editdoc=obj[OxOaac0[0x3]];var name=obj[OxOaac0[0x4]]; function insert_link(){ top[OxOaac0[0x7]]=document.getElementById(OxOaac0[0x6])[OxOaac0[0x5]] ; top.close() ;}  ; function Init(){if(name){ document.getElementById(OxOaac0[0x6])[OxOaac0[0x5]]=name ;} ; updateList() ;}  ; function updateList(){var allanchors=document.getElementById(OxOaac0[0x8]);while(allanchors[OxOaac0[0x9]][OxOaac0[0xa]]!=0x0){ allanchors[OxOaac0[0x9]][0x0]=null ;} ;var Ox538=editdoc.getElementsByTagName(OxOaac0[0xb]);for(var i=0x0;i<Ox538[OxOaac0[0xa]];i++){if(Ox538[i][OxOaac0[0x4]]!=OxOaac0[0xc]){var Ox539=document.createElement(OxOaac0[0xd]); Ox539[OxOaac0[0xe]]=Ox538[i][OxOaac0[0x4]] ; Ox539[OxOaac0[0x5]]=Ox538[i][OxOaac0[0x4]] ; allanchors[OxOaac0[0x9]][allanchors[OxOaac0[0x9]][OxOaac0[0xa]]]=Ox539 ;} ;} ;}  ; function selectAnchor(Ox53b){var allanchors=document.getElementById(OxOaac0[0x8]); editor.FocusDocument() ;var Ox538=editdoc.getElementsByName(Ox53b);if(Ox538[OxOaac0[0xa]]>0x0){var Ox175=editdoc.createRange(); Ox175.selectNode(Ox538[0x0]) ; oSel=editwin.getSelection() ; oSel.removeAllRanges() ; oSel.addRange(Ox175) ;} ; document.getElementById(OxOaac0[0x6])[OxOaac0[0x5]]=Ox53b ;}  ;
		</script>
		<style>
		.btn {border: 1px solid buttonface;padding: 1px;cursor: default;width:14px;height: 12px;vertical-align: middle;}
		select,input,td {font-family: MS Sans Serif; font-size: 9pt; vertical-align: top; cursor: hand;}
		</style>
	</head>
	<body onload="Init();" style="margin:0px;border-width:0px;padding:4px;">
		<table border="0" cellspacing="2" cellpadding="5" width="100%" align="center">
			<tr>
				<td nowrap>
					<div>
						<fieldset style="padding:2px" align="center"><legend>[[InsertAnchor]]</legend>
							<table border="0" cellpadding="5" cellspacing="0">
								<tr>
									<td width="100%">
										<select size="5" name="allanchors" style="width: 255" id="allanchors" onchange="selectAnchor(this.value);"></select>
									</td>
									<td>
									</td>
								</tr>
							</table
							<br><br>
							<table border="0" cellpadding="5" cellspacing="0">
								<tr>
									<td style='vertical-align:middle'>[[Name]]:</td>
									<td style='vertical-align:middle'><input type="text" id="anchor_name" style="width:210"></td>
								</tr>
							</table>
						</fieldset>
					</div>
					<div style="margin-top:8px;width:90%; text-align:center">
						<input class="inputbuttoninsert" type="button" value="[[Insert]]" style="width:80px" onclick="insert_link()">&nbsp;&nbsp;
						<input class="inputbuttoncancel" type="button" value="[[Cancel]]" style="width:80px" onclick="top.close()">
					</div>
				</td>
			</tr>
		</table>
	</body>
</html>
