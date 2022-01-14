import { Component, OnInit } from '@angular/core';
import { CustomerHubService } from './customer-hub.service';
import { HubService } from './hub.service';
import { AppState } from './Store/app.reducer';
import { Store } from '@ngrx/store';
import * as BarberActions from './barber/Store/barber.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'upwork-assignment-app';
  public newCustomerId = '';
  constructor(
    private hubService: HubService,
    private customerHubService: CustomerHubService,
    private store: Store<AppState>
    ) {

  }
  async ngOnInit(){
    this.newCustomerId = '0'
    this.hubService.startListening();
    this.customerHubService.startListening();
    this.customerHubService.castCustomerId.subscribe(customerId => {
      this.newCustomerId = `${customerId}`;
      console.log('this.newCustomerId', this.newCustomerId);
      this.store.dispatch(BarberActions.tryFetchCustomers({payload: null}));
    });
  }
}
