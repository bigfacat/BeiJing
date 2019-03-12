$(function(){
	var jsonStr = '[{"title":"网上税务局","img":"logo"},{"title":"国家税务总局北京市电子税务局","img":"logo_bj"},{"title":"国家税务总局大连市电子税务局","img":"logo_dl"},{"title":"国家税务总局福建省电子税务局","img":"logo_fj"},{"title":"国家税务总局广东省电子税务局","img":"logo_gd"},{"title":"国家税务总局甘肃省电子税务局","img":"logo_gs"},{"title":"国家税务总局贵州省电子税务局","img":"logo_gz"},{"title":"国家税务总局青岛市电子税务局","img":"logo_qd"},{"title":"国家税务总局青海省电子税务局","img":"logo_qh"},{"title":"国家税务总局四川省电子税务局","img":"logo_sc"},{"title":"国家税务总局山东省电子税务局","img":"logo_sd"},{"title":"国家税务总局陕西省电子税务局","img":"logo_sx"},{"title":"国家税务总局云南省电子税务局","img":"logo_yn"}]';
	var path = "/xxmh/resources4/tax-images/logo/";
	var title = "网上税务局";//默认网上税务局
	var footTitle = "国家税务总局北京市税务局";//默认网上税务局
	var logo = "logo";//默认图片为logo	

	var titlecookie = getCookie("golobalTitle");
	if(titlecookie == ""){
		$.ajax({
			type : "post",
	        url : "/xxmh/viewsControlController/getGolobalTitle.do",
	        data :{},
	        datatype:"text",
	        success: function(data){
	        	title = data;
        	// footTitle = data;
        	// footTitle = footTitle.replace('电子', '');
        	// footTitle = footTitle.replace('网上', '');
	        	var jsonObj =  JSON.parse(jsonStr);//转换为json对象
	    		for(var i=0;i<jsonObj.length;i++){
	    	        if(jsonObj[i].title == data){
	    	        	logo = jsonObj[i].img;
	    	        	break;
	    	        }
	    		}
	    		setCookie("golobalTitle",data);
	        },
	        complete: function(data){
	        	$(document).attr("title",title);
	        	if($("#titleLogo").length>0){
	        		$("#titleLogo").attr('src',path+logo+".png");
	        	}
	        	if($("#footTitle").length>0){
	        		$("#footTitle").html(footTitle);
	        	}
	        }
		});
	}else{
		title = titlecookie;
    	footTitle = titlecookie;
    	footTitle = footTitle.replace('电子', '');
    	footTitle = footTitle.replace('网上', '');
    	var jsonObj =  JSON.parse(jsonStr);//转换为json对象
		for(var i=0;i<jsonObj.length;i++){
	        if(jsonObj[i].title == titlecookie){
	        	logo = jsonObj[i].img;
	        	break;
	        }
		}
		$(document).attr("title",title);
    	if($("#titleLogo").length>0){
    		$("#titleLogo").attr('src',path+logo+".png");
    	}
    	if($("#footTitle").length>0){
    		$("#footTitle").html(footTitle);
    	}
	}
	
	
});

function getCookie(c_name){
	if(document.cookie.length>0){
		c_start=document.cookie.indexOf(c_name + "=")
		
		if (c_start!=-1){
			c_start=c_start + c_name.length+1 
			c_end=document.cookie.indexOf(";",c_start)
			if (c_end==-1) c_end=document.cookie.length
			return unescape(document.cookie.substring(c_start,c_end))
		} 
	}
	return ""
}

function setCookie(c_name,value,expiremin)
{
	var exdate=new Date()
	exdate.setMinutes(exdate.getMinutes()+expiremin)
	document.cookie=c_name+ "=" +escape(value)+
	((expiremin==null) ? "" : "; expires="+exdate.toGMTString())
}