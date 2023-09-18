import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WydarzenieResponse } from './wydarzenie/models/wydarzenie-response';

@Injectable({
  providedIn: 'root'
})
export class SekretarzService {
  private readonly url: string = 'http://localhost:5205';

  constructor(private httpClient: HttpClient) { }

  getEvents(): Observable<WydarzenieResponse[]> {
    return this.httpClient.get<WydarzenieResponse[]>(this.url + '/getEvents');
  }

  





}


