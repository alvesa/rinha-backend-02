import {
  BaseEntity,
  Column,
  Entity,
  ManyToOne,
  PrimaryGeneratedColumn,
} from 'typeorm';
import { Clientes } from './clientes.entity';

export enum Tipo {
  c = 'c',
  d = 'd',
}

@Entity('transacoes')
export class Transacoes extends BaseEntity {
  @PrimaryGeneratedColumn({ name: 'transacao_id' })
  transacaoId: number;

  @Column()
  valor: number;

  @Column()
  tipo: number;

  @Column()
  descricao: string;

  @Column('realizada_em')
  realizadaEm: Date;

  @Column('cliente_id')
  // @TableForeignKey()
  clienteId: number;

  @ManyToOne('cliente_id')
  cliente: Clientes[];
}
