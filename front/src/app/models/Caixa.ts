import { CaixaNotas } from './CaixaNotas';

export class Caixa {
	id: number;
	ativo: boolean;
	descricao: string;
  CaixaNotas: CaixaNotas[];
}
