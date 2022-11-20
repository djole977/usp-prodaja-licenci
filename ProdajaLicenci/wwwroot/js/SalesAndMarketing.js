$(document).ready(function () {
    $('#LicensesTable').DataTable();
    $('#newLicenseDateFrom').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        locale: {
            format: 'DD/MM/YYYY'
        }
    })
    $('#newLicenseDateTo').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: parseInt(moment().format('YYYY'), 1),
        locale: {
            format: 'DD/MM/YYYY'
        }
    })
    $('#newLicenseDateTo').data('daterangepicker').setStartDate(moment().add(1, 'years'))
    $('#newLicenseDateTo').data('daterangepicker').setEndDate(moment().add(100, 'years'))
})
function NewLicenseModal() {
    $('#NewLicenseModal').modal('show')
}
function AddNewLicense() {
    var payload = {}
    //payload.CreatedAt = moment()
    payload.Key = $('#newLicenseKey').val()
    payload.VendorId = parseInt($('#newLicenseVendor option:selected').val())
    payload.LicenseCategoryId = parseInt($('#newLicenseCategory option:selected').val())
    payload.Price = parseFloat($('#newLicensePrice').val())
    payload.ValidFrom = $('#newLicenseDateFrom').val()
    payload.ValidTo = $('#newLicenseDateTo').val()
    payload.Description = $('#newLicenseDescription').val()
    console.log(payload)
    $.confirm({
        title: 'Are you sure?',
        content: 'This will add the new license to the marketplace.',
        buttons: {
            Yes: {
                action: function () {
                    $.blockUI()
                    $.ajax({
                        type: 'POST',
                        url: $('#addLicenseUrl').val(),
                        data: payload,
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

            }
        }
    })
}