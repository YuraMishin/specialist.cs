export interface IInventoryTimeline {
  productInventorySnapshots: ISnapshot[];
  timmeline: Date[];
}

export interface ISnapshot {
  productId: number;
  quantityOnHand: number[];
}
