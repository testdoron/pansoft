

IHMSModule.SystemManagementPanel = Ext.extend(Ext.app.Module,
{
	id: "SystemManagementPanel",
	init: function() 
	{
		this.launcher = 
		{
			text: '系统管理',
			iconCls: 'icon-SystemManagementPanel',
			handler: this.createWindow,
			scope: this
		}
	},

	createWindow: function() 
	{
		var desktop = this.app.getDesktop();
		var win = desktop.getWindow('SystemManagementPanel');
		if (!win) {
			win = desktop.createWindow({
				id: 'SystemManagementPanel',
				title: "系统管理",
				width: 640,
				height: 480,
				html: '<p>系统管理...</p>',
				iconCls: 'icon-SystemManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true
			});
		}
		win.show();
	}
});