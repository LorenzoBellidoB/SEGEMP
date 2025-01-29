import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],  // Importa ReactiveFormsModule
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class FormularioPersonaComponent {
  formulario: FormGroup;

  constructor(private fb: FormBuilder) {
    this.formulario = this.fb.group({
      nombre: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  enviarFormulario() {
    if (this.formulario.valid) {
      console.log('Datos enviados:', this.formulario.value);
    } else {
      console.log('Formulario inválido');
    }
  }
}
