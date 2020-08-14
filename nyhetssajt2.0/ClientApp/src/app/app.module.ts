import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NyhetsfeedComponent } from './nyhetsfeed/nyhetsfeed.component';
import { NyhetspuffComponent } from './nyhetspuff/nyhetspuff.component';
import { NyhetspuffAddEditComponent } from './nyhetspuff-add-edit/nyhetspuff-add-edit.component';
import { NyhetspuffService } from './services/nyhetspuff.service';

@NgModule({
  declarations: [
    AppComponent,
    NyhetsfeedComponent,
    NyhetspuffComponent,
    NyhetspuffAddEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    NyhetspuffService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
