<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<html>
	<head>
		<title>[[Hyperlink_Information]] 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
		<link rel=stylesheet href='gecko_style.css' >
		<script src=gecko_dialog.js></script><script src=../_shared.js></script>
		<style>
		.btn {border: 1px solid buttonface;padding: 1px;cursor: default;width:14px;height: 12px;vertical-align: middle;}
		select,input,td {font-family: MS Sans Serif; font-size: 9pt; vertical-align: top; cursor: pointer;}
		</style>
	</head>
	<body  style="margin:0px;border-width:0px;padding:4px;">
		<table border="0" cellspacing="2" cellpadding="5" width="100%" align="center">
			<tr>
				<td nowrap>
					<div>
					<fieldset>
						<table class="normal">
							<tr>
								<td style="width:60px">[[Url]]:</td>
								<td><input type="text" id="inp_src" style="width:200px"></td>
								<td></td>
							</tr>
							<tr>
								<td style="width:60px">[[Title]]:</td>
								<td colspan="2"><input type="text" id="inp_title" style="width:200px"></td>
							</tr>
							<tr>
								<td style="width:60px">[[Target]]</td>
								<td colspan="2">
									<SELECT id="inp_target" NAME="inp_target">
										<OPTION value="">[[NotSet]]</OPTION>
										<OPTION value="_blank">[[Newwindow]]</OPTION>
										<OPTION value="_self">[[Samewindow]]</OPTION>
										<OPTION value="_top">[[Topmostwindow]]</OPTION>
										<OPTION value="_parent">[[Parentwindow]]</OPTION>
									</SELECT>
								</td>
							</tr>		
						</table>
					</fieldset>
					</div>
					<div style="margin-top:8px;width:60%; text-align:center">
						<input class="inputbuttoninsert" type="button" value="[[Insert]]" style="width:80px" onclick="insert_link()">&nbsp;&nbsp;
						<input class="inputbuttoncancel" type="button" value="[[Cancel]]" style="width:80px" onclick="top.returnValue=false;top.close()">
					</div>
				</td>
			</tr>
		</table>
	</body>
</html>
	
		<script language="JavaScript">
			var OxO480e=["availWidth","availHeight","inp_target","sel_protocol","inp_src","inp_title","dialogArguments","href","value","title","target","returnValue"]; window.resizeTo(0x15e,0xd4) ; window.moveTo((screen[OxO480e[0x0]]-0x15e)/0x2,(screen[OxO480e[0x1]]-0xd4)/0x2) ;var inp_target=document.getElementById(OxO480e[0x2]);var sel_protocol=document.getElementById(OxO480e[0x3]);var inp_src=document.getElementById(OxO480e[0x4]);var inp_title=document.getElementById(OxO480e[0x5]);var obj=top[OxO480e[0x6]];if(obj){if(obj[OxO480e[0x7]]){ inp_src[OxO480e[0x8]]=obj[OxO480e[0x7]] ;} ;if(obj[OxO480e[0x9]]){ inp_title[OxO480e[0x8]]=obj[OxO480e[0x9]] ;} ;if(obj[OxO480e[0xa]]){ inp_target[OxO480e[0x8]]=obj[OxO480e[0xa]] ;} ;} ; function insert_link(){var arr= new Array(); arr[0x0]=inp_src[OxO480e[0x8]] ;if(inp_target[OxO480e[0x8]]){ arr[0x1]=inp_target[OxO480e[0x8]] ;} ;if(inp_title[OxO480e[0x8]]){ arr[0x2]=inp_title[OxO480e[0x8]] ;} ; top[OxO480e[0xb]]=arr ; top.close() ;}  ;
		</script>
