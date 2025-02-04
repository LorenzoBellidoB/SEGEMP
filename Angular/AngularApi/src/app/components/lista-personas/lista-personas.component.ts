import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';  // ✅ Importa MatTableModule
import { CommonModule } from '@angular/common';
import { MatTableDataSource } from '@angular/material/table';
import { Persona } from '../../interfaces/persona';
import { PersonasService } from '../../services/personas.service';

@Component({
  selector: 'app-lista-personas',
  standalone: true,  // ✅ Esto indica que es un Standalone Component
  imports: [CommonModule, MatTableModule],  // ✅ Agrega MatTableModule aquí
  templateUrl: './lista-personas.component.html',
  styleUrls: ['./lista-personas.component.scss']
})
export class ListaPersonasComponent implements OnInit {
  displayedColumns: string[] = ['id', 'nombre', 'apellidos', 'fechaNacimiento'];
  dataSource = new MatTableDataSource<Persona>([]);

  constructor(private personaService: PersonasService) {}

  ngOnInit(): void {
    this.obtenerPersonas();
  }

  obtenerPersonas(): void {
    this.personaService.getPersonas().subscribe({
      next: (response) => {
        this.dataSource.data = response;
      },
      error: () => {
        alert("Ha ocurrido un error al obtener los datos del servidor");
      }
    });
  }
}
