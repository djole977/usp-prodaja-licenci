// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function AlertSuccess(reload) {
    $.alert({
        title: 'Success',
        content: 'The action was completed successfully.',
        type: 'blue',
        buttons: {
            Ok: {
                action: function () {
                    if (reload === true) {
                        location.reload()
                    }
                }
            }
        }
    })
}
function AlertError() {
    $.alert({
        title: 'Error',
        content: 'There has been an error.',
        type: 'red',
        buttons: {
            Ok: {

            }
        }
    })
}