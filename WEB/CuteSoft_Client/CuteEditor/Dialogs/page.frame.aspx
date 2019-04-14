<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<html>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
	<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
	<link rel=stylesheet href='style.css' >
	<script src=dialog.js></script><script src=../_shared.js></script>
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
										<img id="bgcolor_Preview" src="../images/colorpicker.gif" align="absMiddle" style='BEHAVIOR:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
											oncolorchange="bgcolor.value=this.selectedColor; bgcolor.style.backgroundColor=this.selectedColor; bgcolor_Preview.style.backgroundColor=this.selectedColor">
								</td>
								<td width="5"></td>
								<td nowrap>[[ForeColor]]:</td>
								<td>
									<input type="text" id="fontcolor" name="fontcolor" size="7" style="WIDTH:57px">
										<img id="fontcolor_Preview" src="../images/colorpicker.gif" align="absMiddle" style='BEHAVIOR:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
											oncolorchange="fontcolor.value=this.selectedColor; fontcolor.style.backgroundColor=this.selectedColor; fontcolor_Preview.style.backgroundColor=this.selectedColor">
								</td>
							</tr>
							
							<tr>
								<td>[[Backgroundimage]]:</td>
								<td colspan="4">
									<input type="text" id="Backgroundimage" style="width:250px"><button id="btnbrowse">[[Browse]]</button>
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
			<tr>
				<td style="text-align:right;height:36px;padding-top:2px;padding-bottom:2px;padding-right:24px;">
					<button id="btnok" style='width:80px'>[[OK]]</button> &nbsp; <button id="btncc" style='width:80px'>
						[[Cancel]]</button>
				</td>
			</tr>
		</table>
	</body>
	<script>
	
	var OxO67e8=["dialogArguments","editor","window","document","body","head","backgroundColor","style","color","background","title","innerHTML","","meta","length","name","keywords","content","description","httpEquiv","content-type","content-language","DOCTYPE","value","inp_doctype","inp_title","inp_description","inp_keywords","Backgroundimage","fontcolor","fontcolor_Preview","bgcolor","bgcolor_Preview","topMargin","TopMargin","bottomMargin","BottomMargin","leftMargin","LeftMargin","rightMargin","RightMargin","marginWidth","MarginWidth","marginHeight","MarginHeight","PageLanguage","HTMLEncoding","[[ValidNumber]]","Please enter a valid color number.","lastChild","\x3CMETA ","=\x22","\x22 CONTENT=\x22","\x22\x3E","parentNode","http-equiv","Content-Type","Content-Language","SelectImage.Aspx?settinghash=[[_setting_]]\x26file=","\x26[[DNN_Arg]]","[[SelectFileDialogOption]]"];var obj=top[OxO67e8[0x0]];var editor=obj[OxO67e8[0x1]];var editwin=obj[OxO67e8[0x2]];var editdoc=obj[OxO67e8[0x3]];var body=editdoc.getElementsByTagName(OxO67e8[0x4]).item(0x0);var head=obj[OxO67e8[0x5]];var body_bgcolor=editdoc[OxO67e8[0x4]][OxO67e8[0x7]][OxO67e8[0x6]];var body_fontcolor=editdoc[OxO67e8[0x4]][OxO67e8[0x7]][OxO67e8[0x8]];var Backgroundimage=editdoc[OxO67e8[0x4]][OxO67e8[0x9]];var str_title=editdoc.getElementsByTagName(OxO67e8[0xa])[0x0]; str_title=str_title?str_title[OxO67e8[0xb]]:OxO67e8[0xc] ;var str_keywords=OxO67e8[0xc];var str_description=OxO67e8[0xc];var str_HTMLEncoding=OxO67e8[0xc];var str_PageLanguage=OxO67e8[0xc];var str_BaseHref=OxO67e8[0xc];var str_DOCTYPE=OxO67e8[0xc];var metas=editdoc.getElementsByTagName(OxO67e8[0xd]);for(var m=0x0;m<metas[OxO67e8[0xe]];m++){if(metas[m][OxO67e8[0xf]].toLowerCase()==OxO67e8[0x10]){ str_keywords=metas[m][OxO67e8[0x11]] ;} ;if(metas[m][OxO67e8[0xf]].toLowerCase()==OxO67e8[0x12]){ str_description=metas[m][OxO67e8[0x11]] ;} ;if(metas[m][OxO67e8[0x13]].toLowerCase()==OxO67e8[0x14]){ str_HTMLEncoding=metas[m][OxO67e8[0x11]] ;} ;if(metas[m][OxO67e8[0x13]].toLowerCase()==OxO67e8[0x15]){ str_PageLanguage=metas[m][OxO67e8[0x11]] ;} ;} ; document.getElementById(OxO67e8[0x18])[OxO67e8[0x17]]=obj[OxO67e8[0x16]] ; document.getElementById(OxO67e8[0x19])[OxO67e8[0x17]]=str_title ; document.getElementById(OxO67e8[0x1a])[OxO67e8[0x17]]=str_description ; document.getElementById(OxO67e8[0x1b])[OxO67e8[0x17]]=str_keywords ; document.getElementById(OxO67e8[0x1c])[OxO67e8[0x17]]=Backgroundimage ; document.getElementById(OxO67e8[0x1d])[OxO67e8[0x17]]=body_fontcolor ; document.getElementById(OxO67e8[0x1e])[OxO67e8[0x7]][OxO67e8[0x6]]=body_fontcolor ; document.getElementById(OxO67e8[0x1f])[OxO67e8[0x17]]=body_bgcolor ; document.getElementById(OxO67e8[0x20])[OxO67e8[0x7]][OxO67e8[0x6]]=body_bgcolor ;if(body[OxO67e8[0x21]]){ document.getElementById(OxO67e8[0x22])[OxO67e8[0x17]]=body[OxO67e8[0x21]] ;} ;if(body[OxO67e8[0x23]]){ document.getElementById(OxO67e8[0x24])[OxO67e8[0x17]]=body[OxO67e8[0x23]] ;} ;if(body[OxO67e8[0x25]]){ document.getElementById(OxO67e8[0x26])[OxO67e8[0x17]]=body[OxO67e8[0x25]] ;} ;if(body[OxO67e8[0x27]]){ document.getElementById(OxO67e8[0x28])[OxO67e8[0x17]]=body[OxO67e8[0x27]] ;} ;if(body[OxO67e8[0x29]]){ document.getElementById(OxO67e8[0x2a])[OxO67e8[0x17]]=body[OxO67e8[0x29]] ;} ;if(body[OxO67e8[0x2b]]){ document.getElementById(OxO67e8[0x2c])[OxO67e8[0x17]]=body[OxO67e8[0x2b]] ;} ; document.getElementById(OxO67e8[0x2d])[OxO67e8[0x17]]=str_PageLanguage ; document.getElementById(OxO67e8[0x2e])[OxO67e8[0x17]]=str_HTMLEncoding ; function btnok.onclick(){try{ body[OxO67e8[0x21]]=document.getElementById(OxO67e8[0x22])[OxO67e8[0x17]] ; body[OxO67e8[0x23]]=document.getElementById(OxO67e8[0x24])[OxO67e8[0x17]] ; body[OxO67e8[0x25]]=document.getElementById(OxO67e8[0x26])[OxO67e8[0x17]] ; body[OxO67e8[0x27]]=document.getElementById(OxO67e8[0x28])[OxO67e8[0x17]] ;if(document.getElementById(OxO67e8[0x2a])[OxO67e8[0x17]]){ body[OxO67e8[0x29]]=document.getElementById(OxO67e8[0x2a])[OxO67e8[0x17]] ;} ;if(document.getElementById(OxO67e8[0x2c])[OxO67e8[0x17]]){ body[OxO67e8[0x2b]]=document.getElementById(OxO67e8[0x2c])[OxO67e8[0x17]] ;} ;} catch(er){ alert(OxO67e8[0x2f]) ;return ;} ; str_DOCTYPE=document.getElementById(OxO67e8[0x18])[OxO67e8[0x17]] ; body_fontcolor=document.getElementById(OxO67e8[0x1d])[OxO67e8[0x17]] ; body_bgcolor=document.getElementById(OxO67e8[0x1f])[OxO67e8[0x17]] ; str_title=document.getElementById(OxO67e8[0x19])[OxO67e8[0x17]] ; str_description=document.getElementById(OxO67e8[0x1a])[OxO67e8[0x17]] ; str_keywords=document.getElementById(OxO67e8[0x1b])[OxO67e8[0x17]] ; str_PageLanguage=document.getElementById(OxO67e8[0x2d])[OxO67e8[0x17]] ; str_HTMLEncoding=document.getElementById(OxO67e8[0x2e])[OxO67e8[0x17]] ; Backgroundimage=document.getElementById(OxO67e8[0x1c])[OxO67e8[0x17]] ;try{ editdoc[OxO67e8[0x4]][OxO67e8[0x7]][OxO67e8[0x6]]=body_bgcolor ; editdoc[OxO67e8[0x4]][OxO67e8[0x7]][OxO67e8[0x8]]=body_fontcolor ;if(Backgroundimage){ editdoc[OxO67e8[0x4]][OxO67e8[0x9]]=Backgroundimage ;} ;} catch(er){ alert(OxO67e8[0x30]) ;return ;} ;var metas=head.getElementsByTagName(OxO67e8[0xd]);var Ox5dc=null;var Ox5dd=null;var Ox5de=null;var Ox5df=null;var Oxb1=head.getElementsByTagName(OxO67e8[0xa])[0x0];if(Oxb1){while(node=Oxb1[OxO67e8[0x31]]){ Oxb1.removeChild(node) ;} ;} else { Oxb1=editdoc.createElement(OxO67e8[0xa]) ; head.appendChild(Oxb1) ;} ;if(str_title){ editdoc[OxO67e8[0xa]]=str_title ;} else { editdoc[OxO67e8[0xa]]=OxO67e8[0xc] ;} ;for(var m=0x0;m<metas[OxO67e8[0xe]];m++){if(metas[m][OxO67e8[0xf]].toLowerCase()==OxO67e8[0x10]){ Ox5dc=metas[m] ;} ;if(metas[m][OxO67e8[0xf]].toLowerCase()==OxO67e8[0x12]){ Ox5dd=metas[m] ;} ;if(metas[m][OxO67e8[0x13]].toLowerCase()==OxO67e8[0x14]){ Ox5de=metas[m] ;} ;if(metas[m][OxO67e8[0x13]].toLowerCase()==OxO67e8[0x15]){ Ox5df=metas[m] ;} ;} ; function Ox5e0(Oxb6,name,Ox4db){var Ox67c=editdoc.createElement(OxO67e8[0x32]+Oxb6+OxO67e8[0x33]+name+OxO67e8[0x34]+Ox4db+OxO67e8[0x35]); head.appendChild(Ox67c) ;}  ;if(Ox5dc){ Ox5dc[OxO67e8[0x36]].removeChild(Ox5dc) ; Ox5dc=null ;} ;if(!Ox5dc&&str_keywords){ Ox5e0(OxO67e8[0xf],OxO67e8[0x10],str_keywords) ;} ;if(Ox5dd){ Ox5dd[OxO67e8[0x36]].removeChild(Ox5dd) ; Ox5dd=null ;} ;if(!Ox5dd&&str_description){ Ox5e0(OxO67e8[0xf],OxO67e8[0x12],str_description) ;} ;if(Ox5de){ Ox5de[OxO67e8[0x36]].removeChild(Ox5de) ; Ox5de=null ;} ;if(!Ox5de&&str_HTMLEncoding){ Ox5e0(OxO67e8[0x37],OxO67e8[0x38],str_HTMLEncoding) ;} ;if(Ox5df){ Ox5df[OxO67e8[0x36]].removeChild(Ox5df) ; Ox5df=null ;} ;if(!Ox5df&&str_PageLanguage){ Ox5e0(OxO67e8[0x37],OxO67e8[0x39],str_PageLanguage) ;} ; editor[OxO67e8[0x16]]=str_DOCTYPE ; top.close() ;}  ; function btnbrowse.onclick(){var Ox74=showModalDialog(OxO67e8[0x3a]+escape(document.getElementById(OxO67e8[0x1c]).value)+OxO67e8[0x3b],null,OxO67e8[0x3c]);if(Ox74){ document.getElementById(OxO67e8[0x1c])[OxO67e8[0x17]]=Ox74 ;} ;}  ; function btncc.onclick(){ top.close() ;}  ;
	</script>
</html>
