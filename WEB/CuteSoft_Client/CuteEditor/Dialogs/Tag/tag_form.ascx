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


var OxOc7a6=["inp_name","inp_id","inp_action","sel_Method","inp_encode","sel_target","Name","value","name","id","action","method","encoding","application/x-www-form-urlencoded","","target"];var inp_name=document.getElementById(OxOc7a6[0x0]);var inp_id=document.getElementById(OxOc7a6[0x1]);var inp_action=document.getElementById(OxOc7a6[0x2]);var sel_Method=document.getElementById(OxOc7a6[0x3]);var inp_encode=document.getElementById(OxOc7a6[0x4]);var sel_target=document.getElementById(OxOc7a6[0x5]); function UpdateState(){}  ; function SyncToView(){if(element[OxOc7a6[0x6]]){ inp_name[OxOc7a6[0x7]]=element[OxOc7a6[0x6]] ;} ;if(element[OxOc7a6[0x8]]){ inp_name[OxOc7a6[0x7]]=element[OxOc7a6[0x8]] ;} ; inp_id[OxOc7a6[0x7]]=element[OxOc7a6[0x9]] ; inp_action[OxOc7a6[0x7]]=element[OxOc7a6[0xa]] ; sel_Method[OxOc7a6[0x7]]=element[OxOc7a6[0xb]] ;if(element[OxOc7a6[0xc]]==OxOc7a6[0xd]){ inp_encode[OxOc7a6[0x7]]=OxOc7a6[0xe] ;} else { inp_encode[OxOc7a6[0x7]]=element[OxOc7a6[0xc]] ;} ; sel_target[OxOc7a6[0x7]]=element[OxOc7a6[0xf]] ;}  ; function SyncTo(element){ element[OxOc7a6[0x8]]=inp_name[OxOc7a6[0x7]] ;if(element[OxOc7a6[0x6]]){ element[OxOc7a6[0x6]]=inp_name[OxOc7a6[0x7]] ;} else {if(element[OxOc7a6[0x8]]){ element.removeAttribute(OxOc7a6[0x8],0x0) ; element[OxOc7a6[0x6]]=inp_name[OxOc7a6[0x7]] ;} else { element[OxOc7a6[0x6]]=inp_name[OxOc7a6[0x7]] ;} ;} ; element[OxOc7a6[0x9]]=inp_id[OxOc7a6[0x7]] ; element[OxOc7a6[0xa]]=inp_action[OxOc7a6[0x7]] ; element[OxOc7a6[0xb]]=sel_Method[OxOc7a6[0x7]] ;try{ element[OxOc7a6[0xc]]=inp_encode[OxOc7a6[0x7]] ;} catch(e){} ; element[OxOc7a6[0xf]]=sel_target[OxOc7a6[0x7]] ;if(element[OxOc7a6[0xf]]==OxOc7a6[0xe]){ element.removeAttribute(OxOc7a6[0xf]) ;} ;if(element[OxOc7a6[0x6]]==OxOc7a6[0xe]){ element.removeAttribute(OxOc7a6[0x6]) ;} ;if(element[OxOc7a6[0xa]]==OxOc7a6[0xe]){ element.removeAttribute(OxOc7a6[0xa]) ;} ;}  ;

</script>
