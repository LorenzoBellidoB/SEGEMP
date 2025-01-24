class ClsPersonaje {


    constructor(nombre, fechaNac, idBando) {
        this.nombre = nombre;
        this.fechaNac = fechaNac;
        this.idBando = idBando;
    }
}

class ClsPersonajeEdadBando {
    constructor(personaje, edad, nombreBando) {
        this.id = personaje.id;
        this.nombre = personaje.nombre;
        this.fechaNac = personaje.fechaNac;
        this.idBando = personaje.idBando;
        this.edad = edad;
        this.nombreBando = nombreBando;
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

function volver() {
    document.getElementById("cuerpo").innerHTML = "";
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
        <input type="text" id="nombreG" placeholder="nombre">
        <label for="fechaNac">Fecha Nacimiento</label>
        <input type="date" id="fechaNacG" placeholder="fechaNac">
        <label for="idBando">Bando</label>
        <input type="text" id="idBandoG" placeholder="idBando">
        </form>
        <button class="boton" onclick="guardarPersonaje()">Guardar</button>
        <button class="boton" onclick="volver()">Volver</button>
    `
}

function guardarPersonaje() {
    const nombreG = document.getElementById('nombreG').value.trim()
    const fechaNacG = document.getElementById('fechaNacG').value.trim()
    const idBandoG = document.getElementById('idBandoG').value.trim()
    let personaje = new ClsPersonaje(nombreG, fechaNacG, idBandoG)
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

function editarPersona(id) {
    // Solicitar los datos del personaje seleccionado
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", personajeUri + "/" + id);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // Puedes mostrar un mensaje de "Cargando..." si lo deseas
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var personaje = JSON.parse(miLlamada.responseText);

            // Mostrar el formulario de edición con los datos del personaje cargados
            mostrarFormularioEdicion(personaje);
        }
    };
    miLlamada.send();
}

function mostrarFormularioEdicion(personaje) {
    let fechaFormateada = new Date(personaje.fechaNac).toISOString().split('T')[0];
    document.getElementById("cuerpo").innerHTML = `
        <form id="editar">
            <label for="nombre">Nombre</label>
            <input type="text" id="nombreE" value="${personaje.nombre}">
            
            <label for="fechaNac">Fecha de Nacimiento</label>
            <input type="date" id="fechaNacE" value="${fechaFormateada}">
            
            <label for="idBando">Bando</label>
            <input type="text" id="idBandoE" value="${personaje.idBando}">
            
            <button class="boton" type="button" onclick="guardarEdicion(${personaje.id})">Guardar Cambios</button>
        </form>
        <button class="boton" onclick="volver()">Volver</button>
    `;
}

function guardarEdicion(id) {
    // Obtener los valores editados
    const nombre = document.getElementById("nombreE").value.trim();
    const fechaNac = document.getElementById("fechaNacE").value.trim();
    const idBando = document.getElementById("idBandoE").value.trim();

    // Crear un objeto con los datos editados
    let personaje = new ClsPersonaje(nombre, fechaNac, idBando);

    // Llamada para actualizar el personaje
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("PUT", personajeUri + "/" + id);

    miLlamada.setRequestHeader("Content-type", "application/json; charset=utf-8");

    var json = JSON.stringify(personaje);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // Puedes mostrar un mensaje de "Cargando..." si lo deseas
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            alert("Personaje actualizado con éxito");
            mostrarDatos(); // Volver a cargar la lista de personajes
        }
    };

    miLlamada.send(json);
}
