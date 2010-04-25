
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
				width: GeanJs.GetBrowserWidth() * 0.65,
				height: GeanJs.GetBrowserHeight() * 0.88,
				iconCls: 'icon-OperationManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true,
				items: [ BuildOperationManagementPanel() ]
			});
		}
		win.show();
	}
});



function BuildOperationManagementPanel() {

	var tabs = new Ext.TabPanel({
			iconCls: 'icon-OperationManagementPanel',
			border: false,
			autoHeight: true,
			activeTab: 0,
			frame:true,
			defaults:{autoHeight: true},
			items:[
				BuildCustomManagementTabPanel_OperationTypeGrid(),
				BuildCustomManagementTabPanel_BusinessProcessSetting(),
				BuildCustomManagementTabPanel_GetTecketUISetting(),
				BuildCustomManagementTabPanel_TecketPrintingSetting()
			]
		});

	return tabs;
}


function BuildCustomManagementTabPanel_OperationTypeGrid() {
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-OperationManagementPanel',
		title: '业务列表',
		html: '这里将是一个展示取号机业务的列表Grid，考虑应该使用TreeGrid，可以增删改查'
	});
	
	return gridPanel;
	
}

function BuildCustomManagementTabPanel_BusinessProcessSetting() {
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-OperationManagementPanel',
		title: '业务流程',
		html: '将510的一部份业务流程设置等后台设置内容定义在这个面板'
	});
	
	return gridPanel;	
}

function BuildCustomManagementTabPanel_GetTecketUISetting() {
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-OperationManagementPanel',
		title: '取号机界面',
		html: '取号机界面，很显然了，不需要多讲了'
	});
	
	return gridPanel;	
}

function BuildCustomManagementTabPanel_TecketPrintingSetting() {
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-OperationManagementPanel',
		title: '号票打印设置',
		html: '号票打印设置，号票打印设置，很显然了，不需要多讲了'
	});
	
	return gridPanel;	
}