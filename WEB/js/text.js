// JScript 文件

 function chkAll() 
    { 
        var a = document.getElementsByTagName("input"); 
        for (var i=0; i<a.length; i++) 
    	 if (a[i].type == "checkbox") 
    	    if(a[i].name=="checkboxRecord")
    		    a[i].checked =!a[i].checked; 
    }
    function chkAll2() 
    { 
        var a = document.getElementsByTagName("input"); 
    	for (var i=0; i<a.length; i++) 
    	 if (a[i].type == "checkbox") 
    	    if(a[i].name=="checkboxRecord")
    	        a[i].checked =true; 
    }
    
    
    //获取所选的值,添加到购物车中
    function GetChkValue()
	{
	    var a = document.documentElement.getElementsByTagName("input");
		var str="";

		for (var i=0; i<a.length; i++) 
		{
			if (a[i].type == "checkbox")
			{
			    if(a[i].name=="checkboxRecord")
			    {
				    if(a[i].checked)
				    {
					    str+=a[i].value+",";
				    }
				}
			}
		}
		DelData(str);
	}
	
	/////
	  function disp(iType)
                {
                    if(iType=="1")
                    {
                        window.document.getElementById("step1").style.display="none";
                        window.document.getElementById("step2").style.display="block";
                    }
                    if(iType=="2")
                    {
                        window.document.getElementById("step1").style.display="block";
                        window.document.getElementById("step2").style.display="none";
                    }
                }
                
                function chkpost()
               {
                        var kj="";
                        var zt="";
                        var obj="";
                        
                        //标题
                        var ProjectName="txtProjectName";
                        if(trim(document.getElementById(ProjectName).value)=="")
                        {
                            alert("项目标题不能为空...");
                            document.getElementById(ProjectName).focus();
                            return false;
                        }
                        
                        //行业
                        if(document.getElementById("SelectIndustryControl1_hdselectValue").value=="")
                        {
                            alert("请选择行业...");
                            document.getElementById("SelectIndustryControl1_sltIndustryName_all").focus();
                            return false;
                        }
                        
                        //区域
                        if(document.getElementById("CountryListCN").value=="CN")
                        {
                            if(document.getElementById("ZoneSelectControl1_hideProvince").value=="")
                            { 
                                alert("请选择省份...");
                                document.getElementById("provinceCN").focus();
                                return false;
                            }
                            if(document.getElementById("ZoneSelectControl1_hideCapitalCity").value=="")
                            {
                                alert("请选择城市...");
                                document.getElementById("capitalCN").focus();
                                return false;
                            }
                        }
                        
                           //项目立项情况 cblXmlxqk
                        if(!ChkCbl("<%=this.cblXmlxqk.ClientID %>","项目立项情况"))
                        {
                            return ;
                        }


                        //项目投资总额 txtCapitalTotal
                        var obj=document.getElementById("txtCapitalTotal");
                        if(trim(trim(obj.value))=="")
                        {
                            alert("项目投资总额不能为空，请检查！");
                            obj.focus();
                            obj.select();
                            return ;
                        }
                        else 
                        {
                            if(isNaN(trim(obj.value)))
                            {
                                alert("项目投资总额的值只能为数字，请检查!！");
                                obj.focus();
                                obj.select();
                                return ;
                            }
                        }
                        
                        
                        
                        //融资金额 rbtnCapital
                        if(!ChkRbl("<%=this.rbtnCapital.ClientID %>","融资金额"))
                        {
                            return ;
                        }
                        
                        //融资额占股份比重
                        kj="txtSellStockShare";
                        zt="融资额占股份比重";
                        if(!ChkData(kj,zt))
                        {
                            return ;
                        }
                        
                        //融资对象cblTnObj
                        if(!ChkCbl("<%=this.cblTnObj.ClientID %>","融资对象"))
                        {
                            return;
                        }
                        
                        //退出方式 chkReturn
                        if(!ChkCbl("<%=this.chkReturn.ClientID %>","退出方式"))
                        {
                            return ;
                        }
                        
                        //企业发展阶段rblQyfzjd
                        if(!ChkRbl("<%=this.rblQyfzjd.ClientID %>","企业发展阶段"))
                        {
                            return;
                        }
                        
                        // 要求资金到位情况 rblYqzjdwqk
                        if(!ChkRbl("<%=this.rblYqzjdwqk.ClientID %>","要求资金到位情况"))
                        {
                            return ;
                        }
                        
                        //市场占有率(份额) tbSczylfy
                        kj="tbSczylfy";
                        zt="市场占有率(份额)"
                        if(!ChkData(kj,zt))
                        {
                            return ;
                        }
                        
                        //行业市场增长率 tbYysczzl
                        kj="tbYysczzl";
                        zt="行业市场增长率";
                        if(!ChkData(kj,zt))
                        {
                            return ;
                        }
                        
                        //资产负债率 tbZcfzl
                        kj="tbZcfzl";
                        zt="资产负债率";
                        if(!ChkData(kj,zt))
                        {
                            return ;
                        }
                        
                        //暂不用
            //            //项目投资回报周期 rblXmtzfbzq
            //            if(!ChkRbl("<%=this.rblXmtzfbzq.ClientID %>","项目投资回报周期"))
            //            {
            //                return ;
            //            }
                        
                        //项目有效期限 rblXmyxqxx
                        if(!ChkRbl("<%=this.rblXmyxqxx.ClientID %>","项目有效期限"))
                        {
                            return ;
                        }
                        
                        //项目摘要
                        var ProIntro="txtProIntro";
                        obj=document.getElementById(ProIntro);
                        if(!checkByteLength(obj.value,50,1200))
                        {
                            alert("填写项目摘要.建议600字以内（不少于50字）");
                            document.getElementById(ProIntro).focus();
                            document.getElementById(ProIntro).select();
                            return ;
                        }
                        
                        //项目详细描述
                        kj="txtXmqxms";
                        obj=document.getElementById(kj);
                        if(!checkByteLength(obj.value,50,1000))
                        {
                            alert("项目详细描述不得超过1000个汉字(不少于50字),请检查！");
                            obj.focus();
                            obj.select();
                            return ;
                        }
                        
                        
                        
                        //产品概述
                        var displ="（字数请控制在30到1000字以内！）";
                        kj="txtProjectAbout";
                        obj=document.getElementById(kj);
                        if(!checkByteLength(obj.value,30,2000))
                        {
                            alert("产品概述不得超过1000个汉字，请检查！"+displ);
                            obj.focus();
                            obj.select();
                            return ;
                        }
                        
                        //市场前景
                        kj="txtMarketAbout";
                        obj=document.getElementById(kj);
                        if(!checkByteLength(obj.value,30,2000))
                        {
                            alert("市场前景不得超过1000个汉字，请检查！"+displ);
                            obj.focus();
                            obj.select();
                            return ;
                        }
                        
                        //竞争分析
                        kj="txtCompetitioAbout";
                        obj=document.getElementById(kj);
                        if(!checkByteLength(obj.value,30,2000))
                        {
                            alert("竞争分析不得超过1000个汉字，请检查！"+displ);
                            obj.focus();
                            obj.select();
                            return ;
                        }
                        
                        //商业模式
                        kj="txtBussinessModeAbout";
                        obj=document.getElementById(kj);
                        if(!checkByteLength(obj.value,30,2000))
                        {
                            alert("商业模式不得超过1000个汉字,请检查！"+displ);
                            obj.focus();
                            obj.select();
                            return ;
                        }
                        
                        //管理团队
                        kj="txtManageTeamAbout";
                        obj=document.getElementById(kj);
                        if(!checkByteLength(obj.value,30,2000))
                        {
                            alert("管理团队不得超过1000个汉字，请检查！"+displ);
                            obj.focus();
                            obj.select();
                            return ;
                        }
                
                        //我已阅读不能为空
                        if(!document.getElementById("chkReadMe").checked)
                        {
                            alert("请选择‘我已阅读《拓富·中国招商投资网服务协议》’。");
                            document.getElementById("chkReadMe").focus();
                            return false;
                        }
                        
                        //第二步
                        window.document.getElementById("step1").style.display="none";
                        window.document.getElementById("step2").style.display="block";
                }
                
                function disp(iType)
                {
                    if(iType=="1")
                    {
                        window.document.getElementById("step1").style.display="none";
                        window.document.getElementById("step2").style.display="block";
                    }
                    if(iType=="2")
                    {
                        window.document.getElementById("step1").style.display="block";
                        window.document.getElementById("step2").style.display="none";
                    }
                }
                
                
                 //输入0到100之间的数值
                function ChkData(kjName,ztName)
                {
                    var val=document.getElementById(kjName).value;
                    if(val!="")
                    {
                        if(!isNaN(val))
                        {
                            if(val>100 || val<0)
                                {
                                    alert("输入的数值应该在0到100之间，请检查！");
                                    document.getElementById(kjName).focus();
                                    document.getElementById(kjName).select();
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                        }
                        else
                        {
                            alert(ztName+"只能为数值，且输入的范围应该在0到100之间！");
                            document.getElementById(kjName).focus();
                            document.getElementById(kjName).select();
                            return false;
                        }
                    }
                    else
                    {
                        alert(ztName+"不能空，且输入的范围应该在0到100之间，请检查！");
                        document.getElementById(kjName).focus();
                        document.getElementById(kjName).select();
                        return false;
                    }
                }
                
                
                
                
                
                //---------------------------公用，单选框的判断----------------------
                function ChkRbl(kjID,kjName)
                {
                    var kjVal=kjID.replace(/_/g,"$");
                    if(GetCheckNum(kjVal)<=0)
                    {
                        alert("请选择"+kjName);
                        document.getElementById(kjID).focus();
                        return false;
                    }
                    else 
                    {
                        return true;
                    }
                }
                function GetCheckNum(checkobjectname)
                {
	                var truei2 = 0;
	                var checkobject = document.getElementsByName(checkobjectname);
                //	var checkobject = eval("document.all." + checkobjectname + "");
	                var inum = checkobject.length;
	                if (isNaN(inum))
	                {
		                inum = 0;
	                }
	                for(i=0;i<inum;i++){
		                if (checkobject[i].checked == 1){
			                truei2 = truei2 + 1;
		                }
	                }
	                return truei2;
                }
                //----------------------END-----------------------------------
               

                //-------------------公用 ，选择checkbox------------------------
                function ChkCbl(kjID,kjName)
                {
                    if(GetCheckBoxListCheckNum(kjID)<=0)
                    {
                        alert("请选择"+kjName);
                        document.getElementById(kjID).focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                function GetCheckBoxListCheckNum(checkobjectid)
                {
                    var selectedItemCount = 0;
                    var liIndex = 0;
                    var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
                    while (currentListItem != null)
                    {
                        if (currentListItem.checked) selectedItemCount++;
                        liIndex++;
                        currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
                    }
                    return selectedItemCount;
                }
                //-------------------------------END----------------------------------
                
                
                //判断多少个汉字,限制汉字
                function checkByteLength(str,minlen,maxlen) 
                {
	            if (str == null) return false;
	            var l = str.length;
	            var blen = 0;
	            for(i=0; i<l; i++) {
		            if ((str.charCodeAt(i) & 0xff00) != 0) {
			            blen ++;
		            }
		            blen ++;
	            }
	            if (blen > maxlen || blen < minlen) {
		            return false;
	            }
	            return true;
                }
                
                
                
            //////////////////////
            //去除字符串两边空格的函数
            //参数：mystr传入的字符串
            //返回：字符串mystr
            function trim(mystr){
            while ((mystr.indexOf(" ")==0) && (mystr.length>1)){
            mystr=mystr.substring(1,mystr.length);
            }//去除前面空格
            while ((mystr.lastIndexOf(" ")==mystr.length-1)&&(mystr.length>1)){
            mystr=mystr.substring(0,mystr.length-1);
            }//去除后面空格
            if (mystr==" "){
            mystr="";
            }
            return mystr;
            }


            //替换掉字符串空格
            function repl(obj)
            {
                if(obj.value.length>0)
                {
                    obj.value=trim(obj.value);
                }
            }
	
	

