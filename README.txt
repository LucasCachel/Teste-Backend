Meu Projeto Backend
Descrição do Projeto
Este projeto é uma aplicação backend desenvolvida para demonstrar as práticas de desenvolvimento e infraestrutura utilizando .NET Core, Docker, e outras tecnologias relacionadas. A aplicação é uma API RESTful que permite realizar operações CRUD para a entidade Produto.

Instruções para Configurar e Executar o Projeto Localmente
Para rodar o projeto localmente, siga as etapas abaixo:

1. Clone o Repositório
Primeiro, clone o repositório:

git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio

2. Instale as Dependências
Certifique-se de que o .NET Core SDK esteja instalado na sua máquina. Caso não tenha, faça o download e instale a partir de https://dotnet.microsoft.com/download.

Execute o comando abaixo para restaurar as dependências:

dotnet restore

3. Suba a Aplicação Localmente
Agora, você pode rodar o projeto localmente com o seguinte comando:

dotnet run
A aplicação estará disponível em http://localhost:5207 (ou a URL configurada no seu launchSettings.json).

Instruções para Rodar as Migrações de Banco de Dados
Este projeto usa o Entity Framework Core para gerenciar o banco de dados. Siga os passos abaixo para rodar as migrações:

1. Aplicar as Migrações
Execute o comando para aplicar as migrações:

dotnet ef database update
Isso irá criar ou atualizar o banco de dados de acordo com as migrações que foram configuradas no projeto.

2. Verifique o Banco de Dados
Após rodar as migrações, você pode verificar o banco de dados utilizando o SQL Server Management Studio (SSMS) ou outro gerenciador de banco de dados que você preferir. O banco de dados deve estar configurado na string de conexão do appsettings.json.

Instruções para Rodar os Testes Unitários
Este projeto utiliza xUnit para os testes unitários. Para rodar os testes, execute o seguinte comando no diretório do projeto:

dotnet test
Os testes serão executados e o resultado será mostrado no terminal.

Detalhes sobre a Imagem Docker
Este projeto está configurado para ser rodado dentro de um contêiner Docker. Aqui estão as etapas para rodar a aplicação usando Docker:

1. Baixar a Imagem Docker
Caso queira rodar a imagem Docker já criada, você pode fazer o pull da imagem do Docker Hub com o seguinte comando:

docker pull seu-usuario/meu-projeto-backend:v1
Substitua seu-usuario pelo seu nome de usuário no Docker Hub.

2. Subir o Contêiner Docker
Após o pull da imagem, execute o contêiner com o comando:

docker run -p 8080:80 seu-usuario/meu-projeto-backend:v1
Esse comando irá rodar a aplicação dentro de um contêiner Docker, mapeando a porta 8080 da sua máquina local para a porta 80 do contêiner. Acesse a aplicação em http://localhost:8080.

