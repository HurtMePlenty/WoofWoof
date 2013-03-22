(function () {
    if (typeof console == "undefined")
        return;
    var A = function() {
        this.name = "name";
    };
    
    console.log(A.constructor.prototype == A.prototype);
    console.log(A.__proto__ == A.prototype);
    console.log(A.constructor == A.__proto__.constructor);

})();


