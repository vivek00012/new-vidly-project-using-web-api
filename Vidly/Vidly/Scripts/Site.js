$(function () {

  
    $('.gallery-List').perfectScrollbar();

    $("#formDatepicker").datepicker({
        onSelect: function (dateText, inst) {
            var date = $(this).val();
            console.log(date)
            
            console.log(date.split('/')[1]);
            var new_date = date.split('/')[1] + "-" + date.split('/')[0] + "-" + date.split('/')[2];
            $(this).focus().val(date).delay(1000).blur();

        }});
    //$('#aniimated-thumbnials').lightGallery({
    //    thumbnail: true
    //}); 
    $(".validate-form").on("focus", ".input100", function (e) {
        if (!e.target.value) {
            $(this).parent().find(".field-validation-error").css("visibility", "visible");
        } else {
            $(this).parent().find(".field-validation-error").css("visibility", "hidden");

        }
    }).on("blur", ".input100", function (e) {
        if (!e.target.value) {
            $(this).parent().find(".field-validation-error").css("visibility", "visible");
        } else {
            $(this).parent().find(".field-validation-error").css("visibility", "hidden");

        }
    })

    var $animThumb = $('#aniimated-thumbnials');
    if ($animThumb.length) {
        $animThumb.justifiedGallery({
            border: 6
        }).on('jg.complete', function () {
            $animThumb.lightGallery({
                thumbnail: true,

            });
        });
    };


    //$('#aniimated-thumbnials').easyPaginate({
    //    paginateElement: 'a',
    //    elementsPerPage: 1,
    //});



    /*[ Select 2 Config ]
      ===========================================================*/

    try {
        var selectSimple = $('.js-select-simple');

        selectSimple.each(function () {
            var that = $(this);
            var selectBox = that.find('select');
            var selectDropdown = that.find('.select-dropdown');
            selectBox.select2({
                dropdownParent: selectDropdown
            });
        });

    } catch (err) {
        console.log(err);
    }

  
});

//$(function () {

//    //if ($("#Movie_Id").val() == 0) {
//    //    $("#releaseDateDatepicker,#Movie_NumberInStock").val("");
//    //}
//})