
/**
	模块：IHMSModule
	模块：CustomManagementPanel(客户管理)
*/
IHMSModule.CustomManagementPanel = Ext.extend(Ext.app.Module, 
{
	id: "CustomManagementPanel",
	init: function() 
	{
		this.launcher = 
		{
			text: '客户管理',
			iconCls: 'icon-CustomManagementPanel',
			handler: this.createWindow,
			scope: this
		}
	},

	createWindow: function() 
	{
		var desktop = this.app.getDesktop();
		var win = desktop.getWindow('CustomManagementPanel');
		if (!win) {
			win = desktop.createWindow({
				id: 'CustomManagementPanel',
				title: "客户管理",
				width: GeanJs.GetBrowserWidth() * 0.70,
				height: GeanJs.GetBrowserHeight() * 0.85,
				//layout: 'border', 
				iconCls: 'icon-CustomManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true,
				items: [ BuildCustomManagementTabPanel() ]
			});
		}
		win.show();
	}

});   


function BuildCustomManagementTabPanel() {

	var tabs = new Ext.TabPanel({
			iconCls: 'icon-CustomManagementPanel',
			border: false,
			height: 428,
			//autoHeight: true,
			activeTab: 0,
			frame:true,
			defaults:{autoHeight: true},
			items:[
				BuildCustomManagementTabPanel_VipCustomerManage(),
				BuildCustomManagementTabPanel_VipValidateRuleManage(),
				BuildCustomManagementTabPanel_CRMGrid()
			]
		});

	return tabs;
}


function BuildCustomManagementTabPanel_CRMGrid() {
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-CustomManagementPanel',
		title: '客户报表',
		html: '这里将是一个展示“进入营业厅较多的客户”的柱状图与客户报表'
	});
	
	return gridPanel;
	
}

function BuildCustomManagementTabPanel_VipValidateRuleManage() {

	var gridPanel = new Ext.Panel({
		iconCls: 'icon-CustomManagementPanel',
		title: 'VIP验证规则管理',
		html: '1.点击“添加规则”按键则弹出“添加规则”页面； 2．输入“规则号码”；3．在下拉框中选择“客户等级”；4．输入“卡类型”；5．输入“备注”（可为空）；6．点击“保存”按键即可。'
	});
	
	return gridPanel;

}