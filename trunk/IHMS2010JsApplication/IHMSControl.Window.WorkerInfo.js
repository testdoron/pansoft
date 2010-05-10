
var workerInfoWindow = null;
function BuildWorkerInfoWindow ( flag, brachId) {

    var form = new Ext.form.FormPanel({
        baseCls: 'x-plain',
        labelWidth: 90,
        //url:'save-form.php',
        defaultType: 'textfield',

        items: [
		{
            fieldLabel: '登录名',
            name: 'subject',
            anchor: '60%'
        },{
            name: 'id',
			hidden: true,
			value: jQuery.Guid.New(),
        },{
            fieldLabel: '员工编号',
            name: 'subject',
            anchor: '50%'
        },{
            fieldLabel: '员工姓名',
            name: 'subject',
            anchor: '50%'
        },{
            xtype: 'radiogroup',
            fieldLabel: '性别',
            items: [
                {boxLabel: '男', name: 'rb-auto', inputValue: 4},
                {boxLabel: '女', name: 'rb-auto', inputValue: 5}
            ],
            anchor: '50%'
        },{
            fieldLabel: '联系电话',
            name: 'subject',
            anchor: '100%'
        },{
            fieldLabel: '手机号码',
            name: 'subject',
            anchor: '100%'
        },{
            fieldLabel: '部门',
            name: 'subject',
            anchor: '100%'
        },{
            fieldLabel: '职位',
            name: 'subject',
            anchor: '100%'
        },{
            fieldLabel: '备注',
			xtype: 'textarea',
            name: 'subject',
            anchor: '100%'
        },{
			xtype: 'checkboxgroup',
            fieldLabel: '用户角色设置',
            // autoHeight: true,
			// layout: 'form',
			columns: 3,
            defaultType: 'checkbox', // each item will be a checkbox
            items: [
                {boxLabel: 'Item 111', name: 'cb-vert-1'},
                {boxLabel: 'Item 222', name: 'cb-vert-2', checked: true},
                {boxLabel: 'Item 333', name: 'cb-vert-3'},
                {boxLabel: 'Item 444', name: 'cb-vert-4'},
                {boxLabel: 'Item 333', name: 'cb-vert-3'},
                {boxLabel: 'Item 444', name: 'cb-vert-4'}, 
				{boxLabel: 'Item 333', name: 'cb-vert-3'},
                {boxLabel: 'Item 444', name: 'cb-vert-4'}, 
				{boxLabel: 'Item 333', name: 'cb-vert-3'},
                {boxLabel: 'Item 444', name: 'cb-vert-4'},
                {boxLabel: 'Item 555', name: 'cb-vert-5'}
            ]
		}]
    });

	if (jQuery.isEmptyObject(workerInfoWindow)) {
		workerInfoWindow = new Ext.Window({
			title: flag + ' ' + GetCompanyInfo(brachId, 'alias'),
			width: 480,
			height: 460,
			minWidth: 480,
			minHeight: 460,
			layout: 'fit',
			plain: true,
			bodyStyle: 'padding:5px;',
			closable: false,
			items: form,

			buttons: [{
				text: '确定',
				handler: function(){ 
					workerInfoWindow.close();
					workerInfoWindow = null;
				}
			},{
				text: '取消',
				handler: function(){ 
					workerInfoWindow.close();
					workerInfoWindow = null;
				}
			}]
		});
	}

	return workerInfoWindow;

}
