$(function () {

    initializeCollapsers();
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
        
        function salat(salatName, price) {
            this.salatName = ko.observable(salatName);
            this.price = ko.observable(price);
        }
        
        this.salats = ko.observableArray([new salat('Cool salat', 7.30),
                                     new salat('Shit trash',  5.50)]);

        function meal (mealName, price) {
            this.mealName = ko.observable(mealName);
            this.price = ko.observable(price);
        }

        this.availableMeals = ko.observableArray([
            new meal('Standard (sandwich)', 23.45),
            new meal('Premium (lobster)', 34.95)
        ]);

        function person(personName, meal, salat) {
            this.personName = ko.observable(personName);
            this.meal = ko.observable(meal);
            this.salat = ko.observable(salat);
            this.price = function () {
                return (parseFloat(this.meal().price()) + parseFloat(this.salat().price())).toFixed(2);
            };
 }

        this.persons = ko.observableArray([
                        new person('Ashot', this.availableMeals()[0], this.salats()[0]),
                        new person('Vazgen', this.availableMeals()[1], this.salats()[1])]
        );

        this.totalSurcharge = function() {
            var surcharge = 0;
            for(var i in this.persons())
            {
                surcharge += parseFloat(this.persons()[i].price());
            }
            return surcharge.toFixed(2);
            
        };

        this.firstPersonSurcharge = function() {
            return self.persons()[0].price();
        };


        this.addOneMore = function() {
            self.persons.push( new person('New person', this.availableMeals()[0], this.salats()[1]));
        };

        this.removePerson = function (person) {
            self.persons.remove(person);
        };

        this.mutateAll = function() {
            for(var i = 0; i < self.persons().length; i++) {
                self.persons()[i].personName('aaaa');
            }
        };
    }

    // Activates knockout.js
    ko.applyBindings(new appViewModel());

});