//日志管理
function BuildCustomManagementTabPanel_VipCustomerManage() {

	var stone = GetGridDsssata();
	var gridPanel = new Ext.grid.GridPanel({
		title: 'VIP客户管理',
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