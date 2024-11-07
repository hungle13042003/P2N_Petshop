import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBreedComponent } from './list-breed.component';

describe('ListBreedComponent', () => {
  let component: ListBreedComponent;
  let fixture: ComponentFixture<ListBreedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListBreedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListBreedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
