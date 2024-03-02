import { InjectRepository } from '@nestjs/typeorm';
import { Clientes } from 'src/infra/entities/clientes.entity';
import { Repository } from 'typeorm';

export class ClientesRepository extends Repository<Clientes> {
  constructor(@InjectRepository(Clientes) repository: Repository<Clientes>) {
    super(Clientes, repository.manager);
  }
  async findById(id: number) {
    return await this.findOne({ where: { clienteId: id } });
  }
}
