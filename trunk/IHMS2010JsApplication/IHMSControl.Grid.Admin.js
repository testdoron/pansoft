


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

		var stone = GetGridDsssata();
		var gridPanel = new Ext.grid.GridPanel({
			title: '日志管理',
			store: stone,
			border: false,
			viewConfig: {
				forceFit:true
			},
			columns: [
				new Ext.grid.RowNumberer(),
				{id:'workerid', hidden: true},
				{header: "编号", width: 120, sortable: true, dataIndex: 'workerName'},
				{header: "等级", width: 100, sortable: true, dataIndex: 'workerNo'},
				{header: "时间", width: 120, sortable: true, dataIndex: 'workerRealName'},
				{header: "描述", width: 400, sortable: true, dataIndex: 'workerSex'}
			],
			tbar: 
			[
				' ',
				getMenuItem("所有日志"),
				'-',
				getMenuItem("错误日志"),
				'-',
				getMenuItem("警告日志"),
				'-',
				getMenuItem("日志清理"),
				'-', 
				'搜索:', 
				new Ext.app.SearchField({ width:120, store: this.store, paramName: 'q' })
			],
			bbar: ['共 7347582 日志', ' ', ' ']

		});
		
		function getMenuItem(str) {
			var myMenu = new Ext.menu.Item({
				iconCls: 'icon-StatisticsDataButton',// 'menu' + n.id + "-icon"
				text: str
			});
			
			myMenu.on("click", //定义菜单项的点击事件
				function() { 
					Ext.MessageBox.confirm(str,str);
				}
			);
			return myMenu;
		}
		

		return gridPanel;

	}

	//备份管理
	function getBackupManagerPanel() {
	
		var stone = GetGridDsssata();
		var gridPanel = new Ext.grid.GridPanel({
			title: '备份管理',
			store: stone,
			border: false,
			viewConfig: {
				forceFit:true
			},
			columns: [
				new Ext.grid.RowNumberer(),
				{id:'workerid', hidden: true},
				{header: "备份记录编号", width: 120, sortable: true, dataIndex: 'workerName'},
				{header: "备份时间", width: 120, sortable: true, dataIndex: 'workerNo'},
				{header: "备份操作员", width: 100, sortable: true, dataIndex: 'workerRealName'},
				{header: "描述", width: 400, sortable: true, dataIndex: 'workerSex'},
				{header: "备份类型", width: 200, sortable: true, dataIndex: 'workerTel'},
			],
			tbar: 
			[
				' ',
				getMenuItem("管理平台设置备份"),
				'-',
				getMenuItem("业务数据备份"),
				'-',
				getMenuItem("清理备份数据"),
			],
			bbar: ['备份统计：34', ' ', ' ']

		});
		
		function getMenuItem(str) {
			var myMenu = new Ext.menu.Item({
				iconCls: 'icon-StatisticsDataButton',// 'menu' + n.id + "-icon"
				text: str
			});
			
			myMenu.on("click", //定义菜单项的点击事件
				function() { 
					Ext.MessageBox.confirm(str,str);
				}
			);
			return myMenu;
		}
		
		return gridPanel;

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