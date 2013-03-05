$(function() {

    $('')


    function appViewModel() {
        this.name = "Bert";
        this.adress = "Bertington";
    }

    // Activates knockout.js
    ko.applyBindings(new appViewModel());

});