import {ILineItem} from "@/types/IInvoice";
import {ICustomer} from "@/types/Customer";

export interface ISalesOrder {
  id: number;
  createdOn: Date;
  updateJon?: Date;
  customer: ICustomer;
  isPaid: boolean;
  salesOrderItems: ILineItem[];
}
