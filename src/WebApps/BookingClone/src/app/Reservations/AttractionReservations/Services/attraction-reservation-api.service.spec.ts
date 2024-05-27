import { TestBed } from '@angular/core/testing';

import { AttractionReservationApiService } from './attraction-reservation-api.service';

describe('AttractionReservationApiService', () => {
  let service: AttractionReservationApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AttractionReservationApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
