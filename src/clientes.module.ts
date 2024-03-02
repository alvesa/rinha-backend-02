import { Module } from '@nestjs/common';
import { ClientesService } from './services/clientes.service';
import { DatabaseModule } from './configs/database.module';
import { ClientesRepository } from './repositories/clientes.respository';
import { TransacoesRepository } from './repositories/transacoes.respository';

@Module({
  imports: [DatabaseModule],
  providers: [ClientesService, ClientesRepository, TransacoesRepository],
  exports: [ClientesService],
})
export class ClientesModule {}
