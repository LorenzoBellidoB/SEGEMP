import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { TablaPersonasComponent } from "./components/tabla-personas/tabla-personas.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, RouterLinkActive],  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'HolaMundoSinRender';
  saludo = "";
  saludar(){
    this.saludo = "Hola";
  }
  // Manda a pagina del formulario
  mostrarFormulario(){
    
  }
}
