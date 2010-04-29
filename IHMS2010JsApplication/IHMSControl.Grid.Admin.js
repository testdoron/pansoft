


function BuildAdminPanel () {

	
    var myTabPanel = new Ext.TabPanel ({
	
		height: 448,
		border: false,
		activeTab: 0,
		bbar: [ '状态' ],
		items: [ getParameterManagerPanel(), getLogManagerPanel(), getBackupManagerPanel(), getAboutPanel()]
	
	})
	
	return myTabPanel;
	
	//参数管理
	function getParameterManagerPanel() {
	
		var myForm = new Ext.Panel({
			title: "参数管理",
			border: false,
			bbar:['参数管理']
			//standardSubmit: true,
			//items: myFieldset
		});
		return myForm;
	
	}
	
	//日志管理
	function getLogManagerPanel() {
	
		var myForm = new Ext.grid.GridPanel({
			title: "日志管理",
			border: false
		});
		return myForm;

	}

	//备份管理
	function getBackupManagerPanel() {
	
		var myForm = new Ext.grid.GridPanel({
			title: "备份管理",
			border: false
		});
		return myForm;

	}

	//关于
	function getAboutPanel() {
	
		var myForm = new Ext.Panel({
			title: "关于",
			border: false
		});
		return myForm;

	}
	
}