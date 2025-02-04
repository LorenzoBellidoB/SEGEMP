import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet, Router } from '@angular/router';
import { ListaPersonasComponent } from './components/lista-personas/lista-personas.component';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, RouterLinkActive, MatButtonModule, MatIconModule, MatDividerModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'AngularApi';

  constructor(private router: Router){}

  mostrarListado(){
    this.router.navigate(['listaPersonas']);
  }
}
