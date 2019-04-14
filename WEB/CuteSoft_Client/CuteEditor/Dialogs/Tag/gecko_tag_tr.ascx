<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[EditRow]]</legend>
	<table class="normal">
		<tr>
			<td colspan=2>
				<table class="normal" cellpadding=2 cellspacing=1>
					<tr>
						<td width="80" nowrap>[[Width]] :</td>
						<td><input type="text" id="inp_width" onkeypress="return IsDigit(event);" size="14"></td>
						<td>&nbsp;</td>
						<td width="80" nowrap>[[Height]] :</td>
						<td><input type="text" id="inp_height" onkeypress="return IsDigit(event);" size="14"></td>
					</tr>
					<tr>
						<td nowrap>[[Alignment]]:</td>
						<td>
							<select id="sel_align" style="width:90px">
								<option value="">[[NotSet]]</option>
								<option value="left">[[Left]]</option>
								<option value="center">[[Center]]</option>
								<option value="right">[[Right]]</option>
							</select>
						</td>
						<td></td>
						<td nowrap>[[vertical]] [[Alignment]]:</td>
						<td><select id="sel_valign" style="width:90px">
								<option value="">[[NotSet]]</option>
								<option value="top">[[Top]]</option>
								<option value="middle">[[Middle]]</option>
								<option value="baseline">[[Baseline]]</option>
								<option value="bottom">[[Bottom]]</option>
							</select>
						</td>
					</tr>
					<tr>
						<td nowrap>[[BackgroundColor]]:</td>
						<td><input size="14" type="text" id="inp_bgColor" onclick="SelectColor('inp_bgColor',this);">
						</td>
						<td></td>
						<td nowrap>[[BorderColor]]:</td>
						<td><input size="14" type="text" id="inp_borderColor" onclick="SelectColor('inp_borderColor',this);">
						</td>
					</tr>
					<tr>
						<td nowrap>[[BorderColorLight]]:</td>
						<td><input size="14" type="text" id="inp_borderColorLight" onclick="SelectColor('inp_borderColorLight',this);">
						</td>
						<td></td>
						<td nowrap>[[BorderColorDark]]:</td>
						<td><input size="14" type="text" id="inp_borderColorDark"  onclick="SelectColor('inp_borderColorDark',this);">
						</td>
					</tr>
					<tr>
						<td nowrap>[[CssClass]]:</td>
						<td><input size="14" type="text" id="inp_class"></td>
						<td></td>
						<td valign="middle" nowrap>[[ID]]:</td>
						<td><input type="text" id="inp_id" size="14"></td>
					</tr>
					<tr>
						<td nowrap>[[Title]]:</td>
						<td colspan="4"><textarea id="inp_tooltip" rows="6" cols="53"></textarea></td>
					</tr>
				</table>
			</td>			
		</tr>
	</table>
</fieldset>
<script>

var OxOdc7d=["inp_width","inp_height","sel_align","sel_valign","inp_bgColor","inp_borderColor","inp_borderColorLight","inp_borderColorDark","inp_borderColorlight_Preview","inp_borderColordark_Preview","inp_class","inp_tooltip","inp_id","bgColor","value","backgroundColor","style","borderColor","borderColorLight","borderColorDark","className","width","height","align","vAlign","title","id","[[ValidNumber]]","[[ValidID]]","","valign"];var inp_width=document.getElementById(OxOdc7d[0x0]);var inp_height=document.getElementById(OxOdc7d[0x1]);var sel_align=document.getElementById(OxOdc7d[0x2]);var sel_valign=document.getElementById(OxOdc7d[0x3]);var inp_bgColor=document.getElementById(OxOdc7d[0x4]);var inp_borderColor=document.getElementById(OxOdc7d[0x5]);var inp_borderColorLight=document.getElementById(OxOdc7d[0x6]);var inp_borderColorDark=document.getElementById(OxOdc7d[0x7]);var inp_borderColorlight_Preview=document.getElementById(OxOdc7d[0x8]);var inp_borderColordark_Preview=document.getElementById(OxOdc7d[0x9]);var inp_class=document.getElementById(OxOdc7d[0xa]);var inp_tooltip=document.getElementById(OxOdc7d[0xb]);var inp_id=document.getElementById(OxOdc7d[0xc]); function SyncToView(){if(element[OxOdc7d[0xd]]){ inp_bgColor[OxOdc7d[0xe]]=element[OxOdc7d[0xd]] ; inp_bgColor[OxOdc7d[0x10]][OxOdc7d[0xf]]=inp_bgColor[OxOdc7d[0xe]] ;} ;if(element[OxOdc7d[0x11]]){ inp_borderColor[OxOdc7d[0xe]]=element[OxOdc7d[0x11]] ; inp_borderColor[OxOdc7d[0x10]][OxOdc7d[0xf]]=inp_borderColor[OxOdc7d[0xe]] ;} ;if(element[OxOdc7d[0x12]]){ inp_borderColorLight[OxOdc7d[0xe]]=element[OxOdc7d[0x12]] ; inp_borderColorLight[OxOdc7d[0x10]][OxOdc7d[0xf]]=element[OxOdc7d[0x12]] ; inp_borderColorlight_Preview[OxOdc7d[0x10]][OxOdc7d[0xf]]=element[OxOdc7d[0x12]] ;} ;if(element[OxOdc7d[0x13]]){ inp_borderColorDark[OxOdc7d[0xe]]=element[OxOdc7d[0x13]] ; inp_borderColorDark[OxOdc7d[0x10]][OxOdc7d[0xf]]=element[OxOdc7d[0x7]] ; inp_borderColordark_Preview[OxOdc7d[0x10]][OxOdc7d[0xf]]=element[OxOdc7d[0x7]] ;} ;if(element[OxOdc7d[0x14]]){ inp_class[OxOdc7d[0xe]]=element[OxOdc7d[0x14]] ;} ;if(element[OxOdc7d[0x15]]){ inp_width[OxOdc7d[0xe]]=element[OxOdc7d[0x15]] ;} ;if(element[OxOdc7d[0x16]]){ inp_height[OxOdc7d[0xe]]=element[OxOdc7d[0x16]] ;} ;if(element[OxOdc7d[0x17]]){ sel_align[OxOdc7d[0xe]]=element[OxOdc7d[0x17]] ;} ;if(element[OxOdc7d[0x18]]){ sel_valign[OxOdc7d[0xe]]=element[OxOdc7d[0x18]] ;} ;if(element[OxOdc7d[0x19]]){ inp_tooltip[OxOdc7d[0xe]]=element[OxOdc7d[0x19]] ;} ; inp_id[OxOdc7d[0xe]]=element[OxOdc7d[0x1a]] ;}  ; function SyncTo(){ element[OxOdc7d[0xd]]=inp_bgColor[OxOdc7d[0xe]] ; element[OxOdc7d[0x11]]=inp_borderColor[OxOdc7d[0xe]] ; element[OxOdc7d[0x12]]=inp_borderColorLight[OxOdc7d[0xe]] ; element[OxOdc7d[0x13]]=inp_borderColorDark[OxOdc7d[0xe]] ; element[OxOdc7d[0x14]]=inp_class[OxOdc7d[0xe]] ;try{ element[OxOdc7d[0x15]]=inp_width[OxOdc7d[0xe]] ; element[OxOdc7d[0x16]]=inp_height[OxOdc7d[0xe]] ;} catch(er){ alert(OxOdc7d[0x1b]) ;} ;var Ox535=/[^a-z\d]/i;if(Ox535.test(inp_id.value)){ alert(OxOdc7d[0x1c]) ;return ;} ; element[OxOdc7d[0x17]]=sel_align[OxOdc7d[0xe]] ; element[OxOdc7d[0x1a]]=inp_id[OxOdc7d[0xe]] ; element[OxOdc7d[0x18]]=sel_valign[OxOdc7d[0xe]] ; element[OxOdc7d[0x19]]=inp_tooltip[OxOdc7d[0xe]] ;if(element[OxOdc7d[0xd]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0xd]) ;} ;if(element[OxOdc7d[0x11]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x11]) ;} ;if(element[OxOdc7d[0x12]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x12]) ;} ;if(element[OxOdc7d[0x7]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x7]) ;} ;if(element[OxOdc7d[0x14]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x14]) ;} ;if(element[OxOdc7d[0x17]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x17]) ;} ;if(element[OxOdc7d[0x18]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x1e]) ;} ;if(element[OxOdc7d[0x19]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x19]) ;} ;if(element[OxOdc7d[0x15]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x15]) ;} ;if(element[OxOdc7d[0x16]]==OxOdc7d[0x1d]){ element.removeAttribute(OxOdc7d[0x16]) ;} ;}  ;
</script>
