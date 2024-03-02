import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Clientes } from 'src/infra/entities/clientes.entity';

@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'postgres',
      host: '0.0.0.0',
      port: 5432,
      username: 'admin',
      password: '123',
      database: 'rinha',
      entities: [Clientes],
      synchronize: true,
    }),
    TypeOrmModule.forFeature([Clientes]),
  ],
  exports: [TypeOrmModule],
})
export class DatabaseModule {}
