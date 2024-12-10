class Persona{
    constructor(nombre, apellido){
    this.nombre = nombre;
    this.apellido = apellido;
    }
}

function saludar(){
    var persona = new Persona(document.getElementById("nombre").value, document.getElementById("apellido").value);
    alert("Hola " + persona.nombre + " " + persona.apellido);
}