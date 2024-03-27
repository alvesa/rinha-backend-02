import { Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity({ name: 'clientes' })
export class Clientes {
  @PrimaryGeneratedColumn({ name: 'cliente_id' })
  clienteId: number;

  @Column()
  nome: string;

  @Column({ type: 'integer' })
  saldo: number;

  @Column({ type: 'integer' })
  limite: number;
}
