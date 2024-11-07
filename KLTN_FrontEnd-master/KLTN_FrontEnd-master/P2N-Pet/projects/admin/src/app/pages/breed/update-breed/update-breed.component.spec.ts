import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateBreedComponent } from './update-breed.component';

describe('UpdateBreedComponent', () => {
  let component: UpdateBreedComponent;
  let fixture: ComponentFixture<UpdateBreedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateBreedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateBreedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
