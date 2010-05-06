
var operationInfoWindow = null;
function BuildOperationInfoWindow ( flag ) {

    var form = new Ext.form.FormPanel({
        baseCls: 'x-plain',
        labelWidth: 90,
        //url:'save-form.php',
        defaultType: 'textfield',

        items: [
		{
			xtype: 'compositefield',
            fieldLabel: '业务ID',
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
            fieldLabel: '所属机构',
			xtype: 'combo',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        },{
            fieldLabel: '业务名称',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        },{
            fieldLabel: '业务编码',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        },{
            fieldLabel: '号票分段前缀',
			xtype: 'combo',
            name: 'subject',
            anchor: '35%',
			forceSelection: true,
			editable: false,
			store: ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','1','2','3','4','5','6','7','8','9']
        },{
   			xtype: 'compositefield',
			fieldLabel: '号段数字范围',
			items:
			[
                {xtype: 'textfield', name: 'phone-1', width: 60, value: 1 },
                {xtype: 'displayfield', value: ' - '},
                {xtype: 'textfield', name: 'phone-2', width: 60, value: 999 }
			]
        },{
			xtype: 'compositefield',
			fieldLabel: '叫号时间段1',
			msgTarget : 'side',
			anchor    : '-20',
			defaults: {
				flex: 1
			},
			items: [
				{ xtype: 'timefield', name: 'startDate', fieldLabel: 'Start' },
				{ xtype: 'timefield',name: 'endDate', fieldLabel: 'End'}
			]
        },{
			xtype: 'compositefield',
			fieldLabel: '叫号时间段2',
			msgTarget : 'side',
			anchor    : '-20',
			defaults: {
				flex: 1
			},
			items: [
				{ xtype: 'timefield', name: 'startDate', fieldLabel: 'Start' },
				{ xtype: 'timefield',name: 'endDate', fieldLabel: 'End'}
			]
        },{
   			xtype: 'compositefield',
			fieldLabel: '取票上限',
			items:
			[
                {xtype: 'displayfield', value: '上午: '},
                {xtype: 'textfield', name: 'phone-1', width: 60, value: 500 },
                {xtype: 'displayfield', value: ' - 下午: '},
                {xtype: 'textfield', name: 'phone-2', width: 60, value: 500 }
			]
        },{
			xtype: 'textarea',
            fieldLabel: '业务说明',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        }]
    });

	if (jQuery.isEmptyObject(companyInfoWindow)) {
		companyInfoWindow = new Ext.Window({
			title: flag + ' 业务',
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
					companyInfoWindow.close();
					companyInfoWindow = null;
				}
			},{
				text: '取消',
				handler: function(){ 
					companyInfoWindow.close();
					companyInfoWindow = null;
				}
			}]
		});
	}

	return companyInfoWindow;

}
