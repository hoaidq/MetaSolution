"use strict";

// Class definition
var KTSigninGeneral = function() {
    // Elements
    var form;
    var submitButton;
    var validator;

    // Handle form
    var handleForm = function(e) {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validator = FormValidation.formValidation(
			form,
			{
				fields: {					
					'Username': {
                        validators: {
							notEmpty: {
								message: 'Tài khoản không được để trống!'
							}
						}
					},
                    'Password': {
                        validators: {
                            notEmpty: {
                                message: 'Mật khẩu không được để trống!'
                            }
                        }
                    } 
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: '.fv-row'
                    })
				}
			}
		);		

        // Handle form submit
        submitButton.addEventListener('click', function (e) {
            // Prevent button default action
            e.preventDefault();

            // Validate form
            validator.validate().then(function (status) {
                console.log(status, "status");

                if (status == 'Valid') {
                    // Show loading indication
                    submitButton.setAttribute('data-kt-indicator', 'on');

                    // Disable button to avoid multiple click 
                    submitButton.disabled = true;

                    $.ajax({
                        url: './Services/UserService/Login',
                        type: 'GET',
                        data: {
                            'Username': '123',
                            'Password': 'abc'
                        },
                        dataType: 'json',
                        success: function (data) {
                            alert('Data: ' + data);
                        },
                        error: function (request, error) {
                            alert("Request: " + JSON.stringify(request));
                        }
                    });

                    // Simulate ajax request
                    //setTimeout(function() {
                    //    // Hide loading indication
                    //    submitButton.removeAttribute('data-kt-indicator');

                    //    // Enable button
                    //    submitButton.disabled = false;

                    //    // Show message popup. For more info check the plugin's official documentation: https://sweetalert2.github.io/
                    //    Swal.fire({
                    //        text: "You have successfully logged in!",
                    //        icon: "success",
                    //        buttonsStyling: false,
                    //        confirmButtonText: "Ok, got it!",
                    //        customClass: {
                    //            confirmButton: "btn btn-primary"
                    //        }
                    //    }).then(function (result) {
                    //        if (result.isConfirmed) { 
                    //            form.querySelector('[name="email"]').value= "";
                    //            form.querySelector('[name="password"]').value= "";                                
                    //            //form.submit(); // submit form
                    //        }
                    //    });
                    //}, 2000);   						
                }
            });
		});
    }

    // Public functions
    return {
        // Initialization
        init: function() {
            form = document.querySelector('#kt_sign_in_form');
            submitButton = document.querySelector('#kt_sign_in_submit');
            
            handleForm();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTSigninGeneral.init();
});
