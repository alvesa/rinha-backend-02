import { Clientes } from 'src/infra/entities/clientes.entity';
import { DataSource } from 'typeorm';

export const databaseProvider = {
  provide: 'DATA_SOURCE',
  useFactory: async () => {
    const dataSource = new DataSource({
      type: 'postgres',
      host: '0.0.0.0',
      port: 5432,
      username: 'admin',
      password: '123',
      database: 'rinha',
      entities: [Clientes],
      synchronize: true,
    });

    return dataSource.initialize();
  },
};
