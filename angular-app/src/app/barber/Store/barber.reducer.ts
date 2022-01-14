import { CustomerGridItem } from "../models/customer-grid-item.model";
import { createReducer, on, Action } from '@ngrx/store'
import * as BarberActions from './barber.actions';

export interface CustomersListState{
  customers: Array<CustomerGridItem>
}

const initialState: CustomersListState = {
  customers: []
};

export function customerReducer(state, action) {
  return _customersListReducer(state, action);
}

const _customersListReducer = createReducer(
  initialState,
  on(BarberActions.setCustomers, (state, payload) => {
    return {
      ...state,
      ...payload.payload
    }
  })
)
export function reducer(state: CustomersListState | undefined, action: Action) {
  return customerReducer(state, action);
}
