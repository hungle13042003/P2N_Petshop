import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPetdetailComponent } from './list-petdetail.component';

describe('ListPetdetailComponent', () => {
  let component: ListPetdetailComponent;
  let fixture: ComponentFixture<ListPetdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListPetdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPetdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
