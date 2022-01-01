$(document).ready(function () {

    var x = 0;
    var s = "";

    console.log("Hello Pluralsight");



    var theForm = $("#theForm");
    /*theForm.hide();*/

    function foo() {

    };

    var button = $("buyButton");
    button.on("click", function () {
        alert("Buying Item");
    });

    var productInfo = $(".product-props");

    productInfo.on("click", function () {
        console.log("You Clicked On " + $(this).text());
    });



});