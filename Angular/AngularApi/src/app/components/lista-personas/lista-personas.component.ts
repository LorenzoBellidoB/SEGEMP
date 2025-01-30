import { Component, OnInit } from '@angular/core';
import { Persona } from '../../interfaces/persona';
import { PersonasService } from '../../services/personas.service';

@Component({
  selector: 'app-lista-personas',
  imports: [],
  templateUrl: './lista-personas.component.html',
  styleUrl: './lista-personas.component.scss'
})
export class ListaPersonasComponent {
  listadoPersonas:Persona[];

  constructor(private personaService: PersonasService) { }
  
  ngOnInit(): void {
  

  
  }
}
