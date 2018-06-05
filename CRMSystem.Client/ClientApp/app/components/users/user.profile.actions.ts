import { Injectable } from '@angular/core';
import { UserProfileService } from './user.profile.service';
import { CustomerData } from '../customers/customer.data';

@Injectable()
export class UserProfileActions {
    constructor(private userProfileService: UserProfileService) { }

    addCustomer(customer: CustomerData) {
        this.userProfileService
            .setData(customer)
            .subscribe(result => {
                console.log(result)
            });
    }
}
