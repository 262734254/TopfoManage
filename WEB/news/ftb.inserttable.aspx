<%@ Page language="c#" %>
<script runat="server">

private void Page_Load(object sender, System.EventArgs e) {
}

</script>
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
<META HTTP-EQUIV="Expires" CONTENT="0">
<title>插入表格</title>
<style>

body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff; 
	width: 100%;
	overflow:hidden;
	border: 0;
}

body,tr,td {
	color: #000000;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10pt;
}
</style>


<script language="javascript">
function returnTable() {
	var arr = new Array();

	arr["width"] = document.getElementById('Width').value;  
	arr["height"] = document.getElementById('Height').value;
	arr["cellpadding"] = document.getElementById('Cellpadding').value;  
	arr["cellspacing"] = document.getElementById('Cellspacing').value;
	arr["border"] = document.getElementById('Border').value;  	

	arr["cols"] = document.getElementById('Columns').value;
	arr["rows"] = document.getElementById('Rows').value;
	arr["valigncells"] = document.getElementById('VAlignCells')[document.getElementById('VAlignCells').selectedIndex].value;
	arr["haligncells"] = document.getElementById('HAlignCells')[document.getElementById('HAlignCells').selectedIndex].value;
	arr["percentcols"] = document.getElementById('PercentCols').checked;	
			 
	window.returnValue = arr;
	window.close();	
}		
</script>		
		<link href="../ioffice.css" type="text/css" rel="stylesheet">														
</HEAD>
<body leftmargin="0" topmargin="0" class="mainbg">
<table width="100%"  border="0" cellspacing="0" cellpadding="0" class="mtitlebg">
  <tr>
    <td valign="bottom"><table width="100%"  border="0" cellspacing="0" cellpadding="0" class="mtitletable">
        <tr>
          <td height="5" colspan="3" class="mtitleline"><img name="" src="" width="0" height="4" alt=""></td>
        </tr>
        <tr>
          <td width="49" align="right" nowrap style="height: 25px"><img src="../images/ri_titleicon.gif" width="26" height="25" align="absmiddle">&nbsp;</td>
          <td nowrap class="mtitle" style="height: 25px">插入表格</td>
          <td width="161" valign="bottom" style="height: 25px"><div align="right"><img src="../images/rs_iconright.gif" width="161" height="23"></div></td>
        </tr>
    </table></td>
  </tr>
</table>
<table width=100% border=0 cellpadding=1 cellspacing=3 class="stable">
<tr><td valign=top>
	<fieldset ><legend>表格</legend>
	<table width=100% height=100% cellpadding=0 cellspacing=0 border=0>
		<tr>
			<td>宽度</td>
			<td><input type=text id="Width" name="Width" value=100 style="width:50px;"></td>
		</tr><tr>
			<td>高度</td>
			<td><input type=text id="Height" name="Height" value=100 style="width:50px;"></td>
		</tr><tr>
			<td>单元格边距</td>
			<td><input type=text id="Cellpadding" name="Cellpadding" style="width:50px;" value=0></td>
		</tr><tr>
			<td>单元格间距</td>
			<td><input type=text id="Cellspacing" name="Cellspacing" style="width:50px;" value=0></td>
		</tr><tr>
			<td>边框粗细</td>
			<td><input type=text id="Border" name="Border" style="width:50px;" value=1></td>
		</tr>
	</table>
	</fieldset>
</td>
<td>&nbsp;&nbsp;</td>

<td valign=top>
	<fieldset ><legend>单元格</legend>
	<table width=100% height=100% cellpadding=0 cellspacing=0 border=0>
		<tr>
			<td>列数</td>
			<td><input type=text id="Columns" name="Columns" style="width:80px;" value=2></td>
		</tr><tr>
			<td>行数</td>
			<td><input type=text id="Rows" name="Rows" style="width:80px;" value=2></td>
		</tr><tr>
			<td>垂直对齐方式</td>
			<td><select id="VAlignCells" name="VAlignCells" style="width:80px;">
					<option>默认</option>
					<option value="top">顶端对齐</option>
					<option value="center">相对垂直居中</option>
					<option value="bottom">相对底边对齐</option>				
				</select>
			</td>
		</tr><tr>
			<td>水平对齐方式</td>
			<td><select id="HAlignCells" name="HAlignCells" style="width:80px;">
					<option>默认</option>
					<option value="left">左对齐</option>
					<option value="center">居中</option>
					<option value="right">右对齐</option>				
				</select>
			</td>
		</tr><tr>		
			<td>平均分配各列</td>
			<td><input type="checkbox" id="PercentCols" name="PercentCols" value="1"></td>			
		</tr>
	</table>
	</fieldset>
</td></tr>
<tr><td colspan=3 align=center>
  <input type="button" onClick="returnTable();return false;" value="插入表格" class="allbutton" onFocus="this.blur();" onMouseOut="javascript:this.style.backgroundImage= 'url(../images/b_bg1.gif)';" onMouseOver="javascript:this.style.backgroundImage= 'url(../images/b_bg.gif)';"></td>
</tr>
</table>

</body>
</html>
