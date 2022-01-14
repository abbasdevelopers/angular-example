import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AppointmentModel } from '../models/appointment.model';

@Injectable()
export class AppointmentHttpService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public addAppointment(model: AppointmentModel) {
    return this.httpClient.post(`${environment.baseUrl}/appointments`, model)
      .pipe(
        take(1),
        map((appointmentId: number) => {
          return appointmentId;
        }),
        catchError((err) => {
          console.error(err);
          return of(0);
        })
      )
  }
}
