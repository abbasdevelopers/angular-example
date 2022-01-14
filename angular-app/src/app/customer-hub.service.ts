import { Injectable } from '@angular/core';
import * as SignalR from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerHubService {

  private hubConnection: SignalR.HubConnection;
  private customersSubject = new BehaviorSubject<number>(null);

  castCustomerId = this.customersSubject.asObservable();

  constructor() { }

  private startConnection = () => {
    this.hubConnection = new SignalR.HubConnectionBuilder()
                            .withUrl(`${environment.baseUrl}/hubs/customers`)
                            .build();

    this.hubConnection
    .start()
    .then(() => console.log('Hub connection started!'))
    .catch(err => console.error(err));
  }

  public startListening = () => {
    this.startConnection();
    this.hubConnection.on('CustomerAdded', data => {
      console.log('data received', data);
      this.customersSubject.next(data);
    })
  }
}
