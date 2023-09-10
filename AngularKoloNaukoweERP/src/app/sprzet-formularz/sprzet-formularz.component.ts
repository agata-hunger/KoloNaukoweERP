import { Component, Input, OnInit } from '@angular/core';
import { SprzetResponse } from '../sprzet/models/sprzet-response';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SekretarzService } from '../sekretarz.service';
import { Router } from '@angular/router';
import { SprzetRequest } from '../sprzet/models/sprzet-request';

@Component({
  selector: 'app-sprzet-formularz',
  templateUrl: 'sprzet-formularz.component.html',
  styles: [
  ]
})
export class SprzetFormularzComponent implements OnInit{

  @Input() sprzet?: SprzetResponse = undefined;

  formSprzet!: FormGroup;


              //upewnić się czy na pewno ten serwis!!!!!!!!!!!!!!!
  constructor(private formBuilder: FormBuilder, private sekretarzService: SekretarzService, private router: Router) {

  }

  ngOnInit(): void {
    this.formSprzet = this.formBuilder.group({
      nazwa: this.formBuilder.control(null),
      opis: this.formBuilder.control(null),
      czyDostepny: this.formBuilder.control(null),
    });


  }

  isValid(name: string): boolean {
    const pole = this.formSprzet.controls[name];
    return pole.valid || !pole.touched;
  }

  onSubmit() {
    const req: SprzetRequest = new SprzetRequest(this.formSprzet.value.nazwa, this.formSprzet.value.opis, this.formSprzet.value.czyDostepny);

    // if(this.projekt != null) {
    //   this.sekretarzService.put(this.projekt.idProjektu, req).subscribe({
    //     next: (res) => {
    //       this.router.navigateByUrl('');
    //     }
    //   });
    // } else {
    //   this.sekretarzService.post(req).subscribe({
    //     next: (res) => {
    //       this.router.navigateByUrl('');
    //     }
    //   });
    // }
  }
}