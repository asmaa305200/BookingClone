import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllAttractionReservationsComponent } from './all-attraction-reservations.component';

describe('AllAttractionReservationsComponentComponent', () => {
  let component: AllAttractionReservationsComponent;
  let fixture: ComponentFixture<AllAttractionReservationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllAttractionReservationsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllAttractionReservationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
