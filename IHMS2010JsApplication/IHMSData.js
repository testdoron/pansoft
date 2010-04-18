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
		"ChartType": {
			"Default": "统计图表",
			"Content" : [
				{ "Id": "000001CT-ERTQ-HJGR-FSEG-POIUYTREWQ" , "Text": "机构业务量统计" },
				{ "Id": "000002CT-ERTQ-HJGR-FSEG-POIUYTREWQ" , "Text": "客户办理时长统计" },
				{ "Id": "000003CT-ERTQ-HJGR-FSEG-POIUYTREWQ" , "Text": "业务类型统计" },
				{ "Id": "000004CT-ERTQ-HJGR-FSEG-POIUYTREWQ" , "Text": "客户满意度统计" }
			]
		},
		"TimeType": {
			"Default": "时间段类型",
			"Content" : [
				{ "Id": "000001TT-GJHJ-TYJU-FSEG-POIUYTREWQ" , "Text": "近一天" },
				{ "Id": "000002TT-GJHJ-TYJU-FSEG-POIUYTREWQ" , "Text": "近一周" },
				{ "Id": "000003TT-GJHJ-TYJU-FSEG-POIUYTREWQ" , "Text": "近两周" },
				{ "Id": "000004TT-GJHJ-TYJU-FSEG-POIUYTREWQ" , "Text": "近一月" },
				{ "Id": "000005TT-GJHJ-TYJU-FSEG-POIUYTREWQ" , "Text": "近一季" },
				{ "Id": "000006TT-GJHJ-TYJU-FSEG-POIUYTREWQ" , "Text": "近半年" },
				{ "Id": "000007TT-GJHJ-TYJU-FSEG-POIUYTREWQ" , "Text": "近一年" },
				{ "Id": "000008TT-GJHJ-TYJU-FSEG-POIUYTREWQ" , "Text": "指定时间" }
			]
		},
		"TimeGroupType": {
			"Default": "汇总类型",
			"Content" : [
				{ "Id": "000001TG-HJDS-KRXC-FSEG-POIUYTREWQ" , "Text": "按天汇总" },
				{ "Id": "000002TG-HJDS-KRXC-FSEG-POIUYTREWQ" , "Text": "按周汇总" },
				{ "Id": "000003TG-HJDS-KRXC-FSEG-POIUYTREWQ" , "Text": "按季汇总" },
				{ "Id": "000004TG-HJDS-KRXC-FSEG-POIUYTREWQ" , "Text": "按半年汇总" },
				{ "Id": "000005TG-HJDS-KRXC-FSEG-POIUYTREWQ" , "Text": "按年汇总" },
				{ "Id": "000006TG-HJDS-KRXC-FSEG-POIUYTREWQ" , "Text": "按指定时间汇总" }
			]
		},
		"OperationType": {
			"Default": "业务类型",
			"Content" : [
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

IHMSData.StatisticsState= {
	"GroupId": "555",
	"Grid": true,
	"ChartType": "000001CT-ERTQ-HJGR-FSEG-POIUYTREWQ",
	"TimeType": "000001TT-GJHJ-TYJU-FSEG-POIUYTREWQ",
	"TimeGroupType": "000001TG-HJDS-KRXC-FSEG-POIUYTREWQ",
	"OperationType": "FDRXXKGY-0001-CVER-QVFD-WE84XFDGWE"
}

IHMSData.StaticsticsData = [
        ['000001FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000002FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000003FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000004FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000005FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000006FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000007FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000008FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000009FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000010FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000011FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000012FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000013FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000014FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000015FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000016FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000017FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000018FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000019FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000020FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000021FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000022FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ],
        ['000023FF-8B86-D011-B42D-00C04FC964' , '平安世界银行北京支行' , 82348 , 7347 , 8347 , 2234 ]
    ];

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

IHMSData.CompanyGroup = {
	"id": "0000 - root - 0000",
	"name": "平安银行北京分行",
	"items": 
	[
		{ "id": "111", "name": "平安银行北京分行将台路分行" , "alias": "将台路" },
		// { "id": "222", "name": "平安银行北京分行亚运村分行" , "alias": "亚运村"  },
		{ "id": "333", "name": "平安银行北京分行平安大街分行" , "alias": "平安大街"  },
		{ "id": "444", "name": "平安银行北京分行昌平分行" , "alias": "昌平" ,
			"items": 
			[
				{ "id": "444 - 111", "name": "平安银行北京分行昌平南关大街分行", "alias": "昌平南关" },
				{ "id": "444 - 222", "name": "平安银行北京分行昌平西关大街分行", "alias": "昌平西关" },
				// { "id": "444 - 333", "name": "平安银行北京分行昌平北关大街分行", "alias": "昌平北关" },
				// { "id": "444 - 444", "name": "平安银行北京分行昌平东关大街分行", "alias": "昌平东关" }
			]
		},
		{ "id": "555", "name": "平安银行北京分行顺义分行", "alias": "顺义" ,
			"items": 
			[
				{ "id": "555 - 111", "name": "平安银行北京分行顺义府前西街分行", "alias": "顺义府前西"  },
				{ "id": "555 - 222", "name": "平安银行北京分行顺义府前东街分行", "alias": "府前东" ,
					"items": 
					[
						{ "id": "555 - 222 - 111", "name": "平安银行北京分行顺义东兴路分行", "alias": "顺义东兴路"  },
						{ "id": "555 - 222 - 222", "name": "平安银行北京分行顺义下关路分行", "alias": "顺义下关路" ,
							"items": 
							[
								{ "id": "555 - 222 - 222 - 111", "name": "平安银行北京分行顺义下路分行", "alias": "下路" },
								{ "id": "555 - 222 - 222 - 222", "name": "平安银行北京分行顺义关路分行", "alias": "关路" },
							]
						},
						{ "id": "555 - 222 - 333", "name": "平安银行北京分行顺义滨河南路分行", "alias": "顺义滨河南路" }
					]
				},
				{ "id": "555 - 333", "name": "平安银行北京分行顺义五里仓分行", "alias": "顺义五里仓" },
				{ "id": "555 - 444", "name": "平安银行北京分行顺义西环路分行", "alias": "顺义西环" }
			]
		},
		{ "id": "666", "name": "平安银行北京分行长安街分行", "alias": "长安街" },
		// { "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		// { "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		// { "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		// { "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		{ "id": "141414", "name": "平安银行北京分行左安门分行", "alias": "左安门",
			"items": 
			[
				{ "id": "141414 - 111", "name": "平安银行北京分行左安门方庄分行", "alias": "左安门方庄" },
				{ "id": "141414 - 222", "name": "平安银行北京分行左安门芳星园分行", "alias": "左安门芳星园" }
			]                     
		},
		{ "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
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
		{ "id": "131313", "name": "平安银行北京分行酒仙桥分行", "alias": "酒仙桥" }
	]
}








