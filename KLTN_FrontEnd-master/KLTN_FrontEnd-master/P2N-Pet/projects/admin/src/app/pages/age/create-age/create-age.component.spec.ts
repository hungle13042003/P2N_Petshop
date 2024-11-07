import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAgeComponent } from './create-age.component';

describe('CreateAgeComponent', () => {
  let component: CreateAgeComponent;
  let fixture: ComponentFixture<CreateAgeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateAgeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateAgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
