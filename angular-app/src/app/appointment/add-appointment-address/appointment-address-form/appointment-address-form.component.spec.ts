import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentAddressFormComponent } from './appointment-address-form.component';

describe('AppointmentAddressFormComponent', () => {
  let component: AppointmentAddressFormComponent;
  let fixture: ComponentFixture<AppointmentAddressFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppointmentAddressFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppointmentAddressFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
