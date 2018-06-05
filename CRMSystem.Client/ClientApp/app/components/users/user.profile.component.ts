import { Component } from '@angular/core';
import { CustomerData } from '../customers/customer.data';
//import { CustomerService } from '../customers/customer.service';


enum Status {
    active = 0,
    inactive = 1
}

@Component({
    selector: 'user',
    templateUrl: './user.profile.component.html'
})
export class UserComponent {
    customer = new CustomerData();

    //status = Status;
    //keys: any;

    //constructor() {
    //    this.keys = Object.keys(this.status).filter(Number);
    //}


    //data: CustomerData | undefined;

    //constructor(private customerService: CustomerService) { }

    //getCustomerData(): any {
    //    this.customerService
    //        .getData()
    //        .then(custData => {
    //            this.data = custData;
    //        })
    //}


}