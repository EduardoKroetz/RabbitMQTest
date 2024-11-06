# RabbitMQ Teste com Aplicações Console em .NET

Este projeto demonstra a comunicação entre duas aplicações console em .NET, usando o RabbitMQ como Message Broker. O `MessageBroker.Publisher` envia mensagens, enquanto o `MessageBroker.Consumer` as recebe.

## Configuração do Ambiente

### Executando o RabbitMQ com Docker

Para iniciar uma instância do RabbitMQ usando Docker, execute o comando:

```bash
docker run -d --hostname rmq --name rmq-server -p 8080:15672 -p 5672:5672 rabbitmq:3.12-management
```

O painel de gerenciamento do RabbitMQ estará disponível em: http://localhost:8080
Credenciais de acesso:

-Usuário: guest

-Senha: guest

### Requisitos

-.NET SDK instalado

-Docker para executar o RabbitMQ

## Como Usar

Inicie o RabbitMQ conforme o comando acima.
No terminal, navegue até a pasta do projeto e execute as duas aplicações:

MessageBroker.Publisher para enviar mensagens.

MessageBroker.Consumer para receber mensagens.

As mensagens enviadas pelo Publisher serão recebidas pelo Consumer através do RabbitMQ.

## Tecnologias

RabbitMQ

.NET Console Applications
