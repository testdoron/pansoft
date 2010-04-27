

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
				width: GeanJs.GetBrowserWidth() * 0.65,
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
		autoHeight: true,
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
	
	var menuItem = getMenuItem();
    var treegrid = new Ext.ux.tree.TreeGrid({
		iconCls: 'icon-SystemManagementPanel',
		border: false,
        width: 500,
        autoHeight: true,
        enableDD: true,

        columns:[
		{
            dataIndex: 'companyId',
            hidden: true
        },{
            header: '机构名称',
            dataIndex: 'companyName',
            width: 300
        },{
            header: '机构编码',
            width: 100,
            dataIndex: 'companyNo',
            align: 'center'
        },{
            header: '营业厅联系人',
            width: 100,
            dataIndex: 'companyManager'
        },{
            header: '联系电话',
            width: 100,
            dataIndex: 'companyPhone'
        },{
			id: 'companyAddress',
            header: '地址',
            dataIndex: 'companyAddress'
        }],

		tbar: [
			menuItem
		],
		
		bbar: [
			{text: '共20机构'}
		],
		
        //dataUrl: 'company.json',
        autoExpandColumn: 'companyAddress'

    });
	
	function getMenuItem() {
		var menuitem = new Ext.menu.Item({
			id: 'systemManagementAddCompany',
			text: '新增机构',
			iconCls: 'icon-StatisticsDataButton'// 'menu' + n.id + "-icon"
		});
		
		menuitem.on("click", //定义菜单项的点击事件
			function() { 
				var win = BuildCompanyInfoWindow('新建');
				win.show();
			}
		);
		return menuitem;
	}
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-SystemManagementPanel',
		title: '机构管理',
		border: false,
		layout: 'fit',
		items: [ treegrid ]
	});
	
	return gridPanel;
}

function BuildSystemManagementPanel_WorkerManagerGrid() {
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-SystemManagementPanel',
		title: '用户管理',
		layout: 'fit',
		html: '维护一个所有柜员的Grid，可以增删改查'
	});
	
	return gridPanel;
	
}

function BuildSystemManagementPanel_GroupAndRoleManagePanel() {
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-SystemManagementPanel',
		title: '用户组/角色/权限管理',
		layout: 'fit',
		html: '维护用户组/角色/权限管理的面板，可以增删改查'
	});
	
	return gridPanel;
	
}

function BuildSystemManagementPanel_AdministratorPanel() {
	
	var gridPanel = new Ext.Panel({
		iconCls: 'icon-SystemManagementPanel',
		title: '管理员维护',
		layout: 'fit',
		html: '包括参数维护，日志维护，备份等功能'
	});
	
	return gridPanel;
	
}
