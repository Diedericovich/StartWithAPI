import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserOverviewComponent } from './user-overview/user-overview.component';
import { HomePageComponent } from './home-page/home-page.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { NavigationComponent } from './navigation/navigation.component';
// Import Angular Forms
import { FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    UserOverviewComponent,
    HomePageComponent,
    UserDetailComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
