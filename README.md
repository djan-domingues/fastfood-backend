# Fast Food Self-Service Ordering System (MVP)

Este projeto implementa o backend de um sistema de autoatendimento para uma lanchonete em expansão. O sistema foi desenvolvido em **C# com .NET**, seguindo arquitetura **hexagonal**, com persistência em **PostgreSQL** e execução local via **Docker Compose**.

## 🧩 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Docker & Docker Compose
- Swagger (Swashbuckle)

## 📦 Funcionalidades

### Cliente
- Cadastro de cliente com nome, email e CPF
- Identificação por CPF ou pedido anônimo
- Montagem de pedido (Main, Side, Drink, Dessert)
- Simulação de pagamento via QR Code
- Acompanhamento do pedido via status:
  - RECEIVED → PREPARING → READY → FINISHED

### Administrador
- Gerenciamento de produtos (CRUD)
- Filtro de produtos por categoria
- Atualização do status de pedidos
- Acompanhamento da fila de pedidos

## 🗂️ Estrutura do Projeto

```
/src
  /FastFood.Domain         → Entidades e interfaces
  /FastFood.Application    → Casos de uso e serviços
  /FastFood.Infrastructure → Repositórios, DB, QR Code mock
  /FastFood.WebAPI         → Controllers, DI, Swagger
```

## 🗄️ Banco de Dados

Banco: **PostgreSQL**  
Tabelas principais:
- `customers`
- `products`
- `orders`
- `order_items`

Status do pedido é armazenado como string sobrescrita (`RECEIVED`, etc).

## 🚀 Como Executar Localmente

### Pré-requisitos
- Docker
- Docker Compose

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repo.git
   cd seu-repo
   ```

2. Inicie o ambiente:
   ```bash
   docker-compose up --build
   ```

3. Acesse a API:
   - Swagger: [http://localhost:8080/swagger](http://localhost:8080/swagger)

### Variáveis de Ambiente

O `docker-compose.yml` já define:
```env
POSTGRES_USER=postgres
POSTGRES_PASSWORD=postgres
POSTGRES_DB=fastfood
```

A aplicação usa:
```env
ConnectionStrings__Default=Host=db;Database=fastfood;Username=postgres;Password=postgres
```

## ✅ Teste Rápido

1. Cadastre um cliente via `/api/customers`
2. Busque produtos por categoria `/api/products?category=Drink`
3. Crie um pedido via `/api/orders`
4. Atualize status do pedido via `/api/orders/{id}/status`
5. Acompanhe o status com `/api/orders/{id}/status`
