import { Component } from '@angular/core';
import { User } from './User';

@Component({
    selector: 'signin',
    templateUrl: './signin.component.html'
})
export class SignInComponent {
    user: User = new User();

    signin() {
        console.log(this.user);
    }
}