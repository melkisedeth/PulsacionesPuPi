import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { PersonaRegistroComponent } from './pulsacion/persona-registro/persona-registro.component';
import { PersonaConsultaComponent } from './pulsacion/persona-consulta/persona-consulta.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { PersonaService } from './services/persona.service';
import { PersonaBusquedaComponent } from './pulsacion/persona-busqueda/persona-busqueda.component';
import { PersonaActualizacionComponent } from './pulsacion/persona-actualizacion/persona-actualizacion.component';
import { PersonaEliminacionComponent } from './pulsacion/persona-eliminacion/persona-eliminacion.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavMenuComponent,
    FooterComponent,
    HomeComponent,
    PersonaRegistroComponent,
    PersonaConsultaComponent,
    PersonaBusquedaComponent,
    PersonaActualizacionComponent,
    PersonaEliminacionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatIconModule
  ],
  providers: [PersonaService],
  bootstrap: [AppComponent]
})
export class AppModule { }