/*
 类名称：业务量报表
 作　者：lukan.pan@gmail.com
 时　间：2010.04.03
 描　述：
 业务量报表是在指定时间内按营业网点、窗口、柜员或业务种类的有效业务办理数量的统计分析，管理者可从中分析营业网点、
 窗口、柜员的工作绩效；各业务的数量对比，以便管理者调整窗口办理业务的分配；不同时间业务量的对比，获得业务办理的
 高低峰期，适时对业务设置进行调控。
 按照统计的时间来分，业务量报表分为：
 - 业务量日报表。对选择日期的业务量划分为时间段进行统计，时间段可通过系统设置进行修改。
 - 业务量周报表。对一周的业务量按日进行统计。
 - 业务量月报表。对年度业务量按月进行统计。
 按照统计对象来分，业务量报表又可分为：
 - 按营业厅。在“机构选择区”选择上级机构，则按各营网点分类，给出各网点不同时间段的业务量数据。同时，需要统计出在一定时间范围内（一天或一周）各网点不同业务种类的业务量。
 - 按窗口。在“机构选择区”选择营业网点，在报表页面上方的条件指定域中选择“按窗口”统计方式，指定统计日期后点击“查看报表”按钮即打开报表。
 - 按柜员。在“机构选择区”选择营业网点，在报表页面上方的条件指定域中选择“按柜员”统计方式，指定统计日期后点击“查看报表”按钮即打开报表。
 - 按业务。在“机构选择区”选择营业网点，在报表页面上方的条件指定域中选择“按业务”统计方式，指定统计日期后点击“查看报表”按钮即打开报表。
 */
ihmsModule.BusinessGrid = Ext.extend(Ext.app.Module, {
    id: 'BusinessGrid',
    init: function(){
        this.launcher = {
            text: uiTxt.modules.BusinessGrid.text,
            iconCls: 'icon-BusinessGrid',
            handler: this.createWindow,
            scope: this
        }
    },
    createWindow: function(){
        var desktop = this.app.getDesktop();
        var win = desktop.getWindow('BusinessGrid');
        if (!win) {
            win = desktop.createWindow({
                id: 'BusinessGrid',
                title: uiTxt.modules.BusinessGrid.text,
                width: 500,
                height: 300,
                iconCls: 'icon-BusinessGrid',
                shim: true,
                animCollapse: false,
                border: true,
                constrainHeader: true,
                
                //layout: 'fit',
            });
        }
        win.show();
    }
});

/*

 createWindow: function(){

 var tabs = new Ext.TabPanel({

 region: 'center',

 margins: '3 3 3 0',

 activeTab: 0,

 defaults: {

 autoScroll: true

 },

 

 items: [{

 title: 'Bogus Tab',

 html: 'Bogus Tab Bogus Tab'

 }, {

 title: 'Another Tab',

 html: 'Another Tab Another Tab'

 }, {

 title: 'Closable Tab',

 html: 'Closable Tab Closable Tab',

 closable: true

 }]

 });

 

 var winItems = [tabs];

 if (companyGroup.items.length > 0) {//当因权限或机构的确无子级机构时，不显示机构树

 winItems.push(companyGroupTree);

 }

 

 var desktop = this.app.getDesktop();

 var win = desktop.getWindow('businessGrid');

 

 if (!win) {

 win = desktop.createWindow({

 id: 'businessGrid',

 title: uiTxt.modules.businessGrid.text,

 iconCls: 'icon-businessGrid',//标题栏图标

 layout: 'border',//多栏布局

 shim: false,

 animCollapse: false,

 constrainHeader: true,

 closable: true,

 width: getBrowserWidth() - 100,

 height: getBrowserHeight() - 50,

 border: true,

 plain: true,

 items: winItems

 });

 }

 win.show();

 }

 });

 */

