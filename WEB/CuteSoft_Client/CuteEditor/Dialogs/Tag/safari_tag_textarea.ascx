<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset>
<legend>[[Input]]</legend>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Name]]:</td>
			<td><input type="text" id="inp_name" style="width:100px"></td>
			<td style='width:60px'>[[ID]]:</td>
			<td><input type="text" id="inp_id" style="width:100px"></td>
		</tr>
		<tr>
			<td style='width:60px'>[[Columns]]:</td>
			<td><input type="text" id="inp_cols" style="width:100px"></td>
			<td style='width:60px'>[[Rows]]:</td>
			<td><input type="text" id="inp_rows" style="width:100px"></td>
		</td>
		<tr>
			<td style='width:60px'>[[Value]]:</td>
			<td colspan="3"><textarea rows="4" style="width:300px" id="inp_value"></textarea></td>
		</tr>
		<tr>
			<td>[[CssClass]]:</td>
			<td><input type="text" id="inp_class" style="width:100px"></td>
		</tr>
	</table>
</fieldset>
<script>

var OxOdf00=["inp_name","inp_id","inp_cols","inp_rows","inp_value","inp_class","name","value","id","cols","rows","className","[[ValidNumber]]"];var inp_name=document.getElementById(OxOdf00[0x0]);var inp_id=document.getElementById(OxOdf00[0x1]);var inp_cols=document.getElementById(OxOdf00[0x2]);var inp_rows=document.getElementById(OxOdf00[0x3]);var inp_value=document.getElementById(OxOdf00[0x4]);var inp_class=document.getElementById(OxOdf00[0x5]); function SyncToView(){ inp_name[OxOdf00[0x7]]=element[OxOdf00[0x6]] ; inp_id[OxOdf00[0x7]]=element[OxOdf00[0x8]] ; inp_value[OxOdf00[0x7]]=element[OxOdf00[0x7]] ; inp_cols[OxOdf00[0x7]]=element[OxOdf00[0x9]] ; inp_rows[OxOdf00[0x7]]=element[OxOdf00[0xa]] ; inp_class[OxOdf00[0x7]]=element[OxOdf00[0xb]] ;}  ; function SyncTo(){ element[OxOdf00[0x6]]=inp_name[OxOdf00[0x7]] ; element[OxOdf00[0x8]]=inp_id[OxOdf00[0x7]] ; element[OxOdf00[0x7]]=inp_value[OxOdf00[0x7]] ; element[OxOdf00[0xb]]=inp_class[OxOdf00[0x7]] ;try{ element[OxOdf00[0x9]]=inp_cols[OxOdf00[0x7]] ; element[OxOdf00[0xa]]=inp_rows[OxOdf00[0x7]] ;} catch(er){ alert(OxOdf00[0xc]) ;} ;}  ;

</script>
