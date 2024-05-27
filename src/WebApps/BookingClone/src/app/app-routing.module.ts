import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './Shared/Components/not-found/not-found.component';
import { StaysComponent } from './Shared/Components/stays/stays.component';
import { HotelsComponent } from './Hotels/Components/hotels/hotels.component';
import { combineLatest } from 'rxjs';
import { HotelDetailsComponent } from './Hotels/Components/hotel-details/hotel-details.component';
import { AllRoomReservationsComponent } from './Reservations/RoomReservations/Components/all-room-reservations/all-room-reservations.component';
import { AllAttractionReservationsComponent } from './Reservations/AttractionReservations/Components/all-attraction-reservations/all-attraction-reservations.component';
import { FormsComponent } from './UserForm/Components/forms/forms.component';

const routes: Routes = [
  { path: 'Stays', component: StaysComponent },
  { path: 'Room/Reservations', component: AllRoomReservationsComponent },
  { path: 'Attraction/Reservations', component: AllAttractionReservationsComponent },
  { path: 'Hotels', component: HotelsComponent },
  { path: 'HotelDetails/:id', component: HotelDetailsComponent },
  { path: 'Forms', component: FormsComponent },
  { path: '', redirectTo: '/Hotels', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
