import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonaBusquedaComponent } from './persona-busqueda.component';

describe('PersonaBusquedaComponent', () => {
  let component: PersonaBusquedaComponent;
  let fixture: ComponentFixture<PersonaBusquedaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonaBusquedaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonaBusquedaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
