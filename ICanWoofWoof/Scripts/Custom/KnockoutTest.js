$(function () {

    $('.knockout-container-collapser').mousedown(function (e) {
        e.preventDefault();
    });

    $('.knockout-container-collapser').click(function (e) {
        e.preventDefault();
        var $cont = $(this).parent().find('.knockout-container');
        $cont.removeClass("collapse-transitions");

        var contHeight;
        if ($cont.css('box-sizing') == 'border-box') {
            contHeight = $cont.outerHeight();
        } else {
            contHeight = $cont.height();
        }

        var $self = $(this);
        $cont.css('height', contHeight);
        window.setTimeout(function () {
            $cont.addClass("collapse-transitions");
            var isCollapsed = $cont.data('isCollapsed');
            if (!isCollapsed) {
                $self.data('init-width', $self.width());
                $cont.data('isCollapsed', true);
                $cont.data('initHeight', contHeight);
                $cont.data('padding-top', $cont.css('padding-top')).css('padding-top', 0);
                $cont.data('padding-bottom', $cont.css('padding-bottom')).css('padding-bottom', 0);;
                $cont.css('height', 0);
                $self.width($cont.width());

            } else {
                $self.width($self.data('init-width'));
                $cont.data('isCollapsed', false);
                $cont.height($cont.data('initHeight'));
                $cont.css('padding-top', $cont.data('padding-top'));
                $cont.css('padding-bottom', $cont.data('padding-bottom'));
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
                var a = this.personName();
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
                self.persons()[i].personName('Gogi');
            }
        };
    }

    // Activates knockout.js
    ko.applyBindings(new appViewModel());

});