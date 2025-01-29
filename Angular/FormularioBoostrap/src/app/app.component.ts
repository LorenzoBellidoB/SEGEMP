import { Component } from '@angular/core';
import {  RouterOutlet, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FormularioMaterial';
  saludo = "";

  constructor(private router: Router){

  }
  saludar(){
    this.saludo = "Hola";
  }
  // Manda a pagina del formulario
  mostrarFormulario(){
    this.router.navigate(['formulario']);
  }
}

