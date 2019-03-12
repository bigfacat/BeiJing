/**
 * 当一般纳税人 点击“是否适用增值税小规模纳税人减征优惠”选择是时，弹出提示框提示：“增值税一般纳税人不适用增值税小规模纳税人减征政策，是否确定要申报减征优惠？”
 * 点击按钮“是” 关闭提示框 ，并默认选中是；点“否” 则选中否。
 * Add by C.Q 20190131 23:35
 */
function jmyhTips(bqsfsyxgmyhzc,sfzzsxgmjz,qzjyXgmFlag){
	//IF($..fjsnsrxxForm.bqsfsyxgmyhzc=='Y' && $..qcs.jzxx.xgmzg.sfzzsxgmjz=='N' && $..qcs.jzxx.xgmzg.qzjyXgmFlag=='N',false,true)
	if (bqsfsyxgmyhzc=='Y' && sfzzsxgmjz=='N' && qzjyXgmFlag=='N') {
		//当纳税人是本期非增值税小规模纳税人
		var tips="增值税一般纳税人不适用增值税小规模纳税人减征政策，是否确定要申报减征优惠？";
		/*viewEngine.formApply($('#viewCtrlId'));
		viewEngine.tipsForVerify(document.body);*/
		var b=layer.confirm(tips,{
			area: ['230px','210px'],
			title:'提示',
			closeBtn: false,
			btn : ['是','否']
		},function(index){
			layer.close(b);
		},function(index){
			//点击取消自动选为否。				
			formData.fjsSbbdxxVO.fjssbb.fjsnsrxxForm.bqsfsyxgmyhzc = "N";
			//重新执行相关公式
			var _jpath = "fjsSbbdxxVO.fjssbb.fjsnsrxxForm.bqsfsyxgmyhzc";
			formulaEngine.apply(_jpath,"N");
			// 去子页面刷新视图，子页面需要引入var subViewCustomScripts = ["/sbzs_res/fjssb/js/fjssb_cus.js"];
			$("#frmSheet")[0].contentWindow.refreshView();
			/*viewEngine.formApply($('#viewCtrlId'));
			viewEngine.tipsForVerify(document.body);*/
		});
	}
	//返回true不提示，提示改由上面弹框处理
	return true;
}
