


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
		var treepanel = BuildCompanyGroupTreePanel();
		var desktop = this.app.getDesktop();
		var win = desktop.getWindow('DeviceManagementPanel');
		if (!win) {
			win = desktop.createWindow({
				id: 'DeviceManagementPanel',
				title: "设备管理",
				width: GeanJs.GetBrowserWidth() * 0.90,
				height: GeanJs.GetBrowserHeight() * 0.87,
				layout: 'border', 
				iconCls: 'icon-DeviceManagementPanel',
				shim: false,
				animCollapse: false,
				constrainHeader: true,
				items: [ treepanel, BuildDeviceView() ]
			});
		}
		win.show();
		if (!jQuery.isEmptyObject(IHMSData.Group.Branches.items)) {
			treepanel.expandAll();
		}
	}
});

//BuildDeviceView();

function BuildDeviceView() {
	var store = new Ext.data.ArrayStore({
		fields: [
			'name', 
			'url',
			{name:'size', type: 'float'},
			{name:'lastmod', type:'date', dateFormat:'timestamp'}
		]
	});
	var d = GetDeviceData();
	store.loadData(d);
	
	var tpl = new Ext.XTemplate(
		'<tpl for=".">',
			'<div id="{name}" class="thumb-wrap">',
			'<div class="thumb"><img src="{url}" title="{name}" class="thumb-img"></div>',
		'</tpl>',
		'<div class="x-clear"></div>'
	);

	var deviceView = new Ext.DataView({
		store: store,
		tpl: tpl,
		autoHeight:true,
		multiSelect: true,
		style:'overflow:auto',
		//overClass:'x-view-over',
		itemSelector:'div.thumb-wrap',
		emptyText: 'No images to display'
	});
	
	var devicePanel = new Ext.Panel({
		id: 'DevicePanel',
		region: 'center',
		layout: 'fit',
		margins: '3 0 3 3',
		cmargins: '3 3 3 3',
		tbar: [
			{text: 'ReadyState'}
		],
		items: [deviceView]

	});

	//panel.renderTo("deviceImgView");
	
	return devicePanel;
}



