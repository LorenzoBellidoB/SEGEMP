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
