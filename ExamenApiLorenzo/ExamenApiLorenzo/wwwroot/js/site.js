// Clase persona con los datos de una persona
class ClsPersona {
    constructor(id, nombre, apellidos, telefono, direccion, foto, fechaNacimiento, idDepartamento) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.direccion = direccion;
        this.foto = foto;
        this.fechaNacimiento = fechaNacimiento;
        this.idDepartamento = idDepartamento;
    }
}

// Clase PersonaConNombreDptEdad que hereda de persona y contiene ademas nombreDpt y edad
class PersonaConNombreDptEdad {
    constructor(persona, edad, nombreDpt) {
        this.Id = persona.Id;
        this.Nombre = persona.Nombre;
        this.Apellidos = persona.Apellidos;
        this.Telefono = persona.Telefono;
        this.Direccion = persona.Direccion;
        this.Foto = persona.Foto;
        this.FechaNacimiento = persona.FechaNacimiento;
        this.IdDepartamento = persona.IdDepartamento;
        this.edad = edad;
        this.nombreDpt = nombreDpt;
    }
}
// Direcciones de cada pagina de api
let personasUri = "http://localhost:5081/api/personas"
let personaDetalleUri = "http://localhost:5081/api/persona/detalle"
let departamentosUri = "http://localhost:5081/api/departamentos"

// Funcion que muestra los departamentos al abrir la ventana
window.onload = inicializaEventos;

 function inicializaEventos() {
     mostrarDatos();
}

// Muestra los distintos departamentos
function mostrarDatos() {
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", departamentosUri);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayDepartamentos = JSON.parse(miLlamada.responseText);

            listarDepartamentos(arrayDepartamentos);
        }
    };
    miLlamada.send();
}


// Funcion que pinta los distintos departamentos
// function listarDepartamentos(departamentos) {
//     document.getElementById("cuerpoDpt").innerHTML += departamentos.map((departamento) =>
//         `
//         <button onclick="mostrarPersonas(${departamento.id})">${departamento.nombre}</button >
//         `
//     ).join("");
// }
// He intentado hacer el desplegable pero cuando clico no me muestra la tabla. Se debe a que lo estoy haciendo en el option y no en el select
// pero no me ha dado tiempo para poner el id con una funcion utilizando el getbyid.value
function listarDepartamentos(departamentos) {
    document.getElementById("deplegableDpt").innerHTML = departamentos.map((departamento) =>
       `
       <
           <option id="${departamento.id}" value="${departamento.id}">${departamento.nombre}</option>
       `
   ).join("");

    document.getElementById("deplegableDpt").addEventListener("change", function() {
        mostrarPersonas(this.value);
});
}

// Funcion que obtiene las personas
function mostrarPersonas(idDpt){
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", personasUri + "/" + idDpt);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPersonas = JSON.parse(miLlamada.responseText);

            listarPersonas(arrayPersonas);
        }
    };
    miLlamada.send();
}

// Funcion que pinta las personas en una tabla
function listarPersonas(arrayPersonas) {
    document.getElementById("tabla").innerHTML = arrayPersonas.map((persona) =>
        `
                <tbody>
                <tr onclick="mostrarDetalles(${persona.id})">
                    <td>${persona.nombre}</td >
                    <td>${persona.apellidos}</td >
                </tr>
                </tbody>
        `
    ).join();

}

// Funcion que obtiene los detalles de una persona
function mostrarDetalles(id) {
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", personaDetalleUri + "/" + id);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var persona = JSON.parse(miLlamada.responseText);

            detallePersona(persona);
        }
    };
    miLlamada.send();
}

// Funcion que pinta los detalles de las personas
function detallePersona(persona) {
    document.getElementById("detalles").innerHTML = 
        `
            <ul>
                <li>Nombre: ${persona.nombre}</li >
                <li>Apellidos: ${persona.apellidos}</li >
                <li>Direccion: ${persona.direccion}</li >
                <li>Telefono: ${persona.telefono}</li >
                <li>Edad: ${persona.edad}</li >
                <li>Fecha de Nacimiento: ${persona.fechaNacimiento}</li >
                <li>Id Departamento: ${persona.idDepartamento}</li >
                <li>Nombre Departamento: ${persona.nombreDpt}</li >
            </ul>
        `
}