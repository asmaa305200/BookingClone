import { ReservationStatus } from "src/app/Shared/Enums/reservation-status";

export interface IAttractionReservation {
    id: Number,
    totalCost: Number,
    status: ReservationStatus,
    tourStart: Date,
}
