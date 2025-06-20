# Sistema de Gerenciamento de Turismo

## 1. Visão Geral do Projeto
Este projeto consiste numa aplicação web completa para a gestão de uma agência de turismo, desenvolvida como avaliação final para a disciplina de Fundamentos de Desenvolvimento Web com Banco de Dados. O sistema permite o controlo de clientes, pacotes turísticos, destinos e reservas, com uma interface administrativa protegida por autenticação.

A aplicação foi construída utilizando a arquitetura Code-First com Entity Framework Core, onde as classes C# (Modelos) definem a estrutura do banco de dados.

## 2. Tecnologias Utilizadas
- **Backend:** C# com ASP.NET Core 8  
- **Frontend:** Razor Pages com HTML5 e CSS3  
- **Base de Dados:** Entity Framework Core 8 com SQLite  
- **Framework CSS:** Bootstrap 5  
- **Controlo de Versão:** Git e GitHub  

## 3. Funcionalidades Implementadas
A aplicação conta com um conjunto robusto de funcionalidades, cobrindo todos os requisitos solicitados:

### Gestão e CRUDs
- **Gestão de Clientes:** CRUD completo (Criar, Ler, Atualizar, Apagar) com páginas geradas via Scaffolding e personalizadas.
- **Gestão de Pacotes Turísticos:** CRUD completo construído manualmente para demonstrar o domínio do Razor Pages.
- **Gestão de Reservas:** Sistema para criar e visualizar reservas, associando Clientes a Pacotes Turísticos.
- **Catálogo de Destinos:** Base de dados com Cidades e Países, populada inicialmente via Data Seeding.

### Regras de Negócio e Segurança
- **Sistema de Reservas Inteligente:**
  - Impede reservas em pacotes sem vagas disponíveis.
  - Bloqueia reservas em pacotes cuja data de início já passou.
  - Valida se um cliente já não possui uma reserva para o mesmo pacote.
- **Exclusão Lógica (Soft Delete):** Clientes "excluídos" são marcados como inativos (`DeletedAt`) em vez de serem removidos permanentemente, preservando a integridade dos dados históricos.
- **Autenticação e Autorização:**
  - Sistema de autenticação baseado em cookies.
  - Toda a aplicação é protegida por padrão, exigindo login.
  - Login e senha definidos no código (admin/1234) para simplificação.
  - Páginas públicas (Login, Erro) são explicitamente marcadas com `[AllowAnonymous]`.

### Experiência do Utilizador (UX) e Outros
- **Dashboard Inicial:** A página principal exibe um painel com estatísticas chave da aplicação (total de clientes, pacotes, reservas, etc.).
- **Notificações de Feedback:** Mensagens de sucesso são exibidas após operações de CRUD bem-sucedidas.
- **Manipulação de Arquivos:** Funcionalidade para criar, salvar, listar e visualizar anotações em arquivos de texto (.txt) na pasta wwwroot.
- **Estrutura Organizada:** Utilização de ViewModels, Partial Views para reutilização de código e classes de Configuration para manter o DbContext limpo.
- **Roteamento Personalizado:** Uso da diretiva `@page "{id:int}"` para criar URLs limpas e semânticas (ex: /Clientes/Details/1).

## 4. Como Executar a Aplicação
Siga os passos abaixo para clonar, construir e executar o projeto localmente.

### Pré-requisitos
- .NET 8 SDK ou superior.
- Git.

### Passos para Execução
#### Clonar o Repositório
Abra um terminal e clone o repositório para a sua máquina:

```
git clone <URL_DO_SEU_REPOSITORIO_AQUI>
```
Navegue para a pasta do projeto:

```
cd <NOME_DA_PASTA_DO_PROJETO>
```
### Restaurar as Dependências
Execute o comando build, que irá restaurar todos os pacotes NuGet necessários:

```
dotnet build
```
### Criar e Popular o Banco de Dados
Este projeto usa Migrations para gerar o banco de dados. O ficheiro .db é intencionalmente ignorado pelo .gitignore. Para criar o banco, execute:

```
dotnet ef database update
```
Este comando irá criar o ficheiro AgenciaTurismo.db e aplicar todas as migrations para gerar as tabelas e inserir os dados iniciais.

### Executar a Aplicação
Com o banco de dados pronto, inicie o servidor web:

```
dotnet run
```
A aplicação estará disponível no endereço indicado no terminal (geralmente https://localhost:7149/).

## 5. Credenciais de Acesso
Para aceder às áreas protegidas do sistema, utilize as seguintes credenciais:

- Utilizador: admin
- Senha: 1234

## 6. Autor
Matheus Felipe Alves Santos
