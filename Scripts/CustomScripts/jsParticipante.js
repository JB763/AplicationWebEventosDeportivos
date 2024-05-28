$(document).ready(function () {
    $('#crearParticipanteForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario       
        var idParticipante = $('#idParticipanteCrear').val().trim();
        var nombre = $('#NombreCrear').val().trim();
        var apellido = $('#ApellidoCrear').val().trim();
        var sexo = $('#SexoCrear').val().trim();
        var edad = $('#EdadCrear').val().trim();    
        var telefono = $('#TelefonoCrear').val().trim();

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idParticipante === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (nombre === '') {
            camposConEspaciosEnBlanco.push('Nombre');
        }
        if (apellido === '') {
            camposConEspaciosEnBlanco.push('Apellido');
        }
        if (sexo === '') {
            camposConEspaciosEnBlanco.push('Sexo');
        }
        if (edad === '') {
            camposConEspaciosEnBlanco.push('Edad');
        }
        if (telefono === '') {
            camposConEspaciosEnBlanco.push('Telefono');
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
    $('#actualizarParticipanteForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario       
        var idParticipante = $('#idParticipanteActualizar').val().trim();
        var nombre = $('#NombreActualizar').val().trim();
        var apellido = $('#ApellidoActualizar').val().trim();
        var sexo = $('#SexoActualizar').val().trim();
        var edad = $('#EdadActualizar').val().trim();
        var telefono = $('#TelefonoActualizar').val().trim();

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idParticipante === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (nombre === '') {
            camposConEspaciosEnBlanco.push('Nombre');
        }
        if (apellido === '') {
            camposConEspaciosEnBlanco.push('Apellido');
        }
        if (sexo === '') {
            camposConEspaciosEnBlanco.push('Sexo');
        }
        if (edad === '') {
            camposConEspaciosEnBlanco.push('Edad');
        }
        if (telefono === '') {
            camposConEspaciosEnBlanco.push('Telefono');
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
function ActualizarParticipante(idParticipante, nombre, apellido, sexo, edad, telefono) {  
    $('#idParticipanteActualizar').val(idParticipante);
    $('#NombreActualizar').val(nombre);
    $('#ApellidoActualizar').val(apellido);
    $('#SexoActualizar').val(sexo);
    $('#EdadActualizar').val(edad);
    $('#TelefonoActualizar').val(telefono);  
}

// Asignar evento de clic al botón "Actualizar" en cada fila de la tabla
$(document).ready(function () {
    $('.btn-warning[data-bs-target="#actualizarParticipante"]').click(function () {
        var fila = $(this).closest('tr');      
        var idParticipante = fila.find('td:eq(0)').text().trim();
        var nombre = fila.find('td:eq(1)').text().trim();
        var apellido = fila.find('td:eq(2)').text().trim();
        var sexo = fila.find('td:eq(3)').text().trim();
        var edad = fila.find('td:eq(4)').text().trim();
        var telefono = fila.find('td:eq(5)').text().trim();      
        ActualizarParticipante(idParticipante, nombre, apellido, sexo, edad, telefono);
    });
});