import { Caixa } from './../models/Caixa';
import { CaixasService } from './caixas.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-caixas',
  templateUrl: './caixas.component.html',
  styleUrls: ['./caixas.component.css']
})
export class CaixasComponent implements OnInit {
  public caixas: Caixa[];

  constructor(private caixaService: CaixasService) { }

  ngOnInit(): void {
    this.carregarCaixas();
  }

  carregarCaixas() {
    this.caixaService.getAll().subscribe(
      (caixas: Caixa[]) => { this.caixas = caixas },
      (erro: any) => { console.log(erro) }
    );
  }
}
