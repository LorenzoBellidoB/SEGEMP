
var personaUrl = "http://localhost:5299/api/persona"
var departamentoUrl = "http://localhost:5299/api/departamento"

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

function detallePersona(id) {
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", personaUrl + "/" + id);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var persona = JSON.parse(miLlamada.responseText);

            mostrarPersona(persona);
        }
    };
    miLlamada.send();
}

function listarPersona(array) {
    
    document.getElementById("cuerpo").innerHTML = array.map((persona) =>
        `<li id="${persona.id}">
            ${persona.id}
            ${persona.nombre}
            <div id="crud">
            <button class="boton" onclick="detallePersona(${persona.id})">Detalles</button>
            <button class="boton" onclick="eliminarPersona(${persona.id})">Eliminar</button>
            <button id="editar" class="boton" onclick="editarPersona(${persona.id})">Editar</button>
            </div>
        </li>`
    ).join("");
}

function mostrarPersona(persona) {
    document.getElementById("cuerpo").innerHTML = `<li id="${persona.id}">
            ${persona.id}
            ${persona.nombre}
            ${persona.direccion}
            <div id="crud">
            <button class="boton" onclick="eliminarPersona(${persona.id})">Eliminar</button>
            <button id="editar" class="boton" onclick="editarPersona(${persona.id})">Editar</button>
            </div>
        </li>`;
}

function eliminarPersona(id) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("DELETE", personaUrl + "/" + id);
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            mostrarDatos();
        }
    };
    miLlamada.send();

}
    