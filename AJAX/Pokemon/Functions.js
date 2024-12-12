window.onload = inicializaEventos;

function inicializaEventos() {
    pedirDatos()
}

function buscarPokemon()
{

let nombre = '';

nombre = document.getElementById("nombre").value

var miLlamada = new XMLHttpRequest();

miLlamada.open("GET", "https://pokeapi.co/api/v2/pokemon" + "/" + nombre);

//Definicion estados

miLlamada.onreadystatechange = function () {

if (miLlamada.readyState < 4) {

//aquí se puede poner una imagen de un reloj o un texto “Cargando”

}

else

if (miLlamada.readyState == 4 && miLlamada.status == 200) {

var arrayPokemon = JSON.parse(miLlamada.responseText);
mostrarPokemon(arrayPokemon);


}

};

miLlamada.send();
}

function pedirDatos()

{

var miLlamada = new XMLHttpRequest();

miLlamada.open("GET", "https://pokeapi.co/api/v2/pokemon");

//Definicion estados

miLlamada.onreadystatechange = function () {

if (miLlamada.readyState < 4) {

//aquí se puede poner una imagen de un reloj o un texto “Cargando”

}

else

if (miLlamada.readyState == 4 && miLlamada.status == 200) {

var arrayPokemon = JSON.parse(miLlamada.responseText);
listarPokemon(arrayPokemon);


}

};

miLlamada.send();
}

function listarPokemon(array){

    document.getElementById("lista").innerHTML = array.results.map((pokemon) =>
         `<li>
            <a href="https://pokeapi.co/api/v2/pokemon/1/">${pokemon.name}</a>
    </li> `
).join("");
}

function mostrarPokemon(array){
    document.getElementById("pokemon").innerHTML = array.results.map((pokemon) =>
    `<p>${pokemon.name}</p>
    <img src="${pokemon.sprites.front_default}">
    
    `
    )
}