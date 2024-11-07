import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePetdetailComponent } from './create-petdetail.component';

describe('CreatePetdetailComponent', () => {
  let component: CreatePetdetailComponent;
  let fixture: ComponentFixture<CreatePetdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatePetdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePetdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
