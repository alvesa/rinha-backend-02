import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Clientes } from 'src/infra/entities/clientes.entity';
import { Transacoes } from 'src/infra/entities/transacoes.entity';

@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'postgres',
      host: 'db',
      port: 5432,
      username: 'admin',
      password: '123',
      database: 'rinha',
      entities: [Clientes, Transacoes],
      synchronize: true,
      poolSize: 5,
      // extra: {
      //   connectionLimit: 5,
      // },
    }),
    TypeOrmModule.forFeature([Clientes]),
    TypeOrmModule.forFeature([Transacoes]),
  ],
  exports: [TypeOrmModule],
})
export class DatabaseModule {}
