define(['jquery', 'backbone', 'underscore', 'collections/taskCollection', 'text!templates/taskTemplate.html'],
    function($,Backbone,_, TaskCollection,tasksTemplate) {

        var TasksView = Backbone.View.extend({

            initialize:function() {
                this.listenTo(this.collection, 'change reset add remove sort', this.render);
                this.filterByTitle = _.throttle(this.filterByTitle, 100);
            },

            events: {
                'keyup .filters input': 'applyThrottleAndFilter',
                'change .tasks_completion':'filterTasksByCompletion',
                'click .task_removal': 'deleteTask',
                'click .task_finish': 'finishTask',
                'click li.desc': 'orderTasksDesc',
                'click li.asc': 'orderTasksAsc'
            },

            template: _.template(tasksTemplate),

            el: $('#tarefas'),

            render: function() {
                this.$el.html(
                    this.template({ tasks: this.collection.toJSON() })
                );
                return this;
            },

            orderTasksAsc:function(e){
                e.preventDefault();
                this.collection.sortCollection("asc");
            },
          
            orderTasksDesc: function (e) {
                e.preventDefault();
                this.collection.sortCollection("desc");
            },

           finishTask:function(e){
              var elementToDelete = $(e.target);
              var id = elementToDelete.data("id");
              var task = this.collection.get(id);
              if (task) {
                  task.set({ Concluida: true });
                  task.save();
                 }
            },
            

            deleteTask: function (e) {
                var elementToDelete = $(e.target);
                var id = elementToDelete.data("id");
                var task = this.collection.get(id);
                if(task)
                    task.destroy();
            },

            applyThrottleAndFilter: function (e) {
                var throttle = _.throttle(_.bind(this.filterTasksByInput, this, e), 1000);
                throttle();
            },
            
            filterTasksByCompletion: function (e) {
                e.preventDefault();
                e.stopPropagation();
                var target = $(e.target);
                var value = target.val();
                var columnIndex = target.parent().index();
                var table = $(this.$el.find('.tasks'));
                var rows = $(table.find('tbody tr'));
                                
                var filteredRows = rows.filter(function () {
                    var elementValue = $(this).find('td.itemTarefa').eq(columnIndex).first().data("value");
                    if(elementValue===true && (value==="undone"))
                    {
                        return true;
                    }
                    else {
                        if (elementValue===false && (value==='done')) {
                            return true;
                        }
                    }
                });
                this.filterResultsPresentation(table,rows,filteredRows);
               
            },

            filterTasksByInput:function(e) {
            var code = e.keyCode || e.which;
            if (code === '9')
                return;

            var input = $(e.target);
            var inputContent = input.val().toLowerCase();
            var columnIndex = input.parent().index();
            var table = $(this.$el.find('.tasks'));
            var rows = $(table.find('tbody tr'));
                
            var filteredRows = rows.filter(function () {
                var value = $(this).find('td.itemTarefa').eq(columnIndex).text().toLowerCase();
                return value.indexOf(inputContent) === -1;
            });

                this.filterResultsPresentation(table, rows, filteredRows);
            
            },

            filterResultsPresentation: function (table, rows, filteredRows) {

                table.find('tbody .no-result').remove();

                rows.show();
                filteredRows.hide();

                if (filteredRows.length === rows.length) {
                    table.find('tbody').prepend($('<tr class="no-result text-center"><td colspan="' + table.find('.filters th').length + '">Sem resultados</td></tr>'));
                }
            }   
            
     });

    return TasksView;

    });