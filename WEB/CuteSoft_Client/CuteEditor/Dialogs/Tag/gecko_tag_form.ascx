<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[InsertForm]]</legend>
	<table class="normal">
		<tr>
			<td width="100">[[Action]]:</td>
			<td><input type="text" id="inp_action" style="width:200px"></td>
		</tr>
		<tr>
			<td>[[Method]]:</td>
			<td>
				<select id="sel_Method" style="width:200px">
					<option value="post">post</option>
					<option value="get">get</option>
				</select>
			</td>
		</tr>
		<tr>
			<td>[[Name]]:</td>
			<td><input type="text" id="inp_name" style="width:200px"></td>
		</tr>
		<tr>
			<td>[[ID]]:</td>
			<td><input type="text" id="inp_id" style="width:200px"></td>
		</tr>
		<tr>
			<td>[[EncodingType]]:</td>
			<td><input type="text" id="inp_encode" style="width:200px"></td>
		</tr>
		<tr>
			<td>[[Target]]:</td>
			<td>				
				<SELECT id="sel_target" NAME="sel_target">
					<OPTION value=""></OPTION>
					<OPTION value="_blank">_blank</OPTION>
					<OPTION value="_self">_self</OPTION>
					<OPTION value="_top">_top</OPTION>
					<OPTION value="_parent">_parent</OPTION>
				</SELECT>
			</td>
		</tr>
	</table>
</fieldset>
<script>

var OxO7685=["inp_name","inp_id","inp_action","sel_Method","inp_encode","sel_target","name","value","id","action","method","encoding","target","","enctype"];var inp_name=document.getElementById(OxO7685[0x0]);var inp_id=document.getElementById(OxO7685[0x1]);var inp_action=document.getElementById(OxO7685[0x2]);var sel_Method=document.getElementById(OxO7685[0x3]);var inp_encode=document.getElementById(OxO7685[0x4]);var sel_target=document.getElementById(OxO7685[0x5]); function SyncToView(){ inp_name[OxO7685[0x7]]=element[OxO7685[0x6]] ; inp_id[OxO7685[0x7]]=element[OxO7685[0x8]] ; inp_action[OxO7685[0x7]]=element[OxO7685[0x9]] ; sel_Method[OxO7685[0x7]]=element[OxO7685[0xa]] ; inp_encode[OxO7685[0x7]]=element[OxO7685[0xb]] ; sel_target[OxO7685[0x7]]=element[OxO7685[0xc]] ;}  ; function SyncTo(){ element[OxO7685[0x6]]=inp_name[OxO7685[0x7]] ; element[OxO7685[0x8]]=inp_id[OxO7685[0x7]] ; element[OxO7685[0x9]]=inp_action[OxO7685[0x7]] ; element[OxO7685[0xa]]=sel_Method[OxO7685[0x7]] ;try{ element[OxO7685[0xb]]=inp_encode[OxO7685[0x7]] ;} catch(e){} ; element[OxO7685[0xc]]=sel_target[OxO7685[0x7]] ;if(element[OxO7685[0xc]]==OxO7685[0xd]){ element.removeAttribute(OxO7685[0xc]) ;} ;if(element[OxO7685[0x9]]==OxO7685[0xd]){ element.removeAttribute(OxO7685[0x9]) ;} ;if(element[OxO7685[0x8]]==OxO7685[0xd]){ element.removeAttribute(OxO7685[0x8]) ;} ;if(element[OxO7685[0x6]]==OxO7685[0xd]){ element.removeAttribute(OxO7685[0x6]) ;} ;if(element[OxO7685[0xb]]==OxO7685[0xd]){ element.removeAttribute(OxO7685[0xe]) ;} ;}  ;

</script>
