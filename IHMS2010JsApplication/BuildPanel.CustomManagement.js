
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
				BuildCustomManagementTabPanel_VipValidateRuleProManage(),
				BuildCustomManagementTabPanel_VipRemoteValidateManage(),
				BuildCustomManagementTabPanel_VipChart()
			]
		});

	return tabs;
}
