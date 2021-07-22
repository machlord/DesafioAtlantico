import { Caixa } from './../models/Caixa';
import { CaixasService } from './caixas.service';
import { Component, OnInit } from '@angular/core';
import { faMoneyBillWave, fas, faExclamationCircle } from '@fortawesome/free-solid-svg-icons';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'app-caixas',
  templateUrl: './caixas.component.html',
  styleUrls: ['./caixas.component.css']
})
export class CaixasComponent implements OnInit {
  //** Variáveis Públicas**//
  public caixas: Caixa[];

  //** Icones**//
  public faMoneyBillWave = faMoneyBillWave;
  public faExclamationCircle = faExclamationCircle;

  //** Construtor **//
  constructor(private caixaService: CaixasService) {}

  //** Funções**//

  //Init
  ngOnInit(): void {
    this.carregarCaixas();
  }

  //Carrega todos os caixas
  carregarCaixas(): void{
    this.caixaService.getAll().subscribe(
      (caixas: Caixa[]) => { this.caixas = caixas },
      (erro: any) => { console.log(erro) }
    );
  }

  //Ativa um caixa Expecífico
  ativarCaixa(caixa : Caixa) {
    this.caixaService.disableCaixa(caixa.id).subscribe(
      (response: Caixa) => {
        let index = this.caixas.indexOf(caixa);
        this.caixas[index] = response;
      },
      (erro: any) => { console.log(erro) }
    );
  }

  //Desativa um caixa Expecífico
  desativarCaixa(caixa : Caixa) {
    this.caixaService.enableCaixa(caixa.id).subscribe(
      (response: Caixa) => {
        let index = this.caixas.indexOf(caixa);
        this.caixas[index] = response;
      },
      (erro: any) => { console.log(erro) }
    );
  }
}
