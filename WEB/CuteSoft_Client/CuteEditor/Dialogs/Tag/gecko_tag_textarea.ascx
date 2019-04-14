<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>Textarea</legend>
	<table class="normal">
		<tr>
			<td width="60">[[Name]]:</td>
			<td><input type="text" id="inp_name" style="width:100px"></td>
		</tr>
		<tr>
			<td>[[Columns]]:</td>
			<td><input type="text" id="inp_cols" style="width:100px" onkeypress="return IsDigit(event);"></td>
		</tr>
		<tr>
			<td>[[Rows]]:</td>
			<td><input type="text" id="inp_rows" style="width:100px" onkeypress="return IsDigit(event);"></td>
		</tr>
		<tr>
			<td>[[Value]]:</td>
			<td><textarea rows="2" style="width:258px" id="inp_value"></textarea></td>
		</tr>
		<tr>
			<td>[[Wrap]]:</td>
			<td>
				<SELECT id="sel_Wrap" NAME="sel_Wrap">
					<OPTION value="">Default</OPTION>
					<OPTION value="off">off</OPTION>
					<OPTION value="virtual">virtual</OPTION>
					<OPTION value="physical">physical</OPTION>
				</SELECT>
			</td>		
		</tr>
		<tr>
			<td>[[CssClass]]:</td>
			<td><input type="text" id="inp_class" style="width:100px"></td>
		</tr>
		<tr>
			<td width="60">[[ID]]:</td>
			<td><input type="text" id="inp_id" style="width:100px"></td>
		</tr>
		<tr>
			
			<td nowrap>[[AccessKey]]:</td>
			<td>
				<input type="text" id="inp_access" size="1" maxlength=1>
		</tr>
		<tr>
			<td>[[TabIndex]]:</td>
			<td><input type="text" id="inp_index" size="5" value="" maxlength=5 onkeypress="return IsDigit(event);">		
			</td>
		</tr>
		<tr>
			<td>
			</td>
			<td><input type="checkbox" id="inp_Disabled"><label for="inp_Disabled">[[Disabled]]</label>
			</td>
		</tr>
		<tr>
			<td>
			</td>
			<td><input type="checkbox" id="inp_Readonly"><label for="inp_Readonly">[[Readonly]]</label>
			</td>
		</tr>
	</table>
</fieldset>

<script>

var OxOc953=["inp_name","inp_id","inp_cols","inp_rows","inp_value","inp_class","inp_Disabled","inp_Readonly","sel_Wrap","inp_index","inp_access","name","value","id","tabIndex","","className","cols","rows","disabled","checked","readOnly","wrap","accessKey","class"];var inp_name=document.getElementById(OxOc953[0x0]);var inp_id=document.getElementById(OxOc953[0x1]);var inp_cols=document.getElementById(OxOc953[0x2]);var inp_rows=document.getElementById(OxOc953[0x3]);var inp_value=document.getElementById(OxOc953[0x4]);var inp_class=document.getElementById(OxOc953[0x5]);var inp_Disabled=document.getElementById(OxOc953[0x6]);var inp_Readonly=document.getElementById(OxOc953[0x7]);var sel_Wrap=document.getElementById(OxOc953[0x8]);var inp_index=document.getElementById(OxOc953[0x9]);var inp_access=document.getElementById(OxOc953[0xa]); function SyncToView(){ inp_name[OxOc953[0xc]]=element[OxOc953[0xb]] ; inp_id[OxOc953[0xc]]=element[OxOc953[0xd]] ; inp_value[OxOc953[0xc]]=element[OxOc953[0xc]] ;if(element[OxOc953[0xe]]<=0x0){ inp_index[OxOc953[0xc]]=OxOc953[0xf] ;} else { inp_class[OxOc953[0xc]]=element[OxOc953[0x10]] ;} ;if(element[OxOc953[0x11]]<=0x0){ inp_cols[OxOc953[0xc]]=OxOc953[0xf] ;} else { inp_cols[OxOc953[0xc]]=element[OxOc953[0x11]] ;} ;if(element[OxOc953[0x12]]<=0x0){ inp_rows[OxOc953[0xc]]=OxOc953[0xf] ;} else { inp_rows[OxOc953[0xc]]=element[OxOc953[0x12]] ;} ; inp_Disabled[OxOc953[0x14]]=element[OxOc953[0x13]] ; inp_Readonly[OxOc953[0x14]]=element[OxOc953[0x15]] ; sel_Wrap[OxOc953[0xc]]=element.getAttribute(OxOc953[0x16]) ;if(element[OxOc953[0xe]]<=0x0){ inp_index[OxOc953[0xc]]=OxOc953[0xf] ;} else { inp_index[OxOc953[0xc]]=element[OxOc953[0xe]] ;} ;if(element[OxOc953[0x17]]){ inp_access[OxOc953[0xc]]=element[OxOc953[0x17]] ;} ;}  ; function SyncTo(){ element[OxOc953[0xb]]=inp_name[OxOc953[0xc]] ; element[OxOc953[0xd]]=inp_id[OxOc953[0xc]] ; element[OxOc953[0xc]]=inp_value[OxOc953[0xc]] ; element.setAttribute(OxOc953[0xc],inp_value.value) ; element[OxOc953[0x10]]=inp_class[OxOc953[0xc]] ; element[OxOc953[0x11]]=inp_cols[OxOc953[0xc]] ; element[OxOc953[0x12]]=inp_rows[OxOc953[0xc]] ; element[OxOc953[0xe]]=inp_index[OxOc953[0xc]] ; element[OxOc953[0x13]]=inp_Disabled[OxOc953[0x14]] ; element[OxOc953[0x15]]=inp_Readonly[OxOc953[0x14]] ; element[OxOc953[0x17]]=inp_access[OxOc953[0xc]] ;try{ element.setAttribute(OxOc953[0x16],sel_Wrap.value) ;} catch(e){ element.removeAttribute(OxOc953[0x16]) ;} ; element[OxOc953[0xe]]=inp_index[OxOc953[0xc]] ;if(element[OxOc953[0x11]]==OxOc953[0xf]){ element.removeAttribute(OxOc953[0x11]) ;} ;if(element[OxOc953[0x12]]==OxOc953[0xf]){ element.removeAttribute(OxOc953[0x12]) ;} ;if(element[OxOc953[0xe]]==OxOc953[0xf]){ element.removeAttribute(OxOc953[0xe]) ;} ;if(element[OxOc953[0x10]]==OxOc953[0xf]){ element.removeAttribute(OxOc953[0x18]) ;} ;if(element[OxOc953[0xd]]==OxOc953[0xf]){ element.removeAttribute(OxOc953[0xd]) ;} ;if(element[OxOc953[0xb]]==OxOc953[0xf]){ element.removeAttribute(OxOc953[0xb]) ;} ;if(element.getAttribute(OxOc953[0x16])==OxOc953[0xf]){ element.removeAttribute(OxOc953[0x16]) ;} ;if(element[OxOc953[0x17]]==OxOc953[0xf]){ element.removeAttribute(OxOc953[0x17]) ;} ;}  ;

</script>
