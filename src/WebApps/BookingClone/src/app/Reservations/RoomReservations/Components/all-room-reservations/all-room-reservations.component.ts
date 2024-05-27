import { Component, OnInit } from '@angular/core';
import { IRoomReservation } from '../../Models/iroom-reservation';
import { RoomReservationApiService } from '../../Services/room-reservation-api.service';

@Component({
  selector: 'app-all-room-reservations',
  templateUrl: './all-room-reservations.component.html',
  styleUrls: ['./all-room-reservations.component.css']
})
export class AllRoomReservationsComponent implements OnInit {
  roomReservationsList: IRoomReservation[] = [];

  constructor(private roomReservationApi: RoomReservationApiService) { }

  ngOnInit(): void {
    this.roomReservationApi.getPagedRoomReservation().subscribe(response => {
      this.roomReservationsList = response.data;
    })
  }


}
