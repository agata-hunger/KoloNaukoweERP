import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SekretarzService } from '../sekretarz.service';
import { ProjektRequest } from '../projekt/models/projekt-request';
import { ProjektResponse } from '../projekt/models/projekt-response';

@Component({
  selector: 'app-projekt-formularz',
  templateUrl: './projekt-formularz.component.html',
  styles: [
  ]
})
export class ProjektFormularzComponent implements OnInit{

  @Input() projekt?: ProjektResponse = undefined;

  formProjekt!: FormGroup;


              //upewnić się czy na pewno ten serwis!!!!!!!!!!!!!!!
  constructor(private formBuilder: FormBuilder, private sekretarzService: SekretarzService, private router: Router) {

  }

  ngOnInit(): void {
    this.formProjekt = this.formBuilder.group({
      idZespolu: this.formBuilder.control(null),
      nazwa: this.formBuilder.control(null),
      terminRealizacji: this.formBuilder.control(null),
      opis: this.formBuilder.control(null),
    });


  }

  isValid(name: string): boolean {
    const pole = this.formProjekt.controls[name];
    return pole.valid || !pole.touched;
  }

  onSubmit() {
    const req: ProjektRequest = new ProjektRequest(this.formProjekt.value.idZespolu, this.formProjekt.value.nazwa, 
      this.formProjekt.value.terminRealizacji, this.formProjekt.value.opis);

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


