<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="report_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="http://www.topfo.com/V4/css/common.css" rel="stylesheet" type="text/css" />
    <link href="http://www.topfo.com/V4/css/sj.css" rel="stylesheet" type="text/css" />
    <link href="http://www.topfo.com/V4/css/Investment_Details.css" rel="stylesheet"
        type="text/css" />
    <link href="http://www.topfo.com/V4/css/Latest_Merchants_Project.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">  
    .blk_02  
    {  
      margin-top: 4px;  
    }  
    .blk_02 .table_title table  
    {  
      border-left: 1px solid #b3d3ec;  
      border-top: 1px solid #b3d3ec;  
      background: #e0f0fd;  
      color: #5198cc;  
    }  
    .blk_02 .table_title table th  
    {  
      border-right: 1px solid #b3d3ec;  
      border-bottom: 1px solid #b3d3ec;  
      height: 20px;  
      font-weight: normal;  
      text-align: center;  
    }  
    .blk_02 .table_data  
    {  
      height: 210px;  
      overflow: hidden; 
      border-bottom:1px solid #D6D3D6;
    }  
    .blk_02 .table_data table  
    {  
      border-left: 1px solid #b3d3ec;  
    }  
    .blk_02 .table_data table td  
    {  
      border-right: 1px solid #b3d3ec;  
      border-bottom: 1px solid #b3d3ec; 
      height: 21px;  
      font-weight: normal;  
      text-align: center;  
    }  
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="blk_02" id="chg" style="width: 10%;">
            <div class="con1_col">
                <div class="l f_14 strong">
                    最新行业分析报告</div>
                <div class="clear">
                </div>
            </div>
            <div class="table_data" id="demo">
                <div id="demo1">
                    <%=strs %>
                    <br />
                </div>
            </div>
        </div>
        <script>  
    var speed = 50;  
    function Marquee() {  
      if (document.getElementById("demo").scrollTop >= document.getElementById("demo1").offsetHeight - document.getElementById("demo").offsetHeight) {  
        document.getElementById("demo").scrollTop = 0;  
      } else {
        document.getElementById("demo").scrollTop++;
      } 
    } 
     
   var MyMar=setInterval(Marquee, 50);
   
    document.getElementById("demo").onmouseover = function() { clearInterval(MyMar) }  
    document.getElementById("demo").onmouseout = function() { MyMar = setInterval(Marquee, speed)}   
        </script>

    </form>
</body>
</html>
