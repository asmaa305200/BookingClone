import { Component, OnInit } from '@angular/core';
import { HotelServicesService } from '../../Services/hotel-services.service';
import { IHotel } from '../../Models/ihotel';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { hotelImg } from '../../Models/img'



@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.css']
})
export class HotelsComponent implements OnInit {
  hotelList: any
  pageNumber: number = 1;
  pageSize: number = 10;
  totalItems: number = 0;
  totalPages: number = 100;




  constructor(private hotelApi: HotelServicesService, private router: Router) { }
  showMsg: boolean = false;
  getHotels(type: string) {
    if (type === 'Previous' && this.pageNumber > 1) {
      this.pageNumber--;
    }
    else if (type === 'Next') {
      this.pageNumber++;
    }
    else if (type !== 'First') {
      return
    }

    this.hotelApi.getAllHotel(this.pageNumber, this.pageSize).subscribe(({
      next: res => {
        if (Number(res.pageNumber) > Number(res.totalPages)) {
          this.pageNumber--;
          this.showMsg = true;
          return
        }
        else {
          this.showMsg = false;
        }
        this.totalItems = Number(res.totalPages) * Number(res.pageSize);
        this.hotelList = res.data;

        this.hotelList.map((item: IHotel, ind: number) => {
          let hotel = item;

          hotel.url = hotelImg[ind % hotelImg.length].name;
          return hotel
        });
        console.log(this.hotelList)


      }
    }))
  }



  ngOnInit(): void {

    this.getHotels("First");

  }

  seImgtUrl(hotel: IHotel) {
    this.hotelApi.setImgUrl(hotel.url);

  }

}




