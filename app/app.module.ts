import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { ProductComponent } from './products/product.component';
import { FormsModule } from '@angular/forms';
import { WelcomeComponent } from './home/welcome.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ReviewComponent } from './review/review.component';


@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    WelcomeComponent,
    ReviewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'welcome', component: WelcomeComponent },
      { path: 'products', component: ProductComponent },
      { path: 'reviews', component: ReviewComponent },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '**', redirectTo: 'welcome', pathMatch: 'full' }
    ]),
  ],
  exports: [RouterModule],
  providers: [HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
