import { Controller, Get, Param, Post } from '@nestjs/common';
import { ClientesService } from 'src/services/clientes.service';

@Controller('clientes')
export class ClientesController {
  constructor(private readonly clientesService: ClientesService) {}

  @Get(':id/extrato')
  async extrato(@Param('id') id: number): Promise<any> {
    return await this.clientesService.extrato(id);
  }

  @Post('transacoes')
  transacao(): string {
    return this.clientesService.transacao();
  }
}
