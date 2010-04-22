﻿<!------------------------------------>
<!--       数据定义：IHMSData       -->
<!------------------------------------>
var IHMSData = {
	version: '2010.6.0',
	email: 'lukan.pan@gmail.com'
}

IHMSData.ConfigJson = {
	"SoftwareName": 	"力合智能大厅管理系统2010",
	"SoftwareVersion": 	"Base1",
	"WorkerName": 		"马英豪"
}

IHMSData.UITxt = {
	"StartMenuWorkerTxt": 	"登录用户",
	"StartMenuSettingTxt": 	"系统选项",
	"StartMenuLogoutTxt": 	"退出系统",
	"companyGroupTreeRoot": "组织机构",
	"Modules": 
	{
		"CustomManagementPanel": 	 { "Text": "客户管理" },
		"OperationManagementPanel":  { "Text": "业务管理" },
		"DeviceManagementPanel": 	 { "Text": "设备管理" },
		"StatisticsManagementPanel": { "Text": "统计分析" },
		"BookingManagementPanel":    { "Text": "预约管理" },
		"SystemManagementPanel":     { "Text": "系统管理" }
	}
}

IHMSData.Enums = {
	"Statistics": {
		"AmoutGrid": {
			"Default": "数据报表",
			"Content" : [
				{ "Id": "RP01" , "Text": "满意度报表" },
				{ "Id": "RP02" , "Text": "服务数据统计表" },
				{ "Id": "RP03" , "Text": "分类业务交易量报表" },
				{ "Id": "RP04" , "Text": "客户办理时长统计" },
				{ "Id": "RP05" , "Text": "时段客户流量报表" }
			]
		},
		"ChartType": {
			"Default": "统计图表",
			"Content" : [
				{ "Id": "CT01" , "Text": "按机构交易量统计" },
				{ "Id": "CT02" , "Text": "按业务类型交易量统计" },
				{ "Id": "CT03" , "Text": "按柜员交易量统计" },
				{ "Id": "CT04" , "Text": "客户办理时长统计" },
				{ "Id": "CT05" , "Text": "客户满意度统计" }
			]
		},
		"TimeType": {
			"Default": "时间段类型",
			"Content" : [
				{ "Id": "TE01" , "Text": "当天" },
				{ "Id": "TE02" , "Text": "本周" },
				{ "Id": "TE03" , "Text": "近两周" },
				{ "Id": "TE04" , "Text": "本月" },
				{ "Id": "TE05" , "Text": "本季度" },
				{ "Id": "TE06" , "Text": "近半年" },
				{ "Id": "TE07" , "Text": "本年度" },
				{ "Id": "TE08" , "Text": "上年度" },
				{ "Id": "TE09" , "Text": "指定时间" }
			]
		},
		"TimeGroupType": {
			"Default": "汇总类型",
			"Content" : [
				{ "Id": "HZ01" , "Text": "按天汇总" },
				{ "Id": "HZ02" , "Text": "按周汇总" },
				{ "Id": "HZ03" , "Text": "按季汇总" },
				{ "Id": "HZ04" , "Text": "按半年汇总" },
				{ "Id": "HZ05" , "Text": "按年汇总" },
				{ "Id": "HZ06" , "Text": "按小时汇总" }
			]
		},
		"OperationType": {
			"Default": "全部业务",
			"Content" : [
				{ "Id": "FDRXXKGY-0000-CVER-QVFD-WE84XFDGWE" , "Text": "全部业务" },
				{ "Id": "FDRXXKGY-0001-CVER-QVFD-WE84XFDGWE" , "Text": "个人存取款" },
				{ "Id": "FDRXXKGY-0002-CVER-QVFD-WE84XFDGWE" , "Text": "个人缴费" },
				{ "Id": "FDRXXKGY-0003-CVER-QVFD-WE84XFDGWE" , "Text": "贷款业务" },
				{ "Id": "FDRXXKGY-0004-CVER-QVFD-WE84XFDGWE" , "Text": "结算业务" },
				{ "Id": "FDRXXKGY-0005-CVER-QVFD-WE84XFDGWE" , "Text": "投资理财业务" },
				{ "Id": "FDRXXKGY-0006-CVER-QVFD-WE84XFDGWE" , "Text": "基金代销业务" },
				{ "Id": "FDRXXKGY-0007-CVER-QVFD-WE84XFDGWE" , "Text": "商业票据" },
				{ "Id": "FDRXXKGY-0008-CVER-QVFD-WE84XFDGWE" , "Text": "国际结算" },
				{ "Id": "FDRXXKGY-0009-CVER-QVFD-WE84XFDGWE" , "Text": "外汇理财" }
			]
		}
	}
}

IHMSData.StatisticsState = {
	"GroupId": 			"85772b60-e6f8-4393-b673-5588f30de20a",
	"OperationType": 	"FDRXXKGY-0000-CVER-QVFD-WE84XFDGWE",
	"ChartType": 		"CT01",
	"TimeType": 		"TE01",
	"TimeGroupType": 	"HZ01",
	"StartDateTime": 	"",
	"EndDateTime": 		"",
	"Grid": true //为真是表示在“统计分析”面板正在显示的是数据Grid，否则可能在显示Chart
}

function GetOperationTypeById(id)
{
	for (var i = 0; i < IHMSData.Enums.Statistics.OperationType.Content.length; i++) {
		if (id == IHMSData.Enums.Statistics.OperationType.Content[i].Id) {
			return IHMSData.Enums.Statistics.OperationType.Content[i].Text;
		}
	}
}

function GetChartTypeById(id)
{
	for (var i = 0; i < IHMSData.Enums.Statistics.ChartType.Content.length; i++) {
		if (id == IHMSData.Enums.Statistics.ChartType.Content[i].Id) {
			return IHMSData.Enums.Statistics.ChartType.Content[i].Text;
		}
	}
}

function GetTimeTypeById(id)
{
	for (var i = 0; i < IHMSData.Enums.Statistics.TimeType.Content.length; i++) {
		if (id == IHMSData.Enums.Statistics.TimeType.Content[i].Id) {
			return IHMSData.Enums.Statistics.TimeType.Content[i].Text;
		}
	}
}

function GetTimeGroupTypeById(id)
{
	for (var i = 0; i < IHMSData.Enums.Statistics.TimeGroupType.Content.length; i++) {
		if (id == IHMSData.Enums.Statistics.TimeGroupType.Content[i].Id) {
			return IHMSData.Enums.Statistics.TimeGroupType.Content[i].Text;
		}
	}
}

IHMSData.CompanyGroup = 
{
	"id": "3343ce75-e687-43fd-bf2e-d2071e928882", "name": "世界银行北京市平安路分行", "alias": "平安路",
	"items": 
	[
		{ "id": "0895d046-4c5c-45f9-9311-dfede168277b", "name": "平安银行北京分行将台路分行", "alias": "将台路" },
		{ "id": "932b6ecb-046e-43fb-922f-b70e747ee852", "name": "平安银行北京分行亚运村分行", "alias": "亚运村" },
		{ "id": "42d6734b-9225-4bac-a8a9-03d903a992f9", "name": "平安银行北京分行昌平分行", "alias": "昌平" },
		{ "id": "8333fe69-00d2-4063-aa1f-fb2483f3fe25", "name": "平安银行北京分行顺义分行", "alias": "顺义" },
		{ "id": "e797178f-0d8d-4cad-808d-faaed6d6581c", "name": "平安银行北京分行门头沟分行", "alias": "门头沟" }
	]
}	

//根据ID和指定的Key信息获得Group的一些信息
function GetCompanyInfo(id, attribute) 
{
	if (IHMSData.CompanyGroup.id == id) {
		return IHMSData.CompanyGroup[attribute];
	}
	else {
		return eachGroup(IHMSData.CompanyGroup.items);
	}
	
	function eachGroup(items) {
		for (var i = 0; i < items.length; i++) {
			if (items[i].id == id) {
				return items[i][attribute];
			}
			if (!jQuery.isEmptyObject(items[i].items)) {
				if (items[i].items.length > 0) {
					eachGroup(items[i].items);
				}
			}
		}
	}
}

/*		
		,
		// { "id": "222", "name": "平安银行北京分行亚运村分行" , "alias": "亚运村"  },
		{ "id": "333", "name": "平安银行北京分行平安大街分行" , "alias": "平安大街",
			"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
		},
		{ "id": "444", "name": "平安银行北京分行昌平分行" , "alias": "昌平" ,
			"items": 
			[
				{ "id": "444 - 111", "name": "平安银行北京分行昌平南关大街分行", "alias": "昌平南关",
					"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
				},
				{ "id": "444 - 222", "name": "平安银行北京分行昌平西关大街分行", "alias": "昌平西关",
					"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
				},
				// { "id": "444 - 333", "name": "平安银行北京分行昌平北关大街分行", "alias": "昌平北关" },
				// { "id": "444 - 444", "name": "平安银行北京分行昌平东关大街分行", "alias": "昌平东关" }
			],
			"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
		},
		{ "id": "555", "name": "平安银行北京分行顺义分行", "alias": "顺义" ,
			"items": 
			[
				{ "id": "555 - 111", "name": "平安银行北京分行顺义府前西街分行", "alias": "顺义府前西",
					"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
				},
				{ "id": "555 - 222", "name": "平安银行北京分行顺义府前东街分行", "alias": "府前东" ,
					"items": 
					[
						{ "id": "555 - 222 - 111", "name": "平安银行北京分行顺义东兴路分行", "alias": "顺义东兴路",
							"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
						},
						{ "id": "555 - 222 - 222", "name": "平安银行北京分行顺义下关路分行", "alias": "顺义下关路" ,
							"items": 
							[
								{ "id": "555 - 222 - 222 - 111", "name": "平安银行北京分行顺义下路分行", "alias": "下路",
									"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
								},
								{ "id": "555 - 222 - 222 - 222", "name": "平安银行北京分行顺义关路分行", "alias": "关路",
									"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
								},
							],
							"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
						},
						{ "id": "555 - 222 - 333", "name": "平安银行北京分行顺义滨河南路分行", "alias": "顺义滨河南路",
							"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
						},
					],
					"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
				},
				{ "id": "555 - 333", "name": "平安银行北京分行顺义五里仓分行", "alias": "顺义五里仓",
					"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
				},
				{ "id": "555 - 444", "name": "平安银行北京分行顺义西环路分行", "alias": "顺义西环",
					"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
				},
			],
			"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
		},
		{ "id": "666", "name": "平安银行北京分行长安街分行", "alias": "长安街",
			"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
		},
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		{ "id": "141414", "name": "平安银行北京分行左安门分行", "alias": "左安门",
			"items": 
			[
				{ "id": "141414 - 111", "name": "平安银行北京分行左安门方庄分行", "alias": "左安门方庄",
					"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
				},
				{ "id": "141414 - 222", "name": "平安银行北京分行左安门芳星园分行", "alias": "左安门芳星园" ,
					"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
				},
			] ,
			"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
		},
		{ "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门",
			"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
		},
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		{ "id": "131313", "name": "平安银行北京分行酒仙桥分行", "alias": "酒仙桥" ,
			"data":	{  "oId":"", "d": 123, "w": 1230, "tw": 2460, "m": 4920, "q":14760, "2q":29520, "y":59040	}
		},
	]
}

*/

/*
//IHMSData.StaticsticsData = { 
	// "allData" : [
		// [ { "companyId" : "000001FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000002FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000003FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000004FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000005FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000006FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000007FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000008FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000009FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ],
		// [ { "companyId" : "000010FF-8B86-D011-B42D-00C04FC964" }, { "companyName" : "北京银行总部" }, { "companyOpreationAmout" : 1233 }, { "companyOpreationValidAmout" : 123123 }, { "companyOpreationValidEvaluatingAmout" : 12312 }, { "companyOpreationInvalidAmout" : 234234 } ]
	// ]
//}
*/










