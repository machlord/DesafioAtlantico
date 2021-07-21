import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Caixa } from '../models/Caixa';

@Injectable({
  providedIn: 'root'
})
export class CaixasService {
  baseUrl = `${environment.urlBase}api/aluno`;

  constructor(private http: HttpClient) { }

  getAll():Observable<Caixa[]> {
    return this.http.get<Caixa[]>(`${this.baseUrl}`);
  }
}
