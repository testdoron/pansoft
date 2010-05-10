


function BuildGroupRoleResourceManagerPanel () {

    var myTabPanel = new Ext.TabPanel ({
	
		height: 448,
		border: false,
		activeTab: 0,
		bbar: [ '状态' ],
		items: [ getGroupManagerPanel(), getRoleManagerPanel(), getResourceManagerPanel() ]
	
	})
	
	return myTabPanel;
	
	function getGroupManagerPanel() {
	
		var myForm = new Ext.Panel({
			title: "组管理",
			border: false,
			tbar:['新增组'],
			bbar:['分组数量: '+ '16'],
			bodyStyle: 'padding:0 20px 0;',
			items: GetGroupInfoFieldSet()
		})
		return myForm;
	}
	
	function GetGroupInfoFieldSet() {
	
		var groupArray = new Array();
		
		for ( var i = 0; i < 6; i++ ) {
			var groupInfoFieldSet = new Ext.Panel({
				title: '权限组' + i,
				bodyStyle: 'margin: 5px 0px 5px 0px;',
				defaultType: 'button',
				layout:'table',

				items: [{
					text: 'Add User'
				},{
					text: 'Add User',
				},{
					text: 'Add User',
				}]
			});
			groupArray.push(groupInfoFieldSet);
		}
		return groupArray;
	}
	
	function getRoleManagerPanel() {
	
		var myForm = new Ext.form.FormPanel({
			title: "角色管理",
			border: false,
			standardSubmit: true,
			//items: myFieldset
		});
		return myForm;

	}
	
	function getResourceManagerPanel() {
	
		var myForm = new Ext.form.FormPanel({
			title: "资源管理",
			border: false,
			standardSubmit: true,
			//items: myFieldset
		});
		return myForm;

	}

}
