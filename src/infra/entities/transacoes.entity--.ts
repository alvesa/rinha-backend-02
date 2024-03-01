import { BaseEntity, Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

export enum Tipo {
  c = 'c',
  d = 'd',
}

@Entity('transacoes')
export class Transacoes extends BaseEntity {
  @Column('transacao_id')
  @PrimaryGeneratedColumn()
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

  // @ManyToOne()
  // cliente: Clientes;
}
