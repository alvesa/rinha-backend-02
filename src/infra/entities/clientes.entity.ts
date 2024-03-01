import { Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity({ name: 'clientes' })
export class Clientes {
  @PrimaryGeneratedColumn({ name: 'cliente_id' })
  @Column({ name: 'cliente_id' })
  clienteId: number;

  @Column()
  nome: string;

  @Column()
  saldo: number;

  @Column()
  limite: number;
}
