/**
 * 
 */


function tycxlayerDate(){
	laydate({istime: false, format: 'YYYY-MM-DD'});
}
function tycxlayerDateMonth(){
	laydate({istime: false, format: 'YYYY-MM'});
}

$(document).ready(function() {
	$("input").each(function(){
		// 在时间input 里 定义 defualtValue="{xx}" 并且引入该js，则可以使用下面的默认时间功能
		//如：<input type="text" name="skssqq" id="skssqq" class="input01css" onclick="tycxlayerDate();" defualtValue="{CMD1}"/>
		/**
		{LYTD}去年今天; 
		{NOWDATE}当前日期; 
		{M1D1}当年一月一日; 
		{CMD1}当年当月一日;
		{O1M1}代表2000年1月1日
		*/
		var val=$(this).attr("defualtValue");
		if(val!=""){
			if(val=="{LYTD}"){//去年今天
				$(this).val(getLYTD());
			}else if(val=="{NOWDATE}"){//当前日期
				$(this).val(getNowDate());
			}else if(val=="{M1D1}"){//当年一月一日
				$(this).val(getMonth1Day1());
			}else if(val=="{CMD1}"){//当年当月一日
				$(this).val(getCurMonDay1());
			}else if(val=="{CMLD}"){//当月月末
				$(this).val(getCurMonLastDay());
			}else if(val=="{LMD1}"){//上个月1日
				$(this).val(getLastMonDay1());
			}else if(val=="{LMLD}"){//上月月末
				$(this).val(getLastMonLastDay());
			}else if(val=="{O1M1}"){
				$(this).val(getTwoYearMonth1Day1());
			}else if(val=="{NOWNY}"){ //获取当前年月
				$(this).val(getNowYearMonth());
			}
		}
	});
});

//上个月1日{LMD1}
function getLastMonDay1(){
	var myDate = new Date();
	var year = myDate.getFullYear();
	var month = myDate.getMonth();
	if(month<10){
		month="0"+month;
	}
	return year+"-"+month+"-"+"01";
}

//上月月末{LMLD}
function getLastMonLastDay(){
	var myDate = new Date();
	var year = myDate.getFullYear();
	var month = myDate.getMonth();
	if(month<10){
		month="0"+month;
	}
	var firstdate = year + '-' + month + '-01';
	var day = new Date(year,month,0);
	return year+"-"+month+"-"+day.getDate();
}

//获取去年今天的时间
function getLYTD(){
	var myDate = new Date();
	var year=myDate.getFullYear()-1;    //获取完整的年份(4位,1970-????)
	var month=myDate.getMonth()+1;       //获取当前月份(0-11,0代表1月)
	if(month<10){
		month="0"+month;
	}
	var date=myDate.getDate(); //获取当前日(1-31)
	
	if(date <10){
		date = "0"+date;
	}
	return year+"-"+month+"-"+date;
}

//获取当前年月
function getNowYearMonth(){
	var myDate = new Date();
	var year = myDate.getFullYear();
	var month = myDate.getMonth()+1;
	if(month<10){
		month="0"+month;
	}
	return year+"-"+month;
}

//当前时间
function getNowDate(){
	var myDate = new Date();
	var year = myDate.getFullYear();
	var month = myDate.getMonth()+1;
	if(month<10){
		month="0"+month;
	}
	var day = myDate.getDate();
	if(day <10){
		day = "0"+day;
	}
	return year+"-"+month+"-"+day;
}

//当月1日
function getCurMonDay1(){
	var myDate = new Date();
	var year = myDate.getFullYear();
	var month = myDate.getMonth()+1;
	if(month<10){
		month="0"+month;
	}
	return year+"-"+month+"-"+"01";
}

//当月月末
function getCurMonLastDay(){
	var myDate = new Date();
	var year = myDate.getFullYear();
	var month = myDate.getMonth()+1;
	if(month<10){
		month="0"+month;
	}
	var firstdate = year + '-' + month + '-01';
	var day = new Date(year,month,0);
	return year+"-"+month+"-"+day.getDate();
}

//获取当年1月1日的时间
function getMonth1Day1(){
	var myDate = new Date();
	var year=myDate.getFullYear();    //获取完整的年份(4位,1970-????)
	return year+"-01-01";
}

function getTwoYearMonth1Day1(){
	return "2000-01-01";
}
/**将yyyy-MM-dd 格式日期转为yyyy年MM月dd日*/
function format2Show(date){
	if(date=="" || date==null || date==undefined) return "";
	var dates=date.split("-");
	if(dates.length<3){
		return dates[0]+"年"+dates[1]+"月";
	}else{
		return dates[0]+"年"+dates[1]+"月"+dates[2]+"日";
	}
}

/**
 * 展示统计的起止时间
 */
function showStaticsDates(){
	if($(".show_dates").length>0){
		var sjq=$("input[forshow=sjq]").val();
		var sjz=$("input[forshow=sjz]").val();
		$(".show_dates").html(format2Show(sjq)+"至"+format2Show(sjz));
	}
}