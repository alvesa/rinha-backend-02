import { Provider } from '@nestjs/common';
import { Clientes } from 'src/infra/entities/clientes.entity';
import { DataSource, Repository } from 'typeorm';

export class ClientesRepository extends Repository<Clientes> {
  async findById(id: number) {
    return await this.findOne({ where: { clienteId: id } });
  }
}

export const ClienteRepositoryProvider: Provider = {
  provide: 'CLIENTE_REPOSITORY',
  useFactory: (dataSource: DataSource) => dataSource.getRepository(Clientes),
  inject: ['DATA_SOURCE'],
};
