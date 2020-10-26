import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  persona = new Persona();

  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
  }

  add() {
    this.CalcularPulsacion();
    this.personaService.add(this.persona);
    alert("Persona registrada con éxito");
  }

  CalcularPulsacion() {
    this.persona.pulsaciones = (this.persona.sexo == "F")? (220 - this.persona.edad) / 10 : (210 - this.persona.edad) / 10;
  }
}