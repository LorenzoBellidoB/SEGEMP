// Clases Marca y Modelo
class Marca {
    constructor(id, nombre) {
        this.id = id;
        this.nombre = nombre;
    }
}

class Modelo {
    constructor(id, nombre, idMarca) {
        this.id = id;
        this.nombre = nombre;
        this.idMarca = idMarca;
    }
}

// Asignar eventos al cargar la ventana
window.onload = inicializaEventos;

function inicializaEventos() {
    listarMarcas(); // Inicializar marcas
    document.getElementById("marcas").addEventListener("change", listarModelos); // Evento al cambiar marca
}

// Lista de marcas
let listaMarca = [
    new Marca(1, "Audi"),
    new Marca(2, "Mercedes"),
    new Marca(3, "Peugeot"),
    new Marca(4, "Renault"),
    new Marca(5, "Seat")
];

// Lista de modelos
let listaModelo = [
    new Modelo(1, "A1", 1),
    new Modelo(2, "A3", 1),
    new Modelo(3, "A4", 1),
    new Modelo(4, "A5", 1),
    new Modelo(5, "A6", 1),
    new Modelo(6, "208", 3),
    new Modelo(7, "Ibiza", 5),
    new Modelo(8, "Leon", 5)
];

// Función para listar marcas y agregarlas al select
function listarMarcas() {
    const selectElement = document.getElementById("marcas");
    let optionsHTML = '<option value="">Seleccione una marca</option>'; // Opción inicial
    listaMarca.forEach(marca => {
        optionsHTML += `<option value="${marca.id}">${marca.nombre}</option>`;
    });
    selectElement.innerHTML = optionsHTML;
}

// Función para listar modelos según la marca seleccionada
function listarModelos() {
    const marcaSelect = document.getElementById("marcas");
    const modelosContainer = document.getElementById("modelos");
    modelosContainer.innerHTML = ""; // Limpiar el contenedor de modelos

    const idMarca = parseInt(marcaSelect.value); // Obtener el ID de la marca seleccionada

    if (!idMarca) {
        modelosContainer.innerHTML = "<li>Seleccione una marca para ver los modelos.</li>";
        return;
    }

    // Filtrar modelos según la marca seleccionada
    const listaModeloMarca = listaModelo.filter(modelo => modelo.idMarca === idMarca);

    if (listaModeloMarca.length === 0) {
        modelosContainer.innerHTML = "<li>No hay modelos disponibles para esta marca.</li>";
        return;
    }

    // Crear elementos <li> para cada modelo
    let lisHTML = "";
    listaModeloMarca.forEach(modelo => {
        lisHTML += `<li>${modelo.nombre}</li>`;
    });

    modelosContainer.innerHTML = lisHTML; // Insertar los modelos en el contenedor
}
