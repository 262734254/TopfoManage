<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[Input]]</legend>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Name]]:</td>
			<td><input type="text" id="inp_name" style="width:100px"></td>
			<td style='width:60px'>[[ID]]:</td>
			<td><input type="text" id="inp_id" style="width:100px"></td>
		</td>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Type]]:</td>
			<td><input type="text" id="inp_type" readonly="true" disabled="true" style="width:100px"></td>
			<td style='width:60px'><label for="inp_checked">[[Checked]]</label>:</td>
			<td><input type="checkbox" id="inp_checked"><label for="inp_checked">[[Checked]]</label></td>
		</td>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Value]]:</td>
			<td><input type="text" id="inp_value" style="width:268px"></td>
			<td></td>
		</tr>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[CssClass]]:</td>
			<td><input type="text" id="inp_class" style="width:268px"></td>
			<td></td>
		</tr>
	</table>
</fieldset>

<script src=Gecko_dialog.js></script><script src=../_shared.js></script>

<script>

var OxOf7b8=["inp_name","inp_id","inp_type","inp_checked","inp_value","inp_class","name","value","id","type","checked","className"];var inp_name=document.getElementById(OxOf7b8[0x0]);var inp_id=document.getElementById(OxOf7b8[0x1]);var inp_type=document.getElementById(OxOf7b8[0x2]);var inp_checked=document.getElementById(OxOf7b8[0x3]);var inp_value=document.getElementById(OxOf7b8[0x4]);var inp_class=document.getElementById(OxOf7b8[0x5]); function SyncToView(){ inp_name[OxOf7b8[0x7]]=element[OxOf7b8[0x6]] ; inp_id[OxOf7b8[0x7]]=element[OxOf7b8[0x8]] ; inp_value[OxOf7b8[0x7]]=element[OxOf7b8[0x7]] ; inp_type[OxOf7b8[0x7]]=element[OxOf7b8[0x9]] ; inp_checked[OxOf7b8[0xa]]=element[OxOf7b8[0xa]] ; inp_class[OxOf7b8[0x7]]=element[OxOf7b8[0xb]] ;}  ; function SyncTo(){ element[OxOf7b8[0x6]]=inp_name[OxOf7b8[0x7]] ; element[OxOf7b8[0x8]]=inp_id[OxOf7b8[0x7]] ;if(inp_value[OxOf7b8[0x7]]){ element[OxOf7b8[0x7]]=inp_value[OxOf7b8[0x7]] ;} ; element[OxOf7b8[0xa]]=inp_checked[OxOf7b8[0xa]] ;if(inp_class[OxOf7b8[0x7]]){ element[OxOf7b8[0xb]]=inp_class[OxOf7b8[0x7]] ;} ;}  ;

</script>
