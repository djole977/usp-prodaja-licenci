$(document).ready(function () {
    $('#rolesTable').DataTable({
        pageLength: 5
    })
    $('#usersTable').DataTable({
        pageLength: 5
    })
})
function AddRoleModal() {
    $('#addRoleModal').modal('show')
}
function AddUserModal() {
    $('#addUserModal').modal('show')
}
function AddNewRole() {
    var roleName = $('#newRoleName').val()
    $.blockUI()
    $.ajax({
        type: 'POST',
        url: $('#createRoleUrl').val(),
        data: { roleName: roleName },
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
function AddNewUser() {
    var payload = {}
    payload.Email = $('#newUserEmail').val()
    payload.Password = $('#newUserPassword').val()
    payload.FullName = $('#newUserFullName').val()
    payload.Role = $('#newUserRole option:selected').val()
    $.blockUI()
    $.ajax({
        type: 'POST',
        url: $('#createUserUrl').val(),
        data: payload,
        success: function (returnData) {
            $.unblockUI()
            if (returnData.success === true) {
                AlertSuccess(true)
            }
            else {
                AlertError()
            }
        },
        error: function () {
            $.unblockUI()
            AlertError()
        }
    })
}