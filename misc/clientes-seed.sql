-- Coloque scripts iniciais aqui
CREATE TABLE clientes (usuario_id SERIAL PRIMARY KEY, nome VARCHAR NOT NULL, saldo BIGINT DEFAULT 0 NOT NULL, limite BIGINT NOT NULL)

CREATE TABLE transacoes (transacao_id SERIAL PRIMARY KEY, valor BIGINT, tipo SMALLINT, descricao VARCHAR, realizada_em DATE DEFAULT now(), usuarioId INT REFERENCES clientes(usuario_id))

DO $$
BEGIN
  INSERT INTO clientes (nome, limite)
  VALUES
    ('o barato sai caro', 1000 * 100),
    ('zan corp ltda', 800 * 100),
    ('les cruders', 10000 * 100),
    ('padaria joia de cocaia', 100000 * 100),
    ('kid mais', 5000 * 100);
END; $$