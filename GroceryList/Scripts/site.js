var GroceryList = (function () {

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
                var details = result.d;
                var $dialog = $("#nutrition-dialog");
                $dialog.html(details);
                $dialog.dialog('open');
            });
        });
    }

    function initVegetablePageEvents() {
        $(document).on("click", ".lnk-vegetable-details", function () {
            var id = $(this).attr("data-id");
            AjaxMod.POST("Vegetables.aspx/GetVegetableDetails", { id: id }, "json", function (result) {
                if (!result) return;
                var details = result.d;
                var $dialog = $("#nutrition-dialog");
                $dialog.html(details);
                $dialog.dialog('open');
            });
        });
    }


    function initDairyPageEvents() {
        $(document).on("click", ".lnk-dairy-details", function () {
            var id = $(this).attr("data-id");
            AjaxMod.POST("Dairy.aspx/GetDairyProductDetails", { id: id }, "json", function (result) {
                if (!result) return;
                var details = result.d;
                var $dialog = $("#nutrition-dialog");
                $dialog.html(details);
                $dialog.dialog('open');
            });
        });
    }

    function initjQueryDialog() {
        $("#nutrition-dialog").dialog({
            autoOpen: false,
            modal: true,
            width: "530px",
            title: "Details",
            autoResize: true,
        });
    }

    $(document).ready(function () {
        initFruitPageEvents();
        initVegetablePageEvents();
        initDairyPageEvents();
        initjQueryDialog();
    });

    return {
        DisplayNutritionData: displayNutritionData
    }

})();