// JScript 文件
//**************************************************
//PROGRAM:                  HEROMET
//
//AUTHOR:                   (c) Powered by SISER All Right / SISER(Siser0409@163.com)	
//
//CREATEDATE:               2007-12-27
//
//LASTMODIFYDATE:           --
//
//**************************************************

    function CheckAll(reverse,groupname)
    {
        chks = document.getElementsByTagName("input");
        var count = 0;
        for(i=0;i < chks.length;i++)
        {
            if(typeof(groupname) != 'undefined')
            {
                if(chks[i].type == 'checkbox' && !reverse &&
                        chks[i].name == groupname)
                    chks[i].checked = true;
                
                if(chks[i].type == 'checkbox' && reverse &&
                    chks[i].name == groupname)
                    chks[i].checked = !chks[i].checked ;
            }else
            {
                if(chks[i].type == 'checkbox' && !reverse)
                    chks[i].checked = true;
                
                if(chks[i].type == 'checkbox' && reverse)
                    chks[i].checked = !chks[i].checked ;
            }
           
                
        }
       
    }
