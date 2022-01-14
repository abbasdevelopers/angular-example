import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CustomerModel } from '../models/customer.model';
import { catchError, map, take } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable()
export class CustomerHttpService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public addCustomer(model: CustomerModel) {
    return this.httpClient
      .post(`${environment.baseUrl}/customers`, model)
      .pipe(
        take(1),
        map((customerId: number) => {
          return customerId;
        }),
        catchError((err) => {
          console.error(err);
          return of(0);
        })
      );
  }
}
