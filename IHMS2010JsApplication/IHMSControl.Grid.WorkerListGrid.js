

function BuildWorkerListGrid () {

	var stone = GetGridDsssata();
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
			getComboBoxTree(),
			'-',
			getMenuItem("新增员工"),
			'-',
			getMenuItem("修改员工"),
			'-',
			getMenuItem("删除员工"),
			'-', 
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
				Ext.MessageBox.confirm(str,str);
			}
		);
		return myMenu;
	}
	
	function getComboBoxTree() {
		var comboBoxTree;
		comboBoxTree = new Ext.ux.ComboBoxTree({
			//renderTo : 'comboBoxTree',
			width : 180,
			tree : {
				xtype:'treepanel'//,
				// loader: new Ext.tree.TreeLoader({dataUrl:'getNodes.jsp'}),
				// root : new Ext.tree.AsyncTreeNode({id:'0',text:'根结点'})
			},
			
			//all:所有结点都可选中
			//exceptRoot：除根结点，其它结点都可选(默认)
			//folder:只有目录（非叶子和非根结点）可选
			//leaf：只有叶子结点可选
			selectNodeModel:'exceptRoot'
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

Ext.app.SearchField = Ext.extend(Ext.form.TwinTriggerField, {
    initComponent : function(){
        // if(!this.store.baseParams){
			// this.store.baseParams = {};
		// }
		Ext.app.SearchField.superclass.initComponent.call(this);
		this.on('specialkey', function(f, e){
            if(e.getKey() == e.ENTER){
                this.onTrigger2Click();
            }
        }, this);
    },

    validationEvent:false,
    validateOnBlur:false,
    trigger1Class:'x-form-clear-trigger',
    trigger2Class:'x-form-search-trigger',
    hideTrigger1:true,
    width:180,
    hasSearch : false,
    paramName : 'query',

    onTrigger1Click : function(){
        if(this.hasSearch){
            this.store.baseParams[this.paramName] = '';
			this.store.removeAll();
			this.el.dom.value = '';
            this.triggers[0].hide();
            this.hasSearch = false;
			this.focus();
        }
    },

    onTrigger2Click : function(){
        var v = this.getRawValue();
        if(v.length < 1){
            this.onTrigger1Click();
            return;
        }
		if(v.length < 2){
			Ext.Msg.alert('Invalid Search', 'You must enter a minimum of 2 characters to search the API');
			return;
		}
		this.store.baseParams[this.paramName] = v;
        var o = {start: 0};
        this.store.reload({params:o});
        this.hasSearch = true;
        this.triggers[0].show();
		this.focus();
    }
});
