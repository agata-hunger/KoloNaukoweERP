import { Component, Input, OnInit } from '@angular/core';
import { ZespolResponse } from '../zespol/models/zespol-response';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SekretarzService } from '../sekretarz.service';
import { Router } from '@angular/router';
import { ZespolComponent } from '../zespol/zespol.component';
import { ZespolRequest } from '../zespol/models/zespol-request';

@Component({
  selector: 'app-zespol-formularz',
  templateUrl: 'zespol-formularz.component.html',
  styles: [
  ]
})
export class ZespolFormularzComponent implements OnInit{

  @Input() projekt?: ZespolResponse = undefined;

  formZespol!: FormGroup;


              //upewnić się czy na pewno ten serwis!!!!!!!!!!!!!!!
  constructor(private formBuilder: FormBuilder, private sekretarzService: SekretarzService, private router: Router) {

  }

  ngOnInit(): void {
    this.formZespol = this.formBuilder.group({
      idProjektu: this.formBuilder.control(null),
      idWydarzenia: this.formBuilder.control(null),
      idSprzetu: this.formBuilder.control(null),
      idCzlonka: this.formBuilder.control(null),
      nazwa: this.formBuilder.control(null),
    });
  }

  isValid(name: string): boolean {
    const pole = this.formZespol.controls[name];
    return pole.valid || !pole.touched;
  }

  onSubmit() {
    const req: ZespolRequest = new ZespolRequest(this.formZespol.value.idProjektu, this.formZespol.value.idWydarzenia, 
      this.formZespol.value.idSprzetu, this.formZespol.value.idCzlonka,  this.formZespol.value.nazwa);

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



