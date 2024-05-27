import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagedList } from 'src/app/Shared/Models/ipaged-list';
import { environment } from 'src/app/environments/environment.development';
import { IAttractionReservation } from '../Models/iattraction-reservation';

@Injectable({
  providedIn: 'root'
})
export class AttractionReservationApiService {
  httpHeader = {};

  constructor(private httpClient: HttpClient) {
    this.httpHeader = {
      headers: new HttpHeaders({
        'content-type': 'application/json'
      })
    };
  }

  getPagedAttractionReservation(pagesize: Number = 10, pageNumber: Number = 1) : Observable<IPagedList<IAttractionReservation>> {
    return this.httpClient.get<IPagedList<IAttractionReservation>>(`${environment.APIURL}/AttractionReservations?pageNumber=${pageNumber}&pageSize=${pagesize}`);
  }
}
