import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService } from '../../services/persona.service';
import { of } from 'rxjs';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {
  personas: Persona[];
  totales: number[];
  tipoConsulta: string;
  totalHombres: number;
  totalMujeres: number;
  totalPersonas: number;

  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.personas = [];
    this.totales = [];
  }

  Consultar() {
    this.personaService.Consultar(this.tipoConsulta,"Consulta").subscribe(result => {
      this.personas = result;
    });
    this.personaService.Totalizar(this.tipoConsulta,"Totales").subscribe(totales => {
      if (totales.length != 0) {
        this.totales = totales;
        this.totalHombres = this.totales[0];
        this.totalMujeres = this.totales[1];
        this.totalPersonas = this.totales[2];
      }
    })
  }
}
