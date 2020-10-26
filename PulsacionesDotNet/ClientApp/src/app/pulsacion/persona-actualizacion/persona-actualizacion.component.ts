import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-actualizacion',
  templateUrl: './persona-actualizacion.component.html',
  styleUrls: ['./persona-actualizacion.component.css']
})
export class PersonaActualizacionComponent implements OnInit {
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

  actualizarDatos() {
    this.personaService.Modificar(this.persona).subscribe(p =>{
      if (p.identificacion != null) {
        alert('Datos actualizados con éxito:');
        this.persona = p;
      }
      else {
        this.persona = new Persona();
        alert('La persona que intenta modificar no se encuentra registrada');
      }
    });
  }

}
