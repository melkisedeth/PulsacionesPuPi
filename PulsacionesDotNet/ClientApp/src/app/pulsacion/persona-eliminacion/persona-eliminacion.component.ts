import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-eliminacion',
  templateUrl: './persona-eliminacion.component.html',
  styleUrls: ['./persona-eliminacion.component.css']
})
export class PersonaEliminacionComponent implements OnInit {
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

  eliminar() {
    this.personaService.Eliminar(this.persona.identificacion).subscribe(p =>{
      if (p.identificacion != null) {
        alert('Persona eliminada con éxito:');
        this.persona = p;
      }
      else {
        alert('La persona que intenta eliminar no se encuentra registrada');
        this.persona = new Persona();
      }
    });
  }
}
