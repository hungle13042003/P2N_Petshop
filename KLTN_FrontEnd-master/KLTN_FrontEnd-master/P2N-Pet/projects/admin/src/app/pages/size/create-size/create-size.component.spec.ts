import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSizeComponent } from './create-size.component';

describe('CreateSizeComponent', () => {
  let component: CreateSizeComponent;
  let fixture: ComponentFixture<CreateSizeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateSizeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateSizeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
