<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>Textarea</legend>
	<table class="normal">
		<tr>
			<td width="60">[[Name]]:</td>
			<td><input type="text" id="inp_name" style="width:100px"></td>
		</tr>
		<tr>
			<td>[[Columns]]:</td>
			<td><input type="text" id="inp_cols" style="width:100px" onkeypress="event.returnValue=IsDigit();"></td>
		</tr>
		<tr>
			<td>[[Rows]]:</td>
			<td><input type="text" id="inp_rows" style="width:100px" onkeypress="event.returnValue=IsDigit();"></td>
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
			<td><input type="text" id="inp_index" size="5" value="" maxlength=5 onkeypress="event.returnValue=IsDigit();">		
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


var OxOfe9d=["inp_name","inp_id","inp_cols","inp_rows","inp_Disabled","inp_Readonly","sel_Wrap","inp_index","inp_value","inp_access","Name","value","name","id","cols","","rows","disabled","checked","readOnly","wrap","tabIndex","accessKey"];var inp_name=document.getElementById(OxOfe9d[0x0]);var inp_id=document.getElementById(OxOfe9d[0x1]);var inp_cols=document.getElementById(OxOfe9d[0x2]);var inp_rows=document.getElementById(OxOfe9d[0x3]);var inp_Disabled=document.getElementById(OxOfe9d[0x4]);var inp_Readonly=document.getElementById(OxOfe9d[0x5]);var sel_Wrap=document.getElementById(OxOfe9d[0x6]);var inp_index=document.getElementById(OxOfe9d[0x7]);var inp_value=document.getElementById(OxOfe9d[0x8]);var inp_access=document.getElementById(OxOfe9d[0x9]); function UpdateState(){}  ; function SyncToView(){if(element[OxOfe9d[0xa]]){ inp_name[OxOfe9d[0xb]]=element[OxOfe9d[0xa]] ;} ;if(element[OxOfe9d[0xc]]){ inp_name[OxOfe9d[0xb]]=element[OxOfe9d[0xc]] ;} ; inp_id[OxOfe9d[0xb]]=element[OxOfe9d[0xd]] ; inp_value[OxOfe9d[0xb]]=element[OxOfe9d[0xb]] ;if(element[OxOfe9d[0xe]]){if(element[OxOfe9d[0xe]]==0x14){ inp_cols[OxOfe9d[0xb]]=OxOfe9d[0xf] ;} else { inp_cols[OxOfe9d[0xb]]=element[OxOfe9d[0xe]] ;} ;} ;if(element[OxOfe9d[0x10]]){if(element[OxOfe9d[0x10]]==0x2){ inp_rows[OxOfe9d[0xb]]=OxOfe9d[0xf] ;} else { inp_rows[OxOfe9d[0xb]]=element[OxOfe9d[0x10]] ;} ;} ; inp_Disabled[OxOfe9d[0x12]]=element[OxOfe9d[0x11]] ; inp_Readonly[OxOfe9d[0x12]]=element[OxOfe9d[0x13]] ; sel_Wrap[OxOfe9d[0xb]]=element[OxOfe9d[0x14]] ;if(element[OxOfe9d[0x15]]==0x0){ inp_index[OxOfe9d[0xb]]=OxOfe9d[0xf] ;} else { inp_index[OxOfe9d[0xb]]=element[OxOfe9d[0x15]] ;} ;if(element[OxOfe9d[0x16]]){ inp_access[OxOfe9d[0xb]]=element[OxOfe9d[0x16]] ;} ;}  ; function SyncTo(element){ element[OxOfe9d[0xc]]=inp_name[OxOfe9d[0xb]] ;if(element[OxOfe9d[0xa]]){ element[OxOfe9d[0xa]]=inp_name[OxOfe9d[0xb]] ;} else {if(element[OxOfe9d[0xc]]){ element.removeAttribute(OxOfe9d[0xc],0x0) ; element[OxOfe9d[0xa]]=inp_name[OxOfe9d[0xb]] ;} else { element[OxOfe9d[0xa]]=inp_name[OxOfe9d[0xb]] ;} ;} ; element[OxOfe9d[0xd]]=inp_id[OxOfe9d[0xb]] ; element[OxOfe9d[0xb]]=inp_value[OxOfe9d[0xb]] ; element[OxOfe9d[0x15]]=inp_index[OxOfe9d[0xb]] ; element[OxOfe9d[0x11]]=inp_Disabled[OxOfe9d[0x12]] ; element[OxOfe9d[0x13]]=inp_Readonly[OxOfe9d[0x12]] ; element[OxOfe9d[0x16]]=inp_access[OxOfe9d[0xb]] ;if(inp_cols[OxOfe9d[0xb]]==OxOfe9d[0xf]){ element[OxOfe9d[0xe]]=0x14 ;} else { element[OxOfe9d[0xe]]=inp_cols[OxOfe9d[0xb]] ;} ;if(inp_rows[OxOfe9d[0xb]]==OxOfe9d[0xf]){ element[OxOfe9d[0x10]]=0x2 ;} else { element[OxOfe9d[0x10]]=inp_rows[OxOfe9d[0xb]] ;} ;try{ element[OxOfe9d[0x14]]=sel_Wrap[OxOfe9d[0xb]] ;} catch(e){ element.removeAttribute(OxOfe9d[0x14]) ;} ; element[OxOfe9d[0x15]]=inp_index[OxOfe9d[0xb]] ;if(element[OxOfe9d[0x15]]==OxOfe9d[0xf]){ element.removeAttribute(OxOfe9d[0x15]) ;} ;if(element[OxOfe9d[0x16]]==OxOfe9d[0xf]){ element.removeAttribute(OxOfe9d[0x16]) ;} ;}  ;

</script>
