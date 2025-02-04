import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet, Router } from '@angular/router';
import { TablaPersonasComponent } from "./components/tabla-personas/tabla-personas.component";
import { FormularioPersonaComponent } from "./components/formulario-persona/formulario-persona.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, RouterLinkActive],  
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'HolaMundoSinRender';
  saludo = "";

  constructor(private router: Router){}
  saludar(){
    this.saludo = "Hola";
  }
  // Manda a pagina del formulario
  mostrarFormulario(){
    this.router.navigate(['formulario']);
  }
}
