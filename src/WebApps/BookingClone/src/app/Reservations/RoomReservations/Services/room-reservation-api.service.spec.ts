import { TestBed } from '@angular/core/testing';

import { RoomReservationApiService } from './room-reservation-api.service';

describe('RoomReservationApiService', () => {
  let service: RoomReservationApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoomReservationApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
