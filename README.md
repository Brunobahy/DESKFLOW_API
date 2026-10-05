# DeskFlow

API REST para gerenciamento de chamados de suporte técnico, desenvolvida em **C# com ASP.NET Core**.

O projeto permite cadastrar e gerenciar categorias, abrir chamados, acompanhar seus status, registrar interações e finalizar atendimentos.

## 🚀 Tecnologias

* C#
* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger / OpenAPI
* Git

## 📋 Funcionalidades

### Categorias

* Cadastro de categorias
* Listagem de categorias
* Busca por ID
* Atualização de categorias
* Exclusão de categorias
* Validação de categorias inexistentes
* Impedimento de categorias duplicadas
* Impedimento de exclusão de categorias que possuem chamados associados

### Chamados

* Cadastro de chamados
* Listagem de chamados
* Busca por ID
* Atualização de chamados
* Exclusão de chamados
* Filtro por status
* Filtro por prioridade
* Filtro por categoria
* Validação da categoria associada
* Controle do fluxo do chamado
* Início de atendimento
* Finalização do chamado
* Registro da solução
* Registro de interações
* Histórico automático de alterações
* Impedimento de interações em chamados fechados

### Fluxo do chamado

O chamado possui um fluxo de status:

```text
Aberto
   ↓
EmAndamento
   ↓
Fechado
```

Regras implementadas:

* Um chamado aberto precisa ser iniciado antes de ser finalizado.
* Um chamado em andamento pode ser finalizado.
* Um chamado fechado não pode ser iniciado novamente.
* Um chamado fechado não pode receber novas interações.
* Um chamado fechado não pode ser finalizado novamente.
* A finalização exige o preenchimento da solução.

## 🏗️ Arquitetura

O projeto utiliza uma arquitetura separando responsabilidades entre **Controllers, Services e Repositories**.

```text
DeskFlow
│
├── Controllers
│   ├── CategoriaController
│   └── ChamadosController
│
├── Models
│   ├── Categoria
│   ├── Chamado
│   └── Interacao
│
├── Repositories
│   ├── CategoriasRepository
│   └── ChamadosRepository
│
├── Repositories/Interfaces
│   ├── ICategoriasRepository
│   └── IChamadosRepository
│
├── Services
│   ├── CategoriasService
│   └── ChamadosService
│
├── Services/Interfaces
│   ├── ICategoriasService
│   └── IChamadosService
│
├── Exceptions
│   └── Exceções personalizadas
│
├── Middleware
│   └── ExceptionMiddleware
│
├── DeskFlowDbContext
└── Program.cs
```

### Responsabilidade das camadas

**Controller**

Responsável por receber as requisições HTTP e retornar as respostas da API.

**Service**

Responsável pelas regras de negócio da aplicação.

**Repository**

Responsável pelo acesso e comunicação com o banco de dados através do Entity Framework Core.

**Model**

Representa as entidades utilizadas pela aplicação e pelo banco de dados.

## 🗄️ Banco de Dados

O projeto utiliza **SQL Server** com **Entity Framework Core**.

Principais entidades:

```text
Categoria
   │
   └── 1:N ── Chamado
                  │
                  └── 1:N ── Interacao
```

### Categoria

Representa as categorias utilizadas para classificar os chamados.

Principais campos:

* `Id`
* `Nome`

### Chamado

Representa uma solicitação de suporte.

Principais campos:

* `Id`
* `Titulo`
* `Descricao`
* `Prioridade`
* `Status`
* `SolicitanteNome`
* `DataAbertura`
* `DataFechamento`
* `Solucao`
* `CategoriaId`

### Interacao

Representa mensagens e registros relacionados a um chamado.

Principais campos:

* `Id`
* `ChamadoId`
* `Autor`
* `Mensagem`
* `DataRegistro`

As interações são excluídas automaticamente quando o chamado relacionado é removido.

## 🔌 Endpoints

### Categorias

| Método | Endpoint               | Descrição                 |
| ------ | ---------------------- | ------------------------- |
| GET    | `/api/categorias`      | Lista todas as categorias |
| GET    | `/api/categorias/{id}` | Busca uma categoria       |
| POST   | `/api/categorias`      | Cadastra uma categoria    |
| PUT    | `/api/categorias/{id}` | Atualiza uma categoria    |
| DELETE | `/api/categorias/{id}` | Exclui uma categoria      |

### Chamados

| Método | Endpoint                        | Descrição              |
| ------ | ------------------------------- | ---------------------- |
| GET    | `/api/chamados`                 | Lista chamados         |
| GET    | `/api/chamados/{id}`            | Busca um chamado       |
| POST   | `/api/chamados`                 | Cadastra um chamado    |
| PUT    | `/api/chamados/{id}`            | Atualiza um chamado    |
| DELETE | `/api/chamados/{id}`            | Exclui um chamado      |
| POST   | `/api/chamados/{id}/iniciar`    | Inicia o atendimento   |
| POST   | `/api/chamados/{id}/encerrar`   | Finaliza o chamado     |
| POST   | `/api/chamados/{id}/interacoes` | Adiciona uma interação |

## 🔎 Filtros

O endpoint de chamados permite filtrar os resultados por:

```text
/api/chamados?status=EmAndamento
```

```text
/api/chamados?prioridade=Alta
```

```text
/api/chamados?categoriaId=ID_DA_CATEGORIA
```

Os filtros também podem ser combinados:

```text
/api/chamados?status=EmAndamento&prioridade=Alta&categoriaId=ID_DA_CATEGORIA
```

## ⚙️ Configuração

### Pré-requisitos

Antes de executar o projeto, tenha instalado:

* .NET 10 SDK
* SQL Server / SQL Server Express
* Git

### Clone o projeto

```bash
git clone URL_DO_REPOSITORIO
cd DeskFlow
```

### Configuração do banco

Configure a connection string no `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLExpress;Database=db-deskflow;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Ajuste a conexão de acordo com a configuração do SQL Server da sua máquina.

### Executar as migrations

Caso as migrations já estejam configuradas:

```bash
dotnet ef database update
```

### Executar a aplicação

```bash
dotnet run
```

Após iniciar a aplicação, utilize o Swagger para visualizar e testar os endpoints.

## 📖 Swagger

A API possui documentação através do **Swagger/OpenAPI**.

Com a aplicação em execução, acesse a URL do Swagger disponibilizada pela aplicação.

O Swagger permite:

* Visualizar os endpoints
* Consultar os métodos HTTP
* Visualizar parâmetros
* Enviar requisições
* Conferir respostas da API

## 🛡️ Tratamento de erros

O projeto possui exceções personalizadas para representar situações de negócio, como:

* Recurso não encontrado
* Conflito de dados
* Dados inválidos

Essas exceções são tratadas através de middleware, evitando a necessidade de repetir o mesmo tratamento em todos os Controllers.

Exemplos:

```text
404 Not Found
```

Quando uma categoria ou chamado não é encontrado.

```text
409 Conflict
```

Quando ocorre um conflito de regra de negócio, como tentar cadastrar uma categoria duplicada ou excluir uma categoria que possui chamados.

## 🧠 Objetivo do projeto

O DeskFlow foi desenvolvido com o objetivo de praticar e demonstrar conhecimentos em:

* Desenvolvimento de APIs REST
* C#
* ASP.NET Core
* Entity Framework Core
* SQL Server
* Injeção de dependência
* Arquitetura em camadas
* Repository Pattern
* Service Layer
* Modelagem de entidades
* Relacionamentos entre entidades
* Validação de regras de negócio
* Tratamento global de exceções
* Swagger/OpenAPI
* Operações assíncronas com `async/await`

## 👨‍💻 Autor

**Bruno Bahy**

Projeto desenvolvido como parte do processo de aprendizado e desenvolvimento de aplicações backend com **C# e .NET**.
