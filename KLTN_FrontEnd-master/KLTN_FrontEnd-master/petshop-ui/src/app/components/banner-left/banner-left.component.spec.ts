import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BannerLeftComponent } from './banner-left.component';

describe('BannerLeftComponent', () => {
  let component: BannerLeftComponent;
  let fixture: ComponentFixture<BannerLeftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BannerLeftComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BannerLeftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
