import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AppointmentGridItem } from '../models/appointment-grid-item.model';
import { CustomerGridItem } from '../models/customer-grid-item.model';

@Injectable({
  providedIn: 'root'
})
export class BarberHttpService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getCustomers() {
    return this.httpClient.get<Array<CustomerGridItem>>(`${environment.baseUrl}/customers`)
      .pipe(
        take(1),
        map((data: any) => {
          const customers: Array<CustomerGridItem> = data.items;
          return customers;
        }),
        catchError(err => {
          console.error(err);
          const customers: Array<CustomerGridItem> = []
          return of(customers)
        })
      )
  }

  public getAppointments() {
    return this.httpClient.get<Array<AppointmentGridItem>>(`${environment.baseUrl}/appointments`)
      .pipe(
        take(1),
        map((data: any) => {
          return data.items;
        }),
        catchError(err => {
          console.error(err);
          const appointments: Array<AppointmentGridItem> = [];
          return of(appointments)
        })
      )
  }
}
