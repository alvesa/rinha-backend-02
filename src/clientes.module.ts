import { Module } from '@nestjs/common';
import { ClientesService } from './domain/services/clientes.service';
import { DatabaseModule } from './infra/database.module';
import { ClientesRepository } from './infra/repositories/clientes.respository';
import { TransacoesRepository } from './infra/repositories/transacoes.respository';

@Module({
  imports: [DatabaseModule],
  providers: [ClientesService, ClientesRepository, TransacoesRepository],
  exports: [ClientesService],
})
export class ClientesModule {}
