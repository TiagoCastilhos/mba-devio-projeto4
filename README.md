[Coldmart] - Plataforma de cursos online
1. Apresentação
Bem-vindo ao repositório do projeto [Coldmart]. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo `Construção de Aplicações Corporativas`. O objetivo principal é evoluir o projeto da entrega do módulo anterior, transformando a solução em microserviços e utilizando mensageria para eventos de integração.

Autor(es)

✅ Cristian Kruger Silva - @mr.krug3r
✅ Gilberto Moshim Yabiku Junior - @junmoriyama3d
✅ Tiago Henrique de Castilhos - @zsfnightmare
✅ Victor Higaki - @victorhigaki

2. Proposta do Projeto

O projeto consiste em:

APIs RESTful: Exposição dos casos de uso do sistema de gestão de cursos

Autenticação e Autorização: Implementação de controle de acesso, diferenciando administradores e alunos.

Acesso a Dados: Implementação de acesso ao banco de dados através de ORM.

3. Tecnologias Utilizadas

Linguagem de Programação: C#

Frameworks:

ASP.NET Core Web API

Entity Framework Core

Banco de Dados: SQLite e SQL Server

Autenticação e Autorização:

ASP.NET Core Identity

JWT (JSON Web Token) para autenticação na API

Documentação da API: Swagger

Containerização e virtualização: Docker

4. Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

src/

Coldmart.{ Nome do contexto }.Business/ - Definição e implementação da orquestração dos casos de uso.

Coldmart.{ Nome do contexto }.Data/ - Definição da camada de acesso a dados (configuração do EF).

Coldmart.{ Nome do contexto }.Domain/ - Definição das entidades, enums e constantes do módulo.

Coldmart.{ Nome do contexto }.API/ - API RESTful do contexto.

Coldmart.{ Nome do contexto }.{ Nome da camada }.Tests/ - Projeto de testes do respectivo projeto.

README.md - Arquivo de Documentação do Projeto

FEEDBACK.md - Arquivo para Consolidação dos Feedbacks

Dockerfile - Instruções para o build das imagens da respectiva API

docker-compose.yml - Arquivo de instrução para o ambiente virtualizado com as devidas dependências.

.gitignore - Arquivo de para ignorar arquivos e pastas do Git

5. Funcionalidades Implementadas

Casos de uso especificados no documento do projeto, que pode ser acessado [aqui](./docs/Projeto-Quarto-Modulo-Mba-DevXpert.pdf).

Autenticação e Autorização: Diferenciação entre alunos e administradores.

API RESTful: Exposição de use cases via API.
Documentação da API: Documentação automática dos endpoints da API utilizando Swagger.

6. Como Executar o Projeto

Pré-requisitos

.NET SDK 9.0 ou superior

SQL Server (Opcional)

Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)

Git

Docker

Passos para Execução

Clone o Repositório:

git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio

Uma vez na pasta raíz do projeto, rode o comando: `docker compose up`

Os serviços e as dependências serão buildados (ou baixados dos respectivos registries).

7. Instruções de Configuração
JWT para API: As chaves de configuração do JWT estão no appsettings.json.
Migrações do Banco de Dados: As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

8. Documentação da API
A documentação de cada API está disponível através do Swagger. Após executar o docker compose, abra um navegador e então acesse em:

https://localhost:{ Porta do serviço, especificado no docker-compose.yml }/swagger

9. Avaliação

Este projeto é parte de um curso acadêmico e não aceita contribuições externas.

Para feedbacks ou dúvidas utilize o recurso de Issues

O arquivo FEEDBACK.md é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.