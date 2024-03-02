import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Clientes } from 'src/infra/entities/clientes.entity';
import { ClientesRepository } from 'src/repositories/clientes.respository';

export class SaldoResposta {
  total: string;
  data_extrato: Date;
  limite: string;
}

export class ExtratoTransacaoResposta {
  valor: number;
  tipo: string;
  descricao: string;
  realizada_em: Date;
}

export class ExtratoResposta {
  saldo: SaldoResposta;
  ultimas_transacoes: ExtratoTransacaoResposta[];
}

@Injectable()
export class ClientesService {
  constructor(
    @InjectRepository(Clientes)
    private readonly clientesRepository: ClientesRepository,
  ) {}
  async extrato(id: number): Promise<any> {
    const cliente = await this.clientesRepository.findOne({
      where: { clienteId: id },
    });

    console.log(cliente);

    const result = new ExtratoResposta();

    result.saldo = new SaldoResposta();

    result.saldo = {
      data_extrato: new Date(),
      limite: cliente.limite,
      total: cliente.saldo,
    };

    return result;
  }

  transacao(): string {
    return 'Hello World!';
  }
}
