import { Module } from '@nestjs/common';
import { ClientesController } from './controllers/clientes.controller';
import { ClientesModule } from './clientes.module';

@Module({
  imports: [ClientesModule],
  controllers: [ClientesController],
  providers: [],
})
export class AppModule {}
