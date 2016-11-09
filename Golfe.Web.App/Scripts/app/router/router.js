define(['jquery', 'backbone', 'underscore', 'controller/appController'],
    function ($, Backbone, _, AppController) {

        var TasksRouter = Backbone.Router.extend({
            routes: {
                "mapa": "map",
                "tarefas": "showTasks",
                "tarefas/create": "createTask"
             },

            initialize: function () {
                this.appController = new AppController();
                Backbone.history.start();
            },
            
                showTasks:function() {
                this.appController.ShowTasks();
            },

            createTask: function () {
                this.appController.CreateTask();
            },

            map:function() {
                this.appController.ShowMap();
            }

        });

        return TasksRouter;
    });