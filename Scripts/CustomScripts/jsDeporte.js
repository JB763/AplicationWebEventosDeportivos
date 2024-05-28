$(document).ready(function () {
    $('#crearDeporteForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario
        var idDeporte = $('#idDeporteCrear').val().trim();
        var tipoDeporte = $('#TipoDeporteCrear').val().trim();
        var categoria = $('#CategoriaCrear').val().trim();

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo 
        if (idDeporte === '') {
            camposConEspaciosEnBlanco.push('ID de Deporte');
        }
        if (tipoDeporte === '') {
            camposConEspaciosEnBlanco.push('Tipo de Deporte');
        }
        if (categoria === '') {
            camposConEspaciosEnBlanco.push('Categoría');
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
    $('#actualizarDeporteForm').submit(function (event) {
        // Evita que el formulario se envíe automáticamente
        event.preventDefault();

        // Obtiene los valores de los campos del formulario
        var idDeporte = $('#idDeporteActualizar').val().trim();
        var tipoDeporte = $('#TipoDeporteActualizar').val().trim();
        var categoria = $('#CategoriaActualizar').val().trim();

        // Arreglo para almacenar los nombres de los campos con espacios en blanco
        var camposConEspaciosEnBlanco = [];

        // Verifica si cada campo está vacío y lo agrega al arreglo
        if (idDeporte === '') {
            camposConEspaciosEnBlanco.push('ID de Deporte');
        }
        if (tipoDeporte === '') {
            camposConEspaciosEnBlanco.push('Tipo de Deporte');
        }
        if (categoria === '') {
            camposConEspaciosEnBlanco.push('Categoría');
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

function ActualizarDeporte(idDeporte, tipoDeporte, categoria) {
    $('#idDeporteActualizar').val(idDeporte);
    $('#TipoDeporteActualizar').val(tipoDeporte);
    $('#CategoriaActualizar').val(categoria);
}

$(document).ready(function () {
    $('.btn-warning[data-bs-target="#actualizarDeporte"]').click(function () {
        var fila = $(this).closest('tr');
        var idDeporte = fila.find('td:eq(0)').text().trim();
        var tipoDeporte = fila.find('td:eq(1)').text().trim();
        var categoria = fila.find('td:eq(2)').text().trim();
        ActualizarDeporte(idDeporte, tipoDeporte, categoria);
    });
});

    
    
    

   

