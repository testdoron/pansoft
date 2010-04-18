
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
				width: GeanJs.GetBrowserWidth() * 0.9,
				height: GeanJs.GetBrowserHeight() * 0.9,
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
function BuildStatisticsManagementPanel() {

	var panel = new Ext.Panel
	({
		id: 'StatisticsChart',
		region: 'center',
		margins: '3 0 3 3',
		cmargins: '3 3 3 3',
		layout: 'fit',
		tbar: [
			{ //统计数据表
				text: '统计数据表',
				iconCls: 'icon-StatisticsDataButton',
				onClick: GetStatisticsDataGrid
			},
			'-', 
			{ //统计图表
				text: IHMSData.Enums.Statistics.ChartType.Default,
				id: 'StatisticsChartType',
				iconCls: 'icon-StatisticsDataButton',
				menu: GetMenuItemArray(IHMSData.Enums.Statistics.ChartType.Content, 'StatisticsChartType')			
			},
			'-',
			{ //业务类型
				text: IHMSData.Enums.Statistics.OperationType.Default,
				id: 'StatisticsOperationType',
				iconCls: 'icon-StatisticsDataButton',
				menu: GetMenuItemArray(IHMSData.Enums.Statistics.OperationType.Content, 'StatisticsOperationType')
			},
			{ //时间段类型
				text: IHMSData.Enums.Statistics.TimeType.Default,
				id: 'StatisticsTimeType',
				iconCls: 'icon-StatisticsDataButton',
				menu: GetMenuItemArray(IHMSData.Enums.Statistics.TimeType.Content, 'StatisticsTimeType')
			},
			{ //汇总类型
				text: IHMSData.Enums.Statistics.TimeGroupType.Default,
				id: 'StatisticsByGroupType',
				iconCls: 'icon-StatisticsDataButton',
				menu: GetMenuItemArray(IHMSData.Enums.Statistics.TimeGroupType.Content, 'StatisticsByGroupType')
			},
			'-',
			{ //导出
				text: '导出Excel',
				id: 'exportStatisticsExcel',
				iconCls: 'icon-StatisticsDataButton',
				onClick: exportStatisticsExcel
			},
			'-',
			{ //打印
				text: '打印',
				id: 'printStatistics',
				iconCls: 'icon-StatisticsDataButton',
				onClick: printStatistics
			},
			'-',
			{ //刷新
				text: '刷新',
				id: 'refreshStatisticsData',
				iconCls: 'icon-StatisticsDataButton',
				onClick: refreshStatisticsData
			},
		],
		html: '<div id="StatisticsPanel" style="width: 100%; height: 100%"></div>'
	});
	
	//窗体打开时，默认显示数据表格
	//GetStatisticsDataGrid();
	return panel;
	
	/*生成统计类型的菜单子项集合*/
	function GetMenuItemArray(typeArray, parentMenuId) 
	{
		var menuitems = new Array();
		$.each(typeArray, function(i, n) {
			menuitems.push(getItem(n));
		});

		function getItem(n) {
			var menuitem = new Ext.menu.Item({
				id: n.Id,
				text: n.Text,
				iconCls: 'icon-StatisticsDataButton'// 'menu' + n.Text + "-icon"
			})
			menuitem.on("click", //定义菜单项的点击事件
				function() { 
					GetCompanyWorkloadChart(n, parentMenuId);
				}
			);
			return menuitem;
		}
		return menuitems;
	}	
	
	/* 业务量统计的Grid：GetStatisticsDataGrid()  */
	function GetStatisticsDataGrid(item) 
	{

		Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
		//Ext.getCmp('StatisticsChartType').setText(item.text);

		/* var store = new Ext.data.Store({
			// proxy: new Ext.data.MemoryProxy(IHMSData.StaticsticsData.allData), 
			// reader:  new Ext.data.JsonReader({
					// fields: [
						// { name: 'companyId', mapping: 'companyId', type: 'string' }, 
						// { name: 'companyName', mapping: 'companyName', type: 'string' }, 
						// { name: 'companyOpreationAmout', mapping: 'companyOpreationAmout', type: 'int' }, 
						// { name: 'companyOpreationValidAmout', mapping: 'companyOpreationValidAmout', type: 'int' }, 
						// { name: 'companyOpreationValidEvaluatingAmout', mapping: 'companyOpreationValidEvaluatingAmout', type: 'int' }, 
						// { name: 'companyOpreationInvalidAmout', mapping: 'companyOpreationInvalidAmout', type: 'int' }
					// ],
					// remoteSort: true
				// }
			// ),
			// fields: ['companyId', 'companyName', 'companyOpreationAmout', 'companyOpreationValidAmout', 'companyOpreationValidEvaluatingAmout', 'companyOpreationInvalidAmout',]
		// });*/
		
		var store = new Ext.data.ArrayStore({
			 fields: [
			    {name: 'companyId', type: 'string'},
			    {name: 'companyName', type: 'string'},
			    {name: 'companyOpreationAmout', type: 'int'},
			    {name: 'companyOpreationValidAmout', type: 'int'},
			    {name: 'companyOpreationValidEvaluatingAmout', type: 'int'},
			    {name: 'companyOpreationInvalidAmout', type: 'int'}
			 ]
		 });

		store.loadData(IHMSData.StaticsticsData);

		var grid = new Ext.grid.GridPanel({
			store: store,
			columns: [
				new Ext.grid.RowNumberer(),
				{id: 'companyId', hidden:'true' },
				{id: 'companyName', header: '机构名称', sortable: true, dataIndex: 'companyName'},
				{id: 'companyOpreationAmout', header: '取票量', width: 85, sortable: true, dataIndex: 'companyOpreationAmout'},
				{id: 'companyOpreationValidAmout', header: '交易量', width: 85, sortable: true, dataIndex: 'companyOpreationValidAmout'},
				{id: 'companyOpreationValidEvaluatingAmout', header: '有效评价量', width: 85, sortable: true, dataIndex: 'companyOpreationValidEvaluatingAmout'},
				{id: 'companyOpreationInvalidAmout', header: '弃票量', width: 85, sortable: true, dataIndex: 'companyOpreationInvalidAmout'}
			],
			autoExpandColumn:"companyName",
			region: 'center',
			border: false,
			width: Ext.fly("StatisticsPanel").getWidth(),
			height: Ext.fly("StatisticsPanel").getHeight(), 
			title: IHMSData.CompanyGroup.name,
			stateful: true,
			stateId: 'grid',
			bbar: [
					'共计 ' + IHMSData.StaticsticsData.length + ' 机构', '-' ,
					'总取票量： ' + GetAmount(2), '-' ,
					'总交易量： ' + GetAmount(3), '-' ,
					'总有效评价量： ' + GetAmount(4), '-' ,
					'总弃票量： ' + GetAmount(5), '-'
				]

		});			
		
		/*根据数据数组(IHMSData.StaticsticsData)计算单字段的合计值*/
		function GetAmount(num) {
			var amount = 0;
			$.each( IHMSData.StaticsticsData, function(i, n){
				amount += n[num];
			});
			return amount;
		}
		
		//监视Panel的大小变化，以让Grid也发生变化。
		//2010-04-18 0:55:18 未实现效果
		panel.resize = function() {
			grid.setWidth(Ext.fly("StatisticsPanel").getWidth());
			grid.setHeight(Ext.fly("StatisticsPanel").getHeight());
		};
		
		$("#StatisticsPanel").empty();
		grid.render('StatisticsPanel');
	}

	/* 业务量统计柱状图：GetCompanyWorkloadChart */
	function GetCompanyWorkloadChart(chartType, parentMenuId) 
	{
		Ext.getCmp(parentMenuId).setText(chartType.Text);
		var datas = getData();
		new Highcharts.Chart({
			chart: {
				renderTo: 'StatisticsPanel',
				defaultSeriesType: 'column'
			},
			title: { text: chartType.Text },
			subtitle: { text: getChartDescription() },
			xAxis: {
				categories: datas.Groups,
				labels: getXAxisLabels()
			},
			yAxis: {
				min: 0,
				offset: 0,
				title: { enabled: false } 
			},
			tooltip: {
				formatter: function() { return chartType.Text +'<br/><b>'+ this.x +':</b> '+ this.y +' 人'; }
			},
			plotOptions: {
				column: {
					pointPadding: 0.2,
					borderWidth: 0
				}
			},
			series: [{
				name: chartType.Text,
				data: datas.Datas,
				dataLabels: getSeriesDataLabels(this.y)			
			}]
		});
		
		//图表的具体描述，主要为详细说明当前的选择类型
		function getChartDescription()
		{
			
		}
		
		//当项目不太多时，在柱状图的柱子显示数量
		function getSeriesDataLabels(yValue)
		{
			var label = new Object();
			if (datas.Groups.length > 18) {
				label.enabled = false;
			}
			else {
				label.enabled = true;
				label.rotation = -90;
				label.color = '#FFFFFF';
				label.align = 'right';
				label.x = -3;
				label.y = 10;
				label.formatter = yValue;
				label.style = {
					font: 'normal 10px Verdana, sans-serif'
				};
			}
			return label;
		}
		
		//控制X轴的项目名称显示，当项目较多时将斜向显示，太多时不显示
		function getXAxisLabels() 
		{
			var label = new Object();
			if (datas.Groups.length > 25) {
				label.enabled = false;
			}
			if (datas.Groups.length >= 15 && datas.Groups.length <= 25) {
				label.rotation = 30;
				label.align = 'left';
			}
			if (datas.Groups.length > 0 && datas.Groups.length < 15) {
				label.enabled = true;
			}
			return label;
		}

		//获得图中的数据
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
	
	//导出当前的数据到Excel
	function exportStatisticsExcel()
	{
		Ext.MessageBox.show({
		   title:'导出当前的数据到Excel?',
		   msg: '将要导出当前的数据到Excel，可能数据量较大，需要数秒或稍长的时间。 <br />当前统计数据的类型是：<br />业务类型：<br />时间段类型：<br />统计类型是：<br /><br />是否导出当前的数据到Excel?',
		   buttons: Ext.MessageBox.OKCANCEL,
		   animEl: 'exportStatisticsExcel',
		   icon: Ext.MessageBox.QUESTION
	   });
	}
	
	//打印当前的数据
	function printStatistics()
	{
		Ext.MessageBox.show({
		   title:'打印当前的数据?',
		   msg: '将要打印当前的数据，可能数据量较大，需要数秒或稍长的时间。 <br />当前统计数据的类型是：<br />业务类型：<br />时间段类型：<br />统计类型是：<br /><br />是否打印当前的数据?',
		   buttons: Ext.MessageBox.OKCANCEL,
		   animEl: 'printStatistics',
		   icon: Ext.MessageBox.QUESTION
	   });
	}
	
	//刷新当前的数据
	function refreshStatisticsData()
	{
		Ext.MessageBox.show({
		   title:'刷新当前的数据?',
		   msg: '将要刷新当前的数据，可能数据量较大，需要数秒或稍长的时间。 <br />当前统计数据的类型是：<br />业务类型：<br />时间段类型：<br />统计类型是：<br /><br />是否刷新当前的数据?',
		   buttons: Ext.MessageBox.OKCANCEL,
		   animEl: 'refreshStatisticsData',
		   icon: Ext.MessageBox.QUESTION
	   });
	}


}
















