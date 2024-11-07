import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAgeComponent } from './list-age.component';

describe('ListAgeComponent', () => {
  let component: ListAgeComponent;
  let fixture: ComponentFixture<ListAgeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListAgeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListAgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
