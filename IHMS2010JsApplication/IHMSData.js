<!------------------------------------>
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
				{ "id": "RP01" , "name": "满意度报表" },
				{ "id": "RP02" , "name": "服务数据统计表" },
				{ "id": "RP03" , "name": "分类业务交易量报表" },
				{ "id": "RP04" , "name": "客户办理时长统计" },
				{ "id": "RP05" , "name": "时段客户流量报表" }
			]
		},
		"ChartType": {
			"Default": "统计图表",
			"Content" : [
				{ "id": "CT01" , "name": "按机构交易量统计" },
				{ "id": "CT02" , "name": "按业务类型交易量统计" },
				{ "id": "CT03" , "name": "按柜员交易量统计" },
				{ "id": "CT04" , "name": "客户办理时长统计" },
				{ "id": "CT05" , "name": "客户满意度统计" }
			]
		},
		"TimeType": {
			"Default": "时间段类型",
			"Content" : [
				{ "id": "TE01" , "name": "当天" },
				{ "id": "TE02" , "name": "本周" },
				{ "id": "TE03" , "name": "近两周" },
				{ "id": "TE04" , "name": "本月" },
				{ "id": "TE05" , "name": "本季度" },
				{ "id": "TE06" , "name": "近半年" },
				{ "id": "TE07" , "name": "本年度" },
				{ "id": "TE08" , "name": "上年度" },
				{ "id": "TE09" , "name": "指定时间" }
			]
		},
		"TimeGroupType": {
			"Default": "汇总类型",
			"Content" : [
				{ "id": "HZ01" , "name": "按天汇总" },
				{ "id": "HZ02" , "name": "按周汇总" },
				{ "id": "HZ03" , "name": "按季汇总" },
				{ "id": "HZ04" , "name": "按半年汇总" },
				{ "id": "HZ05" , "name": "按年汇总" },
				{ "id": "HZ06" , "name": "按小时汇总" }
			]
		}
	}
}

IHMSData.StatisticsState = {
	"GroupId": 			"",
	"OperationType": 	"",
	"ChartType": 		"CT01",
	"TimeType": 		"TE01",
	"TimeGroupType": 	"HZ01",
	"StartDateTime": 	"",
	"EndDateTime": 		"",
	"Grid": true //为真是表示在“统计分析”面板正在显示的是数据Grid，否则可能在显示Chart
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

IHMSData.Operation = 
{
	"Types": [
		{"id":"ed46013b-12c9-4417-845a-02cbd607a4d4","name":"个人存取款"},
		{"id":"43643829-a419-4e9d-8446-b1f738e15f59","name":"个人缴费"},
		{"id":"05bc13f6-78a1-402f-a0a9-f4ba69936a20","name":"贷款业务"},
		{"id":"40d80ebc-b0a2-44fb-b538-2702b5c88cdd","name":"结算业务"},
		{"id":"bc14f134-9f89-47b5-8001-1f84a5952607","name":"投资理财业务"},
		{"id":"dd25a8b6-6875-4d8a-ace5-eb13f42f4223","name":"基金代销业务"},
		{"id":"22d01186-fd56-4cc1-9cff-d7c849ced942","name":"国际结算"},
		{"id":"2f29a4d7-2d09-49a3-b20d-7181d1416936","name":"商业票据"}
	]
}

function GetOperationTypeById(id)
{
	for (var i = 0; i < IHMSData.Operation.Types.length; i++) {
		if (id == IHMSData.Operation.Types[i].Id) {
			return IHMSData.Operation.Types[i].Text;
		}
	}
}


IHMSData.Group = 
{
	"Branches": {
		"id":"d5bc050e-bd16-4c97-a3f4-b1c9099282bd",
		"name":"平安地球银行北京市分行",
		"alias":"北京市分行",
		"items": [
			{"id":"d0e5ebe6-3cbc-48d3-98e5-49289c28e26e","name":"平安地球银行北京市东京路分行","alias":"东京路"},
			{"id":"4ba36fe2-5963-4f40-aac9-72ccc0574905","name":"平安地球银行北京市南京路分行","alias":"南京路"},
			{"id":"6d95bb7c-0085-4d54-98fc-bd6559b6102c","name":"平安地球银行北京市西京路分行","alias":"西京路"},
			{"id":"c420de39-680e-4d15-99db-3186744be639","name":"平安地球银行北京市北京路分行","alias":"北京路"},
			{"id":"52302acb-81cd-400f-ac92-aff5993c511c","name":"平安地球银行北京市东关大街分行","alias":"东关大街"},
			{"id":"0953322b-e58a-48b0-82d8-8bb80d3717da","name":"平安地球银行北京市南关大街分行","alias":"南关大街"},
			{"id":"dea8124c-569c-4627-8c0b-eb2c4062b47d","name":"平安地球银行北京市西关大街分行","alias":"西关大街"},
			{"id":"e856d6f3-ce1f-4755-b013-f8e11b006cdb","name":"平安地球银行北京市北关大街分行","alias":"北关大街"},
			{"id":"692becde-5833-44c5-afef-e6a87f334926","name":"平安地球银行北京市西直门分行","alias":"西直门"},
			{"id":"714adfe1-0595-4be9-a4f0-5854e15e0fc4","name":"平安地球银行北京市东直门分行","alias":"东直门"},
			{"id":"d6ec08be-72a5-4958-a54d-f5c03c384ae4","name":"平安地球银行北京市崇文门分行","alias":"崇文门"},
			{"id":"e027b46f-785b-4b8b-86dd-f91096a3e2cd","name":"平安地球银行北京市建国门分行","alias":"建国门"},
			{"id":"579dcd54-7575-44f8-878d-9b0ab708b2c0","name":"平安地球银行北京市鼓楼分行","alias":"鼓楼"},
			{"id":"692564ed-4ede-4b28-b82c-3d49fce02703","name":"平安地球银行北京市赵公口分行","alias":"赵公口"},
			{"id":"11703cd8-e17e-4289-986f-76d3a6818399","name":"平安地球银行北京市万寺路分行","alias":"万寺路"},
			{"id":"559b59f6-d558-4490-9fe2-9c7a394f5fdd","name":"平安地球银行北京市天通苑分行","alias":"天通苑"},
			{"id":"17ca3e1c-09bb-4d34-9595-d10458dc6322","name":"平安地球银行北京市回龙观分行","alias":"回龙观"},
			{"id":"104cabff-cff2-4f20-b645-228d9fa64a66","name":"平安地球银行北京市望京分行","alias":"望京"},
			{"id":"79d28e15-6380-4523-83ac-a812da6dbbbc","name":"平安地球银行北京市将台路分行","alias":"将台路"}
		]
	}
}	

//根据ID和指定的Key信息获得Group的一些信息
function GetCompanyInfo(id, attribute) 
{
	if (IHMSData.Group.Branches.id == id) {
		return IHMSData.Group.Branches[attribute];
	}
	else {
		return eachGroup(IHMSData.Group.Branches.items);
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









