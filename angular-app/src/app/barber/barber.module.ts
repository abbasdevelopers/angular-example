import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BarberRoutingModule } from './barber-routing.module';
import { ScheduledAppointmentsComponent } from './scheduled-appointments/scheduled-appointments.component';
import { AppointmentsListComponent } from './scheduled-appointments/appointments-list/appointments-list.component';
import { AppointmentsListItemComponent } from './scheduled-appointments/appointments-list-item/appointments-list-item.component';
import { BarberHttpService } from './services/barber-http.service';
import { HttpClientModule } from '@angular/common/http';
import { CustomerListComponent } from './scheduled-appointments/customer-list/customer-list.component';


@NgModule({
  declarations: [ScheduledAppointmentsComponent, AppointmentsListComponent, AppointmentsListItemComponent, CustomerListComponent],
  imports: [
    CommonModule,
    BarberRoutingModule,
    HttpClientModule
  ],
  providers: [
    BarberHttpService
  ]
})
export class BarberModule { }
