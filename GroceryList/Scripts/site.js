﻿var GroceryList = (function () {

    function displayNutritionData(json) {
        swal({
            html: JSON.stringify(json)
        });
    }

    function initFruitPageEvents() {
        $(document).on("click", ".lnk-fruit-details", function () {
            var id = $(this).attr("data-id");
            AjaxMod.POST("Fruits.aspx/GetFruitDetails", { id: id }, "json", function (result) {
                if (!result) return;
                var fruit = {};//empty object
                try { fruit = $.parseJSON(result.d); } catch (ex) { fruit = {}; }
                GroceryList.DisplayNutritionData(fruit);
            });
        });
    }

    function initVegetablePageEvents() {
        $(document).on("click", ".lnk-vegetable-details", function () {
            var id = $(this).attr("data-id");
            AjaxMod.POST("Vegetables.aspx/GetVegetableDetails", { id: id }, "json", function (result) {
                if (!result) return;
                var vegetable = {};//empty object
                try { vegetable = $.parseJSON(result.d); } catch (ex) { vegetable = {}; }
                GroceryList.DisplayNutritionData(vegetable);
            });
        });
    }

    $(document).ready(function () {
        initFruitPageEvents();
        initVegetablePageEvents();
    });

    return {
        DisplayNutritionData: displayNutritionData
    }

})();