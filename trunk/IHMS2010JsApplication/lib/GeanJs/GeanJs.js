<!------------------------------------>
<!--       			GeanJs         	-->
<!------------------------------------>
var GeanJs = {
	version: '2.0.1',
	email: 'nsimple.cn@gmail.com'
}


/* �����������ӽ���ĸ߶� */
GeanJs.GetBrowserHeight = function() {
	if ($.browser.msie) {
		return document.compatMode == "CSS1Compat" ? document.documentElement.clientHeight : document.body.clientHeight;
	}
	else {
		return self.innerHeight;
	}
}

/* �����������ӽ���Ŀ�� */
GeanJs.GetBrowserWidth = function() {
	if ($.browser.msie) {
		return document.compatMode == "CSS1Compat" ? document.documentElement.clientWidth : document.body.clientWidth;
	}
	else {
		return self.innerWidth;
	}
}


