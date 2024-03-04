export class SaldoResposta {
  total: number;
  data_extrato: Date;
  limite: number;
}

export class ExtratoTransacaoResposta {
  valor: number;
  tipo: string;
  descricao: string;
  realizada_em: string;
}

export class ExtratoResposta {
  saldo: SaldoResposta;
  ultimas_transacoes: ExtratoTransacaoResposta[];
}
