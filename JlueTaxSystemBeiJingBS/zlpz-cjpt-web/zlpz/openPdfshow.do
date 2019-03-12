











<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=8; IE=EDGE">
<title>网上税务局</title>
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/abacus/resources/css/abacus/main.css">
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/abacus/resources/css/message/message_solid.css">
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/abacus/resources/css/ecm-taglib/message/Message.css"/>
<script src="/zlpz-cjpt-web/abacus/resources/js/lib/jquery.min.js"></script>
<script type="text/javascript" src="/zlpz-cjpt-web/abacus/resources4/layui/layui.js"></script>
<script src="/zlpz-cjpt-web/abacus/resources/js/ecm-taglib/layer-v2.2/layer/extend/layer.ext.js"></script>
<style type="text/css">
* {margin: 0px; padding: 0px; font-family: "微软雅黑"; list-style-type: none;}
body {margin: 0px; padding: 0px;}
table {border-spacing: 0px;}
iframe {margin: 0px; padding: 0px; border-spacing: 0px; border:0px;}
.winbox_bg{background-color:#000000; opacity:0; position:fixed; left:0px; top:0px; height:100%; width:100%; z-index:200;}
.winbox{ opacity:0; border-radius:6px; z-index:202; position:absolute; top:-200px; left:50%; background-color:#fff; 
box-shadow:2px 2px 9px #4e4e4e;-moz-box-shadow:2px 2px 9px #4e4e4e;-webkit-box-shadow:2px 2px 9px #4e4e4e;}
 .temp01{ 
	border-radius:50%; 
	width:14px; 
	height:14px; 
	background-color:red; 
	display:block; 
	position:absolute; 
	margin-top:-35px; 
	margin-left:74px;
	color:white;
	line-height:14px;
	font-size:12px;
	text-align:center; 
} 
 .temp02{    
	border-radius:50%; 
    width: 14px;
    height: 14px;
    background-color: #fff;
    display: block;
    position: absolute;
    margin-top: -35px;
    margin-left: 74px;
    color: #ff4e00;
    line-height: 14px;
    font-size:12px;
    text-align: center;
} 
.fszlys{border-radius:50%; width:14px; height:14px; background-color:white; display:block; position:absolute; margin-top:-25px; margin-left:66px;color:white;line-height:14px;font-size:12px;text-align:center; }
.tc_tit {
    line-height: 40px;text-indent: 12px;font-size: 16px;background-color: #1a56a8;color: #fff;font-weight: bold;letter-spacing: 1px;
}
.winclose {
    font-size: 24px;text-align: center;line-height: 18px;height: 20px; width: 20px;color: #FFF;
    position: absolute; top: 10px;right: 20px;cursor: pointer;
}
 
</style>
<script type="text/javascript">
	var swsxDm = "";
    var queryString = '%22nsqx_dm%22%3A%2206%22%2C%22zsxmDm%22%3A%2210101%22%2C%22sbSign%22%3A%2230a3bb2134f9e3b7e74c6abd1d2afe62%22%2C%22gdslxDm%22%3A%221%22%2C%22skssq_z%22%3A%222019-01-31%22%2C%22shxyDm%22%3A%22null%22%2C%22ywbm%22%3A%22YBNSRZZS%22%2C%22yhid%22%3A%22ujJMSXCcAHh+dbQPXxlGlu3jon7+xiZ5lEjyY%2FugFH%2FuU49WHwqRPw%3D%3D%22%2C%22tjNd%22%3A%222019%22%2C%22gszgswskfjDm%22%3A%2211101087113%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22skssq_q%22%3A%222019-01-01%22%2C%22yhm%22%3A%22HWu2Xmju4nAClgAHsV1TlVfybJlCYdNR%22%2C%22sbqx%22%3A%222019-02-22%22%2C%22gsnsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22gotoSbb%22%3A%22Y%22%2C%22tjYf%22%3A%2202%22%2C%22nsqxDmIn%22%3A%22%22%2C%22gsdq%22%3A%22111%22%2C%22zspmDm%22%3A%22101016703%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22nsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22tbbd%22%3A%221111110000010000000001000000000000000000%22';
    var subWidth = window.innerWidth; // C.Q CSGJ-311 窗口放大时，设置子窗口大小
    
    var layer;
    layui.use('layer', function() { //独立版的layer无需执行这一句
        layer = layui.layer;
    });
    function resizeFrame(){
    	var winH = window.innerHeight || Math.max(document.body.offsetHeight, document.documentElement.offsetHeight);
        document.body.style.height = winH + "px";
        var height=$(document).height();
        //$("#frmMain").attr("height",height);
        autoResizeIframe("frmMain",height);
    }
    
    function loadPage(page){
        var href = window.location.href;
        if (href.indexOf("?") > -1) {
            href = href.substr(0, href.indexOf("?"));
        }
        if (href.indexOf(";") > -1) {
            href = href.substr(0, href.indexOf(";"));
        }
        document.getElementById("frmMain").src = href + "/" + page + "?" + queryString;
    }
    var index_loading;
    
    function initFrame(){
    	index_loading = window.parent.layer.load(2,{shade: 0.3});
        window.setTimeout(function(){resizeFrame()}, 50);
    }

    function closePage() {
        window.close();
    }
    
    function autoResizeIframe (frameId,customizedHeight,customizedWidth) {
    	if(typeof frameId !== 'string'){
    		if(frameId.frameElement && frameId.frameElement.id){
    			frameId = frameId.frameElement.id;	
    			//frameId error into frame window object
    		}else{
    			console.info("frameId error into unknow object:"+frameId);
    		}
    	}
    	var frame = document.getElementById(frameId);
    	if (frame != null && !window.opera) {
    		/*var frameDoc = frame.document || frame.ownerDocument;
    		 if (frameDoc != null) {
    			var width = customizedWidth || frameDoc.body.scrollWidth;
    			var height = customizedHeight || frameDoc.body.scrollHeight;
    			frame.height = height;
    			frame.width = width;
    		} */ 
    		if (frame.contentDocument && frame.contentDocument.body && frame.contentDocument.body.offsetHeight) {
    			var height = frame.contentDocument.body.offsetHeight;
    			if(customizedHeight){
    				height = height > customizedHeight?height:customizedHeight;
    				height -= 70;
    			}
     			frame.height = height; 
     			frameContentWidth = frame.contentDocument.body.offsetWidth;
     		} else if (frame.Document && frame.Document.body && frame.Document.body.scrollHeight) { 
     			frame.height = frame.Document.body.scrollHeight; 
     			frameContentWidth = frame.Document.body.scrollWidth; 
     		}else{
     			window.setTimeout("autoResizeIframe("+frameId+","+customizedHeight+","+customizedWidth+")", 50);
     			return;
     		}
     		frameWidth = Math.max(frame.scrollWidth,frame.offsetWidth, $(document).width(),$(document.body).width());
     		frame.style.width= frameWidth +"px";
     		frame.width = frameWidth;
     		subWidth = frameWidth;
			window.parent.layer.close(index_loading);
		}
	}

	$(function() {
		var gdslxDm = "1";
		if(1 == gdslxDm){
   	    	$("#gdFlag").text("国税");
   	    }else if(2 == gdslxDm){
   	    	$("#gdFlag").text("地税");
   	    }else{
   	    	$("#gdFlag").text("国地");
   	    }
		var gdshbbz = "N";
		//判断是否是国地税合并，为Y则不显示国税、地税标识
		if("N" == gdshbbz){
			$("#gdFlag").text("");
			$("#gdFlag").removeClass();
		}
		
	    //按钮控制说明
		$(".areaHeadBtn").append('<li><a id=\"打印\" class="btn btn06" href="javascript:void(0);" onClick=eval(\"window.frames[0].printPDF()\");>打印</a></li>');
        $(".areaHeadBtn").append('<li><a id=\"关闭\" class="btn btn06" href="javascript:void(0);" onClick=closePage()>关闭</a></li>');
		$(".TopHead").show(); 

	});
	
	
</script>
</head>
<body onresize="resizeFrame()" onload="initFrame()">
    <table width="100%" height="100%">
		<tr>
			<td>
			<div class="TopHead">
				<div class="LeftPadding">
				<table width="100%" height="60" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td><div class="HeadTitle">   
								<span class="spangs" id="gdFlag"></span> <span class="spanbm"></span>
							</div></td>
						<td class="areaHeadBtn" align="right">						
						
						</td>						 
					</tr>
				</table>
				</div>
			</div>
			</td>
		</tr>
		<tr height="100%">
			<td vAlign="top"><iframe id="frmMain" name="frmMain" width="100%" height="100%" src="/zlpz-cjpt-web/zlpz/openPdf.do?_bizReq_path_=sbzs/ybnsrzzs&_query_string_=%22nsqx_dm%22%3A%2206%22%2C%22zsxmDm%22%3A%2210101%22%2C%22sbSign%22%3A%2230a3bb2134f9e3b7e74c6abd1d2afe62%22%2C%22gdslxDm%22%3A%221%22%2C%22skssq_z%22%3A%222019-01-31%22%2C%22shxyDm%22%3A%22null%22%2C%22ywbm%22%3A%22YBNSRZZS%22%2C%22yhid%22%3A%22ujJMSXCcAHh+dbQPXxlGlu3jon7+xiZ5lEjyY%2FugFH%2FuU49WHwqRPw%3D%3D%22%2C%22tjNd%22%3A%222019%22%2C%22gszgswskfjDm%22%3A%2211101087113%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22skssq_q%22%3A%222019-01-01%22%2C%22yhm%22%3A%22HWu2Xmju4nAClgAHsV1TlVfybJlCYdNR%22%2C%22sbqx%22%3A%222019-02-22%22%2C%22gsnsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22gotoSbb%22%3A%22Y%22%2C%22tjYf%22%3A%2202%22%2C%22nsqxDmIn%22%3A%22%22%2C%22gsdq%22%3A%22111%22%2C%22zspmDm%22%3A%22101016703%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22nsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22tbbd%22%3A%221111110000010000000001000000000000000000%22&ysqxxid=EAD5D43EFFFFFF8A169783ECF841A023&_re_contextpath_=/zlpz-cjpt-web"></iframe></td>
		</tr>
	</table>
</body>
</html>