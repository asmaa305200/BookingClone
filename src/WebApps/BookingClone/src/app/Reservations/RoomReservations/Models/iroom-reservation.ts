import { ReservationStatus } from "src/app/Shared/Enums/reservation-status";

export interface IRoomReservation {
    id: Number,
    totalCost: Number,
    status: ReservationStatus,
    checkIn: Date,
    checkOut: Date
}
