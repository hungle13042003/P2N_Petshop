import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswordUserComponent } from './password-user.component';

describe('PasswordUserComponent', () => {
  let component: PasswordUserComponent;
  let fixture: ComponentFixture<PasswordUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PasswordUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PasswordUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
