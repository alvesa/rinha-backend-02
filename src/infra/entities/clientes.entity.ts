import { Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity({ name: 'clientes' })
export class Clientes {
  @PrimaryGeneratedColumn({ name: 'cliente_id' })
  clienteId: number;

  @Column()
  nome: string;

  @Column({ type: 'bigint', default: 0 })
  saldo: string;

  @Column({ type: 'bigint', default: 0 })
  limite: string;
}
