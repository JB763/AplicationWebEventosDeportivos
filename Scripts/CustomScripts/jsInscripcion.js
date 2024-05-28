$(document).ready(function () {
    $('#crearInscripcionForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario       
        var idInscripcion = $('#idInscripcionCrear').val().trim();
        var idEvento = $('#idEventoCrear').val().trim();
        var idParticipante = $('#idParticipanteCrear').val().trim();
        var idFormaDePago = $('#idFormaDePagoCrear').val().trim();
        var fechaIn = $('#FechaInCrear').val().trim();
        var fechaFin = $('#FechaFinCrear').val().trim();

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idInscripcion === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (idEvento === '') {
            camposConEspaciosEnBlanco.push('ID de Evento');
        }
        if (idParticipante === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (idFormaDePago === '') {
            camposConEspaciosEnBlanco.push('ID de Forma de pago');
        }
        if (fechaIn === '') {
            camposConEspaciosEnBlanco.push('Fecha de Inicio');
        }
        if (fechaFin === '') {
            camposConEspaciosEnBlanco.push('Fecha de Finalizacion');
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
    $('#actualizarInscripcionForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario       
        var idInscripcion = $('#idInscripcionActualizar').val().trim();
        var idEvento = $('#idEventoActualizar').val().trim();
        var idParticipante = $('#idParticipanteActualizar').val().trim();
        var idFormaDePago = $('#idFormaDePagoActualizar').val().trim();
        var fechaIn = $('#FechaInActualizar').val().trim();
        var fechaFin = $('#FechaFinActualizar').val().trim();

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idInscripcion === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (idEvento === '') {
            camposConEspaciosEnBlanco.push('ID de Evento');
        }
        if (idParticipante === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (idFormaDePago === '') {
            camposConEspaciosEnBlanco.push('ID de Forma de pago');
        }
        if (fechaIn === '') {
            camposConEspaciosEnBlanco.push('Fecha de Inicio');
        }
        if (fechaFin === '') {
            camposConEspaciosEnBlanco.push('Fecha de Finalizacion');
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
function ActualizarInscripcion(idInscripcion, idEvento, idParticipante, idFormaDePago, fechaIn, fechaFin) {
    $('#idInscripcionActualizar').val(idInscripcion);
    $('#idEventoActualizar').val(idEvento);
    $('#idParticipanteActualizar').val(idParticipante);
    $('#idFormaDePagoActualizar').val(idFormaDePago);
    $('#FechaInActualizar').val(fechaIn);
    $('#FechaFinActualizar').val(fechaFin);
   
}

// Asignar evento de clic al botón "Actualizar" en cada fila de la tabla
$(document).ready(function () {
    $('.btn-warning[data-bs-target="#actualizarInscripcion"]').click(function () {
        var fila = $(this).closest('tr');
        var idInscripcion = fila.find('td:eq(0)').text();
        var idEvento = fila.find('td:eq(1)').text();
        var idParticipante = fila.find('td:eq(2)').text();
        var idFormaDePago = fila.find('td:eq(3)').text();
        var fechaIn = fila.find('td:eq(4)').text();
        var fechaFin = fila.find('td:eq(5)').text();
        ActualizarInscripcion(idInscripcion, idEvento, idParticipante, idFormaDePago, fechaIn, fechaFin);
    
    });
});