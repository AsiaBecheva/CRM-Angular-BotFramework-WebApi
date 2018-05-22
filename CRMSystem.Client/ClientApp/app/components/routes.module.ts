import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './users/signin.component';

const routes: Routes = [
    { path: 'users/signin', component: SignInComponent }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class CrmRouteModule {

}


