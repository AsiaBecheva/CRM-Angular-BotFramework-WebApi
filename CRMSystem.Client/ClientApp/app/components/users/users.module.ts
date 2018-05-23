import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UsersService } from './users.service';

import { SignInComponent } from './signin.component';

@NgModule({
    declarations: [SignInComponent],
    providers: [UsersService],
    imports: [FormsModule]
})
export class UsersModule {

}