import { Module } from '@nestjs/common';
import { DatabaseModule } from './configs/database.module';
import { ClienteRepositoryProvider } from './repositories/clientes.respository';
import { ClientesService } from './services/clientes.service';

@Module({
  imports: [DatabaseModule],
  providers: [ClienteRepositoryProvider, ClientesService],
  exports: [ClienteRepositoryProvider, ClientesService],
})
export class ClientesModule {}
