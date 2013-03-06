﻿$(function () {

    $('.knockout-container-collapser').mousedown(function (e) {
        e.preventDefault();
    });

    $('.knockout-container-collapser').click(function (e) {
        e.preventDefault();
        var $cont = $(this).parent().find('.knockout-container');
        $cont.removeClass("collapse-transitions");
        $cont.css('height', $cont.height());
        window.setTimeout(function () {
            $cont.addClass("collapse-transitions");
            var isCollapsed = $cont.data('isCollapsed');
            if (!isCollapsed) {
                $cont.data('isCollapsed', true);
                $cont.data('initHeight', $cont.height());
                $cont.css('height', 0);
            } else {
                $cont.data('isCollapsed', false);
                $cont.css('height', $cont.data('initHeight'));
            }
        }, 10);
    });



    function appViewModel() {
        var self = this;
        this.name = ko.observable("Bert");
        this.adress = ko.observable("Town");

        this.fullInfo = ko.computed(function() {
            return "NAME: " + self.name() + " FROM: " + self.adress();
        }, this);

        this.capitalizeName = function() {
            var currentVal = this.name(); // Read the current value
            this.name(currentVal.toUpperCase()); // Write back a modified value
        };
        
        //function salat(salatName, quality) {
        //    this.salatName = salatName;
        //    this.quality = quality;
        //}
        
        //this.salats = [new salat('Cool salat', 'good'), new salat('Shit trash', 'bad')];

        //function meal (mealName, price, salat) {
        //    this.mealName = mealName;
        //    this.price = price;
        //    this.salat = salat;
        //}

        //this.availableMeals = ko.observableArray([
        //    new meal('Standard (sandwich)', 0, this.salats[0]),
        //    new meal('Premium (lobster)', 34.95, this.salats[1])
        //]);

        //this.availableMeals = ko.observableArray([
        //    { meal: "Standard (sandwich)", price: 0, salat: this.salats[0] },
        //    { meal: "Premium (lobster)", price: 34.95, salat: this.salats[1] },
        //    { meal: "Ultimate (whole zebra)", price: 290, salat: this.salats[0] }
        //]);

        function person(personName, meal, price) {
            this.personName = personName;
            this.meal = meal;
            this.price = price;
        }

        this.persons = ko.observableArray([
                        new person('Ashot', '', ''),
                        new person('Vazgen', '', '')]
        );


        this.addOneMore = function() {
            //self.persons.push({ meal: 'Woof', price: 100, salat: self.salats[0] });
        };
    }

    // Activates knockout.js
    ko.applyBindings(new appViewModel());

});