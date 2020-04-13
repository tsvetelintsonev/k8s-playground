import { Component, OnInit, Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from './models/Product';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

    title = 'nemstore';
    environment = environment;
	products: Array<Product> = [];

  	constructor(private httpClient: HttpClient) {}

	ngOnInit(): void {

    this.httpClient.get<Product[]>(environment.GetProductsUrl)
		.subscribe(
			products => this.products = products,
        	error => console.log(error));
	}
}
