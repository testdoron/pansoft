
var workerInfoWindow = null;
function BuildWorkerInfoWindow ( flag ) {

    var form = new Ext.form.FormPanel({
        baseCls: 'x-plain',
        labelWidth: 90,
        //url:'save-form.php',
        defaultType: 'textfield',

        items: [
		{
			xtype: 'compositefield',
            fieldLabel: '员工ID',
			items:
			[{
				xtype: 'textfield',
				readOnly: true,
				disable: false,
				width: 280,
				style: 'font-size: 10px;',
				value: jQuery.Guid.New()//,
			},{
				xtype: 'displayfield',
				value: '只读字段'
			}]
		},{
            fieldLabel: '登录名',
            name: 'subject',
            anchor: '100%'
        },{
            fieldLabel: '员工编号',
            name: 'subject',
            anchor: '100%'
        },{
            fieldLabel: '员工姓名',
            name: 'subject',
            anchor: '100%'
        },{
            xtype: 'radiogroup',
            fieldLabel: '性别',
            items: [
                {boxLabel: '男', name: 'rb-auto', inputValue: 4},
                {boxLabel: '女', name: 'rb-auto', inputValue: 5}
            ]
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
        }]
    });

	if (jQuery.isEmptyObject(workerInfoWindow)) {
		workerInfoWindow = new Ext.Window({
			title: flag,
			width: 480,
			height:400,
			minWidth: 300,
			minHeight: 200,
			layout: 'fit',
			plain:true,
			bodyStyle:'padding:5px;',
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
