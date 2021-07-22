import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Caixa } from '../models/Caixa';

@Injectable({
  providedIn: 'root'
})
export class CaixasService {
  //Url básica
  baseUrl = `${environment.urlBase}v1/caixa`;

  constructor(private http: HttpClient) { }

  //Pega todos os caixas
  getAll() : Observable<Caixa[]> {
    return this.http.get<Caixa[]>(`${this.baseUrl}`);
  }

  //Desativa um caixa
  disableCaixa(caixa_id : number): Observable<Caixa>{
    return this.http.put<Caixa>(`${this.baseUrl}/ativar/${caixa_id}`, null);
  }

  //Ativa um caixa
  enableCaixa(caixa_id : number): Observable<Caixa> {
    return this.http.put<Caixa>(`${this.baseUrl}/desativar/${caixa_id}`, null);
  }
}
