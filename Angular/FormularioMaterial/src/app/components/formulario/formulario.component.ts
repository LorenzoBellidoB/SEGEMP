import { Component, OnInit } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';

import {FormGroup, FormControl, Validators} from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-formulario',
  imports: [MatFormFieldModule, MatCardModule, MatInputModule, NgIf],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioPersonaComponent implements OnInit {

  formulario!:FormGroup;


  ngOnInit(): void {

  this.formulario=new FormGroup(

  {
    nombre: new FormControl('',[Validators.required]),
    apellidos:new FormControl('',[])
  });
  }

  saluda(){

    if (this.formulario.valid)
      alert('Hola ' + this.formulario.controls.nombre.value + ' ' + this.formulario.controls.apellidos.value);

  }
}
