/**
 * 跳转原index页面，使用原框架进入对应功能页
 * @param url
 * @param m1
 * @param m2
 * @returns
 */
var contPath = "/xxmh";

//从旧门户打开
function goIndexUrl(url,m1,m2,qxkzsx){
	
	var tabTitle = getURLParameter2(url,"tabTitle");
	if(qxkzsx!=undefined && qxkzsx!="" && qxkzsx!=0 && qxkzsx!='null' && qxkzsx!='undefined'){//需要登录的
		$.post(contPath+"/portalSer/checkLogin.do",{},function(d){
			var isLogin=d.isLogin;
			if(isLogin=="N"){
				layer.msg('未登录或登陆超时，请先登录');
				setTimeout(function(){
					login();
				},500);
			}else{
				if(typeof(m1) == 'undefined' || m1=="" || m1=='null' || m1=='undefined'){
					window.location.href=url;
					return;
				}
				window.location.href = "/xxmh/html/index_origin.html?gopage=true"+"&m1="+m1+"&m2="+m2+"&fromWhere="+"&qxkzsx="+qxkzsx+"&tabTitle="+tabTitle;
			}
		});
	}else{
		if(typeof(m1) == 'undefined' || m1=="" || m1=='null' || m1=='undefined'){
			window.location.href=url;
			return;
		}
		window.location.href = "/xxmh/html/index_origin.html?gopage=true"+"&m1="+m1+"&m2="+m2+"&fromWhere="+"&qxkzsx="+qxkzsx+"&tabTitle="+tabTitle;
	}
}

//本页打开
function goUrl(url){
	window.location.href=url;
}

//新页面打开
function openUrl(url,qxkzsx){
	if(qxkzsx!=undefined && qxkzsx!="" && qxkzsx!=0 && qxkzsx!='null' && qxkzsx!='undefined'){//需要登录的
		$.post(contPath+"/portalSer/checkLogin.do",{},function(d){
			var isLogin=d.isLogin;
			if(isLogin=="N"){
				layer.msg('未登录或登陆超时，请先登录');
				setTimeout(function(){
					login();
				},500);
			}else{
                if("sxsq"==getURLParameter2(url,"ywlx")){
                    verifyApply(url);
                }else{
                    window.open(url);
                }
			}
			return isLogin;
		});
	}else{
        if("sxsq"==getURLParameter2(url,"ywlx")){
            verifyApply(url);
        }else{
            window.open(url);
        }
	}
}

function getURLParameter2(url,name) {
    return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(url)||[,""])[1].replace(/\+/g, '%20'))||null;
}