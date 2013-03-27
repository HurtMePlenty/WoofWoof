(function () {
    if (typeof console == "undefined")
        return;
    var A = function() {
        this.name = "nameA";
    };

    var B = function() {
        this.name = "nameB";
    };

    A.prototype.test = "A";
    B.prototype.test = "B";

    A.prototype.constructor = B;

    var inst = new A();
    
    console.log(A.prototype == inst.__proto__);
    console.log(A.__proto__ == Function.prototype);
    console.log(Function.__proto__ == Function.prototype);
    console.log(Function.__proto__.__proto__ == Object.prototype);


    var num = 5;
    var string = "woof";
    var res = num + string;
    var res2 = 5 + "woof";
    

})();


