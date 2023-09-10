import { Component, Input, OnInit } from '@angular/core';
import { WydarzenieResponse } from '../wydarzenie/models/wydarzenie-response';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SekretarzService } from '../sekretarz.service';
import { Router } from '@angular/router';
import { WydarzenieRequest } from '../wydarzenie/models/wydarzenie-request';

@Component({
  selector: 'app-wydarzenie-formularz',
  templateUrl: 'wydarzenie-formularz.component.html',
  styles: [
  ]
})
export class WydarzenieFormularzComponent implements OnInit{

  @Input() projekt?: WydarzenieResponse = undefined;

  formWydarzenie!: FormGroup;


              //upewnić się czy na pewno ten serwis!!!!!!!!!!!!!!!
  constructor(private formBuilder: FormBuilder, private sekretarzService: SekretarzService, private router: Router) {

  }

  ngOnInit(): void {
    this.formWydarzenie = this.formBuilder.group({
      idZespolu: this.formBuilder.control(null),
      nazwa: this.formBuilder.control(null),
      data: this.formBuilder.control(null),
      opis: this.formBuilder.control(null),
    });


  }

  isValid(name: string): boolean {
    const pole = this.formWydarzenie.controls[name];
    return pole.valid || !pole.touched;
  }

  onSubmit() {
    const req: WydarzenieRequest = new WydarzenieRequest(this.formWydarzenie.value.idZespolu, this.formWydarzenie.value.nazwa, 
      this.formWydarzenie.value.data, this.formWydarzenie.value.opis);

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


