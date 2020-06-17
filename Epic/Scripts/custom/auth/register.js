$(() => {   // 
    $("#register-form").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            password: {
                required: true
            },
            confirmpassword: {
                required: true,
                equalTo: "#userPassword"
            }
        },
        messages: {
            email: {
                required: "Ju lutem shkruani email",
                email: "Email nuk është valide"
            },
            password: {
                required: "Ju lutem shkruani fjalëkalimin",

            },
            confirmpassword: {
                required: "Ju lutem shkruani fjalëkalimin përsëri",
                equalTo: "Fjalëkalimi duhet të jetë i njejtë"
            }
        },
        highlight: function (element) {

            // add a class "has_error" to the element
            $(element).addClass('has_error');
        },
        unhighlight: function (element) {

            // remove the class "has_error" from the element
            $(element).removeClass('has_error');
        },
        submitHandler: function () {

            var RoleId = $('.nav-link.active').data('id');
            console.log(RoleId);

            var model = {
                Email: $("#userEmail").val(),
                Password: $("#userPassword").val(),
                RoleId: RoleId
            }
            $.ajax({
                url: '/Account/Register',
                type: 'POST',
                data: model,
                success: function (data) {
                    alert("test");
                },
                error: function () {
                    alert("error");
                }
            });
        }
    });
});