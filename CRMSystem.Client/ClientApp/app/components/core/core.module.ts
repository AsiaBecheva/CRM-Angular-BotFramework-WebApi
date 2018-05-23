import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpService } from './http.service';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
    ],
    providers: [HttpService]
})
export class CoreModule {

}