import { Controller, Get, Param, Post } from '@nestjs/common';
import { ClientesService } from 'src/services/clientes.service';

@Controller('clientes')
export class ClientesController {
  constructor(private readonly clientesService: ClientesService) {}

  @Get(':id/extrato')
  extrato(@Param('id') id: number): string {
    return this.clientesService.extrato(id);
  }

  @Post('transacoes')
  transacao(): string {
    return this.clientesService.transacao();
  }
}
