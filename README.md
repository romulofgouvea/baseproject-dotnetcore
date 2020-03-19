# Base Project .NET Core

Este é um projeto base para criação de APIs .NET Core.
Este projeto foi elaborado a partir de uma arquitetura baseada em DDD. 

Na branch `master` está a arquitetura base do projeto sem a implementação de um ORM. Nas branchs ef-core e nhibernate estão presentes a mesma arquitetura implementando os respectivos ORMs.

## Instalação

O framework utilizado é o [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1). Neste link é possível encontrar o SDK e também o runtime para a versão utilizada.

#### Clonando o projeto
```bash
git clone git@gitlab.ti.lemaf.ufla.br:raulcosta/baseproject-dotnetcore.git
cd baseproject-dotnetcore
```

## Rodando o projeto
Após a instalação do framework, basta rodar o seguinte comando na pasta do projeto.

```bash
dotnet run
```

O comando acima irá instalar as dependências, buildar os projetos e executar a aplicação. Para mais detalhes sobre o comando `dotnet run` e outros comandos consultar a [documentação do comando](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run).

## [Documentação](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
