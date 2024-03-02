import { InjectRepository } from '@nestjs/typeorm';
import { Transacoes } from 'src/infra/entities/transacoes.entity';
import { Repository } from 'typeorm';

export class TransacoesRepository extends Repository<Transacoes> {
  constructor(
    @InjectRepository(Transacoes) repository: Repository<Transacoes>,
  ) {
    super(Transacoes, repository.manager);
  }
  async findById(id: number) {
    return await this.findOne({ where: { clienteId: id } });
  }

  async findAllTransactions(id: number) {
    return await this.find({ where: { clienteId: id } });
  }
}
