import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalizationServiceService {

  constructor(private http: HttpClient) { }


  getUsers() {
    return this.http.get('/assets/users.json');
  }

  addUser(obj: any) {
    return this.http.post('/assets/users.json',
      [
        {
          "username": "ahmed", "password": "123"
        },
        {
          "email": "hamada.com",
          "password": "124"
        }
      ]
    );
  }
}
