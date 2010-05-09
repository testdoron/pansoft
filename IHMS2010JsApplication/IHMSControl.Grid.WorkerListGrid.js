

function BuildWorkerListGrid () {

	var stone = GetGridDsssata();
	var brachTree = getComboBoxTree();
	var gridPanel = new Ext.grid.GridPanel({
	
        store: stone,
		height: 448,
		border: false,
		viewConfig: {
            forceFit:true
        },
		columns: [
			new Ext.grid.RowNumberer(),
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
		tbar: 
		[
			'-', 
			'机构:',
			brachTree,
			'-',
			getMenuItem("新增员工"),
			'-',
			// getMenuItem("修改员工"),
			// '-',
			// getMenuItem("删除员工"),
			// '-', 
			'员工搜索:', 
			new Ext.app.SearchField({ width:120, store: this.store, paramName: 'q' })
		],
		bbar: ['共 788 员工', ' ', ' ']

	});
	
	function getMenuItem(str) {
		var myMenu = new Ext.menu.Item({
			iconCls: 'icon-StatisticsDataButton',// 'menu' + n.id + "-icon"
			text: str
		});
		
		myMenu.on("click", //定义菜单项的点击事件
			function() { 
				if (str == '新增员工') {
					var win = BuildWorkerInfoWindow(str, brachTree.getValue());
					win.show();
				} else {
					Ext.MessageBox.confirm(str,str);
				}
			}
		);
		return myMenu;
	}
	
	var delfileform = new Ext.BasicForm(Ext.get("delfileform"), {});//用于删除文件的form

	gridPanel.addListener('rowcontextmenu', rightClickFn);//右键菜单代码关键部分

	// var rightClick = new Ext.menu.Menu({//定义右键菜单
	Ext.Desktop.contextMenu = new Ext.menu.Menu({
		id:'allContextMenu',  //在HTML文件中必须有个rightClickCont的DIV元素
		items: [
			{//此大括号内是右键的第一个菜单项
				//id: 'rMenu1',
				handler: function(){},//点击后触发的事件,删除当前的资源文件菜单调用的函数
				text: '删除该文件'
			}
		]
	});

	function rightClickFn(grid,rowindex,e){//点击右键时执行的函数
		alert(e);
		grid.getSelectionModel().selectRow(rowindex);//此行代码是为了右键单击时同时选择grid的当前行
		e.preventDefault();
		rightClick.showAt(e.getXY());
	}
	
	function getComboBoxTree() {
	
		var companys = GetAllCompany();
		var store = new Ext.data.ArrayStore({
			fields: ['id', 'alias'],
			data : companys
		});
		var comboBoxTree;
		comboBoxTree = new Ext.form.ComboBox({
			id: 'companyComboBox',
			store: store,
			valueField: 'id',
			displayField: 'alias',
			typeAhead: true,
			mode: 'local',
			forceSelection: true,
			triggerAction: 'all',
			emptyText: '选择机构',
			selectOnFocus: true
		});

		return comboBoxTree;
	}

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
