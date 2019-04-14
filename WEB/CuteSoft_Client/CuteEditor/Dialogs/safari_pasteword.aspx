<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<HTML>
	<head>
		<title>[[PasteWord]] 
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
		<link rel="stylesheet" href='Safari_style.css'>
		<script language="javascript">
			var OxOb101=["availWidth","availHeight","onload","contentWindow","htmlSource","designMode","document","on","contentEditable","body","fontFamily","style","Tahoma","fontSize","11px","color","black","background","white","innerHTML","length","dialogArguments","opener","editor","editdoc","Delete","","\x3C$1B\x3E ","\x3C$1I\x3E ","\x3CP\x3E","\x0A\x3CT","\x3CTD\x3E","\x0A\x3C/TR\x3E","\x3C/TR\x3E"]; window.resizeTo(0x1c2,0x190) ; window.moveTo((screen[OxOb101[0x0]]-0x258)/0x2,(screen[OxOb101[0x1]]-0x190)/0x2) ; window.focus() ; window[OxOb101[0x2]]=function (){var iframe=document.getElementById(OxOb101[0x4])[OxOb101[0x3]]; iframe[OxOb101[0x6]][OxOb101[0x5]]=OxOb101[0x7] ; iframe[OxOb101[0x6]][OxOb101[0x9]][OxOb101[0x8]]=true ; iframe[OxOb101[0x6]][OxOb101[0x9]][OxOb101[0xb]][OxOb101[0xa]]=OxOb101[0xc] ; iframe[OxOb101[0x6]][OxOb101[0x9]][OxOb101[0xb]][OxOb101[0xd]]=OxOb101[0xe] ; iframe[OxOb101[0x6]][OxOb101[0x9]][OxOb101[0xb]][OxOb101[0xf]]=OxOb101[0x10] ; iframe[OxOb101[0x6]][OxOb101[0x9]][OxOb101[0xb]][OxOb101[0x11]]=OxOb101[0x12] ; iframe.focus() ;}  ; function insertContent(){var iframe=document.getElementById(OxOb101[0x4])[OxOb101[0x3]];var Ox4db=iframe[OxOb101[0x6]][OxOb101[0x9]][OxOb101[0x13]];if(Ox4db&&Ox4db[OxOb101[0x14]]>0x0){var obj=window[OxOb101[0x16]][OxOb101[0x15]];var editor=obj[OxOb101[0x17]];var editdoc=obj[OxOb101[0x18]]; editdoc.execCommand(OxOb101[0x19],false,OxOb101[0x1a]) ; editor.PasteHTML(_CleanCode(Ox4db)) ; top.close() ;} ;}  ; function _CleanCode(h){ h=h.replace(/<st1:.*>/g,OxOb101[0x1a]) ; h=h.replace(/<(\/)?strong>/ig,OxOb101[0x1b]) ; h=h.replace(/<(\/)?em>/ig,OxOb101[0x1c]) ; h=h.replace(/<P class=[^>]*>/gi,OxOb101[0x1d]) ; h=h.replace(/<\\?\??xml[^>]>/gi,OxOb101[0x1a]) ; h=h.replace(/<\/?\w+:[^>]*>/gi,OxOb101[0x1a]) ; h=h.replace(/<SPAN[^>]*>/gi,OxOb101[0x1a]) ; h=h.replace(/<\/SPAN>/gi,OxOb101[0x1a]) ; h=h.replace(/<TBODY>/gi,OxOb101[0x1a]) ; h=h.replace(/<\/TBODY>/gi,OxOb101[0x1a]) ; h=h.replace(/<T/gi,OxOb101[0x1e]) ; h=h.replace(/<TD>\n/gi,OxOb101[0x1f]) ; h=h.replace(/<\/TR>/gi,OxOb101[0x20]) ; h=h.replace(/<\/TR>\n/gi,OxOb101[0x21]) ;return h;}  ;
		</script>
	</HEAD>
	<body>
		<table border="0" cellpadding="0" cellspacing="2" align="center" height="100%" width="100%">
        <tr>
            <td class="title">[[PasteWord]]</td>
            <td align="right" nowrap="nowrap">
            </td> 
        </tr>
        <tr>
            <td colspan="2">[[UseApple_VtoPaste]]</td>
        </tr>
        <tr>
            <td colspan="2" align="center" height="100%">
                <iframe id="htmlSource" contenteditable="true" src="../template.aspx" scrolling="yes" style="width: 100%; height: 100%;background-color:white;border:1px solid #000;"></iframe>
			</td>
        </tr>
        <tr>
            <td width="50%" align="left"><input type="button" id="insert" name="insert" value="[[Insert]]" onclick="insertContent();" /></td>
            <td width="50%" align="right"><input type="button" value="[[Cancel]]" onclick="window.close();" /></td>
        </tr>
    </table>
</body>
</HTML>
