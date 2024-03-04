import {
  Body,
  Controller,
  Get,
  NotFoundException,
  Param,
  Post,
  Response,
  UnprocessableEntityException,
} from '@nestjs/common';
import { ClientesService } from '../domain/services/clientes.service';

export class TransacaoRequest {
  valor: number;
  tipo: string;
  descricao: string;
}

export class TransacaoResponse {
  limite: number;
  saldo: number;
}

@Controller('clientes')
export class ClientesController {
  constructor(private readonly clientesService: ClientesService) {}

  @Get(':id/extrato')
  async extrato(@Param('id') id: number): Promise<any> {
    if (!id) throw new NotFoundException();

    return await this.clientesService.extrato(id);
  }

  @Post(':id/transacoes')
  async transacao(
    @Param('id') id: number,
    @Body() payload: TransacaoRequest,
    @Response() response,
  ): Promise<TransacaoResponse> {
    if (!id) throw new NotFoundException();

    if (!payload) throw new NotFoundException();

    if (
      !payload.descricao ||
      payload.descricao.length < 1 ||
      payload.descricao.length > 10
    )
      throw new UnprocessableEntityException();

    if (!['c', 'd'].includes(payload.tipo))
      throw new UnprocessableEntityException();

    if (!(payload.valor % 1 === 0)) throw new UnprocessableEntityException();

    return response
      .status(200)
      .send(await this.clientesService.transacao(id, payload));
  }
}
