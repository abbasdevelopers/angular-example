import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAppointmentAddressComponent } from './add-appointment-address.component';

describe('AddAppointmentAddressComponent', () => {
  let component: AddAppointmentAddressComponent;
  let fixture: ComponentFixture<AddAppointmentAddressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAppointmentAddressComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAppointmentAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
