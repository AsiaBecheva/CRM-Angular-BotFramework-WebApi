import { Component, OnInit } from '@angular/core';
import { CustomerData } from './customer.data';
import { CustomerService } from './customer.service';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})
export class CustomerComponent implements OnInit {
    private customerData: CustomerData;

    constructor(private customerService: CustomerService) { }

    ngOnInit(): void {
        this.customerService
            .getData()
            .then(custData => {
                console.log(custData);
                this.customerData = custData
            })
    }
}

