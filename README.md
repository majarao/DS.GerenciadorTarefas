
# Gerenciador de Tarefas

Aplicação para gerenciar de tarefas

API foi construída utilizando .Net Core 9
Banco de dados SQL Server 2022
Entity Framework para acesso e manipulação de dados
A arquitetura do projeto foi utilizando Arquitetura Limpa, com responsabilidades e escopo bem definidos

Para rodar a API, primeiro precisa provisionar um banco de dados SQL   Server, isso pode ser feito com Docker, subindo um container  utilizando o comando abaixo

    docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest

Para instalar o docker no ambiente, você pode seguir a documentação no link abaixo

    https://docs.docker.com/engine/install/

Ou configurando manualmente o arquivo "AppSettings.json" na seção "ConnectionsString/DefaultConnection"

Após provisionar e configurar o banco de dados, para subir a API, você deve acessar a pasta

> *./backend\src\DS.GerenciadorTarefas.API*

E executar o comando abaixo no seu terminal

    dotnet run

Através do recurso "Migrations" do .Net o banco já será criado, assim como toda a definição de tabela

O frontend foi desenvolvido utilizando ReactJs

Para executar o frontend, acesse a pasta baixo

> *.\frontend*

E digite o seguinte comando no terminal

    npm run dev

É necessário possuir o gerenciador de pacotes NodeJs instalado, para isso pode se seguir o guia no link abaixo

    https://nodejs.org/en/learn/getting-started/how-to-install-nodejs

A API também está dotada de testes de unidade para a camada de domínio, para executar os testes, você deve acessar a pasta

> *.\backend\test\DS.GerenciadorTarefas.Domain.Test*

E executar o seguinte comando em seu terminal

    dotnet test
