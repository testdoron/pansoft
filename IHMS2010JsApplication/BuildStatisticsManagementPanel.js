
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
function BuildStatisticsManagementPanel() {

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
				text: '统计图表',
				id: 'StatisticsChartType',
				iconCls: 'icon-StatisticsDataButton',
				menu:
				[
					GetStatisticsChartTypeMenuItem("机构业务量统计"),
					GetStatisticsChartTypeMenuItem("时段业务量统计"),
					'-',
					GetStatisticsChartTypeMenuItem("办理人数统计"),
					GetStatisticsChartTypeMenuItem("等候时长统计"),
					GetStatisticsChartTypeMenuItem("办理时长统计"),
					'-',
					GetStatisticsChartTypeMenuItem("柜员考勤统计"),
					'-',
					GetStatisticsChartTypeMenuItem("取号机取号量"),
					GetStatisticsChartTypeMenuItem("取号类别统计")
				]
			},
			'-',
			{
				text: '统计时间',
				id: 'StatisticsTimeType',
				iconCls: 'icon-StatisticsDataButton',
				menu:
				[
					GetStatisticsTimeTypeMenuItem("近一天"),
					GetStatisticsTimeTypeMenuItem("近一周"),
					GetStatisticsTimeTypeMenuItem("近两周"),
					GetStatisticsTimeTypeMenuItem("近一月"),
					GetStatisticsTimeTypeMenuItem("近一季"),
					GetStatisticsTimeTypeMenuItem("近一年"),
					GetStatisticsTimeTypeMenuItem("指定时间")
				]
			},
			{
				text: '分类汇总模式',
				id: 'StatisticsByGroupType',
				iconCls: 'icon-StatisticsDataButton',
				menu:
				[
					GetStatisticsTimeGroupTypeMenuItem("按天汇总"),
					GetStatisticsTimeGroupTypeMenuItem("按周汇总"),
					GetStatisticsTimeGroupTypeMenuItem("按月汇总"),
					GetStatisticsTimeGroupTypeMenuItem("按年汇总")
				]
			},
			'-',
			{
				text: '导出Excel',
				iconCls: 'icon-StatisticsDataButton'
			},
			'-',
			{
				text: '打印',
				iconCls: 'icon-StatisticsDataButton'
			},
			'-',
			{
				text: '刷新',
				iconCls: 'icon-StatisticsDataButton'
			},
		],
		html: '<div id="StatisticsPanel" style="width: 100%; height: 100%"></div>'
	});
	
	//窗体打开时，默认显示数据表格
	//GetStatisticsDataGrid();
	return panel;
	
	/*统计数据菜单项*/
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

	/*统计数据图表类型主菜单*/
	function GetStatisticsChartTypeMenuItem(menuStr) {
		var menuitem = new Ext.menu.Item({
			text: menuStr,
			iconCls: 'icon-StatisticsManagementPanel'//menuStr + "-icon"
		})
		
		//定义菜单项的点击事件
		menuitem.on("click", function(item) {
			Ext.getCmp('StatisticsChartType').setText(menuitem.text);
			GetCompanyWorkloadChart();
		});
		
		return menuitem;
	}

	/*统计时间段类型单选项*/
	function GetStatisticsTimeTypeMenuItem(menuStr) {
		var menuitem = new Ext.menu.Item({
			text: menuStr,
			iconCls: 'icon-StatisticsManagementPanel'//menuStr + "-icon"
		})
		
		//定义菜单项的点击事件
		menuitem.on("click", function(item) {
			Ext.getCmp('StatisticsTimeType').setText(menuitem.text);
			GetCompanyWorkloadChart();
		});
		
		return menuitem;
	}

	/*统计分类汇总模式选项菜单*/
	function GetStatisticsTimeGroupTypeMenuItem(menuStr) {
		var menuitem = new Ext.menu.Item({
			text: menuStr,
			iconCls: 'icon-StatisticsManagementPanel'//menuStr + "-icon"
		})
		
		// 定义菜单项的点击事件
		menuitem.on("click", function(item) {
			Ext.getCmp('StatisticsByGroupType').setText(menuitem.text);
			GetCompanyWorkloadChart();
		});
		
		return menuitem;
	}

	
	/* 业务量统计的Grid：GetStatisticsDataGrid()  */
	function GetStatisticsDataGrid() {

		Ext.state.Manager.setProvider(new Ext.state.CookieProvider());

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
	
		var store = new Ext.data.Store({
			proxy: new Ext.data.MemoryProxy(IHMSData.StaticsticsData.allData), 
			reader:  new Ext.data.JsonReader({
					fields: [
						{ name: 'companyId', mapping: 'companyId', type: 'string' }, 
						{ name: 'companyName', mapping: 'companyName', type: 'string' }, 
						{ name: 'companyOpreationAmout', mapping: 'companyOpreationAmout', type: 'int' }, 
						{ name: 'companyOpreationValidAmout', mapping: 'companyOpreationValidAmout', type: 'int' }, 
						{ name: 'companyOpreationValidEvaluatingAmout', mapping: 'companyOpreationValidEvaluatingAmout', type: 'int' }, 
						{ name: 'companyOpreationInvalidAmout', mapping: 'companyOpreationInvalidAmout', type: 'int' }
					],
					remoteSort: true
				}
			)//,
			//fields: ['companyId', 'companyName', 'companyOpreationAmout', 'companyOpreationValidAmout', 'companyOpreationValidEvaluatingAmout', 'companyOpreationInvalidAmout',]
		});

		
		store.load();

		
		// var store = new Ext.data.ArrayStore({
			// fields: [
			   // {name: 'companyId'},
			   // {name: 'companyName', type: 'char'},
			   // {name: 'companyOpreationAmout', type: 'int'},
			   // {name: 'companyOpreationValidAmout', type: 'int'},
			   // {name: 'companyOpreationValidEvaluatingAmout', type: 'int'},
			   // {name: 'companyOpreationInvalidAmout', type: 'int'}
			// ]
		// });

		// var store = new Ext.data.JsonStore({
			// data: IHMSData.StaticsticsData,
			// root: 'data',
			// fields: ['companyId', 'companyName', 'companyOpreationAmout', 'companyOpreationValidAmout', 'companyOpreationValidEvaluatingAmout', 'companyOpreationInvalidAmout',]
		// });


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
			stateId: 'grid'        
		});			
		
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
	

}
















