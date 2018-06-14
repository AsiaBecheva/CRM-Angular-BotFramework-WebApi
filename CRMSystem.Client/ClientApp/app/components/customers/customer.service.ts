import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { CustomerData } from './customer.data';
import { ProductData } from '../home/product.data';
import 'rxjs/add/operator/toPromise';

var urlCustomers = 'http://localhost:57087/api/Customers/'
var urlProducts = 'http://localhost:57087/api/Products/'

@Injectable()
export class CustomerService {

    constructor(private http: Http) { }

    getData(): Promise<CustomerData> {
        return this.http
            .get(urlCustomers)
            .toPromise()
            .then(resp => resp.json() as CustomerData)
            .catch(err => {
                console.log(err);
                return new CustomerData()
            });
    }

    getProductsData(customerId: number): Promise<ProductData> {
        return this.http
            .get(urlProducts + customerId)
            .toPromise()
            .then(resp => resp.json() as ProductData)
            .catch(err => {
                console.log(err)
                return new ProductData()
            });
    }
}
