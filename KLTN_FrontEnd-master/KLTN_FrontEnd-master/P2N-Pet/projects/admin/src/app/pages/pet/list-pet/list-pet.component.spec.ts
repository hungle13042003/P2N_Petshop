import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPetComponent } from './list-pet.component';

describe('ListPetComponent', () => {
  let component: ListPetComponent;
  let fixture: ComponentFixture<ListPetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListPetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
