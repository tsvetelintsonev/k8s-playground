import { Component, OnInit, Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Order, OrderStatus } from './models/Order';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

	title = 'nemstore';
	environment = environment;
	orders: Array<Order> = [];

	constructor(private httpClient: HttpClient) { }

	ngOnInit(): void {
		this.httpClient.get<Order[]>(environment.GetAllOrdersUrl)
			.subscribe(
				orders => { this.orders = orders; console.log(orders) },
				error => console.log(error));
	}

	public getStatusAsString(order: Order): string {
		return OrderStatus[order.status];
	}

	public formatDate(order: Order): string {
		var date = new Date(order.createdAt);
		return date.toLocaleDateString('en-US');
    }

    public showOrderSummary(order: Order): void {
        order.showOrderSummary = !order.showOrderSummary;
    }
}
