import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Clientes } from 'src/infra/entities/clientes.entity';
import { Transacoes } from 'src/infra/entities/transacoes.entity';

@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'postgres',
      host: process.env.DB_HOSTNAME,
      port: 5432,
      username: process.env.POSTGRES_USER,
      password: process.env.POSTGRES_PASSWORD,
      database: process.env.POSTGRES_SCHEMA,
      entities: [Clientes, Transacoes],
      synchronize: false,
      poolSize: 5,
    }),
    TypeOrmModule.forFeature([Clientes]),
    TypeOrmModule.forFeature([Transacoes]),
  ],
  exports: [TypeOrmModule],
})
export class DatabaseModule {}
