<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="AddReport.aspx.cs"  Inherits="report_AddReport"  ValidateRequest="false"%>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>修改专业服务</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <script language="javascript" type="text/javascript">

function ShowPoint(src)
{
    if(src==0)
    {
		document.getElementById("spShowPoint").style.display="none";
    }
     if(src==1)
    {
    document.getElementById("spShowPoint").style.display="";
		
    }
}
    </script>

</head>
<body>
    <form id="Form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>行业分析报告</b></span></p>
                </h2>
                <h2>
                    <p>
                        <span><b><a href="reportList.aspx">资源管理</a></b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td style="width: 90px">
                        报告名称 :<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtName" runat="server" Width="153px" Height="22px"></asp:TextBox><span
                            style="color: #666666">（如：医药、化工、生活）</span></td>
                </tr>
                <tr>
                    <td>
                        网页title:<span class="hong">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtWtitle" Height="22px" runat="server" Columns="50" Width="285px"></asp:TextBox>
                        <span class="hui">（如：中国招商投资网）</span></td>
                </tr>
                <tr>
                    <td>
                        搜索关键字:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtKeyword1" runat="server" Width="153px" Height="22px"></asp:TextBox>
                        <span class="hui">（如：软文,行业分析）</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        网页描述:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtWebDesr" runat="server" Height="49px" TextMode="MultiLine" Width="413px"></asp:TextBox>
                        <span class="hui">（如：中国招商投资网）</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        行业大类 :</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlbig" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlbig_SelectedIndexChanged">
                            <asp:ListItem Value="all">llllllllll</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        行业小类：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlSmall" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <%--<tr>
                    <td>
                        来源：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlFrom" runat="server">
                            
                            <asp:ListItem Value="1">会员中心</asp:ListItem>
                            <asp:ListItem Value="2">业务员</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td style="height: 22px">
                        项目有效期开始:</td>
                    <td align="left" style="height: 22px">
                        <asp:DropDownList ID="ddlbegin" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="">--请选择--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        项目有效期结束:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlend" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="">--请选择--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="isNoMian" runat="server">
                    <%-- style="display: none;"--%>
                    <td>
                        是否收费：</td>
                    <td align="left">
                        <asp:RadioButton ID="rdomian" runat="server" GroupName="rdoMainShou" onclick="ShowPoint(0)"
                            Text="免费"></asp:RadioButton>
                        <asp:RadioButton ID="rdoShou" runat="server" GroupName="rdoMainShou" onclick="ShowPoint(1)"
                            Text="收费"></asp:RadioButton>
                    </td>
                </tr>
                <tr id="spShowPoint" style="display: none" runat="server">
                    <td>
                        类型及价格:</td>
                    <td align="left">
                        <asp:CheckBox  ID="rdoDian"  runat="server" Text="电子版" />
                        <asp:TextBox ID="txtDian" onkeyup="value=value.replace(/[^\d]/g,'')" onblur="a()"
                            runat="server" Width="36px" Height="18px"></asp:TextBox>
                        <asp:CheckBox  ID="rdoying" runat="server" Text="印刷版"/>
                        <asp:TextBox ID="txtying" onkeyup="value=value.replace(/[^\d]/g,'')" onblur="a()"
                            runat="server" Width="36px" Height="18px"></asp:TextBox>
                         <asp:CheckBox ID="rdoDianying" runat="server" Text="电子+印刷版"/>
                        <asp:TextBox ID="txtDianying" onkeyup="value=value.replace(/[^\d]/g,'')" onblur="a()"
                            runat="server" Width="36px" Height="18px"></asp:TextBox>
                        <asp:CheckBox  ID="rdoYinguang" runat="server" Text="印刷+光碟/电子版"/>
                        <asp:TextBox ID="txtYinguang" onkeyup="value=value.replace(/[^\d]/g,'')" onblur="a()"
                            runat="server" Width="36px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        交付方式:</td>
                    <td align="left">
                        <asp:TextBox ID="txtPay" runat="server" Width="161px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        交付时间:</td>
                    <td align="left">
                        <asp:TextBox ID="txtOverTime" runat="server" Width="161px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        图表数量:</td>
                    <td align="left">
                        <asp:TextBox ID="txtPhotoCount" runat="server" Width="161px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        页数:</td>
                    <td align="left">
                        <asp:TextBox ID="txtYeCount" runat="server" Width="161px" Height="22px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        撰写单位:</td>
                    <td align="left">
                        <asp:TextBox ID="txtWriterCompany" runat="server" Width="160px" Height="22px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        出版日期:</td>
                    <td align="left">
                        <asp:TextBox ID="txtPublishDate" onFocus="WdatePicker({lang:'zh-cn'})" CssClass="Wdate"
                            runat="server" Width="100px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 73px; height: 68px;">
                        摘要：</td>
                    <td align="left" style="height: 68px">
                        <asp:TextBox ID="txtExplain" runat="server" Height="80px" TextMode="MultiLine" Width="413px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        内容:</td>
                    <td align="left">
                        <FTB:FreeTextBox ID="txtMessage" runat="server">
                        </FTB:FreeTextBox>
                        <%--<asp:TextBox ID="txtMessage" runat="server" Height="80px" TextMode="MultiLine" Width="413px"></asp:TextBox>--%>
                    </td>
                </tr>
                 <tr>
                    <%--style="display: none;" runat="server" id="isAct"--%>
                    <td>
                        合作机构:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddrFrom" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="all">--请选择--</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <%--style="display: none;" runat="server" id="isAct"--%>
                    <td>
                        是否推荐:</td>
                    <td align="left">
                        <asp:RadioButton ID="rdoNoAct" GroupName="rblActitv1" runat="server" Text="不推荐" />
                        <asp:RadioButton ID="rdoYesAct" GroupName="rblActitv1" runat="server" Text="推荐" /></td>
                </tr>
                <tr>
                    <%--style="display: none;" runat="server" id="isAudit"--%>
                    <td>
                        审核结果:</td>
                    <td align="left">
                        <asp:RadioButton ID="rdAudit" GroupName="rblAuditingStatus" runat="server" Text="未审核" />
                        <asp:RadioButton ID="rdPass" GroupName="rblAuditingStatus" runat="server" Text="审核通过" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAudit" runat="server" CssClass="btn" Text="审核" OnClick="btnAudit_Click" />
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="录入" OnClick="btnSubmit_Click" />
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" /></td>
                </tr>
            </table>
        </div>

        <script language="javascript" type="text/javascript">
        function $(id)
        {
            return document.getElementById(id);
        }
        function a()
        {
        var patn1 = /^[\+0-9]+$/;
             var price1 = document.getElementById("<%=txtDian.ClientID %>").value;
             var price2 = document.getElementById("<%=txtying.ClientID %>").value;
             var price3 = document.getElementById("<%=txtDianying.ClientID %>").value;
             var price4 = document.getElementById("<%=txtYinguang.ClientID %>").value;
             if(price1!="")
             {
              if(patn1.test(price1)){document.getElementById("<%=rdoDian.ClientID %>").checked=true;}
                else
                {
                 document.getElementById("<%=rdoDian.ClientID %>").checked=false;
                 }
             }
             if(price2!="")
             {
              if(patn1.test(price2)){document.getElementById("<%=rdoying.ClientID %>").checked=true;}
                else
                  {
                   document.getElementById("<%=rdoying.ClientID %>").checked=false;
                   }
             }
              if(price3!="" )
             {
              if(patn1.test(price3)){document.getElementById("<%=rdoDianying.ClientID %>").checked=true;}
                  else
                  {
                   document.getElementById("<%=rdoDianying.ClientID %>").checked=false;
                   }
             }
               if(price4!="")
             {
              if(patn1.test(price4)){document.getElementById("<%=rdoYinguang.ClientID %>").checked=true;}
                  else {
                  document.getElementById("<%=rdoYinguang.ClientID %>").checked=false;
                  }
             }
        }
        function CheckForm(){
            if($("<%=txtName.ClientID %>").value==""){alert('请填写报告名称.');$("<%=txtName.ClientID %>").focus();return false;}
            if($("<%=txtWtitle.ClientID %>").value==""){alert('请填写网页标题.');$("<%=txtWtitle.ClientID %>").focus();return false;}
            if($("<%=txtKeyword1.ClientID %>").value==""){alert('请填写搜索关键字.');$("<%=txtKeyword1.ClientID %>").focus();return false;}
            if($("<%=txtWebDesr.ClientID %>").value==""){alert('请填写网页描述.');$("<%=txtWebDesr.ClientID %>").focus();return false;}
             if($("<%=ddlSmall.ClientID %>").value==""||$("<%=ddlSmall.ClientID %>").value==0){alert('服务小类不能为空.');$("<%=ddlSmall.ClientID %>").focus();return false;}
             
             if($("<%=ddrFrom.ClientID %>").value=="all"){alert('请选择合作机构.');$("<%=ddrFrom.ClientID %>").focus();return false;}
              var patn1 = /^[\+0-9]+$/;
             var price1 = document.getElementById("<%=txtDian.ClientID %>").value;
             var price2 = document.getElementById("<%=txtying.ClientID %>").value;
             var price3 = document.getElementById("<%=txtDianying.ClientID %>").value;
             var price4 = document.getElementById("<%=txtYinguang.ClientID %>").value;
             
             if(price1!="")
             {
              if(!patn1.test(price1)){alert('请正确填写价格'); $("<%=txtDian.ClientID %>").focus();return false;}
             
             }
             if(price2!="")
             {
              if(!patn1.test(price2)){alert('请正确填写价格'); $("<%=txtying.ClientID %>").focus();return false;}
            
             }
              if(price3!="" )
             {
              if(!patn1.test(price3)){alert('请正确填写价格'); $("<%=txtDianying.ClientID %>").focus();return false;}
           
             }
               if(price4!="")
             {
              if(!patn1.test(price4)){alert('请正确填写价格'); $("<%=txtYinguang.ClientID %>").focus();return false;}
             
             }
            var str5 = document.getElementById("<%=txtPhotoCount.ClientID %>").value;
              var str6 = document.getElementById("<%=txtYeCount.ClientID %>").value;
    	   
    	    if($("<%=txtPhotoCount.ClientID %>").value!="")
    	    {
    	    if(!patn1.test(str5)){ alert('请正确填写图表数量'); $("<%=txtPhotoCount.ClientID %>").focus();return false;}
    	    }
    	    if($("<%=txtYeCount.ClientID %>").value!="")
    	    {
            if(!patn1.test(str6)){ alert('请正确填写页数'); $("<%=txtYeCount.ClientID %>").focus();return false;}
            }
            document.getElementById("imgLoding").style.display="";
        }    </script>

      <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: -1px; left: 0px; width: 100%; height: 1050px; filter: alpha(opacity=60);">
            
            <div style="position:absolute; left: 436px; top: 520px;">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
            </div>
        </div>
    </form>
</body>
</html>
