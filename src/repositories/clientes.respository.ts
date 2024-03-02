import { Clientes } from 'src/infra/entities/clientes.entity';
import { Repository } from 'typeorm';

export class ClientesRepository extends Repository<Clientes> {
  async findById(id: number) {
    return await this.findOne({ where: { clienteId: id } });
  }
}
