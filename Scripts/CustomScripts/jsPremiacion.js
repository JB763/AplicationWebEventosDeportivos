$(document).ready(function () {
    $('#crearPremiacionForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario       
        var idParticipante = $('#idPremiacionCrear').val().trim();
        var idEvento = $('#idEventoCrear').val().trim();
        var posicion = $('#PosicionCrear').val().trim();
        var descripcion = $('#DescripcionCrear').val().trim();
        var fecha = $('#FechaCrear').val().trim();
    

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idParticipante === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (idEvento === '') {
            camposConEspaciosEnBlanco.push('ID de Evento');
        }
        if (posicion === '') {
            camposConEspaciosEnBlanco.push('Posicion');
        }
        if (descripcion === '') {
            camposConEspaciosEnBlanco.push('Descripcion');
        }
        if (fecha === '') {
            camposConEspaciosEnBlanco.push('Fecha');
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
    $('#actualizarPremiacionForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario       
        var idParticipante = $('#idPremiacionActualizar').val().trim();
        var idEvento = $('#idEventoActualizar').val().trim();
        var posicion = $('#PosicionActualizar').val().trim();
        var descripcion = $('#DescripcionActualizar').val().trim();
        var fecha = $('#FechaActualizar').val().trim();


        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idParticipante === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (idEvento === '') {
            camposConEspaciosEnBlanco.push('ID de Evento');
        }
        if (posicion === '') {
            camposConEspaciosEnBlanco.push('Posicion');
        }
        if (descripcion === '') {
            camposConEspaciosEnBlanco.push('Descripcion');
        }
        if (fecha === '') {
            camposConEspaciosEnBlanco.push('Fecha');
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
function ActualizarPremiacion(idPremiacion, idEvento, posicion, descripcion, fecha) {
    $('#idPremiacionActualizar').val(idPremiacion);
    $('#idEventoActualizar').val(idEvento);
    $('#PosicionActualizar').val(posicion);
    $('#DescripcionActualizar').val(descripcion);
    $('#FechaActualizar').val(fecha);
}
// asignando evento click a los botones de actualizar
$(document).ready(function () {
    $('.btn-warning[data-bs-target="#actualizarPremiacion"]').click(function () {
        var fila = $(this).closest('tr');
        var idPremiacion = fila.find('td:eq(0)').text().trim();
        var idEvento = fila.find('td:eq(1)').text().trim();
        var posicion = fila.find('td:eq(2)').text().trim();
        var descripcion = fila.find('td:eq(3)').text().trim();
        var fecha = fila.find('td:eq(4)').text().trim();
        ActualizarPremiacion(idPremiacion, idEvento, posicion, descripcion, fecha);
    });
});