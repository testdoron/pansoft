
var companyInfoWindow = null;
function BuildCompanyInfoWindow ( flag ) {
	if (jQuery.isEmptyObject(companyInfoWindow)) {
		companyInfoWindow = new Ext.Window(
		{
			title: '机构信息',
			closable: false,
			width: 420,
			height: 460,
			plain:true,
			layout: 'fit',
			// items: 
			// [
			// ],
			
			buttons: 
			[
				{
					text: flag,
					handler: function(){ 
						companyInfoWindow.close();
						companyInfoWindow = null;
					}
				},
				{
					text: '取消',
					handler: function(){
						companyInfoWindow.close(); 
						companyInfoWindow = null;
					}
				}
			]
		});
	}
	return companyInfoWindow;
}