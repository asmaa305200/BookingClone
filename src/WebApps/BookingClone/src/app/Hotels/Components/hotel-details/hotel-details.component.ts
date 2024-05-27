import { Component, OnInit } from '@angular/core';
import { HotelServicesService } from '../../Services/hotel-services.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IHotel } from '../../Models/ihotel';
import { Location } from '@angular/common';
import { RoomServiceService } from 'src/app/Rooms/Services/room-service.service';
import { Iroom } from 'src/app/Rooms/Models/iroom';
import { roomImg } from '../../Models/img';

@Component({
  selector: 'app-hotel-details',
  templateUrl: './hotel-details.component.html',
  styleUrls: ['./hotel-details.component.css']
})
export class HotelDetailsComponent implements OnInit {
  rooms: any = [];
  currentHotelID: number = 0
  returnedHotel: IHotel | undefined
  hotel: IHotel | undefined
  id: number
  hotelDetail: any
  imgUrl: string = '';
  roomImgs = roomImg;
  range: any = 500;
  constructor(private hotelApi: HotelServicesService,
    private router: Router,
    private roomService: RoomServiceService,
    private activatedRoute: ActivatedRoute,
    private location: Location) {
    this.id = activatedRoute.snapshot.params['id']
  }

  getHotelDetails() {
    this.hotelApi.getHotelById(this.id).subscribe(({
      next: res => {
        this.hotelDetail = res
        console.log(this.hotelDetail)
      }


    }))
  }

  getRoomsByHotelId(id: number) {
    this.roomService.getRoomsByHotelId(id, 1, 100).subscribe(({
      next: res => {
        this.rooms = res.data?.filter((x: Iroom) => id == x.hotelId);
        this.rooms.map((item: Iroom, ind: number) => {
          let room = item;
          room.url = this.roomImgs[ind].imgName;
          return room
        });
      },
      error: (err: any) => {
        console.log(err.error)
      }
    }))

  }
  ngOnInit(): void {
    this.getHotelDetails()
    this.getRoomsByHotelId(this.id);
    setTimeout(() => {
      this.imgUrl = this.hotelApi.getImgUrl();
    }, 100);
  }

  ChangeValue(input: any, dropValue: any) {

    console.log(dropValue);
    let type = undefined;

    if (dropValue !== "Selcet Type") {
      type = dropValue != 0;
    }
    this.roomService.getFilterdRoom(0, input.value, type).subscribe(x => {
      console.log("this.rooms before");
      console.log(this.rooms);
      this.rooms = x

      this.rooms = x;
      this.rooms = this.rooms.filter((x: any) => x.hotelId == this.id);
      console.log("this.rooms");
      console.log(this.rooms);

      this.rooms.map((item: Iroom, ind: number) => {
        let room = item;
        room.url = roomImg[ind].imgName;
        return room
      });

    })
    this.range = input.value;
  }

}



