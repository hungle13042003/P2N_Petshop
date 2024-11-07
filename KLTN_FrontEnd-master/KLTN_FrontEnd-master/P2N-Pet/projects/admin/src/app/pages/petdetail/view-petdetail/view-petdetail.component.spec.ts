import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPetdetailComponent } from './view-petdetail.component';

describe('ViewPetdetailComponent', () => {
  let component: ViewPetdetailComponent;
  let fixture: ComponentFixture<ViewPetdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewPetdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewPetdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
