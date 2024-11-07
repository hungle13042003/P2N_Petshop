import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePetdetailComponent } from './update-petdetail.component';

describe('UpdatePetdetailComponent', () => {
  let component: UpdatePetdetailComponent;
  let fixture: ComponentFixture<UpdatePetdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatePetdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatePetdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
