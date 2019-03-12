/**
 * 联合附加税申报（专表）自定义callback
 */
var lhfjssbCallback = function() {
	var zsysb = $('#zsysb').val();
	var needInputMdse = $('#isInputMdse').val();
	
	// both,zzs,xfs,neither
	if (zsysb != 'both') {
		$("td.areaHeadBtn", window.parent.document).hide();
		// 主税并未申报完，提示阻断。
		console.log("主税已申报：" + zsysb);
		var msg = "";
		if (zsysb == 'zzs') {				// 增值税未申报完毕
			msg = "您认定了多个主税（增值税或消费税），请完成剩余的【增值税】申报后再进行附加税的申报！";
		} else if (zsysb == 'xfs') {		// 消费税未申报完毕
			msg = "您认定了多个主税（增值税或消费税），请完成剩余的【消费税】申报后再进行附加税的申报！";
		} else {							// 增值税及消费税均未申报完毕
			msg = "您认定了多个主税（增值税或消费税），请完成剩余的【增值税】及【消费税】申报后再进行附加税的申报！";
		}
		
		msg = "<div style='padding-top: 10px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + msg + "</div>";
		
		return parent.layer.alert(msg,{
			title: '提示',
			closeBtn: 0,
			yes:function(index){
				if (navigator.userAgent.indexOf("MSIE") > 0) {
					if (navigator.userAgent.indexOf("MSIE 6.0") > 0) {
						parent.window.opener = null;
						parent.window.close();
					} else {
						parent.window.open('', '_top');
						parent.window.top.close();
					}
				} else if (navigator.userAgent.indexOf("Firefox") > 0) {
					parent.window.location.href = 'about:blank ';
					parent.window.close();
				} else if (navigator.userAgent.indexOf("Chrome") > 0) {
					/* window.location.href = 'about:blank ';
					window.close(); */
					parent.top.open(location, '_self').close();
				}else {
					parent.window.open('', '_top');
					parent.window.top.close();
				}
			}
		});	
	} else {
		var index = window.parent.layer.load(0,{shade: 0.3});
   		formEngine.initialize();
		// 联合附加税暂时不需要在此处弹出免抵税额供用户填写，而是在申报页面放开填写
		/*if (needInputMdse == 'true') {
			// 隐藏父窗体按钮
	        $("td.areaHeadBtn", window.parent.document).hide();
			
			var sHtml = "";
			sHtml += "<br>";
			sHtml += "<table>";
			sHtml += "	<tr style='font-size:16px' >";
			sHtml += "		<td colspan='2' width='100%'>&nbsp;&nbsp;&nbsp;&nbsp;生产型出口退税企业：</td>";
			sHtml += "		<td>";
			sHtml += "			<input type='radio' name='sfscqy' onclick='javascript:document.getElementById(\"mdsetr\").style.visibility=\"visible\";' value='1'/>是&nbsp;&nbsp;";
			sHtml += "			<input type='radio' name='sfscqy' value='2' onclick='javascript:document.getElementById(\"mdsetr\").style.visibility=\"hidden\";' checked='checked'/>否";
			sHtml += "		</td>";
			sHtml += "	</tr>";
			sHtml += "	<tr id='mdsetr' style='visibility:hidden;'>";
			sHtml += "		<td  style='font-size:16px;padding-top:10px;' width='70%'>&nbsp;&nbsp;&nbsp;&nbsp;当期免抵税额：</td>";
			sHtml += "		<td colspan='2'>";
			sHtml += "			<input type='text' id='myInput' style='border:1px solid #fff;border-bottom-color:#b5b5b5;'/>";
			sHtml += "		</td>";
			sHtml += "	</tr>";
			sHtml += "</table>";
			
			return Message.confirmInfo({
				icoCls: '',
				msgCls: '',
				height: 170,
				width: 370,
				btn: [['确定', 'ok']],
				message: sHtml,
				title: '提示',
				closeBtn: false,
				handler:function(tp){
					$("td.areaHeadBtn", parent.document).show();
					
					$(jsonParams).attr("mdse", mdse);
					var index = window.parent.layer.load(0,{shade: 0.3});
					formEngine.initialize();
					Message.close();
					return true;
				}, 
				autoClose: false
			});	
		}*/
	}
}

