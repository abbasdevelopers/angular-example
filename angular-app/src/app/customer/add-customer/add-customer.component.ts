import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerModel } from '../models/customer.model';
import { CustomerHttpService } from '../services/customer-http.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {

  constructor(
    private customerHttpService: CustomerHttpService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  addCustomer($event : CustomerModel) {
    this.customerHttpService.addCustomer($event).subscribe((customerId) => {
      this.router.navigate(['/customer/appointments/book'], {queryParams: {customerId: customerId}});
    });
  }
}
