import { Component, inject } from '@angular/core';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import {MatSnackBar} from '@angular/material/snack-bar';
@Component({
  selector: 'app-formulario',
  imports: [MatProgressSpinnerModule, MatButtonModule],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.scss'
})
export class FormularioComponent {
  private _snackBar = inject(MatSnackBar);

  saludar() {
    this._snackBar.open("Hola", "Cerrar",{
      duration: 2000,
    });
  }
}
