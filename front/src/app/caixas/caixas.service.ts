import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Caixa } from '../models/Caixa';

@Injectable({
  providedIn: 'root'
})
export class CaixasService {
  baseUrl = `${environment.urlBase}v1/caixa`;

  constructor(private http: HttpClient) { }

  getAll() : Observable<Caixa[]> {
    return this.http.get<Caixa[]>(`${this.baseUrl}`);
  }

  disableCaixa(caixa_id : number): Observable<Caixa> {
    return this.http.get<Caixa>(`${this.baseUrl}/ativar/${caixa_id}`);
  }

  enableCaixa(caixa_id : number): Observable<Caixa> {
    return this.http.get<Caixa>(`${this.baseUrl}/desativar/${caixa_id}`);
  }
}
