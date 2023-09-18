import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ZespolComponent } from './zespol/zespol.component';
import { ProjektComponent } from './projekt/projekt.component';
import { WydarzenieComponent } from './wydarzenie/wydarzenie.component';
import { SprzetComponent } from './sprzet/sprzet.component';
import { ProjektTabelaComponent } from './projekt-tabela/projekt-tabela.component';
import { ProjektFormularzComponent } from './projekt-formularz/projekt-formularz.component';
import { SprzetTabelaComponent } from './sprzet-tabela/sprzet-tabela.component';
import { SprzetFormularzComponent } from './sprzet-formularz/sprzet-formularz.component';
import { WydarzenieTabelaComponent } from './wydarzenie-tabela/wydarzenie-tabela.component';
import { WydarzenieFormularzComponent } from './wydarzenie-formularz/wydarzenie-formularz.component';
import { ZespolTabelaComponent } from './zespol-tabela/zespol-tabela.component';
import { ZespolFormularzComponent } from './zespol-formularz/zespol-formularz.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CzlonekComponent } from './czlonek/czlonek.component';
import { CzlonekTabelaComponent } from './czlonek-tabela/czlonek-tabela.component';
import { CzlonekFormularzComponent } from './czlonek-formularz/czlonek-formularz.component';

@NgModule({
  declarations: [
    AppComponent,
    ZespolComponent,
    ProjektComponent,
    WydarzenieComponent,
    SprzetComponent,
    ProjektTabelaComponent,
    ProjektFormularzComponent,
    SprzetTabelaComponent,
    SprzetFormularzComponent,
    WydarzenieTabelaComponent,
    WydarzenieFormularzComponent,
    ZespolTabelaComponent,
    ZespolFormularzComponent,
    CzlonekComponent,
    CzlonekTabelaComponent,
    CzlonekFormularzComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,     
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
