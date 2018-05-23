import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './users/signin.component';
import { HomeComponent } from './home/home.component';
import { CustomerComponent } from './customers/customer.component';
import { ProductComponent } from './products/product.component';

const routes: Routes = [
    { path: 'users/signin', component: SignInComponent },
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'customers/all', component: CustomerComponent },
    { path: 'products/all', component: ProductComponent }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class CrmRouteModule {

}


