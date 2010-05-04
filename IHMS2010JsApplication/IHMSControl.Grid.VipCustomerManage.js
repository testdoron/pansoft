//日志管理
function BuildCustomManagementTabPanel_VipCustomerManage() {

	var stone = GetGridDsssata();
	var gridPanel = new Ext.grid.GridPanel({
		iconCls: 'icon-CustomManagementPanel',
		title: 'VIP客户管理',
		store: stone,
		border: false,
		viewConfig: {
			forceFit:true
		},
		columns: [
			new Ext.grid.RowNumberer(),
			{id:'workerid', hidden: true},
			{header: "客户号", width: 120, sortable: true, dataIndex: 'workerName'},
			{header: "客户姓名", width: 100, sortable: true, dataIndex: 'workerNo'},
			{header: "VIP级别", width: 120, sortable: true, dataIndex: 'workerRealName'},
			{header: "所属机构", width: 200, sortable: true, dataIndex: 'workerSex'},
			{header: "描述", width: 400, sortable: true, dataIndex: 'workerSex'},
			{header: "维护人", width: 100, sortable: true, dataIndex: 'workerSex'},
			{header: "更新日期", width: 100, sortable: true, dataIndex: 'workerSex'}
		],
		tbar: 
		[
			' ',
			'搜索VIP客户:', 
			new Ext.app.SearchField({ width:120, store: this.store, paramName: 'q' }),
			'-',
			getMenuItem("增加VIP客户"),
			'-',
			getMenuItem("导入VIP客户")
		],
		bbar: ['共 734 客户', ' ', ' ']

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