
/** 统计管理模块
 功能：统计管理模块
 名称：StatisticsManagementPanel()
 参数：无
 返回：Ext.app.Module
 */
IHMSModule.StatisticsManagementPanel = Ext.extend(Ext.app.Module, {
	id: 'StatisticsManagementPanel',
	init: function() {
		this.launcher = {
			text: IHMSData.UITxt.Modules.StatisticsManagementPanel.Text,
			iconCls: 'icon-StatisticsManagementPanel',
			handler: this.createWindow,
			scope: this
		}
	},
	createWindow: function() {
		var desktop = this.app.getDesktop();
		var win = desktop.getWindow('StatisticsManagementPanel');
		var treepanel = BuildCompanyGroupTreePanel();
		if (!win) {
			win = desktop.createWindow({
				id: 'StatisticsManagementPanel',
				title: IHMSData.UITxt.Modules.StatisticsManagementPanel.Text,
				width: GeanJs.GetBrowserWidth() * 0.8,
				height: GeanJs.GetBrowserHeight() * 0.85,
				iconCls: 'icon-StatisticsManagementPanel',
				shim: false,
				animCollapse: false,
				border: false,
				constrainHeader: true,
				plain: true,
				layout: 'border', //将容器分为五个区域:east,south,west,north,center
				items:
				[
					treepanel, BuildStatisticsManagementPanel()
				]
			});
			treepanel.expandAll();//.getRootNode().expandAll();
		}
		win.show();
	}
});

/** 创建统计分析图表面板
 功能：创建统计分析图表面板
 名称：BuildStatisticsManagementPanel()
 参数：无
 返回：new Ext.Panel
 */
function BuildStatisticsManagementPanel() 
{
	var panel = new Ext.Panel
	({
		id: 'StatisticsChart',
		region: 'center',
		margins: '3 0 3 3',
		cmargins: '3 3 3 3',
		layout: 'fit',
		tbar: [
			GetStatisticsDataMenuItem("统计数据"), 
			'-', 
			{ 
				text: '统计图示',
				iconCls: 'icon-StatisticsDataButton',
				menu:
				[
					GetStatisticsChartMenuItem("机构业务量统计"),
					GetStatisticsChartMenuItem("时段业务量统计"),
					'-',
					GetStatisticsChartMenuItem("办理人数统计"),
					GetStatisticsChartMenuItem("等候时长统计"),
					GetStatisticsChartMenuItem("办理时长统计"),
					'-',
					GetStatisticsChartMenuItem("柜员考勤统计"),
					'-',
					GetStatisticsChartMenuItem("取号机取号量"),
					GetStatisticsChartMenuItem("取号类别统计")
				]
			},
			'-',
			{
				text: '统计时间',
				iconCls: 'icon-StatisticsDataButton',
				menu:
				[
					GetStatisticsTimeMenuItem("近一天"),
					GetStatisticsTimeMenuItem("近一周"),
					GetStatisticsTimeMenuItem("近两周"),
					GetStatisticsTimeMenuItem("近一月"),
					GetStatisticsTimeMenuItem("近一季"),
					GetStatisticsTimeMenuItem("近一年"),
					GetStatisticsTimeMenuItem("指定时间")
				]
			},
			{
				text: '分类汇总模式',
				id: 'StatisticsByGroupType',
				iconCls: 'icon-StatisticsDataButton',
				menu:
				[
					GetStatisticsTimeGroupMenuItem("按天汇总"),
					GetStatisticsTimeGroupMenuItem("按周汇总"),
					GetStatisticsTimeGroupMenuItem("按月汇总"),
					GetStatisticsTimeGroupMenuItem("按年汇总")
				]
			},
			{
				text: 'Paste',
				iconCls: 'add16',
				menu: [{text: 'Paste Menu Item'}]
			},
			'-',
			{
				text: '刷新',
				iconCls: 'icon-StatisticsDataButton'
			}
		],
		html: '<div id="StatisticsPanel" style="width: 100%; height: 100%"></div>'
	});
	
	//窗体打开时，默认显示数据表格
	//GetStatisticsDataGrid();
	return panel;
}

//统计数据菜单项
function GetStatisticsDataMenuItem(menuStr) {
	var menuitem = new Ext.menu.Item({
		text: menuStr,
		iconCls: 'icon-StatisticsDataButton'//menuStr + "-icon"
	})
	
	//定义菜单项的点击事件
	menuitem.on("click", function(item) {
		GetStatisticsDataGrid();
	});
	
	return menuitem;
}

//统计数据图表主菜单
function GetStatisticsChartMenuItem(menuStr) {
	var menuitem = new Ext.menu.Item({
		text: menuStr,
		iconCls: 'icon-StatisticsManagementPanel'//menuStr + "-icon"
	})
	
	//定义菜单项的点击事件
	menuitem.on("click", function(item) {
		GetCompanyWorkloadChart();
	});
	
	return menuitem;
}

//统计时间段单选项
function GetStatisticsTimeMenuItem(menuStr) {
	var menuitem = new Ext.menu.Item({
		text: menuStr,
		iconCls: 'icon-StatisticsManagementPanel'//menuStr + "-icon"
	})
	
	//定义菜单项的点击事件
	menuitem.on("click", function(item) {
		GetCompanyWorkloadChart();
	});
	
	return menuitem;
}

// 统计分类汇总模式选项菜单
function GetStatisticsTimeGroupMenuItem(menuStr) {
	var menuitem = new Ext.menu.Item({
		text: menuStr,
		iconCls: 'icon-StatisticsManagementPanel'//menuStr + "-icon"
	})
	
	// 定义菜单项的点击事件
	menuitem.on("click", function(item) {
		alert(Ext.getCmp('StatisticsByGroupType').text);
		Ext.getCmp('StatisticsByGroupType').setText(menuitem.text);
		GetCompanyWorkloadChart();
	});
	
	return menuitem;
}


    
/* 业务量统计的Grid：GetStatisticsDataGrid()  */
function GetStatisticsDataGrid() {

	// NOTE: This is an example showing simple state management. During development,
	// it is generally best to disable state management as dynamically-generated ids
	// can change across page loads, leading to unpredictable results.  The developer
	// should ensure that stable state ids are set for stateful components in real apps.    
	Ext.state.Manager.setProvider(new Ext.state.CookieProvider());

	// sample static data for the store
	var myData = [
		['3m Co',71.72,0.02,0.03,'9/1 12:00am'],
		['Alcoa Inc',29.01,0.42,1.47,'9/1 12:00am'],
		['Altria Group Inc',83.81,0.28,0.34,'9/1 12:00am'],
		['American Express Company',52.55,0.01,0.02,'9/1 12:00am'],
		['American International Group, Inc.',64.13,0.31,0.49,'9/1 12:00am'],
		['AT&T Inc.',31.61,-0.48,-1.54,'9/1 12:00am'],
		['Boeing Co.',75.43,0.53,0.71,'9/1 12:00am'],
		['Caterpillar Inc.',67.27,0.92,1.39,'9/1 12:00am'],
		['Citigroup, Inc.',49.37,0.02,0.04,'9/1 12:00am'],
		['E.I. du Pont de Nemours and Company',40.48,0.51,1.28,'9/1 12:00am'],
		['Exxon Mobil Corp',68.1,-0.43,-0.64,'9/1 12:00am'],
		['General Electric Company',34.14,-0.08,-0.23,'9/1 12:00am'],
		['General Motors Corporation',30.27,1.09,3.74,'9/1 12:00am'],
		['Hewlett-Packard Co.',36.53,-0.03,-0.08,'9/1 12:00am'],
		['Honeywell Intl Inc',38.77,0.05,0.13,'9/1 12:00am'],
		['Intel Corporation',19.88,0.31,1.58,'9/1 12:00am'],
		['International Business Machines',81.41,0.44,0.54,'9/1 12:00am'],
		['Johnson & Johnson',64.72,0.06,0.09,'9/1 12:00am'],
		['JP Morgan & Chase & Co',45.73,0.07,0.15,'9/1 12:00am'],
		['McDonald\'s Corporation',36.76,0.86,2.40,'9/1 12:00am'],
		['Merck & Co., Inc.',40.96,0.41,1.01,'9/1 12:00am'],
		['Microsoft Corporation',25.84,0.14,0.54,'9/1 12:00am'],
		['Pfizer Inc',27.96,0.4,1.45,'9/1 12:00am'],
		['The Coca-Cola Company',45.07,0.26,0.58,'9/1 12:00am'],
		['The Home Depot, Inc.',34.64,0.35,1.02,'9/1 12:00am'],
		['The Procter & Gamble Company',61.91,0.01,0.02,'9/1 12:00am'],
		['United Technologies Corporation',63.26,0.55,0.88,'9/1 12:00am'],
		['Verizon Communications',35.57,0.39,1.11,'9/1 12:00am'],            
		['Wal-Mart Stores, Inc.',45.45,0.73,1.63,'9/1 12:00am']
	];

	/**
	 * Custom function used for column renderer
	 * @param {Object} val
	 */
	function change(val){
		if(val > 0){
			return '<span style="color:green;">' + val + '</span>';
		}else if(val < 0){
			return '<span style="color:red;">' + val + '</span>';
		}
		return val;
	}

	/**
	 * Custom function used for column renderer
	 * @param {Object} val
	 */
	function pctChange(val){
		if(val > 0){
			return '<span style="color:green;">' + val + '%</span>';
		}else if(val < 0){
			return '<span style="color:red;">' + val + '%</span>';
		}
		return val;
	}

	// create the data store
	var store = new Ext.data.ArrayStore({
		fields: [
		   {name: 'company'},
		   {name: 'price', type: 'float'},
		   {name: 'change', type: 'float'},
		   {name: 'pctChange', type: 'float'},
		   {name: 'lastChange', type: 'date', dateFormat: 'n/j h:ia'}
		]
	});

	// manually load local data
	store.loadData(myData);

	// create the Grid
	var grid = new Ext.grid.GridPanel({
		store: store,
		columns: [
			new Ext.grid.RowNumberer(),
			{header: 'Company', width: 160, sortable: true, dataIndex: 'company'},
			{header: 'Price', width: 75, sortable: true, renderer: 'usMoney', dataIndex: 'price'},
			{header: 'Change', width: 75, sortable: true, renderer: change, dataIndex: 'change'},
			{header: '% Change', width: 75, sortable: true, renderer: pctChange, dataIndex: 'pctChange'},
			{header: 'Last Updated', width: 85, sortable: true, renderer: Ext.util.Format.dateRenderer('m/d/Y'), dataIndex: 'lastChange'}
		],
		region: 'center',
		border: false,
		width: Ext.fly("StatisticsPanel").getWidth(),
		height: Ext.fly("StatisticsPanel").getHeight(), 
		title: IHMSData.CompanyGroup.name,
		// config options for stateful behavior
		stateful: true,
		stateId: 'grid'        
	});		
	
	// render the grid to the specified div in the page
	$("#StatisticsPanel").empty();
	grid.render('StatisticsPanel');
}

/* 业务量统计柱状图：GetCompanyWorkloadChart */
function GetCompanyWorkloadChart() {
	var datas = getData();
	new Highcharts.Chart({
		chart: {
			renderTo: 'StatisticsPanel',
			defaultSeriesType: 'column'
		},
		title: { text: '机构业务量' },
		subtitle: { text: '2010.03.10  -  2010.04.10' },
		xAxis: {
			categories: datas.Groups,
			labels: { rotation: 30, align: 'left' } //控制坐标轴的标签的显示方式，标签旋转即可在这里
		},
		yAxis: {
			min: 0,
			offset: 0,//设置单位向左偏移一些，否则也会向右偏，遮在图表上
			title: { text: '' }//{ text: '机构业务量' } //设置了标题后会导致Y轴显示的字体的显示严重靠右，遮在图表上
		},
		tooltip: {
			formatter: function() { return '<b>'+ this.series.name +'</b><br/>'+ this.x +': '+ this.y +' 人'; }
		},
		plotOptions: {
			column: {
				pointPadding: 0.2,
				borderWidth: 0
			}
		},
		series: [{
			name: '机构业务量',
			data: datas.Datas
		}]
	});

	function getData() 
	{
		var chartGroup = new Array();
		var chartData = new Array();
		
		loadGroup(chartGroup, IHMSData.CompanyGroup.items);

		for (var i = 0; i < chartGroup.length; i++) { //一些临时显示的数据
			var x = Math.floor(Math.random() * 1500);
			chartData.push(x);
		}

		var chartGroupData = { Groups: chartGroup, Datas: chartData };

		return chartGroupData;
	}

	//机构树的读取函数(递归)
	function loadGroup(chartGroup, array)
	{
		for (var i = 0; i < array.length; i++) {
			chartGroup.push(array[i].alias);
			if (!jQuery.isEmptyObject(array[i].items)) {
				if (array[i].items.length > 0) {
					loadGroup(chartGroup, array[i].items);
				}
			};
		};
	}//loadGroup
}


