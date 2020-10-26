import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PersonaRegistroComponent } from './pulsacion/persona-registro/persona-registro.component';
import { PersonaConsultaComponent } from './pulsacion/persona-consulta/persona-consulta.component';
import { PersonaEliminacionComponent } from './pulsacion/persona-eliminacion/persona-eliminacion.component';
import { PersonaBusquedaComponent } from './pulsacion/persona-busqueda/persona-busqueda.component';
import { PersonaActualizacionComponent } from './pulsacion/persona-actualizacion/persona-actualizacion.component';

const routes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'personaConsulta', component: PersonaConsultaComponent},
    {path: 'personaRegistro', component: PersonaRegistroComponent},
    {path: 'personaBusqueda', component: PersonaBusquedaComponent},
    {path: 'personaEliminacion', component: PersonaEliminacionComponent},
    {path: 'personaActualizacion', component: PersonaActualizacionComponent},
    {path: '', component: HomeComponent}
  ];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
