class ClsPersonaje {


    constructor(nombre, fechaNac, idBando) {
        this.nombre = nombre;
        this.fechaNac = fechaNac;
        this.idBando = idBando;
    }
}

class ClsPersonajeEdadBando {
    constructor(personaje, edad, bando) {
        this.id = personaje.id;
        this.nombre = personaje.nombre;
        this.fechaNac = personaje.fechaNac;
        this.idBando = personaje.idBando;
        this.edad = edad;
        this.bando = bando;
    }
}

let personajeUri = "http://localhost:5253/api/personajes";
let bandosUri = 'http://localhost:5253/api/bandos';

function mostrarDatos() {
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", personajeUri);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var listadoPersonajes = JSON.parse(miLlamada.responseText);

            listarPersonaje(listadoPersonajes);
        }
    };
    miLlamada.send();
}

function listarPersonaje(listadoPersonajes) {
    document.getElementById("cuerpo").innerHTML = listadoPersonajes.map((personaje) =>
        `<ul id="listado">
        <li id="${personaje.id}">
            ${personaje.id}
            ${personaje.nombre}
            <div id="crud">
            <button class="boton" onclick="mostrarPersonaje(${personaje.id})">Detalle</button>
            <button class="boton" onclick="eliminarPersona(${personaje.id})">Eliminar</button>
            <button id="editar" class="boton" onclick="editarPersona(${personaje.id})">Editar</button>
            </div>
        </li>
        </ul>`
    ).join("");
}
function mostrarPersonaje(id) {
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", personajeUri + "/" + id);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var personaje = JSON.parse(miLlamada.responseText);

            detallePersonaje(personaje);
        }
    };
    miLlamada.send();
}

function detallePersonaje(personaje) {
    document.getElementById("cuerpo").innerHTML = 
        `<ul id="detalles">
        <li id="${personaje.id}">
            ${personaje.id}
            ${personaje.nombre}
            ${personaje.fechaNac}
            ${personaje.edad}
            ${personaje.idBando}
            ${personaje.nombreBando}
        </li>
        </ul>`
}
function crearPersonaje() {
    document.getElementById("cuerpo").innerHTML = 
    `<form id="crear">
        <label for="nombre">Nombre</label>
        <input type="text" id="nombre" placeholder="nombre">
        <label for="fechaNac">Fecha Nacimiento</label>
        <input type="date" id="fechaNac" placeholder="fechaNac">
        <label for="idBando">Bando</label>
        <input type="text" id="idBando" placeholder="idBando">
        </form>
        <button class="boton" onclick="guardarPersonaje()">Guardar</button>
    `
}

function guardarPersonaje() {
    const nombre = document.getElementById('nombre').value.trim()
    const fechaNac = document.getElementById('fechaNac').value.trim()
    const idBando = document.getElementById('idBando').value.trim()
    let personaje = new ClsPersonaje(nombre, fechaNac, idBando)
    var miLlamada = new XMLHttpRequest()

    miLlamada.open("POST", personajeUri)

    miLlamada.setRequestHeader('Content-type', 'application/json charset=utf-8')

    var json = JSON.stringify(personaje)

    // Definicion estados
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            alert("Persona insertada con exito")
            document.getElementById("cuerpo").innerHTML = ""
        }
    }

    miLlamada.send(json)
}

function eliminarPersona(id) {

    if (window.confirm("¿Desea eliminar la persona?")) {
        var miLlamada = new XMLHttpRequest();

        miLlamada.open("DELETE", personajeUri + "/" + id);

        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {
                // aquí se puede poner una imagen de un reloj o un texto “Cargando”
            } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                window.alert("Se ha eliminado la persona");
                mostrarDatos();
            }
        };
        miLlamada.send();
    } else {
        window.alert("No se ha eliminado la persona");
    }

}