
var companyInfoWindow = null;
function BuildCompanyInfoWindow ( flag ) {

    var form = new Ext.form.FormPanel({
        baseCls: 'x-plain',
        labelWidth: 90,
        //url:'save-form.php',
        defaultType: 'textfield',

        items: [
		{
			xtype: 'compositefield',
            fieldLabel: '机构ID',
			items:
			[{
				xtype: 'textfield',
				readOnly: true,
				disable: false,
				style: 'font-size: 12px',
				width: 280,
				value: jQuery.Guid.New()//,
				//anchor:'80%'  // anchor width by percentage
			},{
				xtype: 'displayfield',
				value: '只读字段'
			}]
		},{
            fieldLabel: '上级机构',
			xtype: 'combo',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        },{
            fieldLabel: '机构名称',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        },{
            fieldLabel: '机构编码',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        },{
            fieldLabel: '营业厅联系人',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        },{
            fieldLabel: '联系电话',
            name: 'subject',
            anchor: '100%'  // anchor width by percentage
        },{
            fieldLabel: '机构地址',
			name: 'msg',
            anchor: '100%'  // anchor width by percentage and height by raw adjustment
        }]
    });

	if (jQuery.isEmptyObject(companyInfoWindow)) {
		companyInfoWindow = new Ext.Window({
			title: flag + ' 机构信息',
			width: 480,
			height:280,
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
