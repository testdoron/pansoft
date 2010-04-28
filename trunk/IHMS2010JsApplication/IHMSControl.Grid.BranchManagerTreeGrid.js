

function BuildBranchManagerTreeGrid() {

	var topMenuItem = getMenuItem();
    var treegrid = new Ext.ux.tree.TreeGrid({
		border: false,
		height: 450,
        //enableDD: true,

        columns:[
		{
            dataIndex: 'companyId',
            hidden: true
        },{
            header: '机构名称',
            dataIndex: 'companyName',
            width: 300
        },{
            header: '机构编码',
            width: 100,
            dataIndex: 'companyNo',
            align: 'center'
        },{
            header: '营业厅联系人',
            width: 100,
            dataIndex: 'companyManager'
        },{
            header: '联系电话',
            width: 100,
            dataIndex: 'companyPhone'
        },{
			id: 'companyAddress',
            header: '地址',
            dataIndex: 'companyAddress'
        }],
        //autoExpandColumn: 'companyAddress',

		tbar: [
			topMenuItem
		],
		
		bbar: [
			{text: '共20机构'}
		]
		
        //dataUrl: 'company.json',

    });
	
	function getMenuItem() {
		var myMenu = new Ext.menu.Item({
			text: '新增机构',
			iconCls: 'icon-StatisticsDataButton'// 'menu' + n.id + "-icon"
		});
		
		myMenu.on("click", //定义菜单项的点击事件
			function() { 
				var win = BuildCompanyInfoWindow('新建');
				win.show();
			}
		);
		return myMenu;
	}
	
	return treegrid;

}