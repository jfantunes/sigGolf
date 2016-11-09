define(['backbone', 'underscore'],
    function(Backbone, _) {
        var TaskModel = Backbone.Model.extend({
            idAttribute: "Id",
            urlRoot: 'http://localhost:54883/api/Task'
        });

        return TaskModel;
    });

