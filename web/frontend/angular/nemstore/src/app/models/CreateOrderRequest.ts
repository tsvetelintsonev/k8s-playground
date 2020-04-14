export class CreateOrderRequest {
	lines: CreateOrderRequestLine[]
}

export class CreateOrderRequestLine {
	productId : number
    quantity: number
}
