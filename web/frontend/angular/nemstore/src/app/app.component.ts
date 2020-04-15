import { Component, OnInit, Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from './models/Product';
import { CreateOrderRequest, CreateOrderRequestLine } from './models/CreateOrderRequest';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

	title = 'nemstore';
	environment = environment;
	products: Array<Product> = [];

	constructor(private httpClient: HttpClient) { }

	ngOnInit(): void {
		this.httpClient.get<Product[]>(environment.GetProductsUrl)
			.subscribe(
				products => this.products = products,
				error => console.log(error));
	}

	public buy(product: Product): void {
    var request = new CreateOrderRequest();
    var line = new CreateOrderRequestLine();
    line.productId = product.id;
    line.quantity = product.quantity;
    request.lines = new Array<CreateOrderRequestLine>();
    request.lines.push(line);

    this.httpClient.post(environment.CreateOrderUrl, JSON.stringify(request))
			.subscribe(
        response => console.log(response),
				error => console.log(error));
  }

  public incrementProductQuantity(product: Product): void {
    product.quantity = (product.quantity || 1) + 1;
    console.log(product);
  }

  public decrementProductQuantity(product: Product): void {
    if ((product.quantity || 1) == 1) {
      return;
    }

    product.quantity = product.quantity - 1;
  }
}
