import { Inject, Injectable } from '@nestjs/common';
import { Clientes } from 'src/infra/entities/clientes.entity';
import { Repository } from 'typeorm';

@Injectable()
export class ClientesService {
  constructor(
    @Inject('CLIENTE_REPOSITORY')
    private readonly clientesRepository: Repository<Clientes>,
  ) {}
  async extrato(id: number): Promise<any> {
    return await this.clientesRepository.findOne({ where: { clienteId: id } });
  }

  transacao(): string {
    return 'Hello World!';
  }
}
