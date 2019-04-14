<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeModify.aspx.cs" Inherits="System_EmployeeModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改会员</title>
    
    <script type="text/javascript"  src="../js/wpCalendar.js"></script>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
        
</head>
<body style=" font-size:10pt;">
    <form id="form1" runat="server">
    <div>
			<p><FONT face="宋体">
					<table style="border-color:#678897; border-style:solid;  border-collapse:collapse; height:600px;"
						borderColor="#004f71" cellSpacing="0" cellPadding="3" width="768" border="1" align="center" class="liangbianlan">
						<TBODY>
						
							
							<div class="title"><h2><p><span><b>修改用户资料</b></span></p></h2></div>
							<tr>
								<td>
									&nbsp;&nbsp;&nbsp;&nbsp; 用户登录名<FONT face="宋体" color="red"><FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
								<td>&nbsp;
									<asp:textbox id="txtLoginName" runat="server" Enabled="false" MaxLength="16" Width="176px"></asp:textbox>
									</td>
							</tr>
							
							<%-- 暂不用 
							<tr>
								<td><FONT face="宋体">&nbsp;&nbsp; 密码提示问题<FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
								<td><FONT face="宋体"><FONT face="宋体" color="#ff0000">&nbsp;
											<asp:textbox id="txtPasswordQuestion" runat="server" MaxLength="50" Width="176px"></asp:textbox>
											<asp:requiredfieldvalidator id="rfvPasswordQuestion" runat="server" ControlToValidate="txtPasswordQuestion"
												ErrorMessage="密码提示问题不能为空" Display="Dynamic"></asp:requiredfieldvalidator>
												<asp:RegularExpressionValidator ID="revPasswordQuestion" runat="server" ControlToValidate="txtPasswordQuestion"
												ErrorMessage="密码查询问题不能少于2个字符" ValidationExpression="^.{2,}$"  Display="Dynamic"></asp:RegularExpressionValidator>
										</FONT></FONT>
								</td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp; 提示问题答案<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
								<td><FONT face="宋体" color="#ff0000">&nbsp;
										<asp:textbox id="txtPasswordAnswer" runat="server" MaxLength="50" Width="176px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvPasswordAnswer" runat="server" 
                                        ControlToValidate="txtPasswordAnswer" ErrorMessage="密码答案不能为空" Display="Dynamic"></asp:requiredfieldvalidator><FONT face="宋体" color="#ff0000">
											<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="txtPasswordAnswer"
												ErrorMessage="密码答案不能少于2个字符" ValidationExpression="^.{2,}$"  Display="Dynamic"></asp:regularexpressionvalidator></FONT></FONT></td>
							</tr>
							--%>
							
							
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 真实姓名<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT>
									</FONT>
								</td>
								<td><FONT face="宋体" color="#ff0000">&nbsp;
										<asp:textbox id="txtEmployeeName" runat="server" MaxLength="20" Width="176px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvMemberName" runat="server" 
                                        ControlToValidate="txtEmployeeName" ErrorMessage="真实姓名不能为空" Display="Dynamic"></asp:requiredfieldvalidator><FONT face="宋体" color="#ff0000">
											<asp:regularexpressionvalidator id="revMemberName" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="真实姓名为2-20个字符"
												ValidationExpression="^[\u4e00-\u9fa5a-zA-Z0-9]{2,50}$"  Display="Dynamic"></asp:regularexpressionvalidator></FONT></FONT></td>
							</tr>
							<tr>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									性别<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT>
								</td>
								<TD >
									<asp:radiobuttonlist id="rblSex" runat="server" RepeatDirection="Horizontal" Height="24px">
										<asp:ListItem Value="False" Selected="True">男</asp:ListItem>
										<asp:ListItem Value="True">女</asp:ListItem>
									</asp:radiobuttonlist></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 呢称<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
								<td>&nbsp;
									<asp:textbox id="txtNickName" runat="server"  MaxLength="20" Width="216px"></asp:textbox>&nbsp;
									<asp:requiredfieldvalidator id="rfvNickName" runat="server" ControlToValidate="txtNickName" ErrorMessage="呢称不能为空"></asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 出生日期<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
								<td>&nbsp;<input id="tbDate" type="text" runat="server" onfocus="showCalendar(this);"  readonly />
									<FONT face="宋体">
									<asp:requiredfieldvalidator id="rfvNickName0" runat="server" 
                                        ControlToValidate="tbDate" ErrorMessage="出生日期不能为空"></asp:requiredfieldvalidator>
				</FONT>
									</td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 证件类型<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
								<td>&nbsp;
									<asp:dropdownlist id="ddlCertificateID" runat="server" DataTextField="CertificateName" DataValueField="CertificateID"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 证件号码<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
								<td>&nbsp;
									<asp:textbox id="txtCertificateNumber" runat="server" MaxLength="20" Width="272px"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvCertificateNumber" runat="server" ControlToValidate="txtCertificateNumber"
										ErrorMessage="证件号码不能为空"></asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<TD >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 详细地址<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT>
								</td>
								<TD >&nbsp;
									<asp:textbox id="txtAddress" runat="server" MaxLength="25"  Width="416px"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="详细地址不能为空"></asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<td><FONT face="宋体"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
											邮编<FONT face="宋体" color="#ff0000"><FONT face="宋体" color="#ff0000">*</FONT></FONT></FONT></FONT></td>
								<td><FONT face="宋体"><FONT face="宋体">&nbsp;
											<asp:textbox id="txtPostCode" runat="server" MaxLength="6" Width="60px"></asp:textbox>
											<asp:requiredfieldvalidator id="rfvPostCode" runat="server" ControlToValidate="txtPostCode" ErrorMessage="邮编不能为空"  Display="Dynamic"></asp:requiredfieldvalidator>
											<asp:regularexpressionvalidator id="revPostCode" runat="server" ControlToValidate="txtPostCode" ErrorMessage="邮编为六位数字"
												ValidationExpression="^\d{6}$"  Display="Dynamic"></asp:regularexpressionvalidator></FONT></FONT></td>
							</tr>
							<tr>
								<td><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 联系电话<FONT face="宋体" color="#ff0000">*</FONT></FONT></td>
								<td><FONT face="宋体">&nbsp; 国家代码
										<asp:textbox id="txtCountryCode" runat="server" MaxLength="10" Width="40px"></asp:textbox>&nbsp;区号
										<asp:textbox id="txtAreaCode" runat="server" MaxLength="4" Width="88px"></asp:textbox>&nbsp;电话
										<asp:textbox id="txtTelPhone" runat="server" MaxLength="13" Width="128px"></asp:textbox>
										<asp:regularexpressionvalidator id="revCountryCode" runat="server" ControlToValidate="txtCountryCode" ErrorMessage="国家代码为'＋'加2-3个数字"
											ValidationExpression="^\+\d{2,}$"  Display="Dynamic"></asp:regularexpressionvalidator>&nbsp;
										<asp:regularexpressionvalidator id="revAreaCode" runat="server" 
                                        ControlToValidate="txtAreaCode" ErrorMessage="区号为3-4个数字"
											ValidationExpression="^\d{0,}$" Display="Dynamic"></asp:regularexpressionvalidator>
										<asp:regularexpressionvalidator id="revTelPhone" runat="server" 
                                        ErrorMessage="电话7~8位(分机加“-”,如xxxxxxxx-xxx)" ControlToValidate="txtTelPhone"
											ValidationExpression="^\d{7,}(-\d{2,8})?$" Display="Dynamic"></asp:regularexpressionvalidator>
									<asp:requiredfieldvalidator id="rfvAddress0" runat="server" 
                                        ControlToValidate="txtAreaCode" ErrorMessage="区号不能为空"></asp:requiredfieldvalidator>
									<asp:requiredfieldvalidator id="rfvAddress1" runat="server" 
                                        ControlToValidate="txtTelPhone" ErrorMessage="电话不能为空"></asp:requiredfieldvalidator></FONT></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 手机</td>
								<td><FONT face="宋体">&nbsp;
											<asp:textbox id="txtMobile" MaxLength="11" runat="server" Width="168px"></asp:textbox>
											<asp:regularexpressionvalidator id="revMoible" runat="server" ControlToValidate="txtMobile" ErrorMessage="手机号码为11个数字"
												ValidationExpression="^\d{11,}$"></asp:regularexpressionvalidator></FONT></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 传真
								</td>
								<td>&nbsp;
										<asp:textbox id="txtFax" runat="server" MaxLength="13" Width="168px"></asp:textbox>
										<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="txtFax" ErrorMessage="传真为7~8位(分机加“-”,如xxxxxxxx-xxx)"
											ValidationExpression="^\d{7,}(-\d{2,8})?$"></asp:regularexpressionvalidator></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 电子邮箱<FONT face="宋体" color="#ff0000">*</FONT></td>
								<td>&nbsp;
										<asp:textbox id="txtEmail" runat="server" MaxLength="50" Width="272px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfcEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="电子邮箱不能为空"  Display="Dynamic"></asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="电子邮箱范例为webmaster@topfo.com"
											ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  Display="Dynamic"></asp:regularexpressionvalidator></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 部门</td>
								<td>&nbsp;
									<asp:dropdownlist id="ddlDept" runat="server" DataTextField="DeptName" DataValueField="DeptID"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 职位</td>
								<td>&nbsp;
									<asp:dropdownlist id="ddlWorkType" runat="server" DataTextField="WorkTypeName" DataValueField="WorkType"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 学历</td>
								<td>&nbsp;
									<asp:dropdownlist id="ddlDegree" runat="server" DataTextField="DegreeName" DataValueField="DegreeID"></asp:dropdownlist></td>
							</tr>
							
							
							
							
							<tr align="center">
								<td colspan="2"><asp:Button ID="UpdateData" runat="server"  CssClass="btn" Text="修改资料" OnClick="UpdateData_Click" />
								</td>
							</tr>
						</TBODY>
					</table>
					<br />
					
    </div>
    </form>
</body>
</html>
