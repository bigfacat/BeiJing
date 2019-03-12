﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_login.aspx.cs" Inherits="JlueTaxSystemBeiJingBS.xxmh.html.index_login" %>

<!DOCTYPE html>
<html>
<head>
	<meta name="renderer" content="ie-comp" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=EDGE" />
    <meta name="renderer" content="ie-stand">
	<title>国家税务总局北京市电子税务局</title>
	<link rel="stylesheet" href="/xxmh/resources4/layui/css/layui.css">
	<link rel="stylesheet" href="/xxmh/resources4//tax-font-icon/iconfont.css">
	<link rel="stylesheet" href="/xxmh/resources4/tax-css/index.css">
	<link rel="stylesheet" href="/xxmh/resources4/tax-css/common.css">
	<link rel="stylesheet" href="/xxmh/resources/css/newcss/addstyle.css"  type="text/css" />
	<link rel="stylesheet" href="/xxmh/resources4/layui/css/modules/layer/default/layer.css">
	<link rel="icon" href="/xxmh/resources/images/common/favicon.ico" type="image/x-icon">
	<script src="/xxmh/resources/skin/js/jquery.js"></script>
	<script src="/xxmh/resources4/layui/layui.js"></script>
	<script src="/xxmh/resources4/layui/transfer.js"></script>
	<script src="/xxmh/resources4/tax-module/vticker/jquery.vticker-min.js"></script>
	<script type="text/javascript" src="/xxmh/resources/js/jquery.lazyload.min.js"></script>
	<script type="text/javascript" src="/xxmh/resources/js/html5.min.js"></script>
	<script type="text/javascript" src="/xxmh/resources/js/respond.min.js"></script>

	<script src="/xxmh/resources/js/portal.js"></script>
	<script type="text/javascript" src="/xxmh/resources/js/golobalTitle.js"></script>
	<script type="text/javascript" src="/xxmh/resources/js/goPages.js"></script>
	<script type="text/javascript" src="/xxmh/resources/js/menuUtil.js"></script>
	<script src="/xxmh/resources/js/urlLogic.js"></script>
	<script src="/xxmh/resources/js/loginDbtxData.js"></script>
	<script type="text/javascript" src="/xxmh/resources/js/index_login.js"></script>
	<script src="/xxmh/resources/js/mlog.js"></script>
	<script type="text/javascript" src="/xxmh/resources/js/zxkf.js"></script>
</head>
<html>
 <head></head>
 <body class="bodybg-1"> 
  <!--head--> 
  <div class="tax-head-box login-after"> 
   <img id="titleLogo" class="head-logo" src="" /> 
   <div class="head-main"> 
    <!-- <div class="head-user" id="userName" style="min-height:18px;"></div> --> 
    <div class="head-right-menu loginbefore"> 
     <div class="head-search"> 
      <input type="text" id="keyword" name="text" placeholder="请输入需要搜索的内容" class="search-input" /> 
      <a id="keysearch" href="#">搜索</a> 
     </div> 
     <div class="head-btn"> 
      <a style="display:none" href="javascript:backZy();" id="zyBtn" class="head-btn-home"><span style="margin-left: 0px;">主页</span></a> 
      <!-- <p style="display:none">|</p> --> 
      <div id="userBtn" class="user-item" style="display:none;"> 
       <a href="##" class="user-name" id="userName"></a> 
       <ul> 
        <p class="top-dot"><i class="iconfont fsicon-dot-up"></i></p> 
        <dl> 
         <dd class="user-item-txt" id="userName2"></dd> 
         <dd class="user-item-menu" id="qhsfBtn" style="display:none;">
          <a href="javascript:changeCard();"><i class="iconfont fsicon-qiehuanjiaose"></i>切换身份</a>
         </dd> 
         <dd class="user-item-menu" id="zztsfqhBtn" style="display:none;">
          <a href="javascript:zztsfqh();" onclick="event.preventDefault();"><i class="iconfont fsicon-xuanze"></i>选择主管税务机关</a>
         </dd> 
        </dl> 
       </ul> 
      </div> 
      <a href="javascript:logout();" onclick="event.preventDefault();" style="display:none;" id="tcBtn" class="head-btn-close"><span>退出</span></a> 
     </div> 
     <div class="dlbox" id="dlbox" style="display:none;"> 
      <a href="javascript:login();" class="loginico"> <img src="/xxmh/resources4/tax-images/login/loginimg.png" /> <h4>登录</h4> </a> 
     </div> 
    </div> 
   </div> 
  </div>  
  <!--新增头部结束--> 
  <div class="mian-container pad-top layui-row"> 
   <!--side--> 
   <div class="con-side"> 
    <div class="title"> 
     <h3> <img src="/xxmh/resources4/tax-images/login/login_ico1.png" />常用功能 </h3> 
     <div class="title-r"> 
      <a id="cygnsz" href="#">设置</a> 
     </div> 
    </div> 
    <div id="cygn" class="listcon menusDiv menusDiv-l"> 
    </div> 
    <div class="title titnbar"> 
     <h3> <img src="/xxmh/resources4/tax-images/login/login_ico2.png" />套餐业务 </h3> 
    </div> 
    <div class="listcon menusDiv menusDiv-l"> 
    </div> 
    <div class="title titnbar"> 
     <h3> <img src="/xxmh/resources4/tax-images/login/login_ico3.png" />特色业务 </h3> 
    </div> 
    <div class="listcon menusDiv menusDiv-l"> 
    </div> 
   </div> 
   <!--rightcon--> 
   <div class="con-rcon"> 
    <div class="layui-tab layui-tab-brief layui-tab-hover" lay-filter="docDemoTabBrief" id="topTabs"> 
     <ul id="topTabul" class="layui-tab-title contit"> 
      <li id="wdxxTab" class="showtab1 layui-this">我的信息</li> 
      <li id="wybsTab" class="showtab1">我要办税</li> 
      <li id="wycxTab" class="showtab1">我要查询</li> 
      <li id="hdzxTab" class="showtab1">互动中心</li> 
      <li id="gzfwTab" class="showtab2">公众服务</li> 
      <li id="gxfwTab" class="showtab1" style="display:none;">个性服务</li> 
     </ul> 
     <div class="layui-tab-content"> 
      <div class="layui-tab-item layui-show"> 
       <div class="conbox menusDiv menusDiv-r"> 
       </div> 
      </div> 
      <div class="layui-tab-item"> 
       <div class="conbox menusDiv menusDiv-r"> 
       </div> 
      </div> 
      <div class="layui-tab-item"> 
       <div class="conbox menusDiv menusDiv-r"> 
       </div> 
      </div> 
      <div class="layui-tab-item"> 
       <div class="conbox menusDiv menusDiv-r"> 
       </div> 
      </div> 
      <div class="layui-tab-item"> 
       <div class="conbox menusDiv menusDiv-r"> 
       </div> 
      </div> 
      <div class="layui-tab-item"> 
       <div class="conbox menusDiv menusDiv-r"> 
       </div> 
      </div> 
     </div> 
     <div class="nexttab nexttab1" style="display:none;"> 
      <div class="layui-tab layui-tab-brief layui-tab-hover"> 
       <ul class="layui-tab-title contit"> 
        <li class="layui-this">我的待办<span class="layui-badge" id="dbxxTotalCount" style="display: none;"></span></li> 
        <li>服务提醒<span id="sstxTotalCount" class="layui-badge" style="display: none;"></span></li> 
        <a href="#" onclick="return false;goIndexUrl('/xxmh','dbtx','')" class="newsMore link-weakest">更多&gt;</a> 
       </ul> 
       <div class="layui-tab-content secondcon"> 
        <div class="layui-tab-item layui-show"> 
         <div class="tablecon home-table-01"> 
          <table id="dbxxDataList" class="layui-table" lay-even="" lay-skin="nob" lay-size="lg"> 
           <colgroup> 
            <col /> 
            <col width="220" /> 
            <col width="120" /> 
            <col width="120" /> 
           </colgroup> 
           <thead> 
            <tr> 
             <th>事项名称</th> 
             <th>截止日期</th> 
             <th>状态</th> 
             <th>操作</th> 
            </tr> 
           </thead> 
           <tbody>
            <tr name="trData">
             <td colspan="4" style="text-align:center;height:220px;border-top: 1px solid #dddddd;">暂无待办</td>
            </tr>
           </tbody> 
          </table> 
         </div> 
        </div> 
        <div class="layui-tab-item"> 
         <div class="tablecon home-table-01"> 
          <table id="sstxDataList" class="layui-table" lay-even="" lay-skin="nob" lay-size="lg"> 
           <colgroup> 
            <col /> 
            <col width="220" /> 
           </colgroup> 
           <thead> 
            <tr> 
             <th>事项名称</th> 
             <th>时间</th> 
            </tr> 
           </thead> 
           <tbody>
            <tr name="trData">
             <td colspan="2" style="text-align:center;height:220px;border-top: 1px solid #dddddd;">暂无提醒</td>
            </tr>
           </tbody> 
          </table> 
         </div> 
        </div> 
       </div> 
      </div> 
     </div> 
     <div class="nexttab nexttab2" style="display:none;"> 
      <div class="layui-tab layui-tab-brief layui-tab-hover"> 
       <!-- 通知公告 --> 
       <ul class="layui-tab-title contit"> 
        <li class="layui-this">通知公告</li> 
        <a href="#" onclick="return false;goIndexUrl('/xxmh?tabTitle=gzfwTab','tzgg','')" class="newsMore link-weakest">更多&gt;</a> 
       </ul> 
       <div class="layui-tab-content"> 
        <div class="layui-tab-item layui-show newlist" id="znggDiv"> 
         <ul id="znggBox" style="height:288px;"></ul> 
        </div> 
        <div class="layui-tab-item newlist" id="zcfgDiv"> 
         <ul id="zcfgBox" style="height:288px;"></ul> 
        </div> 
        <div class="layui-tab-item newlist" id="zdssDiv"> 
         <ul id="zdssBox" style="height:288px;"></ul> 
        </div> 
        <div class="layui-tab-item newlist" id="xydjDiv"> 
         <ul id="xydjBox" style="height:288px;"></ul> 
        </div> 
        <div class="layui-tab-item newlist" id="qsggDiv"> 
         <ul id="qsggBox" style="height:288px;"></ul> 
        </div> 
       </div> 
      </div> 
     </div> 
     <!--rightconend--> 
    </div> 
   </div> 
  </div> 
  <!--<div class="backtop">
   <ul> 
    <li class="mabox"><a href="#none"><img src="/xxmh/resources/skin/images/icons/left_icons03.png" /><span>微信</span></a> 
     <div class="erweima"> 
      <h3>微信二维码</h3> 
      <div class="ctrl01"> 
       <img src="/xxmh/resources/skin/images/gswx.jpg" width="100" height="100" /> 
       <img src="/xxmh/resources/skin/images/dswx.jpg" width="100" height="100" />
      </div> 
      <div class="ctrl02">
       <img src="/xxmh/resources/skin/images/gswx.jpg" width="100" height="100" />
      </div> 
     </div> </li> 
    <li class="mabox"><a href="#none"><img src="/xxmh/resources/skin/images/icons/left_icons01.png" /><span>微博</span></a> 
     <div class="erweima"> 
      <h3>微博二维码</h3> 
      <div class="ctrl01"> 
       <img src="/xxmh/resources/skin/images/gswb.jpg" width="100" height="100" /> 
       <img src="/xxmh/resources/skin/images/dswb.png" width="100" height="100" />
      </div> 
      <div class="ctrl02">
       <img src="/xxmh/resources/skin/images/gswb.jpg" width="100" height="100" />
      </div> 
     </div> </li> 
    <li class="mabox"> <a href="#none" onclick="onclickZxkf()"> <img title="在线客服" src="/xxmh/resources/skin/images/icons/left_icons06.png" /> </a> </li> 
    <li><a href="#"><img src="/xxmh/resources/skin/images/icons/left_icons04.png" /><span>顶部</span></a></li> 
   </ul> 
  </div> -->
  <input type="hidden" id="logoutUrl" value="" />
  <!-- 退出登录地址 --> 
  <input type="hidden" id="ssoServerAddr" value="" />
  <!-- 单点登录地址 --> 
  <input type="hidden" id="ssoXxmhUrl" value="" />
  <!-- 信息门户单点登录地址 --> 
  <div style="display:none">
   <iframe id="qhsfIfrm" src="" style="display:none"></iframe>
  </div>
  <!-- 切换身份后，通知外围系统 --> 
 </body>
</html>
</html>