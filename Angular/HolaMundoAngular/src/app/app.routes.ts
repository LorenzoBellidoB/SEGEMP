import { Routes } from '@angular/router';
import { TablaPersonasComponent } from './components/tabla-personas/tabla-personas.component';
import { FormularioPersonaComponent } from './components/formulario-persona/formulario-persona.component';
import { ListadoPersonasComponent } from './components/listado-personas/listado-personas.component';

export const routes: Routes = [
    { path: 'tabla', component: TablaPersonasComponent },
    { path: 'formulario', component: FormularioPersonaComponent },
    {path: 'listado', component: ListadoPersonasComponent},
];
