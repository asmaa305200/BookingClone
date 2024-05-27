import { Component, OnInit } from '@angular/core';
import { IAttractionReservation } from '../../Models/iattraction-reservation';
import { AttractionReservationApiService } from '../../Services/attraction-reservation-api.service';

@Component({
  selector: 'app-all-attraction-reservations',
  templateUrl: './all-attraction-reservations.component.html',
  styleUrls: ['./all-attraction-reservations.component.css']
})
export class AllAttractionReservationsComponent implements OnInit {
  attractionReservationsList: IAttractionReservation[] = [];

  constructor(private attractionReservationApi: AttractionReservationApiService) { }
  
  ngOnInit(): void {
    this.attractionReservationApi.getPagedAttractionReservation().subscribe(response => {
      this.attractionReservationsList = response.data;
    })
  }
}
