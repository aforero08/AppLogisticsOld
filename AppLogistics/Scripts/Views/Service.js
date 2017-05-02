$(document).ready(function () {

    // DatePicker para la fecha de ejecución
    $("#ExecutionDate").datepicker({
        dateFormat: "dd-mm-yy",
        changeMonth: true,
        changeYear: true,
        yearRange: "-1:+0"
    });
});


// Evento al seleccionar un cliente
function ClientSelected() {
    UpdateClientAreas();
    UpdateActivities();
}

// Evento al seleccionar una actividad
function ActivitySelected() {
    UpdateVehicleTypes();
}


// Actualizar posibles valores de áreas de clientes
function UpdateClientAreas() {

    // Obtener cliente seleccionado
    var selectedClientId = $('#ClientId').val();

    $.ajax({
        url: '/Clients/GetClientAreas',
        type: "GET",
        dataType: "JSON",
        data: { ClientId: selectedClientId },
        success: function (areas) {
            $("#ClientAreaId").html(""); // Limpiar antes de agregar nuevos

            if (areas.length == 0) {
                $("#ClientAreaId").append(
                    $('<option></option>').val("").html("No hay áreas para este cliente"));
            } else {
                $.each(areas, function (i, area) {
                    $("#ClientAreaId").append(
                        $('<option></option>').val(area.Id).html(area.Name));
                });
            }

            $("#ClientAreaId").focus();
        }
    });
}

// Actualizar posibles valores de áreas de clientes
function UpdateActivities() {

    // Obtener cliente seleccionado
    var selectedClientId = $('#ClientId').val();

    $.ajax({
        url: '/Rates/GetClientActivities',
        type: "GET",
        dataType: "JSON",
        data: { ClientId: selectedClientId },
        success: function (activities) {
            $("#ActivityId").html(""); // Limpiar antes de agregar nuevos

            if (activities.length == 0) {
                $("#ActivityId").append(
                    $('<option></option>').val("").html("No hay tarifas con actividades"));
            } else {
                $.each(activities, function (i, activity) {
                    $("#ActivityId").append(
                        $('<option></option>').val(activity.Id).html(activity.Name));
                });
            }
        }
    });
}


function UpdateVehicleTypes() {

    // Obtener actividad y cliente seleccionados
    var selectedClientId = $('#ClientId').val();
    var selecterActivityId = $('#ActivityId').val();

    $.ajax({
        url: '/Rates/GetClientActivityVehicles',
        type: "GET",
        dataType: "JSON",
        data: { ClientId: selectedClientId, ActivityId: selecterActivityId },
        success: function (vehicles) {
            $("#VehicleId").html("");// Limpiar antes de agregar nuevos

            if (vehicles.length == 0) {
                $("#VehicleId").append(
                    $('<option></option>').val("").html("No hay tarifas con vehículos"));
            } else {
                $.each(vehicles, function (i, vehicle) {
                    $("#VehicleId").append(
                        $('<option></option>').val(vehicle.Id).html(vehicle.Name));
                });
            }
        }
    });
}


