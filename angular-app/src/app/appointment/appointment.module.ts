import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppointmentRoutingModule } from './appointment-routing.module';
import { AddAppointmentComponent } from './add-appointment/add-appointment.component';
import { AppointmentFormComponent } from './add-appointment/appointment-form/appointment-form.component';
import { AddAppointmentAddressComponent } from './add-appointment-address/add-appointment-address.component';
import { AppointmentAddressFormComponent } from './add-appointment-address/appointment-address-form/appointment-address-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppointmentHttpService } from './services/appointment-http.service';


@NgModule({
  declarations: [AddAppointmentComponent, AppointmentFormComponent, AddAppointmentAddressComponent, AppointmentAddressFormComponent],
  imports: [
    CommonModule,
    AppointmentRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule
  ],
  providers: [AppointmentHttpService]
})
export class AppointmentModule { }
