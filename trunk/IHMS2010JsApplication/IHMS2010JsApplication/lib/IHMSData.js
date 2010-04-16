<!------------------------------------>
<!--       数据定义：IHMSData       -->
<!------------------------------------>
var IHMSData = {
	version: '2010.6.0',
	email: 'lukan.pan@gmail.com'
}

IHMSData.UITxt = {
	"StartMenuWorkerTxt": "登录用户",
	"StartMenuSettingTxt": "系统选项",
	"StartMenuLogoutTxt": "退出系统",
	"companyGroupTreeRoot": "组织机构",
	"Modules": 
	{
		"CustomManagementPanel": 	{ "Text": "客户管理" },
		"OperationManagementPanel": { "Text": "业务管理" },
		"DeviceManagementPanel": 	{ "Text": "设备管理" },
		"StatisticsManagementPanel": { "Text": "统计分析" },//StatisticsManagement
		"BookingManagementPanel": { "Text": "预约管理" },
		"SystemManagementPanel": { "Text": "系统管理" }
	}
}

IHMSData.ConfigJson = {
	"SoftwareName": "力合智能大厅管理系统2010",
	"SoftwareVersion": "Base1",
	"WorkerName": "马英豪"
}

IHMSData.CompanyGroup =
{
	"id": "0000 - root - 0000",
	"name": "平安银行北京分行",
	"items": 
	[
		{ "id": "111", "name": "平安银行北京分行将台路分行" , "alias": "将台路" },
		{ "id": "222", "name": "平安银行北京分行亚运村分行" , "alias": "亚运村"  },
		{ "id": "333", "name": "平安银行北京分行平安大街分行" , "alias": "平安大街"  },
		{ "id": "444", "name": "平安银行北京分行昌平分行" , "alias": "昌平" ,
			"items": 
			[
				{ "id": "444 - 111", "name": "平安银行北京分行昌平南关大街分行", "alias": "昌平南关" },
				{ "id": "444 - 222", "name": "平安银行北京分行昌平西关大街分行", "alias": "昌平西关" },
				{ "id": "444 - 333", "name": "平安银行北京分行昌平北关大街分行", "alias": "昌平北关" },
				{ "id": "444 - 444", "name": "平安银行北京分行昌平东关大街分行", "alias": "昌平东关" }
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
						{ "id": "555 - 222 - 222", "name": "平安银行北京分行顺义下关路分行", "alias": "顺义下关路" },
						{ "id": "555 - 222 - 333", "name": "平安银行北京分行顺义滨河南路分行", "alias": "顺义滨河南路" }
					]
				},
				{ "id": "555 - 333", "name": "平安银行北京分行顺义五里仓分行", "alias": "顺义五里仓" },
				{ "id": "555 - 444", "name": "平安银行北京分行顺义西环路分行", "alias": "顺义西环" }
			]
		},
		{ "id": "666", "name": "平安银行北京分行长安街分行", "alias": "长安街" },
		{ "id": "101010", "name": "平安银行北京分行西直门分行", "alias": "西直门" },
		{ "id": "111111", "name": "平安银行北京分行东直门分行", "alias": "东直门" },
		{ "id": "121212", "name": "平安银行北京分行崇文门分行", "alias": "崇文门" },
		{ "id": "131313", "name": "平安银行北京分行鼓楼分行", "alias": "鼓楼" },
		{ "id": "141414", "name": "平安银行北京分行左安门分行", "alias": "左安门",
			"items": 
			[
				{ "id": "141414 - 111", "name": "平安银行北京分行左安门方庄分行", "alias": "左安门方庄" },
				{ "id": "141414 - 222", "name": "平安银行北京分行左安门芳星园分行", "alias": "左安门芳星园" }
			]                     
		}
	]
}