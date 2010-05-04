


function BuildCustomManagementTabPanel_VipValidateRuleManage() {

	var stone = GetGridDsssata();
	var gridPanel = new Ext.grid.GridPanel({
		iconCls: 'icon-CustomManagementPanel',
		title: 'VIP客户号码校验规则',
		store: stone,
		border: false,
		viewConfig: {
			forceFit:true
		},
		columns: [
			new Ext.grid.RowNumberer(),
			{id:'workerid', hidden: true},
			{header: "所属机构", width: 240, sortable: true, dataIndex: 'workerSex'},
			{header: "VIP级别", width: 100, sortable: true, dataIndex: 'workerRealName'},
			{header: "客户号类别", width: 130, sortable: true, dataIndex: 'workerName'},
			{header: "号码长度", width: 100, sortable: true, dataIndex: 'workerNo'},
			{header: "起始位", width: 100, sortable: true, dataIndex: 'workerNo'},
			{header: "结束位", width: 100, sortable: true, dataIndex: 'workerNo'},
			{header: "校验值", width: 120, sortable: true, dataIndex: 'workerNo'},
			{header: "说明", width: 400, sortable: true, dataIndex: 'workerSex'},
			{header: "维护人", width: 120, sortable: true, dataIndex: 'workerSex'},
			{header: "更新日期", width: 120, sortable: true, dataIndex: 'workerSex'}
		],
		tbar: 
		[
			' ',
			getMenuItem("增加VIP客户号码校验规则"),
			'-'
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