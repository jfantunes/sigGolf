require.config({
    paths: {
        "jquery": "../libs/jquery-1.9.1",
        "underscore": "../libs/underscore",
        "backbone": "../libs/backbone",
        "foundation-datepicker": "../libs/foundation-datepicker",
        "text": "../libs/text",
        "moment": "../libs/moment"

    },
    shim: {
       
        "backbone": {
            deps: ["underscore"]
        },
        "foundationDatePicker": {
            deps: ["jquery"]
        }
      
    }
});

require(['router/router','views/tabView'], function (TaskRouter,TabView) {
    var tabs = new TabView();
    tabs.render();
    var router=new TaskRouter();
    router.navigate("mapa",{trigger:true});
});