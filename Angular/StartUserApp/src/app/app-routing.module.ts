import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { UserOverviewComponent } from './user-overview/user-overview.component';

const routes: Routes = [
  {path:'',redirectTo:'/home-page', pathMatch:'full'},
  {path: 'home-page', component: HomePageComponent},
  {path: 'useroverview', component: UserOverviewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
