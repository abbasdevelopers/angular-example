import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCustomerComponent } from './add-customer/add-customer.component';

const routes: Routes = [
  {path: '', component: AddCustomerComponent },
  {
    path: 'appointments',
    loadChildren: () => import('../appointment/appointment.module').then(m => m.AppointmentModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
