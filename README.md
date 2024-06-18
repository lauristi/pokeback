## Pokedex
##### Backend Challenge - Pokémons

> This is a challenge by [Coodesh](https://coodesh.com/)

Projeto desafio doa coodesh/kotas que interage com a API https://pokeapi.co/. e um banco de dados SQLite.

#### EndPoints da API
____
[Post]/api/masters
- Salva dados do mestre pokémon

[Post]/api/captures
- Salva as capturas feitas pelos mestres pokémon

[Get]/api/captures
- Lista as capturas feitas pelos mestres pokémon

[Get]/api/pokemons/{id}
- Recupera os dados de um pokémon através de seu ID.

[Get]/api/pokemons/random
-  Recupera os dados de dez pokémons alectórios. 

#### Tecnologias utilizadas
____

.Net Core 8.0
-  AutoMapper 13.0.1
-  Microsoft.Data.Sqllite 8.0.6
-  Newtonsoft.Json 13.0.3
-  Swashbuckle.AspNetCore

#### Instalação & Utilização

É um back-end, então configure um servidor Windows com IIS ou Kestrel
ou um servidor Linux com Kestrel, para torna-lo acessível.
Aconselho o uso do Ngnix para facilitar a implantação. 
E construção de um front-end para consumi-lo
depois.
;-)

### Decisões sobre o projeto

**O endpoint Da recuperação de dez pokémons randomicamente. **

Inicialmente gostaria de fazer somente uma chamada e trabalhar os dados
no servidor, mas o endpoint limita a quantidade de itens que podem ser retornados a vinte. o que é compreensível devido ao tamanho da massa de dados

Optei por fazer uma busca inicial somente para trazer a quantidade máxima de
pokémons disponíveis e assim fazer um Random numa amostra fechada
Uma busca em informar o ID do pokémon me dava essa informação

Depois de extrair o JSON de retorno, transformando-o numa classe, percebi
o tamanho da encrenca. (Very well played, examiner), eu podia recuperar 10 pokémons aleatórios e traze-los no arranjo JSON original o que estava dando quase 3mb e consumindo um tempo absurdo no Swagger, o que é interessante, se o gargalo é o Swagger talvez o consumo pelo front não fosse tão afetado. De qualquer forma, optei por criar uma classe menos, e fazer a transição entre elas usado mapper, já que usar a classe original não foi um requisito implícito do desafio. Mas claro. Pode ser feito com um custo de processamento.

**A interação com o banco de dados**

Construí as tabelas com id autoincrementada e com dados bem básicos, ainda
assim percebi que algumas informações das tabelas, como id e data não precisavam ser informadas, mas poderiam ser retornadas, por isso optei por usar
classes DTO.

**Geral**

Optei por usar uma estrutura com serviços e injeção de dependência, e uma estrutura de pasta que me é mais familiar. 

### O que poderia ter sido feito, mas não foi

Poderia ter usado uma estrutura com repository, separando mais ainda as responsabilidades

Poderia ter feito testes unitários

Poderia ter implementado uma interação mais complexa com a API de pokémons
para, por exemplo, trazer o nome do pokémon na lista de capturas

Poderia ter implementado um Middleware de tratamento de erro, para tratar
de forma padronizada todos os erros, retornando, por exemplo, um JSON com 
dados para ajudar na correção de erros

Poderia ter usado Dapper ao invés do SqLite Nativo (provavelmente)

E a lista segue...

### Considerações finais

Agradeço a oportunidade do teste, foi divertido. 
Me permitiu trabalhar com SqLite. Coisa que eu não tinha feito antes, além de revisitar alguns conceitos.










