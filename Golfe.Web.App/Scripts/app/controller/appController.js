define(['jquery', 'backbone', 'underscore', 'models/TaskModel', 'collections/taskCollection', 'views/tasksView',
    'views/addTaskView','views/mapView'],
    function ($, backbone, _, TaskModel, TaskCollection,TaskView, AddTaskView,MapView) {

        var appController=function (){
            
            this.taskCollection=new TaskCollection();
            this.taskView = null;
            this.addTaskView = null;
            this.mapView = null;
        };
        
        appController.prototype.prepareAndShowTaskCreationView = function () {
            var deferred = $.Deferred();
           var deferreds = [];
           deferreds.push(
               $.getJSON("http://localhost:54883/api/operations/get"),
               $.getJSON("http://localhost:54883/api/machines/get"),
               $.getJSON("http://localhost:54883/api/gameAreas/get"),
               $.getJSON("http://localhost:54883/api/functionaries/get"));
            var that = this;

            $.when.apply(this,deferreds)
                .done((function (operations,machines,gameAreas,functionaries) {
                    var data = {};
                    data.operations = operations[0];
                    data.machines = machines[0];
                    data.gameAreas = gameAreas[0];
                    data.functionaries = functionaries[0];
                    that.addTaskView = new AddTaskView({ collection: that.taskCollection, model: new TaskModel(), formData: data });
                    that.addTaskView.render();
                    deferred.resolve(true);         
                })).fail(function () {
                    deferred.resolve(false);
                });
            
            return deferred.promise();
            
        }
        
        appController.prototype.fetchTaskCollection = function () {
            var deferred = $.Deferred();
            var deferreds = [];
            deferreds.push(this.taskCollection.fetch());
            var that = this;

            $.when.apply(this, deferreds)
                .done((function () {
                    that.taskView = new TaskView({ collection: that.taskCollection });
                    that.taskView.render();
                    deferred.resolve(true);         
                })).fail(function () {
                    deferred.resolve(false);
                });
            
            return deferred.promise();
        }
        
        appController.prototype.ShowMap=function() {
            if (this.mapView === null) {
                this.switchView("map");
                this.mapView = new MapView();
                this.mapView.render();
            } else {
                this.switchView("map");
            }
        }

        appController.prototype.ShowTasks = function () {
            if (this.taskView === null) {
                this.switchView("list");
                this.fetchTaskCollection();
            } else {
                this.switchView("list");
            }
        }
        
        appController.prototype.CreateTask = function () {
            if (this.addTaskView === null) {
                this.switchView("add");
                this.prepareAndShowTaskCreationView();

            } else {
                this.switchView("add");
            }
        }

        appController.prototype.switchView=function(name) {
            $(".panel-content").hide();
            $(".panel-" + name).show();
            
        }

        return appController;

    });


   