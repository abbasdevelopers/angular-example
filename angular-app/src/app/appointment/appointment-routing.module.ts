import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppointmentAddressFormComponent } from './add-appointment-address/appointment-address-form/appointment-address-form.component';
import { AddAppointmentComponent } from './add-appointment/add-appointment.component';

const routes: Routes = [
  {path: '', component: AddAppointmentComponent},
  {path: 'book', component: AddAppointmentComponent},
  {path: 'address', component: AppointmentAddressFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppointmentRoutingModule { }
