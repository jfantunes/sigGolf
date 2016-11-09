define(['jquery', 'backbone', 'underscore','moment', 'foundation-datepicker', 'collections/taskCollection', 'text!templates/addTaskTemplate.html'],
    function ($, Backbone, _, moment,fdatepicker, TaskCollection, addTaskTemplate) {

        var TasksView = Backbone.View.extend({

            initialize:function(options) {
                this.formData = options.formData;
              
            },
            
            events: {
                'click button.add-task': 'getTaskValues',
                'click .cancel-task': 'cancelTask'
            },

            template: _.template(addTaskTemplate),

            el: $('#tarefasFormAdd'),
            
            render: function () {
                this.$el.html(this.template({dataForForm:this.formData}));
                this.afterRender();
                return this;
            },

            afterRender: function () {
                $(".dateWidget").fdatepicker({
                    weekStart: 1,
                    todayBtn: true,
                    todayHighlight: true,
                    format: "dd/mm/yyyy",
                    language: 'en'
                });
            },

            
            getTaskValues: function (e) {
                e.preventDefault();
                e.stopPropagation();
                var data = {};
                data.functionary = this.$el.find("#funcionario_nome").val();
                data.operation = this.$el.find("#operacao_nome").val();
                data.machine = this.$el.find("#maquina_nome").val();
                data.area = this.$el.find("#areas_nome").val();
                data.date = moment(this.$el.find("#data_valor").val(), 'DD/MM/YYYY').toDate();

                this.addPropertiesToModelAndSave(data);
            },
     
            addPropertiesToModelAndSave: function (data) {
                var that = this;
                this.model.set({
                    AreaJogo: data.area,
                    Operacao: data.operation,
                    Maquina:data.machine,
                    Funcionario:data.functionary,
                    Data:data.date,
                    Concluida:false
                });

                this.model.save({}, {
                    success: function () {
                        that.collection.fetch({
                            success: function () {
                                that.backToTaskMenu();
                            },
                            error: function () {
                                console.log("Couldnt fetch collection");
                            }
                        });

                    }, error: function () {
                        console.log("Couldnt Add Model");

                    }
                });
                
            },

            backToTaskMenu:function() {
                $("#tarefasFormAdd").hide();
                Backbone.history.navigate("/tarefas", { trigger: true });
            },

            cancelTask: function (e) {
                this.backToTaskMenu();
            }
            
           
     });

    return TasksView;

    });