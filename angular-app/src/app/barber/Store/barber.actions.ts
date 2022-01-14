import { createAction, props } from '@ngrx/store';
import { CustomersListState } from './barber.reducer';

export const tryFetchCustomers = createAction(
  'Try Fetching Customers',
  props<{payload: any}>()
)

export const setCustomers = createAction(
  'Set customers list',
  props<{payload: CustomersListState}>()
)
