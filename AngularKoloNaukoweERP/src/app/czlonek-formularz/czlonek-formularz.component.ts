import { Component, Input, OnInit } from '@angular/core';
import { CzlonekResponse } from '../czlonek/models/czlonek-response';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SekretarzService } from '../sekretarz.service';
import { Router } from '@angular/router';
import { CzlonekRequest } from '../czlonek/models/czlonek-request';

@Component({
  selector: 'app-czlonek-formularz',
  templateUrl: './czlonek-formularz.component.html',
  styles: [
  ]
})
export class CzlonekFormularzComponent implements OnInit{

  @Input() projekt?: CzlonekResponse = undefined;

  formCzlonek!: FormGroup;


              //upewnić się czy na pewno ten serwis!!!!!!!!!!!!!!!
  constructor(private formBuilder: FormBuilder, private sekretarzService: SekretarzService, private router: Router) {

  }

  ngOnInit(): void {
    this.formCzlonek = this.formBuilder.group({
      idPelnionejFunkcji: this.formBuilder.control(null),
      idCzlonekZespol: this.formBuilder.control(null),
      kierunekStudiow: this.formBuilder.control(null),
      nrTelefonu: this.formBuilder.control(null),
      mail: this.formBuilder.control(null),
      nazwisko: this.formBuilder.control(null),
      imie: this.formBuilder.control(null),
      uczelnia: this.formBuilder.control(null),
      wydzial: this.formBuilder.control(null),
    });

  }

  isValid(name: string): boolean {
    const pole = this.formCzlonek.controls[name];
    return pole.valid || !pole.touched;
  }

  onSubmit() {
    const req: CzlonekRequest = new CzlonekRequest(this.formCzlonek.value.idPelnionejFunkcji, this.formCzlonek.value.idCzlonekZespol, 
      this.formCzlonek.value.kierunekStudiow, this.formCzlonek.value.nrTelefonu, this.formCzlonek.value.mail, this.formCzlonek.value.nazwisko, this.formCzlonek.value.imie, 
      this.formCzlonek.value.uczelnia, this.formCzlonek.value.wydzial);

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
{

}
