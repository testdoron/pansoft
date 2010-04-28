

function BuildWorkerListGrid () {

	var stone = GetGridDsssata();
	var gridPanel = new Ext.grid.GridPanel({
	
        store: stone,
		height: 450,
		viewConfig: {
            forceFit:true
        },
		columns: [
			{id:'workerid', hidden: true},
			{header: "登录名", width: 100, sortable: true, dataIndex: 'workerName'},
			{header: "员工编号", width: 80, sortable: true, dataIndex: 'workerNo'},
			{header: "员工姓名", width: 100, sortable: true, dataIndex: 'workerRealName'},
			{header: "性别", width: 40, sortable: true, dataIndex: 'workerSex', align: 'center'},
			{header: "联系电话", width: 100, sortable: true, dataIndex: 'workerTel'},
			{header: "手机号码", width: 80, sortable: true, dataIndex: 'workerMobile'},
			{header: "部门", width: 60, sortable: true, dataIndex: 'workerDev'},
			{header: "职位", width: 60, sortable: true, dataIndex: 'workerWei'},
			{header: "首次登录", width: 60, sortable: true, dataIndex: 'workerFistLogin'},
			{header: "最后登录", width: 60, sortable: true, dataIndex: 'workerLastLogin'},
			{header: "登录次数", width: 60, sortable: true, dataIndex: 'workerLoginCount'}
		],
		tbar: [
			{text: '新建员工'}
		],
		bbar: [
			{text: '王小石'}
		]

	});

	return gridPanel;
}

function GetGridDsssata()
{
	var arrayStone = new Ext.data.ArrayStore({
		fields: [
			{name: 'workerName', type: 'string'},
			{name: 'workerNo', type: 'string'},
			{name: 'workerRealName', type: 'string'},
			{name: 'workerSex', type: 'string'},
			{name: 'workerTel', type: 'string'},
			{name: 'workerMobile', type: 'string'},
			{name: 'workerDev', type: 'string'},
			{name: 'workerWei', type: 'string'},
			{name: 'workerFistLogin', type: 'string'},
			{name: 'workerLastLogin', type: 'string'},
			{name: 'workerLoginCount', type: 'string'}
		 ]
	});
	
	function getDData() {
		var ddata = new Array();
		for (var i = 100; i < 200; i++) {
			var ar = new Array();
			for (var j = 10; j < 21; j++) {
				ar.push(i.toString() + j.toString());
			}
			ddata.push(ar);
		}
		return ddata;
	}
	
	arrayStone.loadData(getDData());
	return arrayStone;
}