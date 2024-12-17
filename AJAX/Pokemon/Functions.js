window.onload = inicializaEventos;

function inicializaEventos() {
    mostrarDatos("https://pokeapi.co/api/v2/pokemon");
}

function mostrarDatos(url) {
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", url);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPokemon = JSON.parse(miLlamada.responseText);
            listarPokemon(arrayPokemon);
        }
    };
    miLlamada.send();
}

function listarPokemon(array) {
    document.getElementById("desplegable").innerHTML = array.results.map((pokemon) =>
        `<option id="${pokemon.name}" value="${pokemon.url}">
            ${pokemon.name}
        </option>`
    ).join("");

    // Añadir evento change al select
    document.getElementById("desplegable").addEventListener("change", function() {
        mostrarPokemon(this.value);
    });
}

function mostrarPokemon(url) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", url);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var pokemon = JSON.parse(miLlamada.responseText);
            console.log(pokemon);
            // Aquí puedes mostrar los detalles del Pokémon
        }
    };
    miLlamada.send();
}
