define(['backbone','underscore', 'models/taskModel'],
    function (Backbone, _,taskModel) {
        var TaskCollection = Backbone.Collection.extend({
            
            initialize: function() {
                this.sort_order = "desc";
                
            },

            comparator: function(item) {
                return item.get('Data');
            },

            model: taskModel,

            url: "http://localhost:54883/api/Task",

            comparator: function (item) {
                var date = new Date(item.get('Data'));
                return this.sort_order === "desc"
                     ? -date
                     : date
            },

            sortCollection:function(sort){
                this.sort_order = sort;
                this.sort();
            }

    });


        return TaskCollection;
});