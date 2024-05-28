$(document).ready(function () {
    $('#crearFormaDePagoForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario
        var idFormaDePago = $('#idFormaDePagoCrear').val().trim();
        var tipopago = $('#TipoPagoCrear').val().trim();
      

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        if (idFormaDePago === '') {
            camposConEspaciosEnBlanco.push('ID de Forma de Pago');
        }
        if (tipopago === '') {
            camposConEspaciosEnBlanco.push('Tipo de Pago');
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
    $('#actualizarFormaDePagoForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario
        var idFormaDePago = $('#idFormaDePagoActualizar').val().trim();
        var tipopago = $('#TipoPagoActualizar').val().trim();


        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        if (idFormaDePago === '') {
            camposConEspaciosEnBlanco.push('ID de Forma de Pago');
        }
        if (tipopago === '') {
            camposConEspaciosEnBlanco.push('Tipo de Pago');
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
function ActualizarFormaDePago(idFormaDePago, tipoPago) {
    $('#idFormaDePagoActualizar').val(idFormaDePago);
    $('#TipoPagoActualizar').val(tipoPago);
     
}
// Asignar evento de clic al botón "Actualizar" en cada fila de la tabla
$(document).ready(function () {
    $('.btn-warning[data-bs-target="#actualizarFormaDePago"]').click(function () {
        var fila = $(this).closest('tr');
        var idFormaDePago = fila.find('td:eq(0)').text();
        var tipoPago = fila.find('td:eq(1)').text();
        ActualizarFormaDePago(idFormaDePago, tipoPago);    
    });
});
