// window.onload = inicializaEventos;

// function inicializaEventos() {
//     mostrarDatos("https://lorenzoasp.azurewebsites.net/Api/PersonaApi");
// }

personaUrl = "https://lorenzoasp.azurewebsites.net/Api/PersonaApi";

function mostrarDatos() {
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", personaUrl);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPersona = JSON.parse(miLlamada.responseText);
            
            listarPersona(arrayPersona);
        }
    };
    miLlamada.send();
}

function eliminarPersona(id) {

    if(window.confirm("¿Desea eliminar la persona?")){
        var miLlamada = new XMLHttpRequest();

    miLlamada.open("DELETE", personaUrl + "/" + id);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            window.alert("Se ha eliminado la persona");
            mostrarDatos();
        }
    };
    miLlamada.send();
    }else{
        window.alert("No se ha eliminado la persona");
    }
    
}

function listarPersona(array) {
    document.getElementById("listaPersonas").innerHTML = array.map((persona) =>
        `<li id="${persona.id}">
            ${persona.id}
            ${persona.nombre}
            ${persona.apellidos}
            <img class="imagen" src="${persona.foto}" width="100">
            <button class="boton" onclick="eliminarPersona(${persona.id})">Eliminar</button>
        </li>`
    ).join("");
}


function abrirVentana() {
    // Crear una ventana emergente
    var ventana = window.open("", "Formulario", "width=400,height=400");

    // Escribir el formulario dentro de la ventana emergente
    ventana.document.write(`
      <html>
      <head><title>Formulario</title></head>
      <body>
        <h2>Formulario de Contacto</h2>
        <form id="formulario" onsubmit="enviarFormulario(event)">
          <label for="nombre">Nombre:</label>
          <input type="text" id="nombre" name="nombre" required><br><br>
          <label for="email">Correo Electrónico:</label>
          <input type="email" id="email" name="email" required><br><br>
          <button type="submit">Enviar</button>
        </form>
        <p id="mensaje"></p>
        <script>
          function enviarFormulario(event) {
            event.preventDefault(); // Prevenir el envío real del formulario
            var nombre = document.getElementById('nombre').value;
            var email = document.getElementById('email').value;
            document.getElementById('mensaje').innerText = 'Formulario enviado. Nombre: ' + nombre + ', Email: ' + email;
            
            // Cerrar la ventana emergente después de enviar el formulario
            window.close();
          }
        </script>
      </body>
      </html>
    `);
  }
