import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonaEliminacionComponent } from './persona-eliminacion.component';

describe('PersonaEliminacionComponent', () => {
  let component: PersonaEliminacionComponent;
  let fixture: ComponentFixture<PersonaEliminacionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonaEliminacionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonaEliminacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
