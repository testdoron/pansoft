


function BuildCustomManagementTabPanel_OperationListGrid() {

	var stone = GetGridDsssata();
	var gridPanel = new Ext.grid.GridPanel({
		iconCls: 'icon-OperationManagementPanel',
		title: '业务管理',
		store: stone,
		border: false,
		viewConfig: {
			forceFit:true
		},
		columns: [
			new Ext.grid.RowNumberer(),
			{id:'workerid', hidden: true},
			{header: "所属机构", width: 260, sortable: true, dataIndex: 'workerSex'},
			{header: "业务编码", width: 120, sortable: true, dataIndex: 'workerRealName'},
			{header: "业务名称", width: 180, sortable: true, dataIndex: 'workerName'},
			{header: "号票相关", width: 300, sortable: true, dataIndex: 'workerName'},
			{header: "业务说明", width: 400, sortable: true, dataIndex: 'workerSex'},
			{header: "维护人", width: 120, sortable: true, dataIndex: 'workerSex'},
			{header: "更新日期", width: 120, sortable: true, dataIndex: 'workerSex'}
		],
		tbar: 
		[
			' ',
			getMenuItem("增加业务"),
			'-'
		],
		bbar: ['共 15 业务', ' ', ' ']

	});
	
	function getMenuItem(str) {
		var myMenu = new Ext.menu.Item({
			iconCls: 'icon-StatisticsDataButton',// 'menu' + n.id + "-icon"
			text: str
		});
		
		myMenu.on("click", //定义菜单项的点击事件
			function() { 
				var win = BuildOperationInfoWindow('新建');
				win.show();
			}
		);
		return myMenu;
	}
	

	return gridPanel;
}