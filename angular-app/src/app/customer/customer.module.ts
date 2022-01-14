import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { CustomerFormComponent } from './add-customer/customer-form/customer-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustomerHttpService } from './services/customer-http.service';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [AddCustomerComponent, CustomerFormComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule
  ],
  providers: [
    CustomerHttpService
  ]
})
export class CustomerModule { }
