import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjektTabelaComponent } from './projekt-tabela/projekt-tabela.component';
import { ProjektFormularzComponent } from './projekt-formularz/projekt-formularz.component';
import { SprzetTabelaComponent } from './sprzet-tabela/sprzet-tabela.component';
import { SprzetFormularzComponent } from './sprzet-formularz/sprzet-formularz.component';
import { WydarzenieTabelaComponent } from './wydarzenie-tabela/wydarzenie-tabela.component';
import { WydarzenieFormularzComponent } from './wydarzenie-formularz/wydarzenie-formularz.component';
import { ZespolTabelaComponent } from './zespol-tabela/zespol-tabela.component';
import { ZespolFormularzComponent } from './zespol-formularz/zespol-formularz.component';

const routes: Routes = [
  {
  path: 'projekty', children:
  [
    { path: '', component: ProjektTabelaComponent },
    { path: 'dodajProjekt', component: ProjektFormularzComponent}
  ]
  },
  {
    path: 'sprzet', children:
    [
      { path: '', component: SprzetTabelaComponent },
      { path: 'dodajSprzet', component: SprzetFormularzComponent}
    ]
  },
  {
    path: 'wydarzenia', children:
    [
      { path: '', component: WydarzenieTabelaComponent },
      { path: 'dodajWydarzenie', component: WydarzenieFormularzComponent}
    ]
  },
  {
    path: 'zespoly', children:
    [
      { path: '', component: ZespolTabelaComponent },
      { path: 'dodajZespol', component: ZespolFormularzComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
