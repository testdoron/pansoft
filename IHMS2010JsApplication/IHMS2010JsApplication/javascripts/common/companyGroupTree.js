//定义树的根节点
var companyGroupTreeRoot = new Ext.tree.TreeNode({
    id: "companyGroupTreeRoot-root",//根节点id
    text: companyGroup.name
});

/*
loadGroup(companyGroupTreeRoot, companyGroup.items);

var node;
function loadGroup(treenode, array){
    for (var i = 0; i < array.length; i++) {
        node = new Ext.tree.TreeNode({
            id: array[i].name,
            text: array[i].name,
        });
        treenode.appendChild(node);
        if (array[i].items.length > 0) {
            loadGroup(node, array[i].items);
        };
    };
}
*/

//定义树节点
//var c1 = new Ext.tree.TreeNode({
//    id: 'c1',//子结点id
//    text: '大儿子'
//});
//var c2 = new Ext.tree.TreeNode({
//    id: 'c2',
//    text: '小儿子'
//});
//var c22 = new Ext.tree.TreeNode({
//    id: 'c22',
//    text: '大孙子'
//});
//companyGroupTreeRoot.appendChild(c1);//为根节点增加子结点c1
//companyGroupTreeRoot.appendChild(c2);//为c1增加子节点c2
//c1.appendChild(c22);//为c1增加子节点c22 

//定义根节点的Loader
/*
var treeloader = new Ext.tree.TreeLoader({
    dataUrl: 'tree.jsp?DID=1'
});
*/

//异步加载根节点
/*
var rootnode = new Ext.tree.AsyncTreeNode({
    id: '1',
    text: '目录树根节点'
});
*/


var companyGroupTree = new Ext.tree.TreePanel({
    title: 'companyGroupTree',
    region: 'west',
    split: true,
    width: 300,
    collapsible: true,
    margins: '3 0 3 3',
    cmargins: '3 3 3 3',
    
    useArrows: true,
    autoScroll: true,//自动滚动 
    animate: true,//开启动画效果 
    enableDD: false,//不允许子节点拖动 
    containerScroll: true,
    rootVisible: true,//设为false将隐藏根节点，很多情况下，我们选择隐藏根节点增加美观性 
    //loader: treeloader
});
//设置根节点
companyGroupTree.setRootNode(companyGroupTreeRoot);

//响应事件，传递node参数
//companyGroupTree.on('beforeload', function(node){
//    companyGroupTree.loader.dataUrl = 'tree.jsp?DID=' + node.id; //定义子节点的Loader   
//});

//        companyGroupTree.render();
//        companyGroupTreeRoot.expand(false, false);

