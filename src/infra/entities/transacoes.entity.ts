import { BaseEntity, Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

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

  @Column({ default: '' })
  tipo: string;

  @Column()
  descricao: string;

  @Column({ name: 'realizada_em', type: 'timestamp', default: new Date() })
  realizadaEm: Date;

  @Column({ name: 'cliente_id', foreignKeyConstraintName: 'cliente_id' })
  clienteId: number;
}
