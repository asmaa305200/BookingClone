import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Environment } from 'src/app/Hotels/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class RoomServiceService {

  constructor(private httpClient: HttpClient) { }

  getRoomsByHotelId(id: number, pageNumber: number, pageSize: number): Observable<any> {
    // return this.httpClient.get(`${Environment.APIURL}/api/Rooms/${id}`)
    return this.httpClient.get(`${Environment.APIURL}/api/Rooms?PageNumber=${pageNumber}&PageSize=${pageSize}`)
  }
  getFilterdRoom(from: number, to: number, ava: boolean | undefined): Observable<any> {
    let query = `from=${from}&to=${to}`
    if (ava) {
      query += `&ava=${ava}`;
    }
    return this.httpClient.get(`${Environment.APIURL}/api/Rooms/GetFilterdRooms?${query}`);
  }
}
