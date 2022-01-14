import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentHttpService } from '../services/appointment-http.service';

@Component({
  selector: 'app-add-appointment',
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.css']
})
export class AddAppointmentComponent implements OnInit {

  constructor(
    private appointmentHttpService: AppointmentHttpService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  addAppointment($event) {
    console.log('$event', $event);
    this.appointmentHttpService.addAppointment($event).subscribe((appointmentId: number) => {
      this.router.navigate(['/customer']);
    });

  }

}
