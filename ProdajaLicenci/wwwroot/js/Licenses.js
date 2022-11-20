$(document).ready(function () {
    $('#licensesTable').DataTable()
})

function PurchaseLicense(id) {
    $.confirm({
        title: 'Are you sure?',
        content: 'Proceed with purchase? This action is not reversible.',
        type: 'yellow',
        buttons: {
            Yes: {
                btnClass: 'btn btn-success',
                action: function () {
                    $.blockUI()
                    $.ajax({
                        type: 'POST',
                        url: $('#purchaseLicenseUrl').val(),
                        data: { licenseId: id },
                        success: function () {
                            $.unblockUI()
                            AlertSuccess(true)
                        },
                        error: function () {
                            $.unblockUI()
                            AlertError()
                        }
                    })
                }
            },
            No: {
                btnClass: 'btn btn-warning'
            }
        }
    })
}