import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllRoomReservationsComponent } from './all-room-reservations.component';

describe('AllRoomReservationsComponent', () => {
  let component: AllRoomReservationsComponent;
  let fixture: ComponentFixture<AllRoomReservationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllRoomReservationsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllRoomReservationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
