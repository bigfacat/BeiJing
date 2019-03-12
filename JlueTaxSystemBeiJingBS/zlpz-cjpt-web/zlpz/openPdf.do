



  
   
<!DOCTYPE html>


<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=8; IE=EDGE">
<title>PDF申报</title>
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/resources/css/stylecon.css" />
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/resources/css/common.css" />
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/resources/js/ecm-taglib/message/skin/default/Message.css"/>
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/resources/css/ecm-taglib/css/loadMask.css"/>
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/resources/css/comon0.css" />
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/resources/css/table.css"/>
<link rel="stylesheet" type="text/css" href="/zlpz-cjpt-web/abacus/resources4/tax-module/table_step/table-step.css"/>
<script type="text/javascript" src="/zlpz-cjpt-web/resources/js/lib/jquery.min.js"></script>
<script type="text/javascript" src="/zlpz-cjpt-web/resources/js/ecm-taglib/message/Message.js"></script>
<script type="text/javascript" src="/zlpz-cjpt-web/resources/js/lib/jquery.media.js"></script>
<script type="text/javascript" src="/zlpz-cjpt-web/resources/js/lib/mask.js"></script>
<script type="text/javascript" src="/zlpz-cjpt-web/abacus/resources/js/lib/pdfcheck.js"></script>
<script type="text/javascript" src="/zlpz-cjpt-web/abacus/resources4/layui/layui.js"></script>
<script type="text/javascript" src="/zlpz-cjpt-web/resources/js/framework/diyImport.js"></script>
<script type="text/javascript" src="/zlpz-cjpt-web/resources/js/fjqz/jquery.base64.js"></script>
<script src="/zlpz-cjpt-web/abacus/resources4/tax-module/table_step/table-step.js"></script>
<script type="text/javascript">
		var project_path = "";
		var _bizReq_path_ = "sbzs/ybnsrzzs";
		var prevUrl="";
		var errMsg = "null";
		//申报提交标志
		var prepareWellFlag = true;
		var AcroPDF = null;		
		var width=document.documentElement.clientWidth;
		var height=document.documentElement.clientHeight*0.99;
		var index;
		var ywlx = "sbzs";
		var layer;
        layui.use('layer', function() { //独立版的layer无需执行这一句
            layer = layui.layer;
        });
		
      	window.onload = function (){
      		if(""!="00" && ""!="01" && ""!="99" && ""!=''){//验签失败
				if(""==="21"){
     				errMsg = "尊敬的纳税人:系统检测到您为ca用户,需签名后才能申报，请您先签名！";
    			}
    			var index = layer.load(2,{shade: 0.3});
     			layer.alert(errMsg, {icon: 0}, function(index) {
      				//layer.close(index);
     				layer.closeAll();
     				//显示头部按钮
					var menuBtnConfig = '';
					if(menuBtnConfig != '' ){
						menuBtnConfig = JSON.parse(menuBtnConfig);
					}
					parent.menuBtnControl(menuBtnConfig);
					showPdf();
       			}); 
    		}else{
				showPdf();
			}
			
      		$("body").unmask();
		};
		 window.onresize = function () {
			 height=document.documentElement.clientHeight*0.9;
			 if(typeof window.parent.subWidth != "undefined") {
				 // C.Q CSGJ-311 窗口放大时，设置子窗口大小
				 width = window.parent.subWidth;
			 }
			 $("#main").css("width", width).css("height", height);
		 }
		 
		 function showPdf(){
				//检查是否安装PDF插件
		   		if(!checkPDFPlugin()){
		   		}else{
		   		    //去掉框架页的浮框，设置pdf页浮框，设置main这个div的padding
					if (ywlx === "sxsq"){
                    	$(parent.document).find(".table-step-box").css("display","none");
                        $(".table-step-box").css("display","block");
                        $("#main").css("padding-top", "70px");
                    }
                    $("#main").css("width", width).css("height", height);
		 			var pdfURL = "/zlpz-cjpt-web/zlpz/getPdfFile.do?_query_string_=%22nsqx_dm%22%3A%2206%22%2C%22zsxmDm%22%3A%2210101%22%2C%22sbSign%22%3A%2230a3bb2134f9e3b7e74c6abd1d2afe62%22%2C%22gdslxDm%22%3A%221%22%2C%22skssq_z%22%3A%222019-01-31%22%2C%22shxyDm%22%3A%22null%22%2C%22ywbm%22%3A%22YBNSRZZS%22%2C%22yhid%22%3A%22ujJMSXCcAHh+dbQPXxlGlu3jon7+xiZ5lEjyY%2FugFH%2FuU49WHwqRPw%3D%3D%22%2C%22tjNd%22%3A%222019%22%2C%22gszgswskfjDm%22%3A%2211101087113%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22skssq_q%22%3A%222019-01-01%22%2C%22yhm%22%3A%22HWu2Xmju4nAClgAHsV1TlVfybJlCYdNR%22%2C%22sbqx%22%3A%222019-02-22%22%2C%22gsnsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22gotoSbb%22%3A%22Y%22%2C%22tjYf%22%3A%2202%22%2C%22nsqxDmIn%22%3A%22%22%2C%22gsdq%22%3A%22111%22%2C%22zspmDm%22%3A%22101016703%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22nsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22tbbd%22%3A%221111110000010000000001000000000000000000%22&ysqxxid=EAD5D43EFFFFFF8A169783ECF841A023&ywbm=ybnsrzzs&_bizReq_path_="+_bizReq_path_;
		 			AcroPDF = document.createElement("object");
		 			AcroPDF.setAttribute("data", pdfURL);
		 			AcroPDF.setAttribute("width", "100%");
		 			AcroPDF.setAttribute("height", "100%");
		 	        AcroPDF.setAttribute("type", "application/pdf");
			 	   	document.getElementById("main").appendChild(AcroPDF);  
		 			window.setTimeout('initAcroPDF();',1000);
		 			$("body").mask("正在加载文件，请稍后...");
		     		
		   		}
		 }
		// 初始化控件
		function initAcroPDF() {
			AcroPDF.messageHandler = {
					onMessage: function(msg) {
						if (!isExternalSupported()) {
							if (msg[2] == 'success') {
							} else {
								if (msg[0] != 'initialized') {
									Message.alert("MSG:" + msg[0] + "," + msg[1] + "," + msg[2] + ". Message is:" + msg[3]);
								} else {								
									$("body").unmask();
								}	
							}
						} else {
							window.external.DoOnMessage(msg[0], msg[1], msg[2], msg[3]);
						}
					},
					onError: function(error, msg) {
						if (!isExternalSupported()) {
							layer.closeAll();
							Message.errorInfo({
								title : "错误", 
								message : 'ERROR: ' + error + '; MSG: ' + msg[0] + ',' + msg[1] + ',' + msg[2] + ',' + msg[3]
							});
							
						} else {
							window.external.DoOnError(error.message, msg[0], msg[1], msg[2], msg[3]);
						}				
					} 
				};
			$("body").unmask();
		}
		
		function isExternalSupported() {
			if (window.external != undefined && 'DoOnMessage' in window.external) {
				return true;
			}
			return false;
		}
		
		// 打印文档
		function printPDF() {
			AcroPDF.postMessage(new Array('printPDF','printPDF','','','',''));
		}
		
		// 触发提交申报
      	function ywsb() { 	
      		var index=layer.msg('正在提交申报，请稍后...',{icon: 6,time: 0,shade: 0.3});      	
            var top=$("#layui-layer1").css("top");
            top=top.substring(0,top.indexOf("px"));            
           	$("#layui-layer1").css("top",top*14/15);            	

			var project_path = "/zlpz-cjpt-web/zlpz/submitPdf.do?_query_string_=%22nsqx_dm%22%3A%2206%22%2C%22zsxmDm%22%3A%2210101%22%2C%22sbSign%22%3A%2230a3bb2134f9e3b7e74c6abd1d2afe62%22%2C%22gdslxDm%22%3A%221%22%2C%22skssq_z%22%3A%222019-01-31%22%2C%22shxyDm%22%3A%22null%22%2C%22ywbm%22%3A%22YBNSRZZS%22%2C%22yhid%22%3A%22ujJMSXCcAHh+dbQPXxlGlu3jon7+xiZ5lEjyY%2FugFH%2FuU49WHwqRPw%3D%3D%22%2C%22tjNd%22%3A%222019%22%2C%22gszgswskfjDm%22%3A%2211101087113%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22skssq_q%22%3A%222019-01-01%22%2C%22yhm%22%3A%22HWu2Xmju4nAClgAHsV1TlVfybJlCYdNR%22%2C%22sbqx%22%3A%222019-02-22%22%2C%22gsnsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22gotoSbb%22%3A%22Y%22%2C%22tjYf%22%3A%2202%22%2C%22nsqxDmIn%22%3A%22%22%2C%22gsdq%22%3A%22111%22%2C%22zspmDm%22%3A%22101016703%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22nsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22tbbd%22%3A%221111110000010000000001000000000000000000%22&ysqxxid=EAD5D43EFFFFFF8A169783ECF841A023&_bizReq_path_="+_bizReq_path_+"&_random="+ Math.random();
			AcroPDF.postMessage(new Array('execTijiao','execTijiao',project_path,'PDF','',''));
          	layer.closeAll();
      	}
		
     // 触发提交申报
      	function submitWell() {
			if(prepareWellFlag){
				prepareMakeFlag = false;
				var tjMsg = "正在提交申报，请稍候...";
				var processOnlinehandle='N';
				var ywlx=_bizReq_path_.split("/")[0];
				if(ywlx==='sxsq' || ywlx==='lhsxsq'){
					tjMsg = "正在提交申请，请稍候...";
				}
				if(processOnlinehandle==='Y'&&ywlx==='sxsq'){
					$("#main").hide();
					parent.$("#btnPrintMake").hide();
					parent.$("#btnSubmitWell").hide();
					$("#dshrDiv").show();
				}else{
					$("#main").css({visibility:"hidden"});    	
		      		index=layer.msg(tjMsg,{icon: 6,time: 0,shade: 0.3});   
		      		var heightr = document.documentElement.clientHeight;
                    $("#frmMain",window.parent.document).css("height", heightr+60+"px");
					try{
			            var top=$("#layui-layer1").css("top");
			            if(typeof top != "undefined"){
			            	top=top.substring(0,top.indexOf("px"));            
				           	$("#layui-layer1").css("top",top*14/15); 
			            }
			       		layer.load(2); 
			       		var queryStringBase64 = Base64.encode('%22nsqx_dm%22%3A%2206%22%2C%22zsxmDm%22%3A%2210101%22%2C%22sbSign%22%3A%2230a3bb2134f9e3b7e74c6abd1d2afe62%22%2C%22gdslxDm%22%3A%221%22%2C%22skssq_z%22%3A%222019-01-31%22%2C%22shxyDm%22%3A%22null%22%2C%22ywbm%22%3A%22YBNSRZZS%22%2C%22yhid%22%3A%22ujJMSXCcAHh+dbQPXxlGlu3jon7+xiZ5lEjyY%2FugFH%2FuU49WHwqRPw%3D%3D%22%2C%22tjNd%22%3A%222019%22%2C%22gszgswskfjDm%22%3A%2211101087113%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22skssq_q%22%3A%222019-01-01%22%2C%22yhm%22%3A%22HWu2Xmju4nAClgAHsV1TlVfybJlCYdNR%22%2C%22sbqx%22%3A%222019-02-22%22%2C%22gsnsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22gotoSbb%22%3A%22Y%22%2C%22tjYf%22%3A%2202%22%2C%22nsqxDmIn%22%3A%22%22%2C%22gsdq%22%3A%22111%22%2C%22zspmDm%22%3A%22101016703%22%2C%22djxh%22%3A%2210111101000050272835%22%2C%22nsrsbh%22%3A%2291110108344349177L%22%2C%22sssqQ%22%3A%222019-01-01%22%2C%22sssqZ%22%3A%222019-01-31%22%2C%22tbbd%22%3A%221111110000010000000001000000000000000000%22');
			          	var project_path = "/zlpz-cjpt-web/zlpz/submitPdf.do?queryStringBase64="+queryStringBase64+"&ysqxxid=EAD5D43EFFFFFF8A169783ECF841A023&_re_contextpath_=/zlpz-cjpt-web&_bizReq_path_="+_bizReq_path_+"&_random="+ Math.random()+"&gdslxDm=1&nsrsbh=null"; 
						AcroPDF.postMessage(new Array('execTijiao','execTijiao',project_path,'PDF','',''));
						// 调用父页面的函数，清空按钮区域
						parent.cleanMeunBtn();
						//隐藏外框架页面的头部区域
						parent.hideFrameHead();
					}catch(ex){
						prepareMakeFlag = true;
				        return ;
					}
				}
				
			}
      	}
		
		/**
		 * PDF页[上一步]按钮动作
		 */
		function backForm() {
			var backForm = "/sbzs-cjpt-web/biz/sbzs/ybnsrzzs/begin?gotoSbb=Y&djxh=10111101000050272835&gdslxDm=1&sssqQ=2019-01-01&sssqZ=2019-01-31&skssq_q=2019-01-01&skssq_z=2019-01-31&nsqx_dm=06&sbqx=2019-02-22&zsxmDm=10101&zspmDm=101016703&yhid=ujJMSXCcAHh+dbQPXxlGlu3jon7+xiZ5lEjyY/ugFH/uU49WHwqRPw==&gsnsrsbh=91110108344349177L&gszgswskfjDm=11101087113&shxyDm=null&yhm=HWu2Xmju4nAClgAHsV1TlVfybJlCYdNR&nsqxDmIn=&sbSign=30a3bb2134f9e3b7e74c6abd1d2afe62&tjNd=2019&tjYf=02&ysqxxid=EAD5D43EFFFFFF8A169783ECF841A023";
			backForm = window.location.protocol +"//" 
				+window.location.host + backForm; 
			//去掉重置逻辑
			if (backForm.indexOf("&reset=Y") >= 0) {
				backForm = backForm.replace("&reset=Y", "");
			}
			if(backForm != 'null' && backForm != null && backForm != ''){
				$("#frmMain",window.parent.document).attr('src',backForm);
			}
		}

		$(function(){	
			DiyImport.load("",
					[{
						script:"/nssb/cwbb/openPdf.js",
						key:"CWBB"
					}]);
		});
		
</script>
</head>
<body>
	<div class="table-step-box" style="display:none;z-index:99999">
		<div class="table-step-main">
		<p class="float-icon">进度</p>
		<div class="table-step-center">
			<div class="table-step-item">
				<div class="pro-step finish-step">
					<span></span>
					<i class="pro-line finish-line"></i>
					<p>初始化</p>
				</div>
				<div class="pro-step finish-step">
					<span></span>
					<i class="pro-line finish-line"></i>
					<p>填写申请表及上传附送资料</p>
				</div>
				<div class="pro-step cur-step">
					<span>3</span>
					<i class="pro-line"></i>
					<p>预览提交</p>
				</div>
				<div class="pro-step">
					<span>4</span>
					<p>完成</p>
				</div>
			</div>
		</div>
	</div>
	</div>
	<div id="main"></div>
	<input type="hidden" id="hxdshrInfo"/>
	
	<!-- 待审核人列表【陕西南北厅改造】 -->
	<div id="dshrDiv" style="display: none;">
	
	</div>
</body>
</html>