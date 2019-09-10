﻿
(function ($) {
    "use strict";

    $(".validate-form").on("change", "select", function (e) {
        console.log(e.target)
        alert(e.target.value);
        if ($("select").attr("data-val-number")) {
            var errorNumberText = $("select").attr("data-val-number");
            $("select").find(".field-validation-text").text(errorNumberText)
        }


    })
    /*==================================================================
    [ Validate ]*/



    $(".validate-form").on("focus",".input100" ,function () {
        $(this).parent().removeClass('alert-validate wrap-input-error');




    })
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit', function (e) {
        var check = true;

        $("[data-valmsg-for= 'Customer.MembershipTypeId']").addClass("validation-error-message");
        $("[data-valmsg-for= 'Customer.IsSubscribedToNewsLetter']").addClass("validation-error-message");
        for (var i = 0; i < input.length; i++) {
            if (validate(input[i]) == false) {
                showValidate(input[i]);
                check = false;
            }
        }
       
        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if ($(input).attr('type') == 'Email' || $(input).attr('name') == 'Email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }

    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        console.log("the parent is", thisAlert);
    

        var validationMessage = $(input).attr("data-val-required");


        if (validationMessage) {
            $(thisAlert).addClass('alert-validate wrap-input-error');
            $(thisAlert).attr("data-validate", validationMessage);
        }

        

    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    /*==================================================================
    [ Show pass ]*/
    var showPass = 0;
    $('.btn-show-pass').on('click', function(){
        if(showPass == 0) {
            $(this).next('input').attr('type','text');
            $(this).find('i').removeClass('fa-eye');
            $(this).find('i').addClass('fa-eye-slash');
            showPass = 1;
        }
        else {
            $(this).next('input').attr('type','password');
            $(this).find('i').removeClass('fa-eye-slash');
            $(this).find('i').addClass('fa-eye');
            showPass = 0;
        }
        
    });
    

})(jQuery);