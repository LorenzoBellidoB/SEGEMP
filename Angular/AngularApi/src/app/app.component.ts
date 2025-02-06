import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet, Router } from '@angular/router';
import { ListaPersonasComponent } from './components/lista-personas/lista-personas.component';
import { DialogBodyComponent } from './components/dialog-body/dialog-body.component';
import { MatDialog } from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import {MatDialogModule} from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,  MatButtonModule, MatIconModule, MatDividerModule, MatFormFieldModule, MatInputModule, FormsModule, MatDialogModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'AngularApi';

  constructor(private router: Router, private dialog: MatDialog){}

  mostrarListado(){
    this.router.navigate(['listaPersonas']);
  }

  opendialog(){
    this.dialog.open(DialogBodyComponent,{
      width: '350px',
    })
  }
}
