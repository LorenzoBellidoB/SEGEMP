import { Component } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { FormBuilder, FormGroup, FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import {MatDialogModule} from '@angular/material/dialog';
import { PersonasService } from '../../services/personas.service';

@Component({
  selector: 'app-dialog-body',
  imports: [ReactiveFormsModule, MatButtonModule, MatIconModule, MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule],
  templateUrl: './dialog-body.component.html',
  styleUrl: './dialog-body.component.scss'
})
export class DialogBodyComponent {
  personaForm: FormGroup;
  constructor(private fb: FormBuilder, private personaService: PersonasService) {
    this.personaForm = this.fb.group({
      nombre: [''],
      apellidos: [''],
      telefono: [''],
      direccion: [''],
      foto: [''],
      fechaNacimiento: [''],
      idDepartamento: ['']
    });
  }

  guardarPersona() {
    const persona = this.personaForm.value;
    this.personaService.create(persona).subscribe({
      next: (response) => {
        alert("Persona: " + persona.nombre + " " + persona.apellidos + " creada correctamente");
      },
      error: () => {
        alert("Ha ocurrido un error al obtener los datos del servidor");
      }
    });
  }
}
