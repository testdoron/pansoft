
function GetGridData()
{
	IHMSData.Staticstics = new Array();
	
	$.each(IHMSData.Json.Staticstics, function(i, bankArray) {
		
		var bank = new Array();
		bank.push(bankArray.Id);		//从JSON数据里获取Bank的ID
		bank.push(GetCompanyInfo(bankArray.Id, "name"));		//从JSON数据里获取Bank的名字
		
		var a = 0;
		var b = 0;
		var c = 0;
		var d = 0;
		var e = 0;
		$.each(bankArray.Os, function(j , operation) {	//从业务数据里循环计算“所有业务”的合计
			a += operation.Amount.D.T[0];
			b += operation.Amount.D.T[1];
			c += operation.Amount.D.T[2];
			d += operation.Amount.D.T[3];
			e += operation.Amount.D.T[4];
			f = e;
		});
		bank.push(a);
		bank.push(b);
		bank.push(c);
		bank.push(d);
		bank.push(e);
		bank.push(f);
		IHMSData.Staticstics.push(bank);
	});
	return IHMSData.Staticstics;
}