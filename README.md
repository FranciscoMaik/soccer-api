# SoccerApi

Uma API RESTful para gerenciamento de times de futebol, desenvolvida em ASP.NET Core com Entity Framework e SQLite.

## 📋 Sobre o Projeto

A SoccerApi é uma aplicação web que permite o gerenciamento completo de times de futebol, incluindo informações sobre nome, cidade e títulos conquistados (nacionais e internacionais).

## 🚀 Tecnologias Utilizadas

- **.NET 9.0** - Framework principal
- **ASP.NET Core** - Web API
- **Entity Framework Core 7.0** - ORM para acesso a dados
- **SQLite** - Banco de dados
- **C#** - Linguagem de programação

## 📦 Estrutura do Projeto

```
SoccerApi/
├── SoccerApi.csproj          # Arquivo de projeto
├── SoccerApi.sln             # Arquivo de solução
├── Program.cs                # Ponto de entrada da aplicação
├── AppDBContext.cs           # Contexto do Entity Framework
├── Time.cs                   # Modelo de dados do Time
├── appsettings.json          # Configurações da aplicação
├── Properties/
│   └── launchSettings.json   # Configurações de inicialização
└── Migrations/               # Migrações do banco de dados
```

## 🎯 Funcionalidades

### Endpoints Disponíveis

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET    | `/times` | Lista todos os times |
| GET    | `/times/{id}` | Busca um time específico por ID |
| POST   | `/times` | Cria um novo time |
| PUT    | `/times/{id}` | Atualiza um time existente |
| DELETE | `/times/{id}` | Remove um time |

### Modelo de Dados - Time

```csharp
public class Time
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public int TitlesBrazil { get; set; }
    public int TitlesInternacionais { get; set; }
}
```

## 🛠️ Como Executar

### Pré-requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- Git

### Passos para Execução

1. **Clone o repositório:**
   ```bash
   git clone <url-do-repositorio>
   cd SoccerApi
   ```

2. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```

3. **Execute as migrações do banco de dados:**
   ```bash
   dotnet ef database update
   ```

4. **Execute a aplicação:**
   ```bash
   dotnet run
   ```

5. **Acesse a API:**
   - HTTP: `http://localhost:5281`
   - HTTPS: `https://localhost:7151`

## 📋 Exemplos de Uso

### Criar um novo time
```bash
curl -X POST "http://localhost:5281/times" \
     -H "Content-Type: application/json" \
     -d '{
       "name": "Flamengo",
       "city": "Rio de Janeiro",
       "titlesBrazil": 8,
       "titlesInternacionais": 3
     }'
```

### Listar todos os times
```bash
curl -X GET "http://localhost:5281/times"
```

### Buscar um time específico
```bash
curl -X GET "http://localhost:5281/times/1"
```

### Atualizar um time
```bash
curl -X PUT "http://localhost:5281/times/1" \
     -H "Content-Type: application/json" \
     -d '{
       "name": "Flamengo",
       "city": "Rio de Janeiro",
       "titlesBrazil": 8,
       "titlesInternacionais": 4
     }'
```

### Deletar um time
```bash
curl -X DELETE "http://localhost:5281/times/1"
```

## 🗄️ Banco de Dados

A aplicação utiliza SQLite como banco de dados, criando automaticamente um arquivo `soccer.db` na raiz do projeto. O Entity Framework Core gerencia a criação e manutenção das tabelas através do sistema de migrações.

## 📝 Comandos Úteis

### Entity Framework
```bash
# Adicionar nova migração
dotnet ef migrations add <NomeDaMigracao>

# Atualizar banco de dados
dotnet ef database update

# Remover última migração
dotnet ef migrations remove
```

### Desenvolvimento
```bash
# Executar em modo de desenvolvimento
dotnet run

# Compilar o projeto
dotnet build

# Executar testes (se houver)
dotnet test
```

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

## 👥 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.