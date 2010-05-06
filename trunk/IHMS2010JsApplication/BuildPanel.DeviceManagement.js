


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
				width: GeanJs.GetBrowserWidth() * 0.81,
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
            '<div class="thumb-wrap" id="{name}">',
		    '<div class="thumb"><img src="{url}" title="{name}"></div>',
		    '<span class="x-editable">{shortName}</span></div>',
        '</tpl>',
        '<div class="x-clear"></div>'
	);

	var panel = new Ext.Panel({
		id:'images-view',
		margins: '3 3 3 0',
		cmargins: '3 3 3 3',
		//border: false,
		//autoHeight: true,
		layout: 'border',
		region: 'center',
		
		tbar: 
		[
			'设备运行状态',
		],
		bbar:
		[
			'正常',
		],

		items: new Ext.DataView({
			store: store,
			tpl: tpl,
			region: 'center',
			autoScroll: true, 
			multiSelect: true,
			overClass:'x-view-over',
			itemSelector:'div.thumb-wrap',
			emptyText: 'No images to display',

			plugins: [
				new Ext.DataView.DragSelector()
				//new Ext.DataView.LabelEditor({dataIndex: 'name'})
			],

			prepareData: function(data){
				data.shortName = Ext.util.Format.ellipsis(data.name, 15);
				data.sizeString = Ext.util.Format.fileSize(data.size);
				data.dateString = data.lastmod.format("m/d/Y g:i a");
				return data;
			},
			
			listeners: {
				selectionchange: {
					fn: function(dv,nodes){
						var l = nodes.length;
						var s = l != 1 ? 's' : '';
						//panel.setTitle('Simple DataView ('+l+' item'+s+' selected)');
					}
				}
			}
		})
	});
	return panel;
}



