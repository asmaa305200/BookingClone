import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-room-details',
  templateUrl: './room-details.component.html',
  styleUrls: ['./room-details.component.css']
})
export class RoomDetailsComponent {

  @Input()
  roomDetails: any = {};

  payFlag: boolean = false;

  constructor() { }
  
  togglePayFlag() {
    this.payFlag = !this.payFlag;
  }
}
