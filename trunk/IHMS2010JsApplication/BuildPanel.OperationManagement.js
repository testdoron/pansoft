
/**
OperationManagementPanel(业务管理)
*/
IHMSModule.OperationManagementPanel = Ext.extend(Ext.app.Module, 
{
	id: "OperationManagementPanel",
	init: function() 
	{
		this.launcher = 
		{
			text: '业务管理',
			iconCls: 'icon-OperationManagementPanel',
			handler: this.createWindow,
			scope: this
		}
	},

	createWindow: function() 
	{
		var desktop = this.app.getDesktop();
		var win = desktop.getWindow('OperationManagementPanel');
		if (!win) {
			win = desktop.createWindow({
				id: 'OperationManagementPanel',
				title: "业务管理",
				width: 640,
				height: 480,
				html: '<p>业务管理...</p>',
				iconCls: 'icon-OperationManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true
			});
		}
		win.show();
	}
});