
var workerInfoWindow = null;
function BuildWorkerInfoWindow ( flag, brachId) {

    var form = new Ext.form.FormPanel({
		title: 'asdfasdfsdfad',
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
			xtype: 'fieldset',
            title: '用户角色',
            autoHeight: true,
            defaultType: 'checkbox', // each item will be a checkbox
            items: [{
                checked: true,
                boxLabel: '统计报表查询',
                name: ''
            }, {
                boxLabel: 'Vip客户管理',
                name: ''
            }, {
                boxLabel: '设备查询',
                name: ''
            }]

		}]
    });

	if (jQuery.isEmptyObject(workerInfoWindow)) {
		workerInfoWindow = new Ext.Window({
			title: flag + ' ' + GetCompanyInfo(brachId, 'alias'),
			width: 480,
			height: 500,
			minWidth: 480,
			minHeight: 500,
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
