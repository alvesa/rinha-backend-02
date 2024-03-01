import { Injectable } from '@nestjs/common';

@Injectable()
export class ClientesService {
  extrato(id: number): string {
    return `Hello World! ${id}`;
  }

  transacao(): string {
    return 'Hello World!';
  }
}
