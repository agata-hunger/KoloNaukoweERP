import { Component, inject } from '@angular/core';
import { WydarzenieResponse } from '../wydarzenie/models/wydarzenie-response';
import { SekretarzService } from '../sekretarz.service';

@Component({
  selector: 'app-wydarzenie-tabela',
  templateUrl: './wydarzenie-tabela.component.html',
  styles: [
  ]
})
export class WydarzenieTabelaComponent {

  wydarzenia?: WydarzenieResponse[];

  private service = inject(SekretarzService);

  constructor() {
    this.service.getEvents().subscribe({
      next: (res) => {
        this.wydarzenia = res;
      }
    })
  }

}
