var GroceryList = (function () {

    function displayNutritionData(json) {
        swal({
            html: JSON.stringify(json)
        });
    }

    function initPageEvents() {
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

    $(document).ready(function () {
        initPageEvents();
    });

    return {
        DisplayNutritionData: displayNutritionData
    }

})();