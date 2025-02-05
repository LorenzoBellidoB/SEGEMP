import { inject, Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Persona } from '../interfaces/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {

  /*URL de mi aPI para usar en todo el Servicio*/

urlWebAPI='https://joseluisasp.azurewebsites.net/api/personas';

constructor() { }

http=inject(HttpClient);

getPersonas(): Observable<Persona[]>{

return this.http.get<Persona[]>(this.urlWebAPI);

}

create(miPersona:Persona){
  return this.http.post<Persona>(this.urlWebAPI,miPersona);
}

getById(id:number){
  return this.http.get<Persona>(this.urlWebAPI+"/"+id);
}

update(miPersona:Persona): Observable<Persona>{
  return this.http.put<Persona>(this.urlWebAPI+"/"+miPersona.id,miPersona);
}

delete(id:number):Observable<number>{
  return this.http.delete<Persona>(this.urlWebAPI+"/"+id);
}
}
