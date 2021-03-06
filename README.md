# Cinema Project #
 
### Progrmas necessários###

Este projeto foi desenvolvido de forma isolada, sendo back-end feito em Asp.Net Core, utilizando a IDE [Microsoft Visual Studio]("https://visualstudio.microsoft.com/pt-br/"), e front-end baseado em ReactJs e Next.js utilizando a IDE [Visual Studio Code]("https://visualstudio.microsoft.com/pt-br/"). Para o banco de dados, foi utilizado [MySql]("https://www.mysql.com/") com a ferramenta [XAMPP]("https://www.apachefriends.org/pt_br/index.html").

Na raiz deste projeto existe um arquivo do tipo .sql que contém todo o script para criação das tabelas e os dados atuais utilizados, no console do phpMyAdmin é possível selecionar a opção "importar" e utilizar o arquivo em questão para realizar a criação da tabela. O back-end utiliza os valores padrões de acesso ao banco de dados, sendo o ```user=root``` ```password=```

Para a instalação devida do front é necessário ter [Node.js]("https://nodejs.org/en/") instalado no computador, de preferencia na versão mais recente, o gerenciador de pacotes escolhido foi o '[yarn]("https://classic.yarnpkg.com/en/")', mas o projeto roda normalmente com o 'npm'.

O back-end foi feito usando o template de WebApi Rest, assim que o projeto for baixado, se não estiverem faltando arquivos o ambiente já estara configurado, precisando apenas ser rodado, as portas que o projeto utiliza são: http - 5000, https - 5001*, ssl - 44362. "No momento o https e o ssl estão com problemas, serão resolvidos em breve".

Utilizando um aplicativo que resolve requisições, como [Insomnia]("https://insomnia.rest/download/") ou [Postman]("https://www.postman.com/") é possível utilizar todas as funções sem problemas, pois no atual patch do projeto "Dia 29-01-2021" as requisições feitas pelo front estão sendo bloqueadas por Cors "também será resolvido o mais breve possível".

Para rodar a parte do front, utilizando o Visual Studio Code, podemos instalar as dependencias do projeto com o comando ``` yarn ``` ou ``` npm install```, após instalado, pode-se rodar o projeto com o comando ``` yarn dev ``` ou ``` npm run dev ```.

Na página inicial é possível observar os filmes cadastrados e suas irformações mais relevantes, Título, Duração e Imagem.
Na aba filmes será a futura área de gerenciamente de filmes (em construção)
Na aba de salas é possível visualizar as salas e a quantidade de assentos possíveis em cada.
Na aba sessões é possível visualizar todas as sessões e suas informações, assim como "Deletar e Adicionar novas" (devido ao problema nas requisições não é possível fazer nenhuma operação além de leitura).

Assim como as outras partes, o login tem sido bloqueado, infelizmente, não sendo possível fazer login no momento, futuramente este erro será corrigido.

Do banco de dados, existem 4 entidades, Films, Rooms, Sections, Users. Sections guarda, no banco de dados, uma refencia de Film e Room, utilizando o entity framework o back-end é capaz de renderizar o objeto inteiramente, facilitando as operações desejadas, porém para criar novas sessões é necessário fornecer o objeto por completo para aplicação. O front-end está pronto para realizar essas ações com mais facilidade.
A propriedade Image em Films recebe uma url de imagem que corresponda a capa do filme.

As URLs de requisição são:
Url base: http://localhost:5000,
Salas: /api/salas,
Sessões: /api/sessões,
Filmes: /api/filmes.

Os metodos válidos para as operações são: Get, Post, Put, Delete, Patch.

Para operações que necessitam manipular um objeto em especifico, como por exemplo o filme 5, é necessário apenas adicionar um /{id} no final da requisição => http://localhost:5000/api/filmes/5

Na api de salas é possível requisitar em /{id}/allsections para mostrar todas as sessões referentes a uma sala específica.

Qualquer dificuldade ou sugestão podem entrar em contato.
