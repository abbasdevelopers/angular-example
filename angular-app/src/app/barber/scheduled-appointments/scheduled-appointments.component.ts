import { Component, OnInit } from '@angular/core';
import { CustomerHubService } from 'src/app/customer-hub.service';
import { CustomerGridItem } from '../models/customer-grid-item.model';

@Component({
  selector: 'app-scheduled-appointments',
  templateUrl: './scheduled-appointments.component.html',
  styleUrls: ['./scheduled-appointments.component.css']
})
export class ScheduledAppointmentsComponent implements OnInit {

  constructor(
  ) { }

  ngOnInit(): void {
  }

}
