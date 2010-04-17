    
IHMSModule = new Ext.app.App({
	init: function() {
		Ext.QuickTips.init(); //把 ext:qtip 的值用于显示提示
	},
	getModules: function() {
		return [
			// 以下是模块的载入，在我们的权限中，模块即为资源
			// 所以以下模块的实例需用Jsp根据当前用户的权限来载入相应的实例
			new IHMSModule.CustomManagementPanel(),
			new IHMSModule.OperationManagementPanel(),
			new IHMSModule.DeviceManagementPanel(),
			new IHMSModule.StatisticsManagementPanel(),
			new IHMSModule.BookingManagementPanel(),
			new IHMSModule.SystemManagementPanel()
			];
	},

	// 组装开始菜单
	getStartConfig: function() {
		return {
			title: IHMSData.UITxt.StartMenuWorkerTxt.concat(' : ').concat(IHMSData.ConfigJson.WorkerName),
			iconCls: 'user',
			toolItems: [{
				text: IHMSData.UITxt.StartMenuSettingTxt,
				iconCls: 'settings',
				scope: this
			}, '-', {
				text: IHMSData.UITxt.StartMenuLogoutTxt,
				iconCls: 'logout',
				scope: this
				}]
			};
		}
	});
    
