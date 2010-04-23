
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
				width: 640,
				height: 480,
				html: '<p>客户管理...</p>',
				iconCls: 'icon-CustomManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true
			});
		}
		win.show();
	}

});   