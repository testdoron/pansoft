

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
				layout: 'fit',
				width: GeanJs.GetBrowserWidth() * 0.70,
				height: GeanJs.GetBrowserHeight() * 0.88,
				iconCls: 'icon-SystemManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true,
				items: [ BuildSystemManagementPanel() ]
			});
		}
		win.show();
	}
});


function BuildSystemManagementPanel() {

	var tabs = new Ext.TabPanel({
		iconCls: 'icon-SystemManagementPanel',
		border: false,
		activeTab: 0,
		frame:true,
		defaults:{autoHeight: true},
		items:[
			BuildSystemManagementPanel_BranchManagerTreeGrid(),
			BuildSystemManagementPanel_WorkerManagerGrid(),
			BuildSystemManagementPanel_GroupAndRoleManagePanel(),
			BuildSystemManagementPanel_AdministratorPanel()
		]
	});

	return tabs;
}


function BuildSystemManagementPanel_BranchManagerTreeGrid() {

	var branchManagerTreeGrid = BuildBranchManagerTreeGrid();
	var gridPanel = new Ext.Panel({
		title: '机构管理',
		border: false,
		layout: 'fit',
		iconCls: 'icon-SystemManagementPanel',
		items: branchManagerTreeGrid
	});
	
	return gridPanel;
}

function BuildSystemManagementPanel_WorkerManagerGrid() {
	
	var gridPanel = new Ext.Panel({
		title: '用户管理',
		border: false,
        layout: 'fit' ,
		iconCls: 'icon-SystemManagementPanel',
		items: BuildWorkerListGrid()
	});
	
	return gridPanel;
}

function BuildSystemManagementPanel_GroupAndRoleManagePanel() {
	
	var gridPanel = new Ext.Panel({
		title: '用户组/角色/权限管理',
		layout: 'fit',
		border: false,
		iconCls: 'icon-SystemManagementPanel',
		html: '维护用户组/角色/权限管理的面板，可以增删改查'
	});
	
	return gridPanel;
	
}

function BuildSystemManagementPanel_AdministratorPanel() {
	
	var gridPanel = new Ext.Panel({
		title: '管理员维护',
		layout: 'fit',
		border: false,
		iconCls: 'icon-SystemManagementPanel',
		html: '包括参数维护，日志维护，备份等功能'
	});
	
	return gridPanel;
	
}
