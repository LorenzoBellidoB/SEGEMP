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
            crearCartaPokemon(pokemon);
        }
    };
    miLlamada.send();
}

function crearCartaPokemon(pokemon) {
    var card = document.getElementById("datos");
    card.innerHTML = `
        <img src="${pokemon.sprites.front_default}" alt="${pokemon.name}">
        <h2>${pokemon.name}</h2>
        <p><strong>Altura:</strong> ${pokemon.height}0cm</p>
        <p><strong>Peso:</strong> ${pokemon.weight}kg</p>
        <h3>Movimientos</h3>
        <ul id="movimientos">
            ${pokemon.moves.slice(0, 5).map(move => `
                <li id="${move.move.name}">
                    ${move.move.name}
                </li>`).join('')}
        </ul>
        <h3>Habilidades</h3>
        <ul>
            ${pokemon.abilities.map(ability => `<li>${ability.ability.name}</li>`).join('')}
        </ul>
        <h3>Grito</h3>
        <audio src="${pokemon.cries.latest}" controls></audio>
    `;

    // Obtener tipos de movimientos
    pokemon.moves.slice(0, 5).forEach(move => {
        obtenerTipoMovimiento(move.move.url, move.move.name);
    });
}

function obtenerTipoMovimiento(url, moveName) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", url);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var move = JSON.parse(miLlamada.responseText);
            var tipo = move.type.name;
            switch (tipo) {
                case "normal": 
                    tipo = "icos/normal.png";
                    break;
                case "fire": 
                    tipo = "icos/fuego.png";
                    break;
                case "water": 
                    tipo = "icos/agua.png";
                    break;
                case "electric": 
                    tipo = "icos/electrico.png"; 
                    break;    
                case "grass": 
                    tipo = "icos/planta.png";
                    break;
                case "steel": 
                    tipo = "icos/acero.png";
                    break;
                case "fighting": 
                    tipo = "icos/lucha.png";
                    break;
                case "dragon":
                    tipo = "icos/dragon.png";
                    break;
                case "psychic":
                    tipo = "icos/psiquico.png";
                    break;
                case "dark":
                    tipo = "icos/siniestro.png";
                    break;
                
            }
            document.getElementById(moveName).innerHTML += ` <img src="${tipo}" style="width: 20px; height: 20px;">`;
        }
    };
    miLlamada.send();
}
