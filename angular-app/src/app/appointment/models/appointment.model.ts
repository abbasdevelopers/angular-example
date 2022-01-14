export class AppointmentModel {
  constructor(
    public title: string = null,
    public note: string = null,
    public startDateTime: Date = null,
    public endDateTime: Date = null,
    public customerId: number = 0
  ) {}
}
