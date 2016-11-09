define(['jquery', 'backbone', 'underscore', 'text!templates/tabTemplate.html'],
    function ($, Backbone, _,tabTemplate) {

        var TabView = Backbone.View.extend({

            events: {
                'click li.tab': 'changeSelectedTab',
            },

            template: _.template(tabTemplate),

            el: $('#main-navbar'),

            changeSelectedTab: function (e) {
                e.stopPropagation();
                var target = $(e.target).parent();
                target.siblings().removeClass('active');
                target.addClass('active');
            },

            render: function () {
                this.$el.html(this.template());
            }

        });

        return TabView;

    });