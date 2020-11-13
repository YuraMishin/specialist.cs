import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ServerComponent} from "./components/server/server.component";
import { ButtonDisabledComponent } from './components/button-disabled/button-disabled.component';
import { SimpleusernameComponent } from './components/simpleusername/simpleusername.component';
import { SimpleforComponent } from './components/simplefor/simplefor.component';

@NgModule({
  declarations: [
    AppComponent,
    ServerComponent,
    ButtonDisabledComponent,
    SimpleusernameComponent,
    SimpleforComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
