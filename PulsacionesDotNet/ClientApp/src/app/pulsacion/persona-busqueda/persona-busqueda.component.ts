import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService } from '../../services/persona.service';
import { of } from 'rxjs';

@Component({
  selector: 'app-persona-busqueda',
  templateUrl: './persona-busqueda.component.html',
  styleUrls: ['./persona-busqueda.component.css']
})
export class PersonaBusquedaComponent implements OnInit {
  persona: Persona;

  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.persona = new Persona();
  }

  buscar() {
    this.personaService.Buscar(this.persona.identificacion,"Busqueda").subscribe(result => {
      if (result.identificacion != null)
      {
        this.persona = result;
        alert('Busqueda realizada con éxito');
      }
      else
      {
        this.persona = new Persona();
        alert('La búsqueda no arrojó ningún resultado');
      }
    });
  }
}
