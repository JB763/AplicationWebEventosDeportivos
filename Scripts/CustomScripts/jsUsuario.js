 $(document).ready(function() {
     $('#crearUsuarioForm').submit(function (event) {
            // Evita que el formulario se envíe automáticamente
            event.preventDefault();

            // Obtiene los valores de los campos del formulario
            var idUsuario = $('#idUsuarioCrear').val().trim();
            var idParticipante = $('#idParticipanteCrear').val().trim();
            var correo = $('#CorreoCrear').val().trim();
            var contraseña = $('#ContraseñaCrear').val().trim();

            // Arreglo para almacenar los nombres de los campos con espacios en blanco
            var camposConEspaciosEnBlanco = [];

            // Verifica si cada campo está vacío y lo agrega al arreglo si es así
            if (idUsuario === '') {
                camposConEspaciosEnBlanco.push('ID de Usuario');
            }
            if (idParticipante === '') {
                camposConEspaciosEnBlanco.push('ID de Participante');
            }
            if (correo === '') {
                camposConEspaciosEnBlanco.push('Correo Electrónico');
            }
            if (contraseña === '') {
                camposConEspaciosEnBlanco.push('Contraseña');
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
    $('#actualizarUsuarioForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario
        var idUsuario = $('#idUsuarioActualizar').val().trim();
        var idParticipante = $('#idParticipanteActualizar').val().trim();
        var correo = $('#CorreoActualizar').val().trim();
        var contraseña = $('#ContraseñaActualizar').val().trim();

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo si es así
        if (idUsuario === '') {
            camposConEspaciosEnBlanco.push('ID de Usuario');
        }
        if (idParticipante === '') {
            camposConEspaciosEnBlanco.push('ID de Participante');
        }
        if (correo === '') {
            camposConEspaciosEnBlanco.push('Correo Electrónico');
        }
        if (contraseña === '') {
            camposConEspaciosEnBlanco.push('Contraseña');
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

// Función para llenar el modal de actualización con los datos de la fila seleccionada
function ActualizarUsuario(idUsuario, idParticipante, correo, contraseña) {
    $('#idUsuarioActualizar').val(idUsuario);
    $('#idParticipanteActualizar').val(idParticipante);
    $('#CorreoActualizar').val(correo);
    $('#ContraseñaActualizar').val(contraseña); 
}
// Asignar evento de clic al botón "Actualizar" en cada fila de la tabla
$(document).ready(function () {
    $('.btn-warning[data-bs-target="#actualizarUsuario"]').click(function () {
        var fila = $(this).closest('tr');
        var idUsuario = fila.find('td:eq(0)').text().trim();
        var idParticipante = fila.find('td:eq(1)').text().trim();
        var correo = fila.find('td:eq(2)').text().trim();
        var contraseña = fila.find('td:eq(3)').text().trim();
        ActualizarUsuario(idUsuario, idParticipante, correo, contraseña);
    });
});

