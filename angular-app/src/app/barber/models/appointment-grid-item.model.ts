import { CustomerGridItem } from "./customer-grid-item.model";

export class AppointmentGridItem {
  constructor(
    public title: string = null,
    public note: string = null,
    public startDateTime: Date = null,
    public endDateTime: Date = null,
    public customer: CustomerGridItem = null
  ) {}
}
