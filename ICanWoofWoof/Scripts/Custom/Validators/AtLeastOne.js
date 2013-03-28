$.validator.addMethod("atleastonerequired", function (value, element, param) {
        return true;
});

$.validator.unobtrusive.adapters.addBool("atleastonerequired");