

function BuildWorkerListGrid ( branchId ) {

	var grid = new Ext.grid.GridPanel({
		// store: new Ext.data.Store({
			// reader: reader,
			// data: xg.dummyData
		// }),
		autoHeight:true,
		border: false,
		style:'overflow:auto',

		columns: [
			{id:'company', header: "Company", width: 200, sortable: true, dataIndex: 'company'},
			{header: "Price", width: 120, sortable: true, renderer: Ext.util.Format.usMoney, dataIndex: 'price'},
			{header: "Change", width: 120, sortable: true, dataIndex: 'change'},
			{header: "% Change", width: 120, sortable: true, dataIndex: 'pctChange'},
			{header: "Last Updated", width: 135, sortable: true, renderer: Ext.util.Format.dateRenderer('m/d/Y'), dataIndex: 'lastChange'}
		],
		viewConfig: {
			forceFit: true,

			getRowClass: function(record, index) {
				var c = record.get('change');
				if (c < 0) {
					return 'price-fall';
				} else if (c > 0) {
					return 'price-rise';
				}
			}
		},
		sm: new Ext.grid.RowSelectionModel({singleSelect:true}),
		width:600,
		height:300,
		frame:true,
		title:'Framed with Checkbox Selection and Horizontal Scrolling',
		iconCls:'icon-grid'
	});
	
	var workerListPanel = new Ext.Panel({
		id: 'workerListPanel',
		margins: '3 0 3 3',
		cmargins: '3 3 3 3',
		region: 'right',
		layout: 'fit',
		// tbar: [
			// {text: 'ReadyState'}
		// ],
		items: [ grid ]

	});

	return workerListPanel;
}