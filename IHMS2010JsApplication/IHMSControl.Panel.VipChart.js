


function BuildCustomManagementTabPanel_VipChart() {

	//var stone = GetGridDsssata();
	var panel = new Ext.Panel({
		iconCls: 'icon-CustomManagementPanel',
		title: '客户报表',
		border: false,
		autoHeight: true,
		tbar: 
		[
			' ',
			getMenuItem("VIP客户到达Top100"),
			'-'
		]
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

	return panel;
}