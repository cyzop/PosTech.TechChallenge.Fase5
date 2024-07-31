# Gestão de Porfólios
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)

rep-test-project

# Sobre o Projeto

O Sistema de Gestão de Portfólios foi desenvolvido em .Net Core (7) para atender ao Tech Challenge correspondente à FASE 5 do curso ARQUITETURA DE SISTEMAS .NET COM AZURE da FIAP.

Este sistema tem o intuito de permitir o usuário realizar a gestão de seus portfólios de investimento, de forma simples e intuitiva. Neste sistema o usuário pode se cadastrar, definido uma senha que atenda aos critérios de senha fortes, verificar seu e-mail e acessar a aplicação.

A aplicação apresenta um menu com os ativos disponíveis pelo sistema e a listagem dos Portfólios de investimento do usuário. Em cada portfólio o usuário poderá visualizar consultar uma visão detalhada do Portfólio que mostra o total de cada ativo investido no portfólio, o histórico das transações realizadas no portófio e opção de realizar nova transação de compra ou venda. 

Para utilizar o sistema é exigido que o usuário esteja logado.

A cotação dos ativos disponíveis para negociação é apresentada no momento da realização de uma transação, seja ela venda ou compra.

Este repositório se refere tanto ao Front-end e Back-end da aplicação onde pode ser utilizado com o Swagger (disponível em modo Debug) para visualização dos endpoints disponíveis.

# Requisitos

O documento com o levanto de requisitos do software e seus critérios de aceite podem ser encontradas no arquivo "GestaodePortfolios.pdf" na raiz do projeto ou por [aqui](https://github.com/cyzop/PosTech.TechChallenge.Fase5/blob/master/GestaodePortfolios.pdf)


# 📋 Tecnologias utilizadas

- Microsoft Azure
- Microsoft .Net Core 7 WebApi (Back-end)
- Microsoft .Net Blazor WebAsssembly (Front-end)
- EF Core
- XUnit 
- SqlServer (Azure)

## Banco de Dados

Em função do propósito da aplicação representar uma associação entre diferentes entidades, foi utilizado banco de dados relacional onde foi escolhido o Sql Server.

## Framework de Testes

Para garantir a correta integração e que as diferentes partes do sistema funcionem corretamente é essencial que se utilize os testes de integração.
Em nosso projeto, além dos testes unitários, também realizamos testes de integração com xUnit, desta forma é possível verificar se diferentes componentes do sistema funcionam corretamente juntos.

A execução do testes está automatizada no GitHub Actions.

## Arquitetura do Projeto

Para melhorar organização do código, adotamos o uso de diretórios e dentro de cada um os projetos pertinentes. 
Estes diretórios e projetos estão organizados da seguinta maneira:

📁PortFolio

  - 📁API
      - PosTech.PortFolio.Api
      - PosTech.PortFolio.Ativo.Api
      - PosTech.PortFolio.Cliente.Api
   
  - 📁Controller
      - PosTech.PortFolio.Controllers
   
  - 📁Entity
      - PosTech.PortFolio.Enities
   
  - 📁Gateway
      - PosTech.PortFolio.Gateways
    
  - 📁Infrastructure
      - PosTech.PortFolio.Repository.Sql

  - 📁Interface
      - PosTech.PortFolio.Interfaces

  - 📁Presenter
      - PosTech.PortFolio.Adapter
      - PosTech.PortFolio.Dao
      - PosTech.PortFolio.Messages
      
  - 📁Shared
      - PosTech.PortFolio.Assertion
      
  - 📁UseCase
      - PosTech.PortFolio.UseCases
 
📁Tests
   - PosTech.PortFolio.Tests
   
  - 📁Fixtures
  - 📁IntegratedTests
  - 📁UnitTests

📁Shared
  - PosTech.TechClallenge.Shared
    
📁PosTech.PortFolio.Web
  - PosTech.PortFolioWeb.Client
  - PosTech.PortFolioWeb.Server
  - PosTech.PortFolioWeb.Shared

    
# 🔧 Como executar o projeto (Back End)

## Baixando o código

```bash
# clonar o repositório
git clone https://github.com/cyzop/PosTech.TechChallenge.Fase5
```

## Sql Server

Pode utilizar tanto a instalação local do banco de dados (Sql Server Express), quanto a utilização do banco Azure

Ajustar a ConnectionString nos arquivos appsettings.json das apis.

Para criação do banco de dados da aplicação, utilizar a Migration existente no projeto PosTech.PortFolio.Repository.Sql e após sua criação, executar o script de carga e ativos existente no diretório "scripts"

Para a criação do banco de autenticação, pode-se utilizar a Migration existente no projeto PosTech.PortFolioWeb.Server ou ao acessar a aplicação pela primeira vez será apresentada uma mensagem de erro onde existe a possibilidade de aplicar a migration através de uma opção na tela.


## Utilizando o Visual Studio Community 2022 para rodar o Backend localmente

- Abrir a solução do projeto (PosTech.Arquitetura.TechChallenge.sln) no VS
- Definir o projeto PosTech.Consultorio.Api como projeto para inicialização
- Iniciar o projeto com Depuração apertando o F5, para executar o projeto utilizando o Swagger


# Testes

Por possuir uma abordagem mais moderna e facilitando nosso trabalho com a descoberta de testes sem a necessidade de classes especiais, adotamos o framework xUnit que é uma das mais populares para realização de testes em .NET

## Testes Unitários

Utilizamos o xUnit para realizar os testes unitários em nossas projetos, onde cada método é testado isoladamente para garantir que funcione como esperado, independente do restante do sistema.

Abrindo a solução do projeto pelo Visual Studio, os projetos de teste unitários estão dentro da pasta Tests, separados em dois subdiretórios: 
- IntegratedTests
- UnitTests

## Testes de Integração 

Para garantir a correta integração e que as diferentes partes do sistema funcionem corretamente é essencial que se utilize os testes de integração.
Em nosso projeto, além dos testes unitários, também realizamos testes de integração com xUnit, desta forma é possível verificar se diferentes componentes do sistema funcionam corretamente juntos.


## Integrantes do Grupo de Trabalho (Grupo 36)
- Ricardo Moreira RM351064 
