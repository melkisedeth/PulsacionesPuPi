import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Persona } from '../pulsacion/models/persona';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { stringify } from 'querystring';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseURL: string;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseURL: string, 
  private HandleErrorService: HandleHttpErrorService)
  {
    this.baseURL = baseURL;
  }

  Guardar(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.baseURL + 'api/Persona', persona).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Persona>('Registrar Persona',new Persona()))
    );
  }

  Consultar(identificador: string, formulario: string): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.baseURL + 'api/Persona/' + identificador + '/' + formulario).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Persona[]>('Consultar Persona',null))
    );
  }

  Buscar(identificador: string, formulario: string): Observable<Persona> {
    return this.http.get<Persona>(this.baseURL + 'api/Persona/' + identificador + '/' + formulario).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Persona>('Buscar Persona',new Persona()))
    );
  }

  Modificar(persona: Persona): Observable<Persona> {
    return this.http.put<Persona>(this.baseURL + 'api/Persona', persona).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Persona>('Modificar Persona',new Persona()))
    );
  }

  Eliminar(identificacion: string): Observable<Persona> {
    return this.http.delete<Persona>(this.baseURL + 'api/Persona/' + identificacion).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<Persona>('Eliminar Persona',new Persona()))
    );
  }

  Totalizar(identificador: string, formulario: string): Observable<number[]> {
    return this.http.get<number[]>(this.baseURL + 'api/Persona/' + identificador + '/' + formulario).pipe (
      tap(_ => this.HandleErrorService.log('Datos enviados exitosamente')),
      catchError(this.HandleErrorService.handleError<number[]>('Totalizar Personas',null))
    );
  }
}
