import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomerModel } from '../../models/customer.model';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  @Output() onCustomerformSubmit = new EventEmitter<CustomerModel>();

  public form: FormGroup;
  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      fullName: ['', [Validators.required, Validators.maxLength(300)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(300)]],
      phone: ['', Validators.maxLength(20)]
    });
  }
  onSubmit() {
    if(this.form.valid) {
      this.onCustomerformSubmit.emit(this.form.value);
    }
  }

}
