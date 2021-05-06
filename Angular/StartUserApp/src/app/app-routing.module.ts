import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserOverviewComponent } from './user-overview/user-overview.component';

const routes: Routes = [
  {path:'',redirectTo:'/home-page', pathMatch:'full'},
  {path: 'home-page', component: HomePageComponent},
  {path: 'useroverview', component: UserOverviewComponent},
  {path: 'detail/:id', component: UserDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
