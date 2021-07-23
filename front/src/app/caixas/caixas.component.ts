import { Caixa } from './../models/Caixa';
import { CaixasService } from './caixas.service';
import { Component, OnInit } from '@angular/core';
import { faMoneyBillWave, fas, faExclamationCircle } from '@fortawesome/free-solid-svg-icons';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { Console } from 'console';

@Component({
  selector: 'app-caixas',
  templateUrl: './caixas.component.html',
  styleUrls: ['./caixas.component.css']
})
export class CaixasComponent implements OnInit {
  //** Variáveis Públicas **//
  public caixas: Caixa[];
  public connection: any;
  public baseUrl = `${environment.urlBase}`;
  public caixa_vazia: Caixa;

  //** Icones **//
  public faMoneyBillWave = faMoneyBillWave;
  public faExclamationCircle = faExclamationCircle;
  messages: any;
  userName: any;
  hideJoin: boolean;

  //** Construtor **//
  constructor(private caixaService: CaixasService) {}

  //** Funções **//

  //Init
  ngOnInit(): void {
    this.carregarCaixas();
    this.initWebSocket();

  }

  initWebSocket() : void {
    this.connection = new HubConnectionBuilder()
      .withUrl(`${environment.urlBase}\caixahub`)
      .build();


    this.connection.on('caixaAtivoDesativadoHub', (caixa: Caixa, status: boolean) => {
      let item = this.caixas.find(x => x.id == caixa.id) || this.caixa_vazia;
      let index = this.caixas.indexOf(item);
      this.caixas[index] = caixa;
    });

    this.connection.on('atualizarCaixa', (caixa: Caixa) => {
      let item = this.caixas.find(x => x.id == caixa.id) || this.caixa_vazia;
      let index = this.caixas.indexOf(item);
      this.caixas[index] = caixa;
    });

    this.iniciarConnecao();
  }

  iniciarConnecao(): void {
      this.connection.start();
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
