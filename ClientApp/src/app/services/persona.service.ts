import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Persona } from '../pulsacion/models/persona';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  personas = [];

  constructor() { }

  add(persona: Persona) {
    this.personas.push(persona);
  }

  get() {
    return this.personas;
  }

}
