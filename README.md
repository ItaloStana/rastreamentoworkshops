*Projeto de Gestão de Colaboradores*

Este projeto é uma aplicação web desenvolvida para gestão de colaboradores, utilizando .NET 8 no backend e JavaScript Vanilla no frontend. O sistema permite realizar operações básicas de CRUD (Criar, Ler, Atualizar e Excluir) para gerenciar os dados dos colaboradores de forma eficiente e intuitiva.

Tecnologias Utilizadas:
Backend:
.NET 8: Framework utilizado para desenvolver a API RESTful que fornece as funcionalidades de manipulação de colaboradores.

Entity Framework Core: ORM (Object-Relational Mapping) usado para interagir com o banco de dados.

SQL Server: Banco de dados utilizado para persistir as informações de colaboradores.

Swagger: Utilizado para documentação e testes da API de forma interativa.

Frontend:
JavaScript Vanilla: Utilizado para construir a interface de usuário e realizar a comunicação com o backend através de requisições HTTP.

fetch API: Utilizada para realizar requisições HTTP ao backend. A fetch é uma API nativa do JavaScript para comunicação com servidores.

HTML/CSS: Responsável pela estruturação e estilização da aplicação para uma melhor experiência do usuário.


Como Executar o Projeto:

Passos para Configurar o Backend

1-Clone o Repositório Primeiro, clone o repositório do projeto para o seu computador. Abra o terminal e execute o seguinte comando:
"git clone https://github.com/ItaloStana/rastreamentoworkshops.git"

2-Instale as Dependências do Backend Navegue até a pasta Backend dentro do seu repositório clonado e execute o comando abaixo para restaurar as dependências do projeto:
"cd Backend
dotnet restore"

3-Configure a String de Conexão Abra o arquivo appsettings.json e edite a string de conexão para o banco de dados. Substitua os valores conforme a configuração do seu ambiente local:
""ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MinhaBaseDeDados;Trusted_Connection=True;"
}"

4-Execute as Migrações do Banco de Dados Após configurar a string de conexão, execute o seguinte comando para criar as tabelas no banco de dados:
"dotnet ef database update"

5-Inicie o Backend Agora, você pode rodar o servidor do backend. Execute o comando abaixo para iniciar a API:
"dotnet run"

Passos para Configurar o Frontend:

1-Navegue até a Pasta do Frontend Abra um novo terminal, vá até a pasta do frontend do projeto:
"cd frontend"

2-Instale as Dependências do Frontend Execute o seguinte comando para instalar as dependências do frontend:
"npm install"

3-Configure o Backend no Frontend Certifique-se de que o frontend está configurado para se comunicar com o backend. Abra o arquivo src/api.js (ou similar) e verifique se a URL do backend está correta:

"const apiUrl = 'http://localhost:5050/api/colaboradores';"

4-Inicie o Frontend Execute o comando abaixo para rodar o frontend:
"npm start".

A interface da aplicação estará disponível em http://localhost:5500.


Considerações Finais
Este projeto foi desenvolvido para ser simples de configurar e escalável para a adição de novas funcionalidades. Caso haja algum problema ou dúvida durante a instalação e execução, por favor, entre em contato comigo ou abra uma issue no repositório.

Se você precisar de mais detalhes sobre o código, funcionalidades ou tiver sugestões, fique à vontade para contribuir ou fazer perguntas!

