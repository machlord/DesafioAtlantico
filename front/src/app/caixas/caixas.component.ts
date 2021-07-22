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
  public caixas: Caixa[];
  public faMoneyBillWave = faMoneyBillWave;
  public faExclamationCircle = faExclamationCircle;

  constructor(private caixaService: CaixasService) {

   }

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
