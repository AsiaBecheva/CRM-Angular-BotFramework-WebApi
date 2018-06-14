import { Component, OnInit } from '@angular/core';
import { CustomerData } from './customer.data';
import { ProductData } from '../home/product.data';
import { CustomerService } from './customer.service';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})
export class CustomerComponent implements OnInit {
    customerData: Array<CustomerData> | undefined;
    productData: Array<ProductData> | undefined;

    constructor(private customerService: CustomerService) { }

    ngOnInit(): void {
        this.customerService
            .getData()
            .then(custData => {
                this.customerData = custData;
            })
    }

    getProducts(id: number): void {
        this.customerService
            .getProductsData(id)
            .then(prodData => {
                this.productData = prodData;
                console.log(prodData);
            })
    }

    //getProducts(id: number) {
    //    return this.http
    //        .get(urlProducts + id)
    //        .toPromise()
    //        .then(resp => console.log(resp));
    //}
}

