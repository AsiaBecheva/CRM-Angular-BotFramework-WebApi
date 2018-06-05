import { Component } from '@angular/core';
import { CustomerData } from '../customers/customer.data';
import { UserProfileActions } from './user.profile.actions';
//import { CustomerService } from '../customers/customer.service';


enum Status {
    active = 0,
    inactive = 1
}

@Component({
    selector: 'user',
    templateUrl: './user.profile.component.html',
    styleUrls: ['user.profile.component.css']
})
export class UserComponent {
    customer: CustomerData = new CustomerData();
    constructor(private userProfileActions: UserProfileActions) { }

    addCustomer() {
        this.userProfileActions.addCustomer(this.customer)
    }

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