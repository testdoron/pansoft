<!------------------------------------>
<!--       			GeanJs         	-->
<!------------------------------------>
var GeanJs = {
	version: '2.0.1',
	email: 'nsimple.cn@gmail.com'
}


/* 获得浏览器可视界面的高度 */
GeanJs.GetBrowserHeight = function() {
	if ($.browser.msie) {
		return document.compatMode == "CSS1Compat" ? document.documentElement.clientHeight : document.body.clientHeight;
	}
	else {
		return self.innerHeight;
	}
}

/* 获得浏览器可视界面的宽度 */
GeanJs.GetBrowserWidth = function() {
	if ($.browser.msie) {
		return document.compatMode == "CSS1Compat" ? document.documentElement.clientWidth : document.body.clientWidth;
	}
	else {
		return self.innerWidth;
	}
}


