


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
	
		var myForm = new Ext.form.FormPanel({
			title: "组管理",
			border: false,
			standardSubmit: true,
			//items: myFieldset
		});
		return myForm;
	
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