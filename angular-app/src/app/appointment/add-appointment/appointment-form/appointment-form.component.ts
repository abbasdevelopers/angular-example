import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentModel } from '../../models/appointment.model';
import * as moment from 'moment';

@Component({
  selector: 'app-appointment-form',
  templateUrl: './appointment-form.component.html',
  styleUrls: ['./appointment-form.component.css']
})
export class AppointmentFormComponent implements OnInit {

  @Output() onAppointmentFormSubmit = new EventEmitter<AppointmentModel>();

  public form: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      title: ['', [Validators.required, Validators.maxLength(255)]],
      note: ['', [Validators.maxLength(500)]],
      startDateTime: ['', Validators.required],
      endDateTime: ['', Validators.required],
      customerId: [this.activatedRoute.snapshot.queryParams['customerId']],
    });
  }
  onSubmit() {
    if(this.form.valid) {
      const startDateTime = moment(this.form.value.startDateTime).toDate();
      const endDateTime = moment(this.form.value.endDateTime).toDate();
      const appointmentModel = new AppointmentModel(
        this.form.value.title,
        this.form.value.note,
        startDateTime,
        endDateTime,
        Number.parseInt(this.form.value.customerId)
      )
      this.onAppointmentFormSubmit.emit(appointmentModel);
    }
  }

}
