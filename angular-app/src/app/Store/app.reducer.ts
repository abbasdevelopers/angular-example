import * as fromBarber from '../barber/Store/barber.reducer';
import { ActionReducerMap } from '@ngrx/store';

export interface AppState {
    barber_state: fromBarber.CustomersListState
}

export const reducers: ActionReducerMap<AppState> = {
  barber_state: fromBarber.customerReducer
}
