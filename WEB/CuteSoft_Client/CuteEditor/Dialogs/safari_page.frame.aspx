<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<html>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
	<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
	<link rel=stylesheet href='Safari_style.css' >
	<script src=Gecko_dialog.js></script><script src=../_shared.js></script>
	<body style="border:0px;padding-top:4px;padding-left:4px;padding-right:4px;;margin:0px;overflow:auto;">
		<table border="0" cellspacing="0" cellpadding="2" style="width:100%;">
			<tr>
				<td valign="top">
					<fieldset>
						<legend>[[DocumentPropertyPage]]</legend>
						<div style="height:12px"></div>
						<table border="0" cellpadding="3" cellspacing="0" style="border-collapse:collapse;" class="normal">
							<tr>
								<td>[[Title]]:</td>
								<td colspan="4">
									<input type="text" id="inp_title" style="width:320px">
								</td>
							</tr>
							<tr>
								<td>DOCTYPE:</td>
								<td colspan="4">
									<input type="text" id="inp_doctype" style="width:320px">
								</td>
							</tr>
							<tr>
								<td>[[Description]]:</td>
								<td colspan="4">
									<textarea id="inp_description" rows="3" style="width:320px"></textarea>
								</td>
							</tr>
							<tr>
								<td>[[Keywords]]:</td>
								<td colspan="4">
									<textarea id="inp_keywords" rows="3" style="width:320px"></textarea>
								</td>
							</tr>
							<tr>
								<td>[[HtmlBase]]:</td>
								<td colspan="4"><input type="text" id="inp_htmlbase" style="width:320px"></td>
							</tr>
							<tr>
								<td nowrap>[[PageLanguage]]:</td>
								<td colspan="4">
									<input type="text" id="PageLanguage" name="PageLanguage" size="15" style="WIDTH:320px">
								</td>
							</tr>
							<tr>
								<td nowrap>[[HTMLEncoding]]:</td>
								<td colspan="4">
									<input type="text" id="HTMLEncoding" name="HTMLEncoding" size="15" style="WIDTH:320px">
								</td>
							</tr>
							<tr>
								<td nowrap>[[Backgroundcolor]]:</td>
								<td>
									<input type="text" id="bgcolor" name="bgcolor" size="7" style="WIDTH:57px">	
									<img id="bgcolor_Preview" src="../images/colorpicker.gif" onclick="SelectColor(1);" align="absMiddle">
												
								</td>
								<td width="5"></td>
								<td nowrap>[[ForeColor]]:</td>
								<td>
									<input type="text" id="fontcolor" name="fontcolor" size="7" style="WIDTH:57px">
									<img id="fontcolor_Preview" src="../images/colorpicker.gif" onclick="SelectColor(2);" align="absMiddle">
								</td>
							</tr>							
							<tr>
								<td nowrap>[[TopMargin]]:</td>
								<td>
									<input type="text" id="TopMargin" name="TopMargin" size="7" style="WIDTH:57px"> Pixels
								</td>
								<td width="5"></td>
								<td nowrap>[[BottomMargin]]:</td>
								<td>
									<input type="text" id="BottomMargin" name="BottomMargin" size="7" style="WIDTH:57px"> Pixels
								</td>
							</tr>
							<tr>
								<td nowrap>[[LeftMargin]]:</td>
								<td>
									<input type="text" id="LeftMargin" name="LeftMargin" size="7" style="WIDTH:57px"> Pixels
								</td>
								<td width="5"></td>
								<td nowrap>[[RightMargin]]:</td>
								<td>
									<input type="text" id="RightMargin" name="RightMargin" size="7" style="WIDTH:57px"> Pixels
								</td>
							</tr>
							<tr>
								<td nowrap>[[MarginWidth]]:</td>
								<td>
									<input type="text" id="MarginWidth" name="MarginWidth" size="7" style="WIDTH:57px"> Pixels
								</td>
								<td width="5"></td>
								<td nowrap>[[MarginHeight]]:</td>
								<td>
									<input type="text" id="MarginHeight" name="MarginHeight" size="7" style="WIDTH:57px"> Pixels
								</td>
							</tr>
						</table>
					</fieldset>
				</td>
			</tr>
		</table>
		
		<p align="center">
			<input class="inputbuttoninsert" type="button" value="[[Ok]]" onclick="btnok_click()"
						id="Button1" NAME="Button1">&nbsp;&nbsp;&nbsp; 
			<input class="inputbuttoncancel" type="button" value="[[Cancel]]" onclick="btncc_click()"
								id="Button2" NAME="Button2">
		</p>
	</body>
	<script>
	
	var OxO4e47=["dialogArguments","editor","window","document","DOCTYPE","body","head","backgroundColor","style","color","base","title","innerHTML","","meta","length","name","keywords","content","description","httpEquiv","content-type","content-language","value","inp_doctype","inp_title","inp_description","inp_keywords","fontcolor","fontcolor_Preview","bgcolor","bgcolor_Preview","topMargin","TopMargin","bottomMargin","BottomMargin","leftMargin","LeftMargin","rightMargin","RightMargin","marginWidth","MarginWidth","marginHeight","MarginHeight","PageLanguage","HTMLEncoding","href","inp_htmlbase","[[ValidNumber]]","Please enter a valid color number.","lastChild","META ","=\x22","\x22 CONTENT=\x22","\x22","\x3CBASE href=\x22","\x22 target=_blank\x3E","parentNode","http-equiv","Content-Type","Content-Language","returnValue","../colorpicker.aspx","width=600,height=400,resizable=1,toolbars=0,menubar=0,status=0"]; window.resizeTo(0x1ea,0x203) ;var obj=top[OxO4e47[0x0]];var editor=obj[OxO4e47[0x1]];var editwin=obj[OxO4e47[0x2]];var editdoc=obj[OxO4e47[0x3]];var DOCTYPE=obj[OxO4e47[0x4]];var body=editdoc.getElementsByTagName(OxO4e47[0x5]).item(0x0);var head=obj[OxO4e47[0x6]];var body_bgcolor=editdoc[OxO4e47[0x5]][OxO4e47[0x8]][OxO4e47[0x7]];var body_fontcolor=editdoc[OxO4e47[0x5]][OxO4e47[0x8]][OxO4e47[0x9]];var htmlbase=editdoc.getElementsByTagName(OxO4e47[0xa]).item(0x0);var str_title=editdoc.getElementsByTagName(OxO4e47[0xb])[0x0]; str_title=str_title?str_title[OxO4e47[0xc]]:OxO4e47[0xd] ;var str_keywords=OxO4e47[0xd];var str_description=OxO4e47[0xd];var str_HTMLEncoding=OxO4e47[0xd];var str_PageLanguage=OxO4e47[0xd];var str_BaseHref=OxO4e47[0xd];var str_DOCTYPE=OxO4e47[0xd];var metas=editdoc.getElementsByTagName(OxO4e47[0xe]);for(var m=0x0;m<metas[OxO4e47[0xf]];m++){if(metas[m][OxO4e47[0x10]].toLowerCase()==OxO4e47[0x11]){ str_keywords=metas[m][OxO4e47[0x12]] ;} ;if(metas[m][OxO4e47[0x10]].toLowerCase()==OxO4e47[0x13]){ str_description=metas[m][OxO4e47[0x12]] ;} ;if(metas[m][OxO4e47[0x14]].toLowerCase()==OxO4e47[0x15]){ str_HTMLEncoding=metas[m][OxO4e47[0x12]] ;} ;if(metas[m][OxO4e47[0x14]].toLowerCase()==OxO4e47[0x16]){ str_PageLanguage=metas[m][OxO4e47[0x12]] ;} ;} ; document.getElementById(OxO4e47[0x18])[OxO4e47[0x17]]=obj[OxO4e47[0x4]] ; document.getElementById(OxO4e47[0x19])[OxO4e47[0x17]]=str_title ; document.getElementById(OxO4e47[0x1a])[OxO4e47[0x17]]=str_description ; document.getElementById(OxO4e47[0x1b])[OxO4e47[0x17]]=str_keywords ; document.getElementById(OxO4e47[0x1c])[OxO4e47[0x17]]=body_fontcolor ; document.getElementById(OxO4e47[0x1d])[OxO4e47[0x8]][OxO4e47[0x7]]=body_fontcolor ; document.getElementById(OxO4e47[0x1e])[OxO4e47[0x17]]=body_bgcolor ; document.getElementById(OxO4e47[0x1f])[OxO4e47[0x8]][OxO4e47[0x7]]=body_bgcolor ;if(body[OxO4e47[0x20]]){ document.getElementById(OxO4e47[0x21])[OxO4e47[0x17]]=body[OxO4e47[0x20]] ;} ;if(body[OxO4e47[0x22]]){ document.getElementById(OxO4e47[0x23])[OxO4e47[0x17]]=body[OxO4e47[0x22]] ;} ;if(body[OxO4e47[0x24]]){ document.getElementById(OxO4e47[0x25])[OxO4e47[0x17]]=body[OxO4e47[0x24]] ;} ;if(body[OxO4e47[0x26]]){ document.getElementById(OxO4e47[0x27])[OxO4e47[0x17]]=body[OxO4e47[0x26]] ;} ;if(body[OxO4e47[0x28]]){ document.getElementById(OxO4e47[0x29])[OxO4e47[0x17]]=body[OxO4e47[0x28]] ;} ;if(body[OxO4e47[0x2a]]){ document.getElementById(OxO4e47[0x2b])[OxO4e47[0x17]]=body[OxO4e47[0x2a]] ;} ; document.getElementById(OxO4e47[0x2c])[OxO4e47[0x17]]=str_PageLanguage ; document.getElementById(OxO4e47[0x2d])[OxO4e47[0x17]]=str_HTMLEncoding ;if(htmlbase){ document.getElementById(OxO4e47[0x2f])[OxO4e47[0x17]]=htmlbase[OxO4e47[0x2e]] ;} ; function btnok_click(){try{ body[OxO4e47[0x20]]=document.getElementById(OxO4e47[0x21])[OxO4e47[0x17]] ; body[OxO4e47[0x22]]=document.getElementById(OxO4e47[0x23])[OxO4e47[0x17]] ; body[OxO4e47[0x24]]=document.getElementById(OxO4e47[0x25])[OxO4e47[0x17]] ; body[OxO4e47[0x26]]=document.getElementById(OxO4e47[0x27])[OxO4e47[0x17]] ;if(document.getElementById(OxO4e47[0x29])[OxO4e47[0x17]]){ body[OxO4e47[0x28]]=document.getElementById(OxO4e47[0x29])[OxO4e47[0x17]] ;} ;if(document.getElementById(OxO4e47[0x2b])[OxO4e47[0x17]]){ body[OxO4e47[0x2a]]=document.getElementById(OxO4e47[0x2b])[OxO4e47[0x17]] ;} ;} catch(er){ alert(OxO4e47[0x30]) ;return ;} ; str_DOCTYPE=document.getElementById(OxO4e47[0x18])[OxO4e47[0x17]] ; body_fontcolor=document.getElementById(OxO4e47[0x1c])[OxO4e47[0x17]] ; body_bgcolor=document.getElementById(OxO4e47[0x1e])[OxO4e47[0x17]] ; str_title=document.getElementById(OxO4e47[0x19])[OxO4e47[0x17]] ; str_description=document.getElementById(OxO4e47[0x1a])[OxO4e47[0x17]] ; str_keywords=document.getElementById(OxO4e47[0x1b])[OxO4e47[0x17]] ; str_PageLanguage=document.getElementById(OxO4e47[0x2c])[OxO4e47[0x17]] ; str_HTMLEncoding=document.getElementById(OxO4e47[0x2d])[OxO4e47[0x17]] ; str_BaseHref=document.getElementById(OxO4e47[0x2f])[OxO4e47[0x17]] ;try{ editdoc[OxO4e47[0x5]][OxO4e47[0x8]][OxO4e47[0x7]]=body_bgcolor ; editdoc[OxO4e47[0x5]][OxO4e47[0x8]][OxO4e47[0x9]]=body_fontcolor ;} catch(er){ alert(OxO4e47[0x31]) ;return ;} ;var metas=head.getElementsByTagName(OxO4e47[0xe]);var Ox5dc=null;var Ox5dd=null;var Ox5de=null;var Ox5df=null;var Oxb1=head.getElementsByTagName(OxO4e47[0xb])[0x0];if(Oxb1){while(node=Oxb1[OxO4e47[0x32]]){ Oxb1.removeChild(node) ;} ;} else { Oxb1=editdoc.createElement(OxO4e47[0xb]) ; head.appendChild(Oxb1) ;} ; Oxb1.appendChild(editdoc.createTextNode(str_title)) ;if(str_title){ editdoc[OxO4e47[0xb]]=str_title ;} else { editdoc[OxO4e47[0xb]]=OxO4e47[0xd] ;} ;for(var m=0x0;m<metas[OxO4e47[0xf]];m++){if(metas[m][OxO4e47[0x10]].toLowerCase()==OxO4e47[0x11]){ Ox5dc=metas[m] ;} ;if(metas[m][OxO4e47[0x10]].toLowerCase()==OxO4e47[0x13]){ Ox5dd=metas[m] ;} ;if(metas[m][OxO4e47[0x14]].toLowerCase()==OxO4e47[0x15]){ Ox5de=metas[m] ;} ;if(metas[m][OxO4e47[0x14]].toLowerCase()==OxO4e47[0x16]){ Ox5df=metas[m] ;} ;} ; function Ox5e0(Oxb6,name,Ox4db){var Ox67c=editdoc.createElement(OxO4e47[0x33]+Oxb6+OxO4e47[0x34]+name+OxO4e47[0x35]+Ox4db+OxO4e47[0x36]); head.appendChild(Ox67c) ;}  ;if(htmlbase){try{ head.removeChild(htmlbase) ;} catch(er){ alert(htmlbase.href) ;} ; htmlbase=null ;} ;if(!htmlbase&&str_BaseHref){var Ox359=editdoc.createElement(OxO4e47[0x37]+str_BaseHref+OxO4e47[0x38]); head.appendChild(Ox359) ;} ;if(Ox5dc){ Ox5dc[OxO4e47[0x39]].removeChild(Ox5dc) ; Ox5dc=null ;} ;if(!Ox5dc&&str_keywords){ Ox5e0(OxO4e47[0x10],OxO4e47[0x11],str_keywords) ;} ;if(Ox5dd){ Ox5dd[OxO4e47[0x39]].removeChild(Ox5dd) ; Ox5dd=null ;} ;if(!Ox5dd&&str_description){ Ox5e0(OxO4e47[0x10],OxO4e47[0x13],str_description) ;} ;if(Ox5de){ Ox5de[OxO4e47[0x39]].removeChild(Ox5de) ; Ox5de=null ;} ;if(!Ox5de&&str_HTMLEncoding){ Ox5e0(OxO4e47[0x3a],OxO4e47[0x3b],str_HTMLEncoding) ;} ;if(Ox5df){ Ox5df[OxO4e47[0x39]].removeChild(Ox5df) ; Ox5df=null ;} ;if(!Ox5df&&str_PageLanguage){ Ox5e0(OxO4e47[0x3a],OxO4e47[0x3c],str_PageLanguage) ;} ; top[OxO4e47[0x3d]]=str_DOCTYPE ; top.close() ;}  ; function btncc_click(){ top[OxO4e47[0x3d]]=false ; top.close() ;}  ; function SelectColor(n){var Ox567=OxO4e47[0x3e];if(n==0x1){ showModalDialog(Ox567,null,OxO4e47[0x3f],function (Ox2dc,Ox18d){if(Ox18d[OxO4e47[0x3d]]){ document.getElementById(OxO4e47[0x1e])[OxO4e47[0x17]]=Ox18d[OxO4e47[0x3d]].toUpperCase() ; document.getElementById(OxO4e47[0x1f])[OxO4e47[0x8]][OxO4e47[0x7]]=Ox18d[OxO4e47[0x3d]] ;} ;} ) ;} else { showModalDialog(Ox567,null,OxO4e47[0x3f],function (Ox2dc,Ox18d){if(Ox18d[OxO4e47[0x3d]]){ document.getElementById(OxO4e47[0x1c])[OxO4e47[0x17]]=Ox18d[OxO4e47[0x3d]].toUpperCase() ; document.getElementById(OxO4e47[0x1d])[OxO4e47[0x8]][OxO4e47[0x7]]=Ox18d[OxO4e47[0x3d]] ;} ;} ) ;} ;}  ;
	</script>
</html>
