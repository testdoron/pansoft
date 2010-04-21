//创建机构树面板
function BuildCompanyGroupTreePanel()
{

	//机构树的根节点
	var rootNode = new Ext.tree.TreeNode
	({
		id: IHMSData.CompanyGroup.id,
		text: IHMSData.CompanyGroup.name
	});

	//递归读取机构树
	loadGroup(rootNode, IHMSData.CompanyGroup.items);

	var node;
	//机构树的读取函数(递归)
	function loadGroup(treenode, array) 
	{
		for (var i = 0; i < array.length; i++) 
		{
			node = new Ext.tree.TreeNode
			({
				id: array[i].id,
				text: array[i].name
			});
			treenode.appendChild(node);
			if (!jQuery.isEmptyObject(array[i].items)) 
			{
				if (array[i].items.length > 0) 
				{
					loadGroup(node, array[i].items);
				}
			};
		};
	}

	//机构树面板
	var panel = new Ext.tree.TreePanel
	({
		title: IHMSData.UITxt.companyGroupTreeRoot,
		region: 'west',
		width: 260,
		margins: '3 0 3 3',
		cmargins: '3 3 3 3',

		collapsible: true,
		useArrows: true,
		autoScroll: true,
		animate: true,
		enableDD: true,
		containerScroll: true,
		split: true,
		root: rootNode
	});

	//定义机构树面板节点的点击事件
	panel.on("click", function(node) 
	{
		Ext.Msg.show
		({
			title: ' 提示',
			msg: "你单击了:<br />" + node.id + "<br />" + node.text,
			animEl: node.ui.textNode
		});
	});

	return panel;
}