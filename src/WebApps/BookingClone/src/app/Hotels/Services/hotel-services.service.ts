import { Injectable } from '@angular/core';
import { IHotel } from '../Models/ihotel';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { BehaviorSubject, Observable } from 'rxjs';
import { Environment } from '../environment/environment';


@Injectable({
  providedIn: 'root'
})
export class HotelServicesService {


  constructor(private httpClient: HttpClient) { }
  currentImgUrl = new BehaviorSubject('');
  getImgUrl() {
    if (this.currentImgUrl.value == '') {
      return localStorage.getItem('url') || 'default url';
    }
    return this.currentImgUrl.value;
  }
  setImgUrl(url: string) {
    this.currentImgUrl.next(url);
    console.log(`url is setting ${url}`);
    localStorage.setItem('url', url);
  }

  getAllHotel(pageNumber: number, pageSize: number): Observable<any> {
    return this.httpClient.get(`${Environment.APIURL}/api/Hotels?pageNumber=${pageNumber}&pageSize=${pageSize}`);

    // ?PageNumber=${pageNumber}&PageSize=${}
  }


  getHotelById(id: number): Observable<any> {
    return this.httpClient.get(`${Environment.APIURL}/api/Hotels/${id}`)
  }

}
