IHMSModule.BookingManagementPanel = Ext.extend(Ext.app.Module, 
{
	id: "BookingManagementPanel",
	init: function() {
		this.launcher = {
			text: '预约管理',
			iconCls: 'icon-BookingManagementPanel',
			handler: this.createWindow,
			scope: this
		}
	},

	createWindow: function(src) {
		var desktop = this.app.getDesktop();
		var win = desktop.getWindow('BookingManagementPanel');
		if (!win) {
			win = desktop.createWindow({
				id: 'BookingManagementPanel',
				title: "预约管理",
				width: GeanJs.GetBrowserWidth() * 0.50,
				height: GeanJs.GetBrowserHeight() * 0.60,
				iconCls: 'icon-SystemManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true
				//items: [ BuildSystemManagementPanel() ]
			});
		}
		win.show();
	}
});