import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  persona: Persona;

  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.persona = new Persona();
  }

  add() {
    this.personaService.Guardar(this.persona).subscribe(p => {
      if (p.identificacion != null) {
        alert('La persona con cédula: ' + this.persona.identificacion + ' fue creada con éxito');
        this.persona = p;
      }
      else {
        alert('La persona con cédula: ' + this.persona.identificacion + ' ya se encuentra registrada');
      }
    });
  }
}