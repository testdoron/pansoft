
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
		var treepanel;
		var treeItems;
		if (!jQuery.isEmptyObject(IHMSData.Group.Branches.items)) {
			treepanel = BuildCompanyGroupTreePanel();
			treeItems = [treepanel, BuildStatisticsManagementPanel()]
		}
		else {
			treeItems = [BuildStatisticsManagementPanel()];
		}
		if (!win) {
			win = desktop.createWindow({
				id: 'StatisticsManagementPanel',
				title: IHMSData.UITxt.Modules.StatisticsManagementPanel.Text,
				width: GeanJs.GetBrowserWidth() * 0.85,
				height: GeanJs.GetBrowserHeight() * 0.85,
				iconCls: 'icon-StatisticsManagementPanel',
				shim: false,
				animCollapse: false,
				border: false,
				constrainHeader: true,
				plain: true,
				layout: 'border', //将容器分为五个区域:east,south,west,north,center
				items: treeItems
			});
		if (!jQuery.isEmptyObject(IHMSData.Group.Branches.items)) {
				treepanel.expandAll();
			}
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
			{ //统计图表
				text: IHMSData.Enums.Statistics.AmoutGrid.Default,
				id: 'StatisticsAmoutGrid',
				iconCls: 'icon-StatisticsDataButton',
				menu: GetMenuItemArray(IHMSData.Enums.Statistics.AmoutGrid.Content, 'StatisticsAmoutGrid')			
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
				text: "全部业务",
				id: 'StatisticsOperationType',
				iconCls: 'icon-StatisticsDataButton',
				menu: GetMenuItemArray(IHMSData.Operation.Types, 'StatisticsOperationType')
			}
			,
			{ //时间段类型
				text: IHMSData.Enums.Statistics.TimeType.Default,
				id: 'StatisticsTimeType',
				iconCls: 'icon-StatisticsDataButton',
				menu: GetMenuItemArray(IHMSData.Enums.Statistics.TimeType.Content, 'StatisticsTimeType')
			}
			,
			/* { //汇总类型
				// text: IHMSData.Enums.Statistics.TimeGroupType.Default,
				// id: 'StatisticsByGroupType',
				// iconCls: 'icon-StatisticsDataButton',
				// menu: GetMenuItemArray(IHMSData.Enums.Statistics.TimeGroupType.Content, 'StatisticsByGroupType')
			}, */
			'-',
			{ //导出
				text: '导出Excel',
				id: 'ExportStatisticsExcel',
				iconCls: 'icon-StatisticsDataButton',
				onClick: ExportStatisticsExcel
			},
			'-',
			{ //打印
				text: '打印',
				id: 'PrintStatistics',
				iconCls: 'icon-StatisticsDataButton',
				onClick: PrintStatistics
			},
			'-',
			{ //刷新
				text: '刷新',
				id: 'RefreshStatisticsData',
				iconCls: 'icon-StatisticsDataButton',
				onClick: RefreshStatisticsData
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
			var menuitem = null;
			if (!jQuery.isEmptyObject(n.name)) {
				menuitem = new Ext.menu.Item({
					id: n.id,
					text: n.name,
					iconCls: 'icon-StatisticsDataButton'// 'menu' + n.id + "-icon"
				})
			}
			else {
				menuitem = new Ext.menu.Item({
					id: n.id,
					text: n.name,
					iconCls: 'icon-StatisticsDataButton'// 'menu' + n.id + "-icon"
				})
			}
			menuitem.on("click", //定义菜单项的点击事件
				function() { 
					if (n.id == "TE09") {
						var win = BuildTimeRangeWindow();
						win.show(this);
						win.on("close", function() {
							GetCompanyWorkloadChart(n, parentMenuId);
						});
					}
					else if (n.id.substring(0,2) == "RP") {
						GetStatisticsDataGrid(n);
					} else	{
						GetCompanyWorkloadChart(n, parentMenuId);
					}
				}
			);
			return menuitem;
		}
		return menuitems;
	}	
	
	/* 业务量统计的Grid：GetStatisticsDataGrid()  */
	function GetStatisticsDataGrid(item) 
	{
		IHMSData.StatisticsState.Grid = true;
		Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
		
		var arrayStone = new Object();	//表格中的数据集合
		var colModel = new Object();	//Grid的列模型（ColumnModel）的默认实现。该类由列配置组成的数组初始化。

		if (item.id == "RP01") {  		//满意度报表
			arrayStone = new Ext.data.ArrayStore({
				fields: [
					{name: 'companyId', type: 'string'},
					{name: 'companyName', type: 'string'},
					{name: 'companyWaiterAmout', type: 'int'}, 		//正在等待人数
					{name: 'companyWokingAmout', type: 'int'}, 		//正在办理人数
					{name: 'companyGetTicketAmout', type: 'int'}, 	//取票总量
					{name: 'companyInvalidAmout', type: 'int'}, 	//弃票人数
					{name: 'companyValidAmout', type: 'int'}, 		//有效服务人数
					{name: 'companyAvgAmout', type: 'int'}  		//平均人/天
				 ]
			});
			colModel = [
				new Ext.grid.RowNumberer(),
				{id: 'companyId', hidden:'true' },
				{id: 'companyName', header: '机构名称', sortable: true, dataIndex: 'companyName'},
				{id: 'companyWaiterAmout', header: '正在等待人数', width: 80, sortable: true, dataIndex: 'companyWaiterAmout'},
				{id: 'companyWokingAmout', header: '正在办理人数', width: 80, sortable: true, dataIndex: 'companyWokingAmout'},
				{id: 'companyGetTicketAmout', header: '取票总量', width: 80, sortable: true, dataIndex: 'companyGetTicketAmout'},
				{id: 'companyInvalidAmout', header: '弃票人数', width: 80, sortable: true, dataIndex: 'companyInvalidAmout'},
				{id: 'companyValidAmout', header: '有效服务人数', width: 80, sortable: true, dataIndex: 'companyValidAmout'},
				{id: 'companyAvgAmout', header: '平均人/天', width: 80, sortable: true, dataIndex: 'companyAvgAmout'}
			];
		} else if (item.id == "RP02") { //服务人数报表
			arrayStone = new Ext.data.ArrayStore({
				fields: [
					{name: 'companyId', type: 'string'},
					{name: 'companyName', type: 'string'},
					{name: 'companyWaiterAmout', type: 'int'}, 		//正在等待人数
					{name: 'companyWokingAmout', type: 'int'}, 		//正在办理人数
					{name: 'companyGetTicketAmout', type: 'int'}, 	//取票总量
					{name: 'companyInvalidAmout', type: 'int'}, 	//弃票人数
					{name: 'companyValidAmout', type: 'int'}, 		//有效服务人数
					{name: 'companyAvgAmout', type: 'int'}  		//平均人/天
				 ]
			});
			colModel = [
				new Ext.grid.RowNumberer(),
				{id: 'companyId', hidden:'true' },
				{id: 'companyName', header: '机构名称', sortable: true, dataIndex: 'companyName'},
				{id: 'companyWaiterAmout', header: '正在等待人数', width: 80, sortable: true, dataIndex: 'companyWaiterAmout'},
				{id: 'companyWokingAmout', header: '正在办理人数', width: 80, sortable: true, dataIndex: 'companyWokingAmout'},
				{id: 'companyGetTicketAmout', header: '取票总量', width: 80, sortable: true, dataIndex: 'companyGetTicketAmout'},
				{id: 'companyInvalidAmout', header: '弃票人数', width: 80, sortable: true, dataIndex: 'companyInvalidAmout'},
				{id: 'companyValidAmout', header: '有效服务人数', width: 80, sortable: true, dataIndex: 'companyValidAmout'},
				{id: 'companyAvgAmout', header: '平均人/天', width: 80, sortable: true, dataIndex: 'companyAvgAmout'}
			];

		} else if (item.id == "RP03") { //分类业务交易量报表
			arrayStone = new Ext.data.ArrayStore({
				fields: [
					{name: 'companyId', type: 'string'},
					{name: 'companyName', type: 'string'},
					{name: 'companyOpreationAmout', type: 'int'},
					{name: 'companyOpreationValidAmout', type: 'int'},
					{name: 'companyOpreationValidEvaluatingAmout', type: 'int'},
					{name: 'companyOpreationInvalidAmout', type: 'int'}
				 ]
			});
		} else if (item.id == "RP04") {  //客户办理时长统计
			arrayStone = new Ext.data.ArrayStore({
				fields: [
					{name: 'companyId', type: 'string'},
					{name: 'companyName', type: 'string'},
					{name: 'companyOpreationAmout', type: 'int'},
					{name: 'companyOpreationValidAmout', type: 'int'},
					{name: 'companyOpreationValidEvaluatingAmout', type: 'int'},
					{name: 'companyOpreationInvalidAmout', type: 'int'}
				 ]
			});
		} else if (item.id == "RP05") {  //时段客户流量报表
			arrayStone = new Ext.data.ArrayStore({
				fields: [
					{name: 'companyId', type: 'string'},
					{name: 'companyName', type: 'string'},
					{name: 'companyOpreationAmout', type: 'int'},
					{name: 'companyOpreationValidAmout', type: 'int'},
					{name: 'companyOpreationValidEvaluatingAmout', type: 'int'},
					{name: 'companyOpreationInvalidAmout', type: 'int'}
				 ]
			});
		}
		
		arrayStone.loadData(GetGridData());
		
		var grid = new Ext.grid.GridPanel({
			store: arrayStone,
			autoExpandColumn:"companyName",
			region: 'center',
			border: false,
			width: Ext.fly("StatisticsPanel").getWidth(),
			height: Ext.fly("StatisticsPanel").getHeight(), 
			title: IHMSData.Group.Branches.name + ' - ' + item.name,
			stateful: true,
			stateId: 'grid',
			// bbar: [
					// '共计 ' + IHMSData.StaticsticsData.length + ' 机构', '-' ,
					// '总取票量： ' + getAmount(2), '-' ,
					// '总交易量： ' + getAmount(3), '-' ,
					// '总有效评价量： ' + getAmount(4), '-' ,
					// '总弃票量： ' + getAmount(5), '-'
				// ],
			columns: colModel
		});			

		/*根据数据数组(IHMSData.StaticsticsData)计算单字段的合计值*/
		function getAmount(num) {
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
		IHMSData.StatisticsState.Grid = false;
		SetStatisticsState(chartType, parentMenuId);//将当前的统计状态保存
		Ext.getCmp(parentMenuId).setText(chartType.name);
		
		var datas = GetMyData();
		
		new Highcharts.Chart({
			chart: {
				renderTo: 'StatisticsPanel',
				defaultSeriesType: 'column'
			},
			title: { text: getTitle() },
			subtitle: { text: GetChartDescription() },
			xAxis: {
				categories: datas.Groups,
				labels: GetXAxisLabels()
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
				name: chartType.name,
				data: datas.Datas,
				dataLabels: GetSeriesDataLabels(this.y)			
			}]
		});
		
		//获取柱状图的标题
		function getTitle()
		{
			var arr = IHMSData.Enums.Statistics.ChartType.Content;
			for (i = 0; i < arr.length; i++) {
				if (IHMSData.StatisticsState.ChartType == arr[i].Id) {
					return arr[i].name;
				}
			}
		}
		
		//将当前的统计状态保存
		function SetStatisticsState(chartType, parentMenuId)
		{
			if (parentMenuId == "StatisticsChartType") {
				IHMSData.StatisticsState.ChartType = chartType.Id;
			} 
			else if (parentMenuId == "StatisticsOperationType") {
				IHMSData.StatisticsState.OperationType = chartType.Id;
			} 
			else if (parentMenuId == "StatisticsTimeType") {
				IHMSData.StatisticsState.TimeType = chartType.Id;
			} 
			else if (parentMenuId == "StatisticsByGroupType") {
				IHMSData.StatisticsState.TimeGroupType = chartType.Id;
			}
		}

		//图表的具体描述，主要为详细说明当前的选择类型
		function GetChartDescription()
		{
			return GetStateString(" <b>|</b> ");
		}
		
		//当项目不太多时，在柱状图的柱子显示数量
		function GetSeriesDataLabels(yValue)
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
		function GetXAxisLabels() 
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
		
		//获得所需数据
		function GetMyData() 
		{
			var chartGroup = GetXByCompany();
			var chartData = new Array();
			
			for (var i = 0; i < IHMSData.Json.Staticstics.length; i++) { 
				var x = Math.floor(Math.random() * 1500);
				chartData.push(x);
			}
			
			var chartGroupData = { Groups: chartGroup, Datas: chartData };
			return chartGroupData;
		}
		
		//据统计Json中的Company的ID得到所有对应的机构别名
		function GetXByCompany()
		{
			var companys = new Array();
			for (var i = 0; i < IHMSData.Json.Staticstics.length; i++) {
				companys.push(GetCompanyInfo(IHMSData.Json.Staticstics[i].Id, "alias"));
			}
			return companys;
		}
		
		function GetY()
		{
			var amoutData = new Array();
			if (IHMSData.StatisticsState.TimeType == "TE01") {
			
			}
			else if (IHMSData.StatisticsState.TimeType == "TE02") {
			
			}
			else if (IHMSData.StatisticsState.TimeType == "TE03") {
			
			}
			else if (IHMSData.StatisticsState.TimeType == "TE04") {
			
			}
			else if (IHMSData.StatisticsState.TimeType == "TE05") {
			
			}
			else if (IHMSData.StatisticsState.TimeType == "TE06") {
			
			}
			else if (IHMSData.StatisticsState.TimeType == "TE07") {
			
			}
			else if (IHMSData.StatisticsState.TimeType == "TE08") {
			
			}

		}
	}
	
	//导出当前的数据到Excel
	function ExportStatisticsExcel()
	{
		Ext.MessageBox.show({
		   title:'导出当前的数据到Excel?',
		   msg: "将要导出当前的数据到Excel，可能数据量较大，需要数秒或稍长的时间。<br />" + GetStateString("<br />") + "<br /><br />是否导出当前的数据到Excel?",
		   buttons: Ext.MessageBox.OKCANCEL,
		   animEl: 'ExportStatisticsExcel',
		   icon: Ext.MessageBox.QUESTION
	   });
	}
	
	//打印当前的数据
	function PrintStatistics()
	{
		Ext.MessageBox.show({
		   title:'打印当前的数据?',
		   msg: "将要打印当前的数据，可能数据量较大，需要数秒或稍长的时间。<br />" + GetStateString("<br />") + "<br /><br />是否打印当前的数据?",
		   buttons: Ext.MessageBox.OKCANCEL,
		   animEl: 'PrintStatistics',
		   icon: Ext.MessageBox.QUESTION
	   });
	}
	
	//刷新当前的数据
	function RefreshStatisticsData()
	{
		Ext.MessageBox.show({
		   title:'刷新当前的数据?',
		   msg: "将要刷新当前的数据，可能数据量较大，需要数秒或稍长的时间。<br />" + GetStateString("<br />") + "<br /><br />是否刷新当前的数据?",
		   buttons: Ext.MessageBox.OKCANCEL,
		   animEl: 'RefreshStatisticsData',
		   icon: Ext.MessageBox.QUESTION
	   });
	}
	
	//获取当前统计状态的连接字符串
	function GetStateString(joinChar)
	{
		var stateStr = "业务类型：";
		var arr = IHMSData.Operation.Types;
		for (i = 0; i < arr.length; i++) {
			//alert(IHMSData.StatisticsState.OperationType +"<br />"+arr[i].Id);
			if (IHMSData.StatisticsState.OperationType == arr[i].Id) {
				stateStr += arr[i].name;
				break;
			}
		}
		stateStr += joinChar;
		stateStr += "时间段类型：";
		arr = IHMSData.Enums.Statistics.TimeType.Content;
		for (i = 0; i < arr.length; i++) {
			if (IHMSData.StatisticsState.TimeType == arr[i].Id) {
				stateStr += arr[i].name;
				break;
			}
		}
		// stateStr += joinChar;
		// stateStr += "统计类型：";
		// arr = IHMSData.Enums.Statistics.TimeGroupType.Content;
		// for (i = 0; i < arr.length; i++) {
			// if (IHMSData.StatisticsState.TimeGroupType == arr[i].Id) {
				// stateStr += arr[i].name;
				// break;
			// }
		// }
		//alert(stateStr);
		return stateStr;
	}
	
	
}
