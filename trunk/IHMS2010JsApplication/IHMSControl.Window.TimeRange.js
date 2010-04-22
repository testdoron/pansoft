
Ext.apply(Ext.form.VTypes, {
    daterange : function(val, field) {
        var date = field.parseDate(val);

        if(!date){
            return false;
        }
        if (field.startDateField && (!this.dateRangeMax || (date.getTime() != this.dateRangeMax.getTime()))) {
            var start = Ext.getCmp(field.startDateField);
            start.setMaxValue(date);
            start.validate();
            this.dateRangeMax = date;
        }
        else if (field.endDateField && (!this.dateRangeMin || (date.getTime() != this.dateRangeMin.getTime()))) {
            var end = Ext.getCmp(field.endDateField);
            end.setMinValue(date);
            end.validate();
            this.dateRangeMin = date;
        }
        return true;
    },

});

function BuildTimeRangeWindow()
{
    var win = new Ext.Window(
		{
			title: '时间段选择',
			closable: false,
			width: 320,
			height: 160,
			plain:true,
			layout: 'fit',
			items: 
			[
				new Ext.FormPanel(
				{
					labelWidth: 80,
					labelAlign: "right",
					frame: true,
					border: false,
					defaultType: 'datefield',
					items: 
						[{
							fieldLabel: '开始时间',
							name: 'startdt',
							id: 'startdt',
							width : 160,
							vtype: 'daterange',
							endDateField: 'enddt' // id of the end date field
						},{
							fieldLabel: '结束时间',
							name: 'enddt',
							id: 'enddt',
							width : 160,
							vtype: 'daterange',
							startDateField: 'startdt' // id of the start date field
						}]
				})
			],
			
			buttons: 
			[
				{
					text:'确定',
					handler: function(){ 
						IHMSData.StatisticsState.StartDateTime = Ext.getCmp("startdt").value;
						IHMSData.StatisticsState.EndDateTime = Ext.getCmp("enddt").value;
						win.close();
					}
				},
				{
					text: '取消',
					handler: function(){ win.close(); }
				}
			]
		});
	return win;
}


