import { Component, Input, NgZone, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { CustomerGridItem } from '../../models/customer-grid-item.model';
import { AppState } from '../../../Store/app.reducer';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit, OnChanges {

  customerGridItems: Array<CustomerGridItem> = [];

  constructor(
    private store: Store<AppState>,
    private ngZone: NgZone
  ) { }

  ngOnInit(): void {
    this.store.select(state => state.barber_state).subscribe((barberState) => {
      this.ngZone.run(() => {
        this.customerGridItems = [...barberState.customers];
        console.log('store subscription triggered', this.customerGridItems);
      });
    })
  }

  ngOnChanges(): void {
    console.log('customerGridItems', this.customerGridItems);

  }

}
