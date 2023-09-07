import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ZespolComponent } from './zespol/zespol.component';
import { ProjektComponent } from './projekt/projekt.component';
import { WydarzenieComponent } from './wydarzenie/wydarzenie.component';
import { SprzetComponent } from './sprzet/sprzet.component';

@NgModule({
  declarations: [
    AppComponent,
    ZespolComponent,
    ProjektComponent,
    WydarzenieComponent,
    SprzetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
