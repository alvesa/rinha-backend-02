import { Module } from '@nestjs/common';
import { ClientesService } from './services/clientes.service';
import { DatabaseModule } from './configs/database.module';

@Module({
  imports: [DatabaseModule],
  providers: [ClientesService],
  exports: [ClientesService],
})
export class ClientesModule {}
