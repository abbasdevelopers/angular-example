import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ScheduledAppointmentsComponent } from './scheduled-appointments/scheduled-appointments.component';

const routes: Routes = [
  {path: '', component: ScheduledAppointmentsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BarberRoutingModule { }
