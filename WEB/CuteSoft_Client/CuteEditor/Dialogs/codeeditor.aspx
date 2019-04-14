<%@ Page Language="C#" ResponseEncoding="Unicode" Inherits="CuteEditor.EditorUtilityPage" %>
<HTML>
	<head>
		<title>[[CodeEditor]] 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="content-type" content="text/html ;charset=Unicode">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
		<link rel="stylesheet" href='style.css'>
		<script src=dialog.js></script><script src=../_shared.js></script>
		<script>
			var OxO67a1=["dialogArguments","editor","window","document","onload","contentWindow","idSource","innerHTML","body","contentEditable","clearAttributes","marginTop","style","4","marginLeft","10","fontFamily","Tahoma","fontSize","11px","color","black","background","white","selection","type","None"];var obj=top[OxO67a1[0x0]];var editor=obj[OxO67a1[0x1]];var editwin=obj[OxO67a1[0x2]];var editdoc=obj[OxO67a1[0x3]]; window[OxO67a1[0x4]]=function (){var iframe=document.getElementById(OxO67a1[0x6])[OxO67a1[0x5]]; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0x7]]=editdoc[OxO67a1[0x8]][OxO67a1[0x7]] ; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0x9]]=true ; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0xa]] ; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0xc]][OxO67a1[0xb]]=OxO67a1[0xd] ; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0xc]][OxO67a1[0xe]]=OxO67a1[0xf] ; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0xc]][OxO67a1[0x10]]=OxO67a1[0x11] ; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0xc]][OxO67a1[0x12]]=OxO67a1[0x13] ; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0xc]][OxO67a1[0x14]]=OxO67a1[0x15] ; iframe[OxO67a1[0x3]][OxO67a1[0x8]][OxO67a1[0xc]][OxO67a1[0x16]]=OxO67a1[0x17] ; iframe.focus() ;}  ; function DoCommand(Ox4e2,Ox4e3){var iframe=document.getElementById(OxO67a1[0x6])[OxO67a1[0x5]];var Ox305=iframe[OxO67a1[0x3]][OxO67a1[0x18]].createRange();var Ox4e4=iframe[OxO67a1[0x3]][OxO67a1[0x18]][OxO67a1[0x19]];var Ox4e5=(Ox4e4==OxO67a1[0x1a]?iframe[OxO67a1[0x3]]:Ox305); Ox4e5.execCommand(Ox4e2,false,Ox4e3) ;}  ; function do_update(){ top.close() ;}  ; function do_cancel(){ top.close() ;}  ; function do_ok(){ top.close() ;}  ;		
			
		</script>
	</HEAD>
	<body>
		<form id="formSearch" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tbody>
					<tr>
						<td style="padding:4px 0 1px 4px">
							<IMG src="../Themes/Custom/images/Cut.gif" onclick="DoCommand('Cut');" Alt="[[Cut]]" class="dialogButton"	onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"> 
							<IMG src="../Themes/Custom/images/Copy.gif" onclick="DoCommand('Copy');" Alt="[[Copy]]" class="dialogButton" onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"> 
							<IMG src="../Themes/Custom/images/Paste.gif" onclick="DoCommand('Paste');" Alt="[[Paste]]" class="dialogButton" onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"> 
							<IMG src="../Themes/Custom/images/Undo.gif" onclick="DoCommand('Undo');" Alt="[[Undo]]" class="dialogButton" onmouseover="CuteEditor_ColorPicker_ButtonOver(this);">
							<IMG src="../Themes/Custom/images/Redo.gif" onclick="DoCommand('Redo');" Alt="[[Redo]]" class="dialogButton" onmouseover="CuteEditor_ColorPicker_ButtonOver(this);">
							<IMG src="../Themes/Custom/images/find.gif" onclick="DoCommand('Find');" Alt="[[Find]]" class="dialogButton" onmouseover="CuteEditor_ColorPicker_ButtonOver(this);">
						</td>
					</tr>
					<tr>
						<td style="HEIGHT: 100%">
							<iframe id="idSource" name="idSource" src="../template.aspx" scrolling="auto" style="WIDTH: 100%; HEIGHT: 100%"></iframe>
						</td>
					</tr>
					<tr>
						<td class="dialogFooter" vAlign="top" align="right" style="PADDING-RIGHT: 13px; PADDING-LEFT: 13px; PADDING-BOTTOM: 7px; PADDING-TOP: 7px">
							<table cellSpacing="0" cellPadding="1">
								<tbody>
									<tr>
										<td width="100%">&#160;
											<input id="inpWrap" start="fileopen" type="checkbox"  CHECKED="true" size="20" value="on" name="inpWrap" /> <span id="txtLang" name="txtLang">Wrap Text</span> 
										</td>
										<td>
											<input type="button" value="[[Update]]" onclick="do_update()">&nbsp;
											<input type="button" value="[[Cancel]]" onclick="do_cancel()">&nbsp;
											<input type="button" value="[[OK]]" onclick="do_ok()">
										</tr>
								</tbody>
							</table>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>