import { Injectable } from '@angular/core';
import * as SignalR from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HubService {

  private hubConnection: SignalR.HubConnection;
  public appointmentSubject = new BehaviorSubject<{userId: number, appointmentId: number}>(null);

  constructor() { }

  private startConnection = () => {
    this.hubConnection = new SignalR.HubConnectionBuilder()
                            .withUrl(`${environment.baseUrl}/hubs/appointments`)
                            .build();

    this.hubConnection
    .start()
    .then(() => console.log('Hub connection started!'))
    .catch(err => console.error(err));
  }

  public startListening = () => {
    this.startConnection();
    this.hubConnection.on('AppointmentAdded', data => {
      this.appointmentSubject.next(data);
    })
  }
}
