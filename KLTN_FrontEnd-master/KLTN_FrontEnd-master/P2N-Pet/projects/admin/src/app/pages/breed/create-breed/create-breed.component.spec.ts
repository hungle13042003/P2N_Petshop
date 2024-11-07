import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBreedComponent } from './create-breed.component';

describe('CreateBreedComponent', () => {
  let component: CreateBreedComponent;
  let fixture: ComponentFixture<CreateBreedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateBreedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBreedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
