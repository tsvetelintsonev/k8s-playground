export class Order {
    id: string;
    createdAt: string;
    lines: OrderLine[];
    status: OrderStatus;
    total: number;
    showOrderSummary: boolean = false;
}

export class OrderLine {
    id: string;
    orderId: string;
    productId: number;
    productName: string;
    productImageUrl: string;
    quantity: number;
    totalPrice: number;
}

export enum OrderStatus {
    Created, AwaitingStockApproval, Completed
}
