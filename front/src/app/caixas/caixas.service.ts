import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CaixasService {

  constructor(private http: HttpClientModule) { }
}
