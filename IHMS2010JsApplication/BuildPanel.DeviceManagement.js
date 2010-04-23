


IHMSModule.DeviceManagementPanel = Ext.extend(Ext.app.Module,
{
	id: "DeviceManagementPanel",
	init: function() 
	{
		this.launcher = 
		{
			text: '设备管理',
			iconCls: 'icon-DeviceManagementPanel',
			handler: this.createWindow,
			scope: this
		}
	},

	createWindow: function() 
	{
		var desktop = this.app.getDesktop();
		var win = desktop.getWindow('DeviceManagementPanel');
		if (!win) {
			win = desktop.createWindow({
				id: 'DeviceManagementPanel',
				title: "设备管理",
				width: 640,
				height: 480,
				html: '<p>设备管理...</p>',
				iconCls: 'icon-DeviceManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true
			});
		}
		win.show();
	}
});