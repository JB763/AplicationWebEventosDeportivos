$(document).ready(function () {
    $('#crearEventoForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario       
        var idEvento = $('#idEventoCrear').val().trim();
        var idDeporte = $('#idDeporteCrear').val().trim();
        var nombre = $('#NombreCrear').val().trim();
        var fechaIn = $('#FechaInCrear').val().trim();
        var fechaFin = $('#FechaFinCrear').val().trim();
        var costo = $('#CostoCrear').val().trim();
        var cupo = $('#CupoCrear').val().trim();
        

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idEvento === '') {
            camposConEspaciosEnBlanco.push('ID de Evento');
        }
        if (idDeporte === '') {
            camposConEspaciosEnBlanco.push('ID de Deporte');
        }
        if (nombre === '') {
            camposConEspaciosEnBlanco.push('Nombre');
        }
        if (fechaIn === '') {
            camposConEspaciosEnBlanco.push('Fecha de Inicio');
        }
        if (fechaFin === '') {
            camposConEspaciosEnBlanco.push('Fecha de Finalizacion');
        }
        if (costo === '') {
            camposConEspaciosEnBlanco.push('Costo');
        }
        if (cupo === '') {
            camposConEspaciosEnBlanco.push('Cupo');
        }     
        // verificado, mostrando un mensaje de alerta con los nombres de los campos vacíos
        if (camposConEspaciosEnBlanco.length > 0) {
            var mensaje = 'Los siguientes campos están vacíos:\n\n';
            mensaje += camposConEspaciosEnBlanco.join('\n');
            alert(mensaje);
            return;
        }
        // Envía el formulario si todos los campos están llenos
        this.submit();

    });

});
$(document).ready(function () {
    $('#actualizarEventoForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario       
        var idEvento = $('#idEventoActualizar').val().trim();
        var idDeporte = $('#idDeporteActualizar').val().trim();
        var nombre = $('#NombreActualizar').val().trim();
        var fechaIn = $('#FechaInActualizar').val().trim();
        var fechaFin = $('#FechaFinActualizar').val().trim();
        var costo = $('#CostoActualizar').val().trim();
        var cupo = $('#CupoActualizar').val().trim();


        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idEvento === '') {
            camposConEspaciosEnBlanco.push('ID de Evento');
        }
        if (idDeporte === '') {
            camposConEspaciosEnBlanco.push('ID de Deporte');
        }
        if (nombre === '') {
            camposConEspaciosEnBlanco.push('Nombre');
        }
        if (fechaIn === '') {
            camposConEspaciosEnBlanco.push('Fecha de Inicio');
        }
        if (fechaFin === '') {
            camposConEspaciosEnBlanco.push('Fecha de Finalizacion');
        }
        if (costo === '') {
            camposConEspaciosEnBlanco.push('Costo');
        }
        if (cupo === '') {
            camposConEspaciosEnBlanco.push('Cupo');
        }
        // verificado, mostrando un mensaje de alerta con los nombres de los campos vacíos
        if (camposConEspaciosEnBlanco.length > 0) {
            var mensaje = 'Los siguientes campos están vacíos:\n\n';
            mensaje += camposConEspaciosEnBlanco.join('\n');
            alert(mensaje);
            return;
        }
        // Envía el formulario si todos los campos están llenos
        this.submit();

    });

});

function ActualizarEvento(idEvento, idDeporte, nombre, fechaIn, fechaFin, costo, cupo) {
    $('#idEventoActualizar').val(idEvento);
    $('#idDeporteActualizar').val(idDeporte);
    $('#NombreActualizar').val(nombre);
    $('#FechaInActualizar').val(fechaIn);
    $('#FechaFinActualizar').val(fechaFin);
    $('#CostoActualizar').val(costo);
    $('#CupoActualizar').val(cupo);
    
}
$(document).ready(function () {
    $('.btn-warning[data-bs-target="#actualizarEvento"]').click(function () {
        var fila = $(this).closest('tr');
        var idEvento = fila.find('td:eq(0)').text();
        var idDeporte = fila.find('td:eq(1)').text();
        var nombre = fila.find('td:eq(2)').text();
        var fechaIn = fila.find('td:eq(3)').text();
        var fechaFin = fila.find('td:eq(4)').text();
        var costo = fila.find('td:eq(5)').text();
        var cupo = fila.find('td:eq(6)').text();
        ActualizarEvento(idEvento, idDeporte, nombre, fechaIn, fechaFin, costo, cupo);
    });
});


