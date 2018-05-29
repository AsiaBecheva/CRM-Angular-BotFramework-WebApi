import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { CustomerData } from './customer.data';
import 'rxjs/add/operator/toPromise';

var url = 'http://localhost:57087/api/Customers/'

@Injectable()
export class CustomerService {
    constructor(private http: Http) { }

    getData(): Promise<CustomerData> {
        return this.http
            .get(url)
            .toPromise()
            .then(resp => resp.json() as CustomerData)
            .catch(err => {
                console.log(err);
                return new CustomerData()
            })
    }
}
