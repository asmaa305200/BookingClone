import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Shared/Components/header/header.component';
import { FooterComponent } from './Shared/Components/footer/footer.component';
import { NotFoundComponent } from './Shared/Components/not-found/not-found.component';
import { StaysComponent } from './Shared/Components/stays/stays.component';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HotelsComponent } from './Hotels/Components/hotels/hotels.component';
import { HotelDetailsComponent } from './Hotels/Components/hotel-details/hotel-details.component';
import { RoomsComponent } from './Rooms/Components/rooms/rooms.component';
import { AllRoomReservationsComponent } from './Reservations/RoomReservations/Components/all-room-reservations/all-room-reservations.component';
import { AllAttractionReservationsComponent } from './Reservations/AttractionReservations/Components/all-attraction-reservations/all-attraction-reservations.component';
import { AddNewRoomReservationComponent } from './Reservations/RoomReservations/Components/add-new-room-reservation/add-new-room-reservation.component';
import { NgxPayPalModule } from 'ngx-paypal';
import { RoomDetailsComponent } from './Rooms/Components/room-details/room-details.component';
import { FormsComponent } from './UserForm/Components/forms/forms.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NotFoundComponent,
    StaysComponent,
    HotelsComponent,
    HotelDetailsComponent,
    RoomsComponent,
    AllRoomReservationsComponent,
    AllAttractionReservationsComponent,
    AddNewRoomReservationComponent,
    RoomDetailsComponent,
    FormsComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxPayPalModule,
    TranslateModule.forRoot({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: httpTranslateLoader,
        deps: [HttpClient]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
export function httpTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http);

}


