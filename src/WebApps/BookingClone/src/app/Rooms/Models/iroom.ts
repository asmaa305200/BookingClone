export interface Iroom {

  id: number
  RoomNumber: string

  Description: string

  IsAvailable: boolean

  BedCount: number

  ViewType: any //enum

  hotelId: number
  Price: number
  url?: string
}
