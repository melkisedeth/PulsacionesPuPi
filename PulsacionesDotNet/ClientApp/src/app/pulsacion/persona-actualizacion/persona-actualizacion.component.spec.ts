import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonaActualizacionComponent } from './persona-actualizacion.component';

describe('PersonaActualizacionComponent', () => {
  let component: PersonaActualizacionComponent;
  let fixture: ComponentFixture<PersonaActualizacionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonaActualizacionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonaActualizacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
