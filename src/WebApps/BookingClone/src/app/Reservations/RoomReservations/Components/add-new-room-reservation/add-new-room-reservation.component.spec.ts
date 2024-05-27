import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewRoomReservationComponent } from './add-new-room-reservation.component';

describe('AddNewRoomReservationComponent', () => {
  let component: AddNewRoomReservationComponent;
  let fixture: ComponentFixture<AddNewRoomReservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddNewRoomReservationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddNewRoomReservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
