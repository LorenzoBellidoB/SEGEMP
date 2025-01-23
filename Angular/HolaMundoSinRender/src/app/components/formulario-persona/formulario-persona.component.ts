import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import {FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-formulario-persona',
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './formulario-persona.component.html',
  styleUrl: './formulario-persona.component.css'
})
export class FormularioPersonaComponent implements OnInit {

  formulario:FormGroup;
  

  ngOnInit(): void {

  this.formulario=new FormGroup(

  {
    nombre: new FormControl('',[Validators.required]),
    apellidos:new FormControl('',[])
  });
  }

  saluda(){

    if (this.formulario.valid)
      alert('Hola ' + this.formulario.controls['nombre'].value + ' ' + this.formulario.controls['apellidos'].value);

  }
}
