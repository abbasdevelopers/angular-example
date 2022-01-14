import { Injectable } from "@angular/core";
import { createEffect, Actions, ofType, act } from '@ngrx/effects';
import * as BarberActions from './barber.actions';
import { map, mergeMap, catchError, switchMap } from 'rxjs/operators';
import { CustomersListState } from './barber.reducer';
import { from } from "rxjs";
import { BarberHttpService } from "../services/barber-http.service";

@Injectable()
export class BarberEffects {
  constructor(
    private actions$: Actions,
    private barberHttpService: BarberHttpService
  ) {

  }
  setFetchCustomerEffect$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BarberActions.tryFetchCustomers),
      switchMap(action => {
        return from(
          this.barberHttpService.getCustomers()
        )
      }),
      map((customers) => {
        const customerListState: CustomersListState = {
          customers: customers
        };
        console.log('new state', customerListState);
        return BarberActions.setCustomers({payload: customerListState});
      })
    )
  );
}
