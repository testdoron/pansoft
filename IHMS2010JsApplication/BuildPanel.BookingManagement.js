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
				width: 640,
				height: 480,
				html: '<p>预约管理...</p>',
				iconCls: 'icon-BookingManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true
			});
		}
		win.show();
	}
});