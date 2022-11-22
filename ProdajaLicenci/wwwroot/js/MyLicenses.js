$(document).ready(function () {
    $('#licensesTable').DataTable({
        language: {
            emptyTable: "Ooops, looks like you still haven't bought any keys."
        }
    })
})
function GetLicenseKey(id) {
    $.blockUI()
    $.ajax({
        type: 'GET',
        url: $('#getLicenseKeyUrl').val(),
        data: { licenseId: parseInt(id) },
        success: function (returnData) {
            console.log(returnData)
            $.unblockUI()
            $('#licenseValue').val(returnData.license.key)
            var boughtDate = moment(returnData.license.createdAt)
            $('#licenseDesc').html("Bought on: " + boughtDate.format("DD/MM/YYYY @ H:mm") + "<br/>" + returnData.license.description)
            $('#licenseInfoModal').modal('show')
        },
        error: function () {
            $.unblockUI()
            AlertError()
        }
    })
}